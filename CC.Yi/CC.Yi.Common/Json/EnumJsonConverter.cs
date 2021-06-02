using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace CC.Yi.Common.Json
{
  public  class EnumJsonConverter : JsonConverter<Enum>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }
        //未实现
        public override Enum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                int num;
                reader.TryGetInt32(out num);
                return (Enum)Enum.Parse(typeToConvert,num.ToString());                
            }
            if (reader.TokenType == JsonTokenType.String)
            {
                string str = reader.GetString();              
                return (Enum)Enum.Parse(typeToConvert, str);
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
