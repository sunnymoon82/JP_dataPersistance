using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public TextMeshProUGUI inputName;
    string newname;
    // Start is called before the first frame update
    
    void Start()
    {
        //highscorevalue=DataManager.instance.points.ToString();
        inputName.text = $"Best Score : {DataManager.instance.inputNameText} : {DataManager.instance.points}";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetInputText(string text)
    {
        DataManager.instance.newname= text; 
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.instance.SaveData();
#if UNITY_EDITOR 
        EditorApplication.ExitPlaymode();
#else
 Application.Quit(); //original code to quit unity player;
#endif
    }
    public void ResetData()
    {
        DataManager.instance.inputNameText = "";
        DataManager.instance.points = 0;
        DataManager.instance.SaveData();
        inputName.text = $"Best Score : {DataManager.instance.inputNameText} : {DataManager.instance.points}";
        //Data data = new Data();
        //data.name = "";
        //data.score = 0;
        //string json = JsonUtility.ToJson(data);
        //File.WriteAllText(Application.persistentDataPath + "/saveddata.json", json);
    }
}
