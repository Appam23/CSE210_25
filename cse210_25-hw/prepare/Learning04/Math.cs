
// Math assignment class
public class Math : Homework
{
    public string TextbookSection;
    public string Problems;

    public Math(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        TextbookSection = textbookSection;
        Problems = problems;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $", Section:{TextbookSection}, Problems:{Problems}";
    }
}
