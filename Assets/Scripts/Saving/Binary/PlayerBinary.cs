using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerBinary
{
    public static void SavePlayerData(stats.BaseStats player)
    {
        //Reference a Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //Location to save to
        string path = Application.persistentDataPath + "/" + "Spooky Scary Skeletons" + ".gif";
        //Create a File at Save Path
        FileStream stream = new FileStream(path, FileMode.Create);
        //What data to write to file
        PlayerData data = new PlayerData(player);
        //Write and convert to bytes for writing to binary
        formatter.Serialize(stream, data);
        //Done
        stream.Close();
    }
    public static PlayerData LoadPlayerData(stats.BaseStats player)
    {
        //Locatiob to load
        string path = Application.persistentDataPath + "/" + "Spooky Scary Skeletons" + ".gif";
        //if that location exists
        if (File.Exists(path))
        {
            //Get our binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //read the data from the path
            FileStream stream = new FileStream(path, FileMode.Open);
            //set tje data from what if was to usable variables
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Done
            stream.Close();
            //Load data to game
            return data;
        }
        else
        {
            return null;
        }      
    }
}

