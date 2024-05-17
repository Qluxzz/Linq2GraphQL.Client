﻿using Linq2GraphQL.Generator.Templates.Class;
using Linq2GraphQL.Generator.Templates.Client;
using Linq2GraphQL.Generator.Templates.Enum;
using Linq2GraphQL.Generator.Templates.Interface;
using Linq2GraphQL.Generator.Templates.Methods;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Linq2GraphQL.Generator
{
    public class ClientGenerator
    {
        private readonly string namespaceName;
        private readonly string clientName;
        private readonly bool includeSubscriptions;
        private readonly EnumGeneratorStrategy enumGeneratorStrategy;
        private readonly List<FileEntry> entries = new();

        public ClientGenerator(string namespaceName, string clientName, bool includeSubscriptions,
            EnumGeneratorStrategy enumGeneratorStrategy)
        {
            this.namespaceName = namespaceName;
            this.clientName = clientName;
            this.includeSubscriptions = includeSubscriptions;
            this.enumGeneratorStrategy = enumGeneratorStrategy;
        }

        private void AddFile(string directory, string fileName, string content)
        {
            entries.Add(new FileEntry { Content = content, DirectoryName = directory, FileName = fileName });
        }

        public async Task<List<FileEntry>> GenerateAsync(Uri uri, string authToken = null)
        {
            Console.WriteLine($"Start generating client for endpoint {uri.AbsoluteUri}");
            using var httpClient = new HttpClient();

            if (!string.IsNullOrWhiteSpace(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Linq2GraphQL", "1.0"));
            using var response = await httpClient.PostAsJsonAsync(uri, new { query = General.IntrospectionQuery });
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Failed to get schema. Error: {response.StatusCode}. Details: {await response.Content?.ReadAsStringAsync()}");
            }

            Console.WriteLine("Reading and deserializing schema information ...");
            var schemaJson = await response.Content.ReadAsStringAsync();

            return Generate(schemaJson);
        }

        public List<FileEntry> Generate(string schemaJson)
        {
            entries.Clear();
            var rootSchema = JsonSerializer.Deserialize<RootSchema>(schemaJson,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var schema = rootSchema.Data.Schema;
            var queryType = schema.QueryType;
            var mutationType = schema.MutationType;
            var subscriptionType = schema.SubscriptionType;


            var subscriptionsCount = schema.SubscriptionType?.AllFields?.Count;
            if (!includeSubscriptions && subscriptionsCount > 0)
            {
                Console.WriteLine("");
                Console.WriteLine(
                    "**************************************************************************************************************");
                Console.WriteLine(
                    $"Warning! Subscriptions is not included in client but schema has {subscriptionsCount} subscription(s) defined");
                Console.WriteLine("Set subscription flag to include in client.");
                Console.WriteLine(
                    "**************************************************************************************************************");
                Console.WriteLine("");
            }

            if (!includeSubscriptions)
            {
                subscriptionType = null;
            }

            schema.PopulateFieldTypes();


            Console.WriteLine("Generate Interfaces");

            var classInterfacesList = schema.GetClassTypes().Where(e => e.HasInterfaces)
                .SelectMany(i => i.Interfaces.ToDictionary(e => i.Name, e => e.Name)).ToList();
            foreach (var interfaceType in schema.GetInterfaces())
            {
                var implementedBy = classInterfacesList.Where(e => e.Value == interfaceType.Name).Select(e => e.Key)
                    .ToList();

                var interfaceTemplte =
                    new InterfaceTemplate(interfaceType, namespaceName, implementedBy).TransformText();
                AddFile("Interfaces", interfaceType.FileName, interfaceTemplte);
            }

            Console.WriteLine("Generate Types...");
            foreach (var classType in schema.GetClassTypes()
                         .Where(e => e.Kind != TypeKind.InputObject && !e.IsPageInfo()))
            {
                var classText = new ClassTemplate(classType, namespaceName).TransformText();
                AddFile("Types", classType.FileName, classText);
            }

            Console.WriteLine("Generate Inputs...");
            var inputs = schema.GetClassTypes().Where(e => e.Kind == TypeKind.InputObject).ToList();
            foreach (var classType in inputs)
            {
                var classText = new InputClassTemplate(classType, namespaceName).TransformText();
                AddFile("Inputs", classType.FileName, classText);
            }

            Console.WriteLine("Generate InputFactory...");
            var inputFactoryText = new InputFactoryClassTemplate(inputs, namespaceName).TransformText();
            AddFile("Inputs", "InputFactory.cs", inputFactoryText);

            Console.WriteLine("Generate Enums...");
            foreach (var enumType in schema.GetEnums())
            {
                var enumText = new EnumTemplate(enumType, namespaceName, enumGeneratorStrategy).TransformText();
                AddFile("Enums", enumType.FileName, enumText);
            }

            Console.WriteLine("Generate Methods...");
            var clientDirName = "Client";

            GenerateContextMethods(namespaceName, clientDirName, queryType, "OperationType.Query");
            GenerateContextMethods(namespaceName, clientDirName, mutationType, "OperationType.Mutation");
            GenerateContextMethods(namespaceName, clientDirName, subscriptionType, "OperationType.Subscription");

            var includeQuery = queryType != null;
            var includeMutation = mutationType != null;

            Console.WriteLine("Generate Client...");
            var templateText = new ClientTemplate(namespaceName, clientName, queryType, mutationType, subscriptionType)
                .TransformText();
            var fileName = clientName + ".cs";
            AddFile(clientDirName, fileName, templateText);

            Console.WriteLine("Generate Client Extensions...");
            var clientExtensionsTemplateText =
                new ClientExtensionsTemplate(namespaceName, clientName, includeSubscriptions).TransformText();
            fileName = clientName + "Extensions" + ".cs";
            AddFile(clientDirName, fileName, clientExtensionsTemplateText);

            return entries;
        }


        private void GenerateContextMethods(string namespaceName, string directory, GraphqlType methodType,
            string schemaType)
        {
            if (methodType == null)
            {
                return;
            }

            var fileName = methodType.Name.ToPascalCase() + "Methods" + ".cs";
            var templateText = new MethodsTemplate(methodType, namespaceName, schemaType).TransformText();
            AddFile(directory, fileName, templateText);
        }
    }
}

public enum EnumGeneratorStrategy
{
    FailIfMissing = 0,
    AddUnknownOption = 1
}