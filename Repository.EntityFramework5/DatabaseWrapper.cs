using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

namespace Repository.EntityFramework5
{
    public class DatabaseWrapper : IDatabase
    {
        protected Database database;

        public IDbConnection Connection { get { return this.database.Connection; } }

        public DatabaseWrapper(Database database)
        {
            this.database = database;
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.database.ExecuteSqlCommand(sql, parameters);
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.database.SqlQuery<TElement>(sql, parameters);
        }

        public IEnumerable SqlQuery(Type elementType, string sql, params object[] parameters)
        {
            return this.database.SqlQuery(elementType, sql, parameters);
        }
    }
}
