using System.Collections;
using System.Collections.Generic;
using Assets.HackDuke.scripts;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    public QuestionData questionData = new QuestionData();
    public JsonWrapper wrapper = new JsonWrapper();

    private int index = 0;
	// Use this for initialization
	void Start ()
	{
	    wrapper.Path = Application.persistentDataPath + "/" + wrapper.Filename;
	    for (int k = 0; k < 100; k++)
	    {
            var question = new Question();
	        question.QuestionId = k;
	        question.Title = "This is Question " + k;
	        question.Category = (short) (100 - k);
	        question.Body = "We are testing the initialization of data -- here is the question squared" + k * k;
	        question.ShortAnswer = true;
	        question.MultipleChoice = false;
	        question.TrueFalse = false;
	        question.A = "Not MC";
	        question.B = "Not MC";
	        question.C = "Not MC";
	        question.D = "Not MC";
	        question.E = "Not MC";
	        question.Answer = "You have " + k + "unheard voicemails";

            questions.Add(question);

	    }

	    questionData.Questions = questions;
        wrapper.SaveData(questionData);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
	    {
	        wrapper.GetQuestion(index);
	        index++;
	    }
	}

    
}
