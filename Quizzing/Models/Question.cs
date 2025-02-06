namespace Quizzing.Models
{
    public class Question
    {
        public string QuestionTitle { get; set; } = string.Empty;
        public IEnumerable<Option> Options { get; set; } = new List<Option>();
        public string Answer { get; set; } = string.Empty;
    }

    public class Option
    {
        public string OptionTitle { get; set; } = string.Empty;
        public string OptionReaction { get; set; } =string.Empty;

    }
}
