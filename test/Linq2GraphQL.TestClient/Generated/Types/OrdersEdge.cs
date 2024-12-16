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
/// An edge in a connection.
/// </summary>
public partial class OrdersEdge : GraphQLTypeBase
{
    /// <summary>
    /// A cursor for use in pagination.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; }

    /// <summary>
    /// The item at the end of the edge.
    /// </summary>
    [JsonPropertyName("node")]
    public Order Node { get; set; }

}
