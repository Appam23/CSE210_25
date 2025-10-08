class Prompt
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What's something that made you smile today?",
        "Describe a challenge you overcame recently.",
        "What are you grateful for right now?",
        "Share a goal you have for this week.",
    };
    private Random QuestionGenrator = new Random();
    public string getRandomPrompt()
    {
        int index = QuestionGenrator.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }
}