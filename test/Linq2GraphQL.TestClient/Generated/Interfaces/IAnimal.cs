using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Linq2GraphQL.Client;
using Linq2GraphQL.Client.Converters;

namespace Linq2GraphQL.TestClient;

public static class IAnimalExtentions
{


    [GraphInterface]
    public static Pig Pig(this IAnimal value)
    {
        if (value.__TypeName == "Pig")
        {
            return (Pig)value;
        }
        return null;
    }

    [GraphInterface]
    public static Spider Spider(this IAnimal value)
    {
        if (value.__TypeName == "Spider")
        {
            return (Spider)value;
        }
        return null;
    }
}


internal class IAnimalConverter : InterfaceJsonConverter<IAnimal>
{
    public override IAnimal Deserialize(string typeName, JsonObject json) => typeName switch
    {
          "Pig" => json.Deserialize<Pig>(),
      "Spider" => json.Deserialize<Spider>(),
        _ => json.Deserialize< IAnimal__Concrete>()
    };
}




[JsonConverter(typeof(IAnimalConverter))]
public interface IAnimal 
{
	[JsonPropertyName("name")]
	public string Name { get; set; }  
	[JsonPropertyName("numberOfLegs")]
	public int NumberOfLegs { get; set; }  
    [JsonPropertyName("__typename")]
    public string __TypeName { get; set; }

}

internal class IAnimal__Concrete : IAnimal
{
	[JsonPropertyName("name")]
	public string Name { get; set; }  
	[JsonPropertyName("numberOfLegs")]
	public int NumberOfLegs { get; set; }  

    [JsonPropertyName("__typename")]
    public string __TypeName { get; set; }

}