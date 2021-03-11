
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad 
{

    public static void SaveSound(float Volume)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string FilePath = Application.persistentDataPath + "/Sound.data";
        FileStream Stream = new FileStream(FilePath, FileMode.Create);

        PlayerData _PlayerData = new PlayerData(Volume);
        Formatter.Serialize(Stream, _PlayerData);
        Stream.Close();
    }
    public static PlayerData LoadSound()
    {
        string FilePath = Application.persistentDataPath + "/Sound.data";
        if (File.Exists(FilePath))
        {

            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(FilePath, FileMode.Open);
            PlayerData _PlayerData = Formatter.Deserialize(Stream) as PlayerData;
            Stream.Close();
            return _PlayerData;

        }
        else
        {
            FileStream Stream = new FileStream(FilePath, FileMode.Create);
            Stream.Close();
            return null;
        }
    }





}
