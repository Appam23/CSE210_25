// Base class for all homework assignments
public class Homework
{
    public string StudentName;
    public string Topic;

    public Homework(string studentName, string topic)
    {
        StudentName = studentName;
        Topic = topic;
    }

    public virtual string GetSummary()
    {
        return $"Student: {StudentName}, Topic: {Topic}";
    }
}

    