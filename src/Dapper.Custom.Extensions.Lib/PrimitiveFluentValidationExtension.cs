namespace Dapper.Custom.Extensions.Lib
{
    public static class PrimitiveFluentValidationExtension
    {
        //INT
        public static bool GreaterThanZero(this int value)
        {
            return value > 0;
        }

        public static bool GreaterThan(this int value, int parameter)
        {
            return value > parameter;
        }

        //DOUBLE
        public static bool GreaterThanZero(this double value)
        {
            return value > 0;
        }

        public static bool GreaterThan(this double value, double parameter)
        {
            return value > parameter;
        }

        //DECIMAL
        public static bool GreaterThanZero(this decimal value)
        {
            return value > 0;
        }

        public static bool GreaterThan(this decimal value, decimal parameter)
        {
            return value > parameter;
        }

        //STRING
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        //OBJECT
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool IsNotNull(this object value)
        {
            return value != null;
        }
    }

    public class Objeto { }
}
