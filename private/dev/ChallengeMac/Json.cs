using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public class Json
    {
        public JsonValue Value { get; set; }
    }

    public class JsonValue
    {
        public JsonObject JsonObject { get; set; }
        public List<JsonValue> Values { get; set; }
        public bool BooleanValue { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
    }

    public class JsonObject
    {
        public List<JsonProperty> Properties { get; set; }
    }

    public class JsonProperty
    {
        public string Key { get; set; }
        public JsonValue Value { get; set; }
    }
}
