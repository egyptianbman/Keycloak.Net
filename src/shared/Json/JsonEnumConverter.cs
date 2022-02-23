using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keycloak.Net.Shared.Json
{
    /// <summary>
    /// Generic JSON converter for enums.
    /// </summary>
    public class JsonEnumConverter<TEnum> : JsonConverter
        where TEnum : struct, Enum, IConvertible
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var actualValue = (TEnum)(value ?? default(TEnum));
            writer.WriteValue(ConvertToString(actualValue));
        }

        /// <inheritdoc />
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var items = new List<TEnum>();
                var array = JArray.Load(reader);
                items.AddRange(array.Select(x => ConvertFromString(x.ToString())));

                return items;
            }

            return reader.Value is not string valueString ? default(object?) : ConvertFromString(valueString);
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        /// <summary>
        /// String representation of the enum entity type.
        /// </summary>
        private string EntityString => nameof(TEnum);

        /// <summary>
        /// Convert enum to string.
        /// </summary>
        private string ConvertToString(TEnum value)
        {
            var attributes =
                value.GetType()
                    ?.GetField(value.ToString())
                    ?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Convert string to enum.
        /// </summary>
        private TEnum ConvertFromString(string valueString)
        {
            var fieldDict = new Dictionary<string, string>();
            var fields = typeof(TEnum)?.GetFields() ?? Array.Empty<FieldInfo>();
            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attributes == null || !attributes.Any())
                {
                    continue;
                }

                fieldDict.TryAdd(field.Name, attributes[0].Description);
            }

            // Try parsing case sensitive first
            var fieldMatch = fieldDict.SingleOrDefault(x => x.Value.Equals(valueString));
            var key = fieldMatch.Key ?? valueString;
            if (!Enum.TryParse(key, out TEnum value) &&
                !Enum.TryParse(key, true, out value))
            {
                throw new ArgumentException($"Unknown {EntityString}: '{valueString}'.");
            }

            return value;
        }
    }
}
