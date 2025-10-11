public class Entry
{
    //attributes
    private string _givenPrompt;
    private string _date;
    private string _response;
    public Entry(string date, string givenPrompt, string response)
    {
        _givenPrompt = givenPrompt;
        _date = date;
        _response = response;

    }
    public Entry()
    {
        _givenPrompt = "";
        _date = "";
        _response = "";
    }

    public string GetDate()
    {
        _date = DateTime.Now.ToShortDateString();
        return _date;
    }
    public string GetPrompt()
    {
        Prompt generator = new Prompt();
        _givenPrompt = generator.getRandomPrompt();
        return _givenPrompt;    
    }
    public string GetResponse()
    {
        Console.WriteLine(_givenPrompt);
        Console.Write("Ans: ");
        _response = Console.ReadLine();
        return _response;
    }
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_givenPrompt}");
        Console.WriteLine($"Response: {_response}");
    }
    public override string ToString()
    {
        return $"{_date}#{_givenPrompt}#{_response}";
    }
}



    