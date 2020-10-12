using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CommonUtilities.Utilities
{
    public class EnumUtility
    {
        /// <summary>
        /// Get all the values Description of this Enum
        /// </summary>
        /// <typeparam name="TEnum">enum type</typeparam>
        /// <returns></returns>
        public static List<string> GetDescrptionList<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }

            var enumType = typeof(TEnum);
            var enumDescriptionList = new List<string>();

            foreach (var value in Enum.GetValues(enumType))
            {
                var enumDescription = GetDescription((Enum)value);

                enumDescriptionList.Add(enumDescription);
            }

            return enumDescriptionList;
        }

        /// <summary>
        /// Get the description field of this Enum value
        /// </summary>
        /// <param name="value">Value of enum</param>
        /// <returns></returns>
        public static string GetDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }

        /// <summary>
        /// Get list of values (1,2,3)
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<int> GetValues<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }

            var enumType = typeof(TEnum);
            var enumValues = new List<int>();

            foreach (var value in Enum.GetValues(enumType))
            {
                enumValues.Add((int)value);
            }

            return enumValues;
        }

        /// <summary>
        /// Get names of Enum (e.g.: Contract, Permanent, Intern...)
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<string> GetNames<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }

            var enumType = typeof(TEnum);
            return Enum.GetNames(enumType).ToList();
        }

        /// <summary>
        /// Get the Name + Value pair list
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<string, int>> GetNameValuePairs<TEnum>()
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }
            var enumType = typeof(TEnum);
            var enumNameDescriptionPair = new List<KeyValuePair<string, int>>();

            foreach (var value in Enum.GetValues(enumType))
            {
                var intValue = (int)value;
                enumNameDescriptionPair.Add(new KeyValuePair<string, int>(value.ToString(), intValue));
            }

            return enumNameDescriptionPair;
        }
    }
}
