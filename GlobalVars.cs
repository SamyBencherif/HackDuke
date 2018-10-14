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
        var question0 = new Question();
        question0.QuestionId = 0;
        question0.Title = "What is the nth Fibonacci number (write in terms of 'input')";
        question0.Category = 0;
        question0.Body = "";
        question0.ShortAnswer = true;
        question0.MultipleChoice = false;
        question0.TrueFalse = false;
        question0.A = "Not MC";
        question0.B = "Not MC";
        question0.C = "Not MC";
        question0.D = "Not MC";
        question0.E = "Not MC";
        question0.Answer = "def recurse(input):\n\tif(input < 2): \n\t\treturn 1\n\telse:\n\t\treturn recurse(input-1) + recurse(input-2)\nreturn recurse(input)";


        var question1 = new Question();
        question1.QuestionId = 1;
        question1.Title = "What is (n-1)/3?";
        question1.Category = 0;
        question1.Body = "";
        question1.ShortAnswer = true;
        question1.MultipleChoice = false;
        question1.TrueFalse = false;
        question1.A = "Not MC";
        question1.B = "Not MC";
        question1.C = "Not MC";
        question1.D = "Not MC";
        question1.E = "Not MC";
        question1.Answer = "return (input - 1) / 3";

        var question2 = new Question();
        question2.QuestionId = 2;
        question2.Title = "Solve for the third side of a right triangle with hypotenuse length 20 and leg length 'input'";
        question2.Category = 0;
        question2.Body = "";
        question2.ShortAnswer = true;
        question2.MultipleChoice = false;
        question2.TrueFalse = false;
        question2.A = "Not MC";
        question2.B = "Not MC";
        question2.C = "Not MC";
        question2.D = "Not MC";
        question2.E = "Not MC";
        question2.Answer = "import math\nreturn math.sqrt(20 * *2 - input * *2)";

        var question3 = new Question();
        question3.QuestionId = 3;
        question3.Title = "Return double input 'input'";
        question3.Category = 0;
        question3.Body = "return ";
        question3.ShortAnswer = true;
        question3.MultipleChoice = false;
        question3.TrueFalse = false;
        question3.A = "Not MC";
        question3.B = "Not MC";
        question3.C = "Not MC";
        question3.D = "Not MC";
        question3.E = "Not MC";
        question3.Answer = "return (input * 2)";

        var question4 = new Question();
        question4.QuestionId = 4;
        question4.Title = "Find the area of a circle radius 'input'.";
        question4.Category = 0;
        question4.Body = "return ";
        question4.ShortAnswer = true;
        question4.MultipleChoice = false;
        question4.TrueFalse = false;
        question4.A = "Not MC";
        question4.B = "Not MC";
        question4.C = "Not MC";
        question4.D = "Not MC";
        question4.E = "Not MC";
        question4.Answer = "import math\nreturn (math.pi * input**2)";

        var question5 = new Question();
        question5.QuestionId = 5;
        question5.Title = "Sum of integers 1 to input.";
        question5.Category = 0;
        question5.Body = "return ";
        question5.ShortAnswer = true;
        question5.MultipleChoice = false;
        question5.TrueFalse = false;
        question5.A = "Not MC";
        question5.B = "Not MC";
        question5.C = "Not MC";
        question5.D = "Not MC";
        question5.E = "Not MC";
        question5.Answer = "return input * (input - 1) / 2";

        var question6 = new Question();
        question6.QuestionId = 6;
        question6.Title = "Square input.";
        question6.Category = 0;
        question6.Body = "return ";
        question6.ShortAnswer = true;
        question6.MultipleChoice = false;
        question6.TrueFalse = false;
        question6.A = "Not MC";
        question6.B = "Not MC";
        question6.C = "Not MC";
        question6.D = "Not MC";
        question6.E = "Not MC";
        question6.Answer = "return input ** 2";

        var question7 = new Question();
        question7.QuestionId = 7;
        question7.Title = "What is the square root of 100";
        question7.Category = 1;
        question7.Body = "";
        question7.ShortAnswer = true;
        question7.MultipleChoice = false;
        question7.TrueFalse = false;
        question7.A = "50";
        question7.B = "10";
        question7.C = "20";
        question7.D = "25";
        question7.E = "2";
        question7.Answer = "B";

        var question8 = new Question();
        question8.QuestionId = 8;
        question8.Title = "What is acceleration due to gravity on Earth's surface?";
        question8.Category = 2;
        question8.Body = "return ";
        question8.ShortAnswer = true;
        question8.MultipleChoice = false;
        question8.TrueFalse = false;
        question8.A = "9.8 m/s^2";
        question8.B = "32 cm/s^2";
        question8.C = "6.9 m/s^2 MC";
        question8.D = "A and B";
        question8.E = "A, B, and C";
        question8.Answer = "return ";

        var question9 = new Question();
        question9.QuestionId = 9;
        question9.Title = "US History -- Who was President during the War of 1812?";
        question9.Category = 3;
        question9.Body = "return ";
        question9.ShortAnswer = true;
        question9.MultipleChoice = false;
        question9.TrueFalse = false;
        question9.A = "Harry Truman";
        question9.B = "Gerald Ford";
        question9.C = "James Madison";
        question9.D = "Harrison Ford";
        question9.E = "James Monroe";
        question9.Answer = "C";

        questions.Add(question0);
        questions.Add(question1);
        questions.Add(question2);
        questions.Add(question3);
        questions.Add(question4);
        questions.Add(question5);
        questions.Add(question6);
        questions.Add(question7);
        questions.Add(question8);
        questions.Add(question9);
        return questions;
    }
}
