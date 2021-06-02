using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CC.Yi.Common.Json
{
    public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            //if (TimeSpan.TryParse(reader.GetString(), out TimeSpan date))
            //    return date;

            TimeSpan.TryParse(reader.GetString(), out TimeSpan date);
            return date;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            // writer.WriteStringValue(value.ToString("HH:mm:ss"));
            writer.WriteStringValue(value.ToString());
        }
    }
}
