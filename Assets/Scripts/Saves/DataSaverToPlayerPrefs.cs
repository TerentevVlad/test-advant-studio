using UnityEngine;

namespace Saves
{
    public class DataSaverToPlayerPrefs : IDataSaver
    {
        public void SaveData(string key, object data)
        {
            var jsonData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, jsonData);
        }

        public T LoadData<T>(string key) where T : Data
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }
    }
}