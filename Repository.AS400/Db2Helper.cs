//using System;
//using System.Data;

//using IBM.Data.DB2.iSeries;

//using Repository.Framework;

//namespace Repository.AS400
//{
//    public static class Db2Helper
//    {
//        public static IDbDataParameter CreateParameter(IDbCommand command, string name, char? variable, int size)
//        {
//            iDB2Command db2Command = (iDB2Command)command;

//            iDB2Parameter db2Parameter = db2Command.CreateParameter();
//            db2Parameter.ParameterName = name;
//            db2Parameter.iDB2DbType = iDB2DbType.iDB2Char;
//            db2Parameter.iDB2Value = variable;
//            db2Parameter.Size = size;

//            db2Command.Parameters.Add(db2Parameter);

//            return db2Parameter;
//        }

//        public static IDbDataParameter CreateFauxParameter(IDbCommand command, string name, DateTime variable, bool useTime)
//        {
//            iDB2Command db2Command = (iDB2Command)command;

//            iDB2Parameter db2Parameter = db2Command.CreateParameter();
//            db2Parameter.ParameterName = name;
//            db2Parameter.iDB2DbType = iDB2DbType.iDB2Decimal;
//            db2Parameter.iDB2Value = useTime ? Db2Helper.ToDb2Time(variable) : Db2Helper.ToDb2Date(variable);

//            db2Command.Parameters.Add(db2Parameter);

//            return db2Parameter;
//        }

//        public static IDbDataParameter CreateParameter(IDbCommand command, string name, DateTime variable, bool useTime)
//        {
//            iDB2Command db2Command = (iDB2Command)command;

//            iDB2Parameter db2Parameter = db2Command.CreateParameter();
//            db2Parameter.ParameterName = name;
//            db2Parameter.iDB2DbType = useTime ? iDB2DbType.iDB2Time : iDB2DbType.iDB2Date;
//            db2Parameter.iDB2Value = variable;

//            db2Command.Parameters.Add(db2Parameter);

//            return db2Parameter;
//        }

//        public static IDbDataParameter CreateParameter(IDbCommand command, string name, int variable)
//        {
//            iDB2Command db2Command = (iDB2Command)command;

//            iDB2Parameter db2Parameter = db2Command.CreateParameter();
//            db2Parameter.ParameterName = name;
//            db2Parameter.iDB2DbType = iDB2DbType.iDB2Decimal;
//            db2Parameter.iDB2Value = variable;

//            db2Command.Parameters.Add(db2Parameter);

//            return db2Parameter;
//        }

//        public static IDbDataParameter CreateParameter(IDbCommand command, string name, string variable, int size)
//        {
//            iDB2Command db2Command = (iDB2Command)command;

//            iDB2Parameter db2Parameter = db2Command.CreateParameter();
//            db2Parameter.ParameterName = name;
//            db2Parameter.iDB2DbType = iDB2DbType.iDB2VarChar;
//            db2Parameter.iDB2Value = variable;
//            db2Parameter.Size = size;

//            db2Command.Parameters.Add(db2Parameter);

//            return db2Parameter;
//        }

//        public static DateTime FromDb2Date(decimal num)
//        {
//            return FromDb2Date((int)num);
//        }

//        public static DateTime FromDb2Date(int num)
//        {
//            if (num == 0)
//                return DateTime.MinValue;

//            int century = num / 1000000;
//            // remove century
//            num = num % 1000000;

//            int days = num % 100;
//            int months = (num % 10000) / 100;
//            int years = num / 10000;

//            return new DateTime(years + 1900 + century * 100, months, days);
//        }

//        public static DateTime FromDb2Time(int num, DateTime date)
//        {
//            int seconds = num % 100;
//            int minutes = (num % 10000) / 100;
//            int hours = (num % 1000000) / 10000;

//            return new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds);
//        }

//        public static int ToDb2Date(DateTime date)
//        {
//            if (date < new DateTime(1900, 1, 1))
//                return 0;

//            return ((date.Year / 100) - 19) * 1000000	// century
//                + date.Year % 100 * 10000				// year
//                + date.Month * 100						// month
//                + date.Day;								// day
//        }

//        public static int ToDb2Time(DateTime date)
//        {
//            return date.Hour * 10000
//                + date.Minute * 100
//                + date.Second;
//        }

//        public static int ToDb2Century(DateTime date)
//        {
//            return (date.Year / 100) - 19;
//        }
//    }
//}
