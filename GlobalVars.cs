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
        
        questions = AddQuestions(questions);
        

	    questionData.Questions = questions;
	    wrapper.SaveData(questionData);
        SceneManager.LoadScene("Roomly");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

    List<Question> AddQuestions(List<Question> questions)
    {
        var question = new Question();
        question.QuestionId = 0;
        question.Title = "What is the nth Fibonacci number (write in terms of 'input')";
        question.Category = 0;
        question.Body = "";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "def recurse(input):\n\tif(input < 2): \n\t\treturn 1\n\telse:\n\t\treturn recurse(input-1) + recurse(input-2)\nreturn recurse(input)";
        questions.Add(question);

        question.QuestionId = 1;
        question.Title = "What is (n-1)/3?";
        question.Category = 0;
        question.Body = "";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "return (input - 1) / 3";
        questions.Add(question);

        question.QuestionId = 2;
        question.Title = "Solve for the third side of a right triangle with hypotenuse length 20 and leg length 'input'";
        question.Category = 0;
        question.Body = "";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "import math\nreturn math.sqrt(20 * *2 - input * *2)";
        questions.Add(question);

        question.QuestionId = 3;
        question.Title = "Return double input 'input'";
        question.Category = 0;
        question.Body = "return ";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "return (input * 2)";
        questions.Add(question);

        question.QuestionId = 4;
        question.Title = "Find the area of a circle radius 'input'.";
        question.Category = 0;
        question.Body = "return ";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "import math\nreturn (math.pi * input**2)";
        questions.Add(question);

        question.QuestionId = 5;
        question.Title = "Sum of integers 1 to input.";
        question.Category = 0;
        question.Body = "return ";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "return input * (input - 1) / 2";
        questions.Add(question);

        question.QuestionId = 6;
        question.Title = "Square input.";
        question.Category = 0;
        question.Body = "return ";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Not MC";
        question.B = "Not MC";
        question.C = "Not MC";
        question.D = "Not MC";
        question.E = "Not MC";
        question.Answer = "return input ** 2";
        questions.Add(question);

        question.QuestionId = 7;
        question.Title = "What is the square root of 100";
        question.Category = 1;
        question.Body = "";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "50";
        question.B = "10";
        question.C = "20";
        question.D = "25";
        question.E = "2";
        question.Answer = "B";
        questions.Add(question);

        question.QuestionId = 8;
        question.Title = "What is acceleration due to gravity on Earth's surface?";
        question.Category = 2;
        question.Body = "return ";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "9.8 m/s^2";
        question.B = "32 cm/s^2";
        question.C = "6.9 m/s^2 MC";
        question.D = "A and B";
        question.E = "A, B, and C";
        question.Answer = "return ";
        questions.Add(question);

        question.QuestionId = 9;
        question.Title = "US History -- Who was President during the War of 1812?";
        question.Category = 3;
        question.Body = "return ";
        question.ShortAnswer = true;
        question.MultipleChoice = false;
        question.TrueFalse = false;
        question.A = "Harry Truman";
        question.B = "Gerald Ford";
        question.C = "James Madison";
        question.D = "Harrison Ford";
        question.E = "James Monroe";
        question.Answer = "C";
        questions.Add(question);
        return questions;
    }
}
