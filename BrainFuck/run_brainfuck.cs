using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brainfuck
{
	string src;
	int i_pointer = 0;

	int[] tape;
	int t_pointer = 0;

	Stack loops;

	public string display="";

	public bool requestingCharInput = false;

	public brainfuck(string src)
	{
		this.src = src;
		tape = new int[8];
		loops = new Stack();
	}


	// >+++++++ incr multicand by 7     [ < +++++++ > -]  add 7 multicand times   display .
	//                                  ^              ^
	//                                 i48            i56

	// loops = []
	// loops.push(48) //when you see a '[' at i48.
	// loops.pop()    //when you *pass* a subsequent ']' (ie tape[t_pointer] == 0)
	// i_pointer = loops.peek()    //when you encounter ']' and tape[t_pointer] != 0

	public void step()
	{
		switch (src[i_pointer]) {
			case '+':
				tape[t_pointer]++;
				break;
			case '-':
				tape[t_pointer]--;
				break;
			case '>':
				t_pointer++;

				if (t_pointer == tape.Length)  //wrap around
					t_pointer = 0;

				break;
			case '<':
				t_pointer--;

				if (t_pointer == -1)  //wrap around
					t_pointer = tape.Length - 1;

				break;
			case '[':
				loops.Push(i_pointer);
				break;
			case ']':
				if (tape[t_pointer] == 0) //exit loop
					loops.Pop();
				else //return to beginning of loop
					i_pointer = (int)loops.Peek();
				break;
			case ',':
				requestingCharInput = true;
				break;
			case '.':
				display += (char)tape[t_pointer];
				break;
		}
		i_pointer++;
	}

	public void pushChar(char x)
	{
		tape[t_pointer] = (int)x;
		requestingCharInput = false;
	}

	public bool isComplete()
	{
		return i_pointer == src.Length;
	}

}

public class run_brainfuck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		brainfuck bf = new brainfuck(@",.,. [-] > ++++++++ [ < ++++++++ > -] < ++++++++.> +++++ [ < +++++ > -] < ++++.+++++++..+++.> ++++++++ [ < -------- > -] < ---.------------.> ++++++++ [ < ++++++++ > -] < +++++++++++++.------------.> ++++++++ [ < -------- > -] < -.> ++++++++ [ < ++++++++ > -] < ++.-.+.+++++++++++++++++++++++.> +++++++++ [ < --------- > -] < -------.-.> ++++++ [ < ++++++ > -] < ++++.> +++++ [ < +++++ > -] < ++++.+++++++..+++.> ++++++++ [ < -------- > -] < ---.------------.> ++++++++ [ < ++++++++ > -] < +++++++++++++.------------.> ++++++++ [ < -------- > -] < -.> ++++++++ [ < ++++++++ > -] < ++++++++.+++++++.-.---------.++++++++++++++++++++.> +++++++++ [ < --------- > -] < -------.-.> ++++++ [ < ++++++ > -] < ++++.> +++++ [ < +++++ > -] < ++++.+++++++..+++.> ++++++++ [ < -------- > -] < ---.------------.> ++++++++ [ < ++++++++ > -] < +++++++++++++.------------.> ++++++++ [ < -------- > -] < -.> +++++++++ [ < +++++++++ > -] < +.-----------------.++++++.+++++++++++++.-----------.++++.--------.> ++++++++ [ < -------- > -] < -----.> ++++++++ [ < ++++++++ > -] < +++++++.------.+++++++++++.> ++++++++ [ < -------- > -] < -----------.");

		string inputMsg = "a\n";
		int i = 0;

		while (!bf.isComplete())
		{
			if (bf.requestingCharInput)
			{
				bf.pushChar(inputMsg[i]);
				i++;
			}
			bf.step();
		}

		print(bf.display);
	}

	// Update is called once per frame
	void Update () {

	}
}
