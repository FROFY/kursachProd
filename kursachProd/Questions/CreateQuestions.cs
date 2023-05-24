using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.Questions
{
    internal class CreateQuestions : Question
    {
        public CreateQuestions()
        {
            BodyQuestion = new List<string>();
        }

        public void AddAnswer(string answer)
        {
            BodyQuestion.Add(answer);
        }
    }
}
