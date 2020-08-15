﻿using System;
using UnityEngine;
using Newtonsoft.Json;

namespace ExtraOptions
{
    public class Vector3Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var c = (Vector3)value;
            serializer.Serialize(writer, new float[3] { c.x, c.y, c.z });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            float[] v = (float[])serializer.Deserialize(reader, typeof(float[]));
            return new Vector3(v[0], v[1], v[2]);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(Vector3);
    }
}