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
        private Point point;
        private int count;
        public CreateControlBasedOnQuestions(Form form) => this.form = form;
        public void Init()
        {
            ReadJSON();
            ParseQuestions();
        }
        public void Create(int count)
        {
            this.count= count;
            if (!CheckMax(count))
            {
                CreateLabel();
                DeleteAllRadio();
                return;
            }
            CreateLabel(GetIndex(count));
            CreateCustomControl();
        }
        public string GetIndex(int count) => questions[count];
        private void ReadJSON() => JSONWrapper = new JSON().Read();
        private void CreateCustomControl()
        {
            InitPoint();
            DeleteAllRadio();
            GetCurrentAnswers().ForEach(answer => 
            {
                RadioButton radioButton = new()
                {
                    Text = answer,
                    Location = point,
                    Size = new Size(500, 30)
                };
                AddControlToForm(radioButton);
                AddPointValues();
            });
        }
        private void AddPointValues() => point.Y += 30;
        private void InitPoint() => point = new Point(50, 50);
        private void CreateLabel(string labelText = "END")
        {
            DeleteAllLabels();
            Label label = new()
            {
                Text = labelText,
                Location = new Point(150, 30),
                Size = new Size(300,100)
            };
            AddControlToForm(label);
        }
        private List<string> GetCurrentAnswers()
        {
            List<string> currentAnswers = new();
            JSONWrapper?.Questions.ForEach(quest =>
            {
                if (quest.BodyQuestion.Contains(GetIndex(count)))
                    quest.BodyQuestion.ForEach(getAnswers => { if (!getAnswers.EndsWith('?')) currentAnswers.Add(getAnswers); });
            });
            return currentAnswers;
        }
        private void DeleteAllLabels()
        {
            foreach (Control label in form.Controls.OfType<Label>())
                form.Controls.Remove(label);
        }
        private void DeleteAllRadio()
        {
            form?.Controls.OfType<RadioButton>().ToList().ForEach(form.Controls.Remove);
        }
        private void DeleteAllRadio1()
        {
            foreach (Control radio in form.Controls.OfType<RadioButton>().ToList())
                form.Controls.Remove(radio);
        }
        private bool CheckMax(int count) => questions?.Count > count;
        private void ParseQuestions()
        {
            questions = new List<string>();
            JSONWrapper?.Questions.ForEach(body => { body.BodyQuestion.ForEach(question => { if (question.EndsWith('?')) questions.Add(question); }); });
        }
        private void AddControlToForm(Control control) => form?.Controls.Add(control);
    }
}