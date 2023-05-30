using kursachProd.FormHandlers;
using kursachProd.Questions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursachProd
{
    public partial class CreateQuestionForm : Form
    {
        JSONWrapper JSONWrapper = new();
        CustomControl CustomControl = new();
        public CreateQuestionForm()
        {
            InitializeComponent();
            button2.Click += (s, e) => CustomControl.Init(this);
            button4.Click += (s, e) => new SeeQuestions().Show();
            button5.Click += (s, e) => new AnswerTheQuestions().Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CreateQuestions createQuestions = new();
            foreach (Control textBox in Controls.OfType<TextBox>())
                createQuestions.AddAnswer(textBox.Text);
            JSONWrapper.Questions.Add(createQuestions);
            foreach (Control textBox in Controls.OfType<TextBox>())
                textBox.Text = string.Empty;
            CustomControl.Clear();
        }

        private void CreateQuestionForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void button3_Click(object sender, EventArgs e) => new JSON().Write(JSONWrapper);
    }
}
