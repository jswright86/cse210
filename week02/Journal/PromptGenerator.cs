public class PromptGenerator
{

    public List<String> _prompts = new List<String> { "What's something new I learned today?", "What was the best part of my day?", "How have I seen the hand of the Lord in my life today?", "What is one thing I would do over today if I could?", "What was the strongest emotion I felt today and Why?", "Who was the most interesting person I met today and why?" };
    
    public string GetRandomPrompt()
    {
        Random randomPrompt = new Random();
        int promptNum = randomPrompt.Next(0, _prompts.Count);
        string randomPrompt1 = _prompts[promptNum];
        return randomPrompt1;
    }

}