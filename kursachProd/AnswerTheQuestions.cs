using kursachProd.AnswerTheQuestion;
using kursachProd.Questions;
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
    public partial class AnswerTheQuestions : Form
    {
        CreateControlBasedOnQuestions createQuestions;
        int clickCount = 0;
        public AnswerTheQuestions()
        {
            InitializeComponent();
            createQuestions = new(this);
            createQuestions.Init();
        }

        private void AnswerTheQuestions_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void button1_Click(object sender, EventArgs e)
        {
            createQuestions.Create(clickCount++);
        }
    }
}
