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
        private readonly Form? form; // Форма
        private JSONWrapper? JSONWrapper; // Обертка json файла
        private List<string>? questions; // Контейнер типа строки для хранения вопросов
        private Point point; // Поинт для локации элементов на форме
        private int count; // Счетчик
        /// <summary>
        /// Конструктор принимает форму с которой работаем
        /// </summary>
        /// <param name="form"></param>
        public CreateControlBasedOnQuestions(Form form) => this.form = form;
        /// <summary>
        /// Инициализация:
        /// Чтение файла и парсинг
        /// </summary>
        public void Init()
        {
            ReadJSON();
            ParseQuestions();
        }
        /// <summary>
        /// Вывод вопроса на экран.
        /// Проверяет, нажат ли ответ.
        /// Переименовывает кнопку.
        /// Очищает форму и создает новые элементы для вывода вопроса.
        /// </summary>
        /// <param name="count">Счетчик нажатий кнопки</param>
        public void Create(int count)
        {
            if (!IsCheckedRadioButton())
                return;
            this.count = count;
            RenameButton();
            IsCheckedRadioButton();
            if (!CheckMax(count))
            {
                CreateLabel();
                DeleteAllRadio();
                return;
            }
            CreateLabel(GetIndex());
            CreateCustomRadioButton();
        }
        /// <summary>
        /// Возвращает вопрос по количеству нажатий кнопки
        /// </summary>
        /// <returns>Вопрос</returns>
        public string GetIndex() => questions[count];
        /// <summary>
        /// Десериализация (чтение файла)
        /// </summary>
        private void ReadJSON() => JSONWrapper = new JSON().Read();
        /// <summary>
        /// Создание радиокнопки для выбора вопроса
        /// </summary>
        private void CreateCustomRadioButton()
        {
            InitPoint();
            DeleteAllRadio();
            GetCurrentAnswers().ForEach(answer => 
            {
                RadioButton radioButton = new()
                {
                    Text = answer,
                    Location = point,
                    AutoSize = true
                };
                AddControlToForm(radioButton);
                AddPointValues();
            });
        }
        /// <summary>
        /// Переименовывание кнопки
        /// </summary>
        private void RenameButton() => form.Controls.OfType<Button>().ToList().ForEach(button => button.Text = "Далее");
        /// <summary>
        /// Смещение координаты Y для вариантов ответов
        /// </summary>
        private void AddPointValues() => point.Y += 30;
        /// <summary>
        /// Инициализация стандартных координат ответов
        /// </summary>
        private void InitPoint() => point = new Point(50, 50);
        /// <summary>
        /// Создание заголовка вопроса
        /// </summary>
        /// <param name="labelText">Сам вопрос. По умолчанию END (нет следующего вопроса)</param>
        private void CreateLabel(string labelText = "END")
        {
            DeleteAllLabels();
            Label label = new()
            {
                Text = labelText,
                Location = new Point(150, 30),
                AutoSize = true
            };
            AddControlToForm(label);
        }
        /// <summary>
        /// Достает ответы на вопрос
        /// </summary>
        /// <returns>Контейнер с ответами</returns>
        private List<string> GetCurrentAnswers()
        {
            List<string> currentAnswers = new();
            JSONWrapper?.Questions.ForEach(quest =>
            {
                if (quest.BodyQuestion.Contains(GetIndex()))
                    quest.BodyQuestion.ForEach(getAnswers => { if (!getAnswers.EndsWith('?')) currentAnswers.Add(getAnswers); });
            });
            return currentAnswers;
        }
        /// <summary>
        /// Проверяет выбран ли ответ
        /// </summary>
        /// <returns></returns>
        private bool IsCheckedRadioButton()
        {
            foreach (RadioButton control in form.Controls.OfType<RadioButton>().ToList())
            {
                if (control.Checked)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Удаляет с формы все label (для заголовков)
        /// </summary>
        private void DeleteAllLabels() => form?.Controls.OfType<Label>().ToList().ForEach(form.Controls.Remove);
        /// <summary>
        /// Удаляет все radioButton (для выбора ответа)
        /// </summary>
        private void DeleteAllRadio() => form?.Controls.OfType<RadioButton>().ToList().ForEach(form.Controls.Remove);
        /// <summary>
        /// Проверяет не последний ли вопрос был
        /// </summary>
        /// <param name="count">Количество нажатий</param>
        /// <returns>true or false</returns>
        private bool CheckMax(int count) => questions?.Count > count;
        /// <summary>
        /// Парсинг ответов из файла
        /// </summary>
        private void ParseQuestions()
        {
            questions = new List<string>();
            JSONWrapper?.Questions.ForEach(body => { body.BodyQuestion.ForEach(question => { if (!!question.EndsWith('?')) questions.Add(question); }); });
        }
        /// <summary>
        /// Добавляет контрол на форму
        /// </summary>
        /// <param name="control">Любой контрол</param>
        private void AddControlToForm(Control control) => form?.Controls.Add(control);
    }
}