using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Linq2GraphQL.Client;
using Linq2GraphQL.Client.Common;

namespace StarWars.Client;

public partial class FilmCharactersConnection : GraphQLTypeBase, Linq2GraphQL.Client.Common.ICursorPaging
{
    [JsonPropertyName("pageInfo")]
	public Linq2GraphQL.Client.Common.PageInfo PageInfo { get; set; }  


    [JsonPropertyName("edges")]
	public List<FilmCharactersEdge> Edges { get; set; }  


    [JsonPropertyName("totalCount")]
	public int? TotalCount { get; set; }  


    [JsonPropertyName("characters")]
	public List<Person> Characters { get; set; }  






}
