using System.Collections.Generic;
using System;
using Linq2GraphQL.Client;

namespace Linq2GraphQL.TestClientNullable;

public class QueryMethods
{
    private readonly GraphClient client;

    public QueryMethods(GraphClient client)
    {
        this.client = client;
    }

    public GraphQuery<List<Customer>> CustomerList()
    {
	    var arguments = new List<ArgumentValue>
        {
        };

        return new GraphQuery<List<Customer>>(client,  "customerList", OperationType.Query, arguments); 
    }

    public GraphQuery<Customer?> CustomerNullable()
    {
	    var arguments = new List<ArgumentValue>
        {
        };

        return new GraphQuery<Customer?>(client,  "customerNullable", OperationType.Query, arguments); 
    }

    public GraphQuery<List<Customer?>> CustomerListAllNullable()
    {
	    var arguments = new List<ArgumentValue>
        {
        };

        return new GraphQuery<List<Customer?>>(client,  "customerListAllNullable", OperationType.Query, arguments); 
    }

    public GraphQuery<List<Customer>> CustomerListNullable()
    {
	    var arguments = new List<ArgumentValue>
        {
        };

        return new GraphQuery<List<Customer>>(client,  "customerListNullable", OperationType.Query, arguments); 
    }

    public GraphQuery<List<Customer>> CustomerListInList()
    {
	    var arguments = new List<ArgumentValue>
        {
        };

        return new GraphQuery<List<Customer>>(client,  "customerListInList", OperationType.Query, arguments); 
    }

    }
