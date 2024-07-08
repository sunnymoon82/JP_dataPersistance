using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int points;
    public string inputNameText;
    public string newname;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
        
    }


    [System.Serializable]
    class Data
    {
        public string name;
        public int score;
        
    }


    public void SaveData()
    {
        Data data = new Data();
        data.name = inputNameText;
        data.score = points;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveddata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saveddata.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            inputNameText = data.name;
            points = data.score;
        }
    }
   
}
