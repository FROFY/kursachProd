namespace kursachProd
{
    public partial class WelcomeForm : Form
    {
        private CreateQuestionForm createQuestionForm;
        private AnswerTheQuestions? answerQuestions;

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createQuestionForm = new CreateQuestionForm();
            createQuestionForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            answerQuestions = new AnswerTheQuestions();
            answerQuestions.Show();
            this.Hide();
        }
    }
}