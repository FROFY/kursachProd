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
        /// <summary>
        /// Инициализация. Заполяет контейнер вопросами
        /// </summary>
        public void Init() => json?.Questions.ForEach(x => { x.BodyQuestion.ForEach(y => { if (y.EndsWith('?')) questions?.Add(y); }); });
        /// <summary>
        /// Возвращает вопросы
        /// </summary>
        /// <returns>Контейнер с вопросами</returns>
        public List<string> GetQuestions() => questions;
        /// <summary>
        /// Возвращает обертку json
        /// </summary>
        /// <returns></returns>
        public JSONWrapper GetJSON() => json;
    }
}
