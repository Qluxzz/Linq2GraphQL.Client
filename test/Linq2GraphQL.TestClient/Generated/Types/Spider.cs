//---------------------------------------------------------------------
// This code was automatically generated by Linq2GraphQL
// Please don't edit this file
// Github:https://github.com/linq2graphql/linq2graphql.client
// Url: https://linq2graphql.com
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Linq2GraphQL.Client;
using Linq2GraphQL.Client.Common;

namespace Linq2GraphQL.TestClient;


public partial class Spider : GraphQLTypeBase, IAnimal
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("numberOfLegs")]
    public int NumberOfLegs { get; set; }

    [JsonPropertyName("speed")]
    public int Speed { get; set; }

    [JsonPropertyName("poisonous")]
    public bool Poisonous { get; set; }

    [JsonPropertyName("__typename")]
    public string __TypeName { get; set; }
}
