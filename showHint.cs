using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class showHint : MonoBehaviour
{

	public GameObject hint;
	GlobalVars vars;

	void OnTriggerEnter(Collider collision)
	{
			hint.SetActive (true);

	    
	}

	void OnTriggerExit(Collider collision)
	{
		hint.SetActive (false);
	}

    void OnTriggerStay(Collider collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var door = transform.parent.gameObject.GetComponent<doorOpener>();
            var index = door.Index;
            if (vars.doors[index] == 2)
            {
                return;
            };
            vars.doors[index] = 1;
            vars.currentPosition = collision.transform.position;
            vars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>();
            Random r = new Random();
            int id = r.Next(0, 9);
            vars.currentQuestion = id;

            var danielsABitch = vars.wrapper.Data.Questions.Where(x => x.QuestionId == id).FirstOrDefault();
            if (danielsABitch.MultipleChoice)
            {
                SceneManager.LoadScene("multiplechoice");
            }

            if (danielsABitch.ShortAnswer)
            {
                SceneManager.LoadScene("Daniel");
            }
        }
    }

	// Use this for initialization
	void Start()
	{
		vars = GameObject.Find ("GlobalVars").GetComponent<GlobalVars>();
	}
	
	// Update is called once per frame
	void Update()
	{

    }
}
