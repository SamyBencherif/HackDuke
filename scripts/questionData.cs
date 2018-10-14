using System;

public class QuestionData {
    public Guid QuestionId = Guid.Empty;
    public string Title = "";
    public short Category = 0;
    public string Body = "";
    public bool ShortAnswer = false;
    public bool MultipleChoice = false;
    public bool TrueFalse = false;
    public string A = "";
    public string B = "";
    public string C = "";
    public string D = "";
    public string E = "";
    public string Answer = "";
}
