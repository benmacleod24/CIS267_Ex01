using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void saveScore(int score)
    {
        if (score > loadScore())
        {
            string path = Application.persistentDataPath + "dont_touch_this.secret";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Create);
            bf.Serialize(fs, score);
            fs.Close();
        }
    }

    public static int loadScore()
    {
        string path = Application.persistentDataPath + "dont_touch_this.secret";
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            int score = int.Parse(bf.Deserialize(fs).ToString()); 
            fs.Close();

            return score;
        }
        else
        {
            Debug.LogError("Error w/ File not found in path");
            return -999;
        }
    }
}
