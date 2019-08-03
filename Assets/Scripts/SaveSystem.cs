using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void saveData(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/xInfo.info";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData loadData()
    {
        string path = Application.persistentDataPath + "/xInfo.info";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("file not found in " + path);
            return null;
        }
    }
}
