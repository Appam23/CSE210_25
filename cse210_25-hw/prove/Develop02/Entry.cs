class Entry
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
        return _date;
    }
    public string GetPrompt()
    {
        return _givenPrompt;    
    }
    public string GetResponse()
    {
        if (string.IsNullOrEmpty(_givenPrompt))
        {
            Prompt generator = new Prompt();
            _givenPrompt = generator.getRandomPrompt();
        }
        return _response;
    }
    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_givenPrompt}\nResponse: {_response}\n";
    }
}



    