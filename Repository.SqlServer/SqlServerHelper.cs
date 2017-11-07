using System;
using System.Data;

namespace Repository.SqlServer
{
    public static class SqlServerHelper
    {
        public static IDbDataParameter CreateParameter(IDbCommand command, string name, char? variable, int size)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.DbType = DbType.String;
            parameter.ParameterName = name;
            parameter.Size = size;

            if (!variable.HasValue)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = variable.Value;

            command.Parameters.Add(parameter);

            return parameter;
        }

        public static IDbDataParameter CreateParameter(IDbCommand command, string name, DateTime variable, bool useTime)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = variable;

            command.Parameters.Add(parameter);

            return parameter;
        }

        public static IDbDataParameter CreateParameter(IDbCommand command, string name, int variable)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = variable;

            command.Parameters.Add(parameter);

            return parameter;
        }

        public static IDbDataParameter CreateParameter(IDbCommand command, string name, string variable, int size)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.DbType = DbType.String;
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Value = variable;

            command.Parameters.Add(parameter);

            return parameter;
        }
    }
}
