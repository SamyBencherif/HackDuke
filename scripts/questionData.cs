using System;

public class QuestionData {
    public Guid QuestionId { get; set; }
    public string Title { get; set; }
    public short Category { get; set; }
    public string Body { get; set; }
    public bool ShortAnswer { get; set; }
    public bool MultipleChoice { get; set; }
    public bool TrueFalse { get; set; }
    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string D { get; set; }
    public string E { get; set; }
    public string Answer { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
