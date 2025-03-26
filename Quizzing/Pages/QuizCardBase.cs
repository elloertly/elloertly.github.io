using Microsoft.AspNetCore.Components;
using Quizzing.Models;

namespace Quizzing.Pages
{
    public class QuizCardBase : ComponentBase
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Question> AnsweredQuestions { get; set; } = new List<Question>();
        public List<Question> Cards { get; set; } = new List<Question>();

        protected int questionIndex = 0;
        protected int score = 0;
        protected bool showAnswers = false;

        protected override Task OnInitializedAsync()
        {
            LoadQuestions();
            Cards = new List<Question>(Questions);

            return base.OnInitializedAsync();
        }

        protected void OptionSelected(Option option)
        {
            var currentQuestion = Cards[questionIndex];
            var selectedOption = currentQuestion.Options.Where(x => x.OptionTitle == option.OptionTitle).First();
            
            if (option.IsRight)
            {
                score++;
            }
            selectedOption.IsSelected = true;
            currentQuestion.Answer = option.OptionReaction;
            AnsweredQuestions.Add(currentQuestion);
            questionIndex++;
        }

        protected void RestartQuiz()
        {
            LoadQuestions();
            Cards = new List<Question>(Questions);
            AnsweredQuestions = new List<Question>();
            score = 0;
            questionIndex = 0;
            showAnswers = false;
        }
        protected void ShowNext()
        {
            questionIndex++;
        }

        protected void ShowAnswers()
        {
            Cards = AnsweredQuestions.ToList();
            questionIndex = 0;
            showAnswers = true;
        }

        private void LoadQuestions()
        {
            Questions = new List<Question>();
            Question q1 = new Question
            {
                QuestionTitle = "Який наголос у слові \"разом\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="разОм", 
                        OptionReaction ="Неправильно.Попри те, що багато хто так говорить і навіть співає у піснях",
                        IsRight = false,
                        IsSelected = false},
                    new Option { 
                        OptionTitle ="рАзом", 
                        OptionReaction = "Правильно! Адже рАзом нас багато!",
                        IsRight = true,
                        IsSelected = false
                    },
                    new Option { 
                        OptionTitle ="Обидва варіанти вірні", 
                        OptionReaction = "Неправильно. Вірний варіант лише один - рАзом. Запам'ятай і не помиляйся!",
                        IsRight = false,
                        IsSelected = false}
                }
            };
            Question q2 = new Question
            {
                QuestionTitle = "Який наголос у слові \"спина\"?",
                Options = new List<Option>() {
                    new Option { 
                        OptionTitle ="спИна", 
                        OptionReaction ="Маєш рацію! Тільки так - спИна!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="спинА", 
                        OptionReaction = "Ні.Хоча так інколи говорять навіть лікарі, які лікують спИну",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="Обидва варіанти вірні", 
                        OptionReaction = "Ні! Правильний наголос лише на \"И\" - спИна!",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q3 = new Question
            {
                QuestionTitle = "Який наголос у слові \"також\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="тАкож",
                        OptionReaction ="Правильно, але ця відповідь - неповна. Обидва варіанти - правильні. У слові \"також\" - подвійний наголос!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="такОж",
                        OptionReaction = "Правильно, але ця відповідь - неповна. Обидва варіанти - правильні. У слові \"також\" - подвійний наголос!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="Обидва варіанти невірні",
                        OptionReaction = "\"Ага, попався! Неуважно читаєш і тицяєш відповіді навмання\"",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q4 = new Question
            {
                QuestionTitle = "Який наголос у слові \"щелепа\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="щелЕпа",
                        OptionReaction ="Зараз ти дуже здивуєшся, але - ні! Правильно щЕлепа!",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="щЕлепа",
                        OptionReaction = "Отакої! А ти звідки правильну відповідь знаєш? Так, щЕлепа",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="правильно і так, і так",
                        OptionReaction = "Ні, правильно лише щЕлепа",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q5 = new Question
            {
                QuestionTitle = "Який наголос у слові \"часу\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="часУ",
                        OptionReaction ="Це типова помилка. Правильно говорити \"не маю чАсу\"!\"",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="чАсу",
                        OptionReaction = "Правильно! Оце розумна людина тест проходить!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="слово не має наголосу",
                        OptionReaction = "Ага, попався! Неуважно читаєш і тицяєш відповіді навмання",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q6 = new Question
            {
                QuestionTitle = "Який наголос у слові \"подушка\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="подУшка",
                        OptionReaction ="ПодУшка - це правильно! Гарно пам'ятаєш наймиліше слово!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="пОдушка",
                        OptionReaction = "Ні, правильно говорити подУшка. І краще не говорити, а одразу на неї вмоститися",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="Обидва варіанти вірні",
                        OptionReaction = "Тут варіант правильний лише один. І це - подУшка!",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q7 = new Question
            {
                QuestionTitle = "Який наголос у слові \"одинадцять\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="одИнадцять",
                        OptionReaction ="Неправильно! До речі, у слові чотирнАдцять теж схожий наголос!",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="одинАдцять",
                        OptionReaction = "Саме так! Правильно одинАдцять!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="власний варіант",
                        OptionReaction = "Не існує власного варіанту там, де вже є правильний - одинАдцять!",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q8 = new Question
            {
                QuestionTitle = "Який наголос у слові \"адже\"",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="аджЕ",
                        OptionReaction ="Так! Складне слово, але ти знаєш!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="Адже",
                        OptionReaction = "Ні! Правильний варіант аджЕ",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="Обидва варіанти вірні",
                        OptionReaction = "О ні! Правильно тут лише аджЕ!",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q9 = new Question
            {
                QuestionTitle = "Який наголос у слові \"вантажівка\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="вантАжівка",
                        OptionReaction ="Ні, правильно казати вантажІвка",
                        IsRight = false,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="вантажІвка",
                        OptionReaction = "Правильно на 100%!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="Обидва варіанти вірні",
                        OptionReaction = "Ні! Правильний наголос лише на \"И\" - спИна!",
                        IsRight = false,
                        IsSelected = false}
                },
            };
            Question q10 = new Question
            {
                QuestionTitle = "Який наголос у слові \"перемога\"?",
                Options = new List<Option>() {
                    new Option {
                        OptionTitle ="ПеремОга",
                        OptionReaction ="Щоб не клацнув, а на Україну чекає лише перемОга!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="ПеремОга",
                        OptionReaction = "Щоб не клацнув, а на Україну чекає лише перемОга!",
                        IsRight = true,
                        IsSelected = false},
                    new Option {
                        OptionTitle ="ПеремОга",
                        OptionReaction = "Щоб не клацнув, а на Україну чекає лише перемОга!",
                        IsRight = true,
                        IsSelected = false}
                },
            };

            Questions.AddRange(new List<Question> { q1,q2,q3,q4,q5,q6,q7,q8,q9,q10 });
        }
    }
}
