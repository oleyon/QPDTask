using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using QPDTask;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace QPDTask.Service.Models
{
    public class RawAddressModel
    {
        public string Address { get; set; }
    }

    public class RawAddressModelConverter : JsonConverter<RawAddressModel>
    {
        public override RawAddressModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, RawAddressModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, new[] { value.Address }, options);
        }
    }
}
