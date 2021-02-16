using System;
using System.Linq;

namespace Dapper.Custom.Extentions.Lib
{
    public static class DapperSqlBuilderExtension
    {
        public static void Where(this SqlBuilder builder, string where, object parameter = null, bool applyFilter = false)
        {
            var dynamicsParameters = new DynamicParameters();

            dynamicsParameters.Add(GetParameterName(where), parameter);

            if (applyFilter)
            {
                builder.Where(where, dynamicsParameters);
            }
        }

        public static void Set(this SqlBuilder builder, string where, object parameter = null, bool applyFilter = false)
        {
            var dynamicsParameters = new DynamicParameters();

            dynamicsParameters.Add(GetParameterName(where), parameter);

            if (applyFilter)
            {
                builder.Set(where, dynamicsParameters);
            }
        }

        private static string GetParameterName(string clause)
        {
            if (clause.IsNullOrEmpty())
                throw new Exception("The clause can't be null or empty!");

            if (!clause.Contains("@"))
                throw new Exception("Must contain @ in the clause!");

            if (clause.Where(c=> c.ToString() == "@").Count() > 1)
                throw new Exception("Must contain a single @ in the clause!");

            var index = clause.IndexOf("@");

            return clause.Substring(index++);
        }
    }
}
