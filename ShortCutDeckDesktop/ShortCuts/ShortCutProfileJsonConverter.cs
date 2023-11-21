using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public class ShortCutProfileJsonConverter : JsonConverter<ShortCutProfileDataHolder>
    {
        public override ShortCutProfileDataHolder? ReadJson(JsonReader reader, Type objectType, ShortCutProfileDataHolder? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, ShortCutProfileDataHolder? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
