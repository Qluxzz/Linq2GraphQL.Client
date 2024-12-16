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


/// <summary>
/// A segment of a collection.
/// </summary>
public partial class OrdersOffsetPagingCollectionSegment : GraphQLTypeBase
{
    /// <summary>
    /// Information to aid in pagination.
    /// </summary>
    [JsonPropertyName("pageInfo")]
    public CollectionSegmentInfo PageInfo { get; set; }

    /// <summary>
    /// A flattened list of the items.
    /// </summary>
    [JsonPropertyName("items")]
    public List<Order> Items { get; set; }

    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }

}
