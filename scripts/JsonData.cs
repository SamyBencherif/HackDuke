using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    private string filename = "data.json";

    private string path;

    QuestionData questionData = new QuestionData();
	// Use this for initialization
	void Start ()
	{
	    path = Application.persistentDataPath + "/" + filename;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
	    {
	        SaveData();
	    }
	    if (Input.GetKeyDown(KeyCode.R))
	    {
	        ReadData();
	    }
	}

    void SaveData()
    {
        string contents = JsonUtility.ToJson(questionData, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void ReadData()
    {

    }
}
