
// History (writing) assignment class
public class History : Homework
{
    public string Title;

    public History(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        Title = title;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $", Title: {Title}";
    }
}