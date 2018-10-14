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
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.Data = questionData;
        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(Path, contents);
    }

    public List<Question> ReadData()
    {
        try
        {
            string contents = System.IO.File.ReadAllText(Path);
            JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
            QuestionData questionData = wrapper.Data;
            return questionData.Questions;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            throw new Exception(ex.Message);
        }
    }

    public Question GetQuestion(int questionId)
    {
        var question = ReadData().Where(x => x.QuestionId == questionId).FirstOrDefault();
        if (question == null)
        {
            throw new Exception("Question does not Exist");
        }
        Debug.Log(question.Title);
        return question;
    }
}
