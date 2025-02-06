using Microsoft.AspNetCore.Components;
using Quizzing.Models;

namespace Quizzing.Pages
{
    public class QuizCardBase : ComponentBase
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        protected int questionIndex = 0;
        protected int score = 0;

        protected override Task OnInitializedAsync()
        {
            LoadQuestions();

            return base.OnInitializedAsync();
        }

        protected void OptionSelected(Option option)
        {
            
            if (option.IsRight)
            {
                score++;
            }
            option.IsSelected = true;
           
            questionIndex++;
        }

        protected void RestartQuiz()
        {
            score = 0;
            questionIndex = 0;
        }

        private void LoadQuestions()
        {
            Question q1 = new Question
            {
                QuestionTitle = "Який наголос у слові \"разом\"?",
                Options = new List<Option>() {
                    new Option { OptionTitle ="разОм", OptionReaction ="Неправильно.Попри те, що багато хто так говорить і навіть співає у піснях" },
                    new Option { OptionTitle ="рАзом", OptionReaction = "Правильно! Адже рАзом нас багато!" },
                    new Option { OptionTitle ="Обидва варіанти вірні", OptionReaction = "Неправильно. Вірний варіант лише один - рАзом. Запам'ятай і не помиляйся!" }
                },
                Answer = "рАзом"
            };
            Question q2 = new Question
            {
                QuestionTitle = "Який наголос у слові \"спина\"?",
                Options = new List<Option>() {
                    new Option { OptionTitle ="спИна", OptionReaction ="Маєш рацію! Тільки так - спИна!" },
                    new Option { OptionTitle ="спинА", OptionReaction = "Ні.Хоча так інколи говорять навіть лікарі, які лікують спИну" },
                    new Option { OptionTitle ="Обидва варіанти вірні", OptionReaction = "Ні! Правильний наголос лише на \"И\" - спИна!" }
                },
                Answer = "спИна"
            };

            Questions.AddRange(new List<Question> { q1, q2 });
        }
    }
}
