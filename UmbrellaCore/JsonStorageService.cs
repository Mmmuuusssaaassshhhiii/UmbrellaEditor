using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UmbrellaCore.Entities;

namespace UmbrellaCore.Services
{
    public static class JsonStorageService
    {
        public static void Save(List<UmbrellaEntity> entities, string path)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(entities, settings);

            File.WriteAllText(path, json);
        }

        public static List<UmbrellaEntity> Load(string path)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<UmbrellaEntity>>(json, settings);
        }
    }
}