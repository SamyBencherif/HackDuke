using System;
using System.Collections.Generic;
using System.Linq;
using Assets.HackDuke.scripts;
using UnityEngine;

[Serializable]
public class JsonWrapper
{
    public QuestionData Data;
    public string Filename = "data.json";
    public string Path;

    public void SaveData(QuestionData questionData)
    {
        this.Data = questionData;
        string contents = JsonUtility.ToJson(this, true);
        System.IO.File.WriteAllText(Path, contents);
    }
}
