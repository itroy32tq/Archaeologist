using System;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace SaveModule
{
    public sealed class StorageService : IStorageService
    {

        public void Load<T>(string key, Action<T> callback)
        {
            string path = BuildPath(key);

            using (var fileStream = new StreamReader(path))
            {
                var json = fileStream.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);
                callback?.Invoke(data);
            };
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }

        public void Save<T>(string key, T data, Action<bool> callback = null)
        {
            string path = BuildPath(key);

            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(json);
            }

            callback?.Invoke(true);
        }
    }
}
