
//---------------------------------------------------------------------
// This code was automatically generated by Linq2GraphQL
// Please don't edit this file
// Github:https://github.com/linq2graphql/linq2graphql.client
// Url: https://linq2graphql.com
// Generation Date: den 8 september 2024 17:02:30
//---------------------------------------------------------------------

using Linq2GraphQL.Client;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Linq2GraphQL.TestClientNullable;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum CustomerStatus
{
    [EnumMember(Value = "ACTIVE")]
    Active,
    [EnumMember(Value = "DISABLED")]
    Disabled,
}