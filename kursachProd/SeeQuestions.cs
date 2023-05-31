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
    public partial class SeeQuestions : Form
    {
        List<string>? questions;
        JSONWrapper json;
        DeleteQuestion deleteQuestion;
        /// <summary>
        /// Конструктор Инициализирует переменные и вызывает инициализацию объекта для удаления вопросов.
        /// Также заполняет форму вопросами для выбора
        /// </summary>
        public SeeQuestions()
        {
            InitializeComponent();
            deleteQuestion = new DeleteQuestion(this);
            deleteQuestion.Init();
            questions = deleteQuestion.GetQuestions();
            questions.ForEach(question => { treeView1.Nodes.Add(question); });
        }
        /// <summary>
        /// По нажатию кнопки удаляет вопрос из списка и заново сериализует
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            deleteQuestion.GetJSON().Questions.RemoveAt(treeView1.SelectedNode.Index);
            new JSON().Write(deleteQuestion.GetJSON());
            treeView1.SelectedNode.Remove();
        }
    }
}
