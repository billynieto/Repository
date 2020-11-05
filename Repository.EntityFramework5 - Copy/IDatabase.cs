using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Repository.EntityFramework5
{
    public interface IDatabase
    {
        IDbConnection Connection { get; }
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
        IEnumerable SqlQuery(Type elementType, string sql, params object[] parameters);
    }
}
