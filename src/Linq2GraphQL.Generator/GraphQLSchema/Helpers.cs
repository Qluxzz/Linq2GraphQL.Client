﻿namespace Linq2GraphQL.Generator;

public static class Helpers
{
    public static readonly Dictionary<string, (string Name, Type type)> TypeMapping =
        new(StringComparer.InvariantCultureIgnoreCase)
        {
            { "Int", new ValueTuple<string, Type>("int", typeof(int)) },
            { "Float", new ValueTuple<string, Type>("double", typeof(double)) },
            { "String", new ValueTuple<string, Type>("string", typeof(string)) },
            { "ID", new ValueTuple<string, Type>("string", typeof(string)) },
            { "Date", new ValueTuple<string, Type>("DateTime", typeof(DateTime)) },
            { "Boolean", new ValueTuple<string, Type>("bool", typeof(bool)) },
            { "Long", new ValueTuple<string, Type>("long", typeof(long)) },
            { "uuid", new ValueTuple<string, Type>("Guid", typeof(Guid)) },
            { "timestamptz", new ValueTuple<string, Type>("DateTimeOffset", typeof(DateTimeOffset)) },
            { "Uri", new ValueTuple<string, Type>("Uri", typeof(Uri)) },
            { "DateTime", new ValueTuple<string, Type>("DateTimeOffset", typeof(DateTimeOffset)) },
            { "Decimal", new ValueTuple<string, Type>("decimal", typeof(decimal)) },
            { "TimeSpan", new ValueTuple<string, Type>("TimeSpan", typeof(TimeSpan)) }
        };

   
}