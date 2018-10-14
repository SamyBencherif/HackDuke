using Assets.HackDuke.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVars : MonoBehaviour
{

	public bool showDoorHint = true;
    public bool initialLoad = true;
    public Vector3 currentPosition;
    public Quaternion currentRotation;
    public JsonWrapper wrapper;
    public int currentQuestion;
    public int[] doors;
	// Use this for initialization
	void Start()
	{
        DontDestroyOnLoad(gameObject);
	    doors = new int[]
	    {
	        0, 0, 0, 0, 0, 0, 0
	    };
	    wrapper.Path = Application.persistentDataPath + "/" + wrapper.Filename;
	    var questions = new List<Question>();
        var questionData = new QuestionData();

	    for (int k = 0; k < 7; k++)
	    {
	        var question = new Question();
	        question.QuestionId = k;
	        question.Title = "This is Question " + k;
	        question.Category = (short)(100 - k);
	        question.Body = "return " + k * k;
	        question.ShortAnswer = true;
	        question.MultipleChoice = false;
	        question.TrueFalse = false;
	        question.A = "Not MC";
	        question.B = "Not MC";
	        question.C = "Not MC";
	        question.D = "Not MC";
	        question.E = "Not MC";
	        question.Answer = "return " + k;
            questions.Add(question);

	    }

	    questionData.Questions = questions;
	    wrapper.SaveData(questionData);
        SceneManager.LoadScene("Roomly");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
