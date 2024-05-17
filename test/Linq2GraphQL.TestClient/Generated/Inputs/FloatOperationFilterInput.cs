using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Linq2GraphQL.Client;

namespace Linq2GraphQL.TestClient;

[JsonConverter(typeof(GraphInputConverter<FloatOperationFilterInput>))]
public partial class FloatOperationFilterInput : GraphInputBase
{
	[JsonPropertyName("eq")]
	public double? Eq 
	{
		get => GetValue<double?>("eq");
    	set => SetValue("eq", value);
	}

	[JsonPropertyName("neq")]
	public double? Neq 
	{
		get => GetValue<double?>("neq");
    	set => SetValue("neq", value);
	}

	[JsonPropertyName("in")]
	public List<double?> In 
	{
		get => GetValue<List<double?>>("in");
    	set => SetValue("in", value);
	}

	[JsonPropertyName("nin")]
	public List<double?> Nin 
	{
		get => GetValue<List<double?>>("nin");
    	set => SetValue("nin", value);
	}

	[JsonPropertyName("gt")]
	public double? Gt 
	{
		get => GetValue<double?>("gt");
    	set => SetValue("gt", value);
	}

	[JsonPropertyName("ngt")]
	public double? Ngt 
	{
		get => GetValue<double?>("ngt");
    	set => SetValue("ngt", value);
	}

	[JsonPropertyName("gte")]
	public double? Gte 
	{
		get => GetValue<double?>("gte");
    	set => SetValue("gte", value);
	}

	[JsonPropertyName("ngte")]
	public double? Ngte 
	{
		get => GetValue<double?>("ngte");
    	set => SetValue("ngte", value);
	}

	[JsonPropertyName("lt")]
	public double? Lt 
	{
		get => GetValue<double?>("lt");
    	set => SetValue("lt", value);
	}

	[JsonPropertyName("nlt")]
	public double? Nlt 
	{
		get => GetValue<double?>("nlt");
    	set => SetValue("nlt", value);
	}

	[JsonPropertyName("lte")]
	public double? Lte 
	{
		get => GetValue<double?>("lte");
    	set => SetValue("lte", value);
	}

	[JsonPropertyName("nlte")]
	public double? Nlte 
	{
		get => GetValue<double?>("nlte");
    	set => SetValue("nlte", value);
	}

}