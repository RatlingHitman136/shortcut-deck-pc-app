using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Profiles
{ 
    public class ProfileJsonConverter : JsonConverter<ProfileDataHolder>
    {
        public override ProfileDataHolder? ReadJson(JsonReader reader, Type objectType, ProfileDataHolder? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, ProfileDataHolder? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
