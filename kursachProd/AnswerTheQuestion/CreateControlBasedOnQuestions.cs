using kursachProd.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachProd.AnswerTheQuestion
{
    internal class CreateControlBasedOnQuestions
    {
        private readonly Form? form;
        private JSONWrapper? JSONWrapper;
        public CreateControlBasedOnQuestions(Form form)
        {
            this.form = form;
        }
        public void Init()
        {
            ReadJSON();
            CreateCustomControl();
        }
        private void ReadJSON()
        {
            JSONWrapper = new JSON().Read();
        }
        private void CreateCustomControl()
        {
            RadioButton radioButton = new()
            {
                Text = "Test"
            };
            form?.Controls.Add(radioButton);
        }
    }
}