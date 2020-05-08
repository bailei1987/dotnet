using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BL.WebApi.ResultProcess
{
    public class SystemTextJsonConvert
    {
        public class DecimalConverter : JsonConverter<decimal>
        {
            public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number) return reader.GetDecimal();
                return decimal.Parse(reader.GetString());
            }
            public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }

        public class DecimalNullConverter : JsonConverter<decimal?>
        {
            public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number) return reader.GetDecimal();
                return string.IsNullOrEmpty(reader.GetString()) ? default(decimal?) : decimal.Parse(reader.GetString());
            }
            public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value?.ToString());
            }
        }


        public class DateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.Parse(reader.GetString());
            }
            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
        public class DateTimeNullConverter : JsonConverter<DateTime?>
        {
            public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return string.IsNullOrEmpty(reader.GetString()) ? default(DateTime?) : DateTime.Parse(reader.GetString());
            }
            public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
        public class TimeSpanJsonConvert : JsonConverter<TimeSpan>
        {
            public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return TimeSpan.Parse(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(@"hh\:mm\:ss"));
            }
        }

        public class IntConverter : JsonConverter<int>
        {
            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number) return reader.GetInt32();
                else return string.IsNullOrEmpty(reader.GetString()) ? default : int.Parse(reader.GetString());
            }
            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
        }
        public class IntNullConverter : JsonConverter<int?>
        {
            public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number) return reader.GetInt32();
                return string.IsNullOrEmpty(reader.GetString()) ? default(int?) : int.Parse(reader.GetString());
            }
            public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
            {
                if (value != null) writer.WriteNumberValue(value.Value);
                else writer.WriteNullValue();
            }
        }
    }
}
