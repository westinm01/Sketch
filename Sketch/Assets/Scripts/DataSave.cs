using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System;

public static class DataSave
{
    public static void SaveData ()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.save";

        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        
        FileInfo info = new System.IO.FileInfo(Application.persistentDataPath + "/data.save");

        Data data = new Data(StaticInfo.levelInt, StaticInfo.levelBool, StaticInfo.health);

        //Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());

       /* if (info.Length != 0)
        {
            data = formatter.Deserialize(stream) as Data;
            Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());
            data.levelBool[currentLevel - 1] = true;
            data = RefreshData(data);
            Debug.Log("file has pre-existing data");
        }*/

        formatter.Serialize(stream, data);
        stream.Close();

        //Debug.Log(DataSave.LoadData().levelInt[0].ToString()+ ' ' + DataSave.LoadData().levelBool[0].ToString() + ' ' + DataSave.LoadData().levelBool[1].ToString() + ' ' + DataSave.LoadData().levelBool[2].ToString());
    }

    public static void LoadData ()
    {

        string path = Application.persistentDataPath + "/data.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data data = formatter.Deserialize(stream) as Data;
            Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());

            Array.Copy(data.levelInt, StaticInfo.levelInt, data.levelInt.Length);
            Array.Copy(data.levelBool, StaticInfo.levelBool, data.levelBool.Length);
            StaticInfo.health = data.health;

            stream.Close();

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
}
