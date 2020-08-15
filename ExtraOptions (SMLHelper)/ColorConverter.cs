﻿using System;
using UnityEngine;
using Newtonsoft.Json;

namespace ExtraOptions
{
    public class ColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var c = (Color)value;
            serializer.Serialize(writer, new float[3] { c.r, c.g, c.b });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            float[] v = (float[])serializer.Deserialize(reader, typeof(float[]));
            return new Color(v[0], v[1], v[2]);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(Color);
    }
}