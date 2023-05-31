using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.Questions
{
    internal class CreateQuestions : Question
    {
        /// <summary>
        /// Конструктор. Инициализирует контейнер с телом вопросов.
        /// </summary>
        public CreateQuestions()
        {
            BodyQuestion = new List<string>();
        }
        /// <summary>
        /// Добавляет вопрос в контейнер
        /// </summary>
        /// <param name="answer"></param>
        public void AddAnswer(string answer)
        {
            BodyQuestion.Add(answer);
        }
    }
}
