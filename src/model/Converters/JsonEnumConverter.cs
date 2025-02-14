﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keycloak.Net.Model.Converters
{
    public abstract class JsonEnumConverter<TEnum> : JsonConverter
        where TEnum : struct, IConvertible
    {
        /// <summary>
        /// String representation of the enum entity type.
        /// </summary>
        protected abstract string EntityString { get; }

        /// <summary>
        /// Convert enum to string.
        /// </summary>
        protected abstract string ConvertToString(TEnum value);

        /// <summary>
        /// Convert string to enum.
        /// </summary>
        protected abstract TEnum ConvertFromString(string s);

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var actualValue = (TEnum)(value ?? default(TEnum));
            writer.WriteValue(ConvertToString(actualValue));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var items = new List<TEnum>();
                var array = JArray.Load(reader);
                items.AddRange(array.Select(x => ConvertFromString(x.ToString())));

                return items;
            }

            var s = (string)reader.Value!;
            return ConvertFromString(s);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
