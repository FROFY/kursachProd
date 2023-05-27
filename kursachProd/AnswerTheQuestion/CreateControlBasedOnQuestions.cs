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
        private List<string>? questions;
        private List<string>? answers;
        public CreateControlBasedOnQuestions(Form form)
        {
            this.form = form;
        }
        public void Init()
        {
            ReadJSON();
            ParseQuestions();
            //CreateCustomControl();
            //CreateLabel();
        }
        public void Create(int count)
        {
            if (!CheckMax(count))
            {
                CreateLabel();
                return;
            }
            CreateLabel(GetIndex(count));
        }
        public string GetIndex(int count) => questions[count];
        private void ReadJSON() => JSONWrapper = new JSON().Read();
        private void CreateCustomControl()
        {
            RadioButton radioButton = new()
            {
                Text = "Test"
            };
            form?.Controls.Add(radioButton);
        }
        private void CreateLabel(string labelText = "END")
        {
            ClearForm();
            Label label = new()
            {
                Text = labelText,
                Location = new Point(150, 30)
            };
            AddControlToForm(label);
        }
        private void ClearForm()
        {
            foreach (Control label in form.Controls.OfType<Label>())
                form.Controls.Remove(label);
        }
        private bool CheckMax(int count) => questions.Count > count;
        private void ParseQuestions()
        {
            questions = new List<string>();
            JSONWrapper?.Questions.ForEach(body => { body.BodyQuestion.ForEach(question => { if (question.EndsWith('?')) questions.Add(question); }); });
        }
        private void AddControlToForm(Control control) => form?.Controls.Add(control);
    }
}