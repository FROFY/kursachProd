using kursachProd.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd
{
    internal class DeleteQuestion
    {
        Form form;
        List<string>? questions;
        JSONWrapper? json;
        public DeleteQuestion(Form form)
        {
            questions = new List<string>();
            json = new JSON().Read();
            this.form = form;
        }
        public void Init() => json?.Questions.ForEach(x => { x.BodyQuestion.ForEach(y => { if (y.EndsWith('?')) questions?.Add(y); }); });
        public List<string> GetQuestions() => questions;
        public JSONWrapper GetJSON() => json;
    }
}
