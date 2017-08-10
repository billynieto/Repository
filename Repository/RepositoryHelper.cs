using System;
using System.Collections.Generic;
using System.Text;

using Repository.Framework;

namespace Repository
{
    public static class RepositoryHelper
    {
        public static string ListKeys(IEnumerable<IKey> keys)
        {
            return RepositoryHelper.ListKeys(keys, ", ", "{", "}");
        }

        public static string ListKeys(IEnumerable<IKey> keys, string seperator, string itemPrefix, string itemSuffix)
        {
            StringBuilder listedKeys = new StringBuilder();

            foreach (IKey key in keys)
            {
                if (!string.IsNullOrEmpty(itemPrefix))
                    listedKeys.Append(itemPrefix);

                listedKeys.Append(key.ToString());

                if (!string.IsNullOrEmpty(itemSuffix))
                    listedKeys.Append(itemSuffix);

                listedKeys.Append(seperator);
            }

            return listedKeys.Remove(listedKeys.Length - seperator.Length, seperator.Length).ToString();
        }

        public static void ValidateBounds(string parameterName, DateTime value, DateTime minimumValue, DateTime maximumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateBounds(string parameterName, DateTime? value, DateTime minimumValue, DateTime maximumValue)
        {
            if (value != null)
            {
                RepositoryHelper.CheckMinimum(parameterName, value.Value, minimumValue);
                RepositoryHelper.CheckMaximum(parameterName, value.Value, maximumValue);
            }
        }

        public static void ValidateBounds(string parameterName, double value, double minimumValue, double maximumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateBounds(string parameterName, double? value, double minimumValue, double maximumValue)
        {
            if (value != null)
            {
                RepositoryHelper.CheckMinimum(parameterName, value.Value, minimumValue);
                RepositoryHelper.CheckMaximum(parameterName, value.Value, maximumValue);
            }
        }

        public static void ValidateBounds(string parameterName, float value, float minimumValue, float maximumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateBounds(string parameterName, float? value, float minimumValue, float maximumValue)
        {
            if (value != null)
            {
                RepositoryHelper.CheckMinimum(parameterName, value.Value, minimumValue);
                RepositoryHelper.CheckMaximum(parameterName, value.Value, maximumValue);
            }
        }

        public static void ValidateBounds(string parameterName, int value, int minimumValue, int maximumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateBounds(string parameterName, string value, int minimumLength, int maximumLength)
        {
            if (value != null)
            {
                string temp = value.Trim();

                RepositoryHelper.CheckMinimumLength(parameterName, temp, minimumLength);
                RepositoryHelper.CheckMaximumLength(parameterName, temp, maximumLength);
            }
        }

        public static void ValidateMaximum(string parameterName, DateTime value, DateTime maximumValue)
        {
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateMaximum(string parameterName, DateTime? value, DateTime maximumValue)
        {
            if (value != null)
                RepositoryHelper.CheckMaximum(parameterName, value.Value, maximumValue);
        }

        public static void ValidateMaximum(string parameterName, double value, double maximumValue)
        {
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateMaximum(string parameterName, double? value, double maximumValue)
        {
            if (value != null)
                RepositoryHelper.CheckMaximum(parameterName, value.Value, maximumValue);
        }

        public static void ValidateMaximum(string parameterName, int value, int maximumValue)
        {
            RepositoryHelper.CheckMaximum(parameterName, value, maximumValue);
        }

        public static void ValidateMaximum(string parameterName, int? value, int maximumValue)
        {
            if (value != null)
                RepositoryHelper.CheckMaximum(parameterName, value.Value, maximumValue);
        }

        public static void ValidateMaximum(string parameterName, string value, int maximumLength)
        {
            if (value != null)
                RepositoryHelper.CheckMaximumLength(parameterName, value.Trim(), maximumLength);
        }

        public static void ValidateMinimum(string parameterName, DateTime value, DateTime minimumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
        }

        public static void ValidateMinimum(string parameterName, DateTime? value, DateTime minimumValue)
        {
            if (value != null)
                RepositoryHelper.CheckMinimum(parameterName, value.Value, minimumValue);
        }

        public static void ValidateMinimum(string parameterName, double value, double minimumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
        }

        public static void ValidateMinimum(string parameterName, double? value, double minimumValue)
        {
            if (value != null)
                RepositoryHelper.CheckMinimum(parameterName, value.Value, minimumValue);
        }

        public static void ValidateMinimum(string parameterName, int value, int minimumValue)
        {
            RepositoryHelper.CheckMinimum(parameterName, value, minimumValue);
        }

        public static void ValidateMinimum(string parameterName, int? value, int minimumValue)
        {
            if (value != null)
                RepositoryHelper.CheckMinimum(parameterName, value.Value, minimumValue);
        }

        public static void ValidateNotNull(string parameterName, object model)
        {
            if (model == null)
                throw new ArgumentNullException(parameterName);
        }

        public static void ValidateNotNull(string parameterName, IEnumerable<object> models)
        {
            if (models == null)
                throw new ArgumentNullException(parameterName);

            foreach (object model in models)
                if (model == null)
                    throw new ArgumentNullException(parameterName + " item.");
        }

        public static void ValidateNotNull(string parameterName, string value)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        private static void CheckMaximum(string parameterName, DateTime value, DateTime maximumValue)
        {
            if (value > maximumValue)
                throw new ArgumentException(parameterName + " must be older than + " + maximumValue + ".");
        }

        private static void CheckMaximum(string parameterName, double value, double maximumValue)
        {
            if (value > maximumValue)
                throw new ArgumentException(parameterName + " must be smaller than + " + maximumValue + ".");
        }

        private static void CheckMaximum(string parameterName, float value, float maximumValue)
        {
            if (value > maximumValue)
                throw new ArgumentException(parameterName + " must be smaller than + " + maximumValue + ".");
        }

        private static void CheckMaximum(string parameterName, int value, int maximumValue)
        {
            if (value > maximumValue)
                throw new ArgumentException(parameterName + " must be smaller than + " + maximumValue + ".");
        }

        private static void CheckMinimum(string parameterName, DateTime value, DateTime minimumValue)
        {
            if (value < minimumValue)
                throw new ArgumentException(parameterName + " must be younger than + " + minimumValue + ".");
        }

        private static void CheckMinimum(string parameterName, double value, double minimumValue)
        {
            if (value < minimumValue)
                throw new ArgumentException(parameterName + " must be larger than + " + minimumValue + ".");
        }

        private static void CheckMinimum(string parameterName, float value, float minimumValue)
        {
            if (value < minimumValue)
                throw new ArgumentException(parameterName + " must be larger than + " + minimumValue + ".");
        }

        private static void CheckMinimum(string parameterName, int value, int minimumValue)
        {
            if (value < minimumValue)
                throw new ArgumentException(parameterName + " must be larger than + " + minimumValue + ".");
        }

        private static void CheckMaximumLength(string parameterName, string value, int maximumLength)
        {
            if (value.Trim().Length > maximumLength)
                throw new ArgumentException(parameterName + " must be less than " + maximumLength + " characters in length.");
        }

        private static void CheckMinimumLength(string parameterName, string value, int minimumLength)
        {
            if (value.Trim().Length < minimumLength)
                throw new ArgumentException(parameterName + " must be more than " + minimumLength + " characters in length.");
        }

        private static void CheckNotEmpty(string parameterName, string value)
        {
            if (value.Length == 0)
                throw new ArgumentException(parameterName + " must be at least 1 character.");
            if (value.Trim().Length == 0)
                throw new ArgumentException(parameterName + " must be at least 1 non-whitespace character.");
        }

        private static void CheckNotNull(string parameterName, string value)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }
    }
}
