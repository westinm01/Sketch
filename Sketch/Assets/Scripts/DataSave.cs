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
        string path1 = Application.persistentDataPath + "/data1.save";
        string path2 = Application.persistentDataPath + "/data2.save";
        string path3 = Application.persistentDataPath + "/data3.save";


        if (StaticInfo.saveProfle == 1)
        {
            FileStream stream = new FileStream(path1, FileMode.OpenOrCreate);
            Data data = new Data(StaticInfo.levelInt, StaticInfo.levelBool, StaticInfo.health);
            formatter.Serialize(stream, data);
            stream.Close();
        }
        else if (StaticInfo.saveProfle == 2)
        {
            FileStream stream = new FileStream(path2, FileMode.OpenOrCreate);
            Data data = new Data(StaticInfo.levelInt, StaticInfo.levelBool, StaticInfo.health);
            formatter.Serialize(stream, data);
            stream.Close();
        }
        else if (StaticInfo.saveProfle == 3)
        {
            FileStream stream = new FileStream(path3, FileMode.OpenOrCreate);
            Data data = new Data(StaticInfo.levelInt, StaticInfo.levelBool, StaticInfo.health);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        //FileInfo info = new System.IO.FileInfo(Application.persistentDataPath + "/data.save");


        //Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());

        /* if (info.Length != 0)
         {
             data = formatter.Deserialize(stream) as Data;
             Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());
             data.levelBool[currentLevel - 1] = true;
             data = RefreshData(data);
             Debug.Log("file has pre-existing data");
         }*/



        //Debug.Log(DataSave.LoadData().levelInt[0].ToString()+ ' ' + DataSave.LoadData().levelBool[0].ToString() + ' ' + DataSave.LoadData().levelBool[1].ToString() + ' ' + DataSave.LoadData().levelBool[2].ToString());
    }

    public static void LoadData ()
    {

        string path1 = Application.persistentDataPath + "/data1.save";
        string path2 = Application.persistentDataPath + "/data2.save";
        string path3 = Application.persistentDataPath + "/data3.save";

        if (StaticInfo.saveProfle == 1)
        {
            if (File.Exists(path1))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path1, FileMode.Open);
                Data data = formatter.Deserialize(stream) as Data;
                //Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());

                Array.Copy(data.levelInt, StaticInfo.levelInt, data.levelInt.Length);
                Array.Copy(data.levelBool, StaticInfo.levelBool, data.levelBool.Length);
                StaticInfo.health = data.health;

                stream.Close();

            }
            else
            {
                Debug.LogError("Save file not found in " + path1);
            }
        }
        else if (StaticInfo.saveProfle == 2)
        {
            if (File.Exists(path2))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path2, FileMode.Open);
                Data data = formatter.Deserialize(stream) as Data;
                //Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());

                Array.Copy(data.levelInt, StaticInfo.levelInt, data.levelInt.Length);
                Array.Copy(data.levelBool, StaticInfo.levelBool, data.levelBool.Length);
                StaticInfo.health = data.health;

                stream.Close();

            }
            else
            {
                Debug.LogError("Save file not found in " + path2);
            }
        }
        else if (StaticInfo.saveProfle == 3)
        {
            if (File.Exists(path3))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path3, FileMode.Open);
                Data data = formatter.Deserialize(stream) as Data;
                //Debug.Log(data.levelInt[0].ToString() + ' ' + data.levelBool[0].ToString() + ' ' + data.levelBool[1].ToString() + ' ' + data.levelBool[2].ToString());

                Array.Copy(data.levelInt, StaticInfo.levelInt, data.levelInt.Length);
                Array.Copy(data.levelBool, StaticInfo.levelBool, data.levelBool.Length);
                StaticInfo.health = data.health;

                stream.Close();

            }
            else
            {
                Debug.LogError("Save file not found in " + path3);
            }
        }
    }
}
