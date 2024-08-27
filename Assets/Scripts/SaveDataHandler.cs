using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataHandler : MonoBehaviour
{
    // create public instance
    public static SaveDataHandler Instance;
    public string highScoreName;
    public int highScore;
    public string playerName;

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }
    private void Awake()
    {
        // check if we already have an instance
        if (Instance != null)
        {
            // destroy newly created object
            Destroy(gameObject);

            // end the Awake() method
            return;
        }

        // set instance reference to this object
        Instance = this;

        // keep this object persistent across scene loads
        DontDestroyOnLoad(gameObject);

        // load team color from save data if save exists
        LoadScore();
    }

    public void SaveScore(int score)
    {
        // update current high score for readout
        highScoreName = playerName;
        highScore = score;

        // create a save data instance to fill
        SaveData data = new SaveData();

        // fill data instance with current high scores
        data.highScoreName = playerName;
        data.highScore = score;

        // convert save data to JSON format
        string json = JsonUtility.ToJson(data);

        // write json file from formatted save data
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        // declare save data path
        string path = Application.persistentDataPath + "/savefile.json";

        // check if save file exists at path
        if (File.Exists(path))
        {
            // read json from file at path
            string json = File.ReadAllText(path);

            // put json into a SaveData container
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // read high score and name from SaveData container, load it into variable
            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }

    }
}
