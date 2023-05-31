using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursachProd.FormHandlers
{
    internal class CustomControl
    {
        private Form? form;
        private List<Control>? textBoxesList;
        private List<Control>? labelList;
        private Control? getLastTextBox;
        private Control? getLastLabel;
        /// <summary>
        /// Конструктор. Инициализирует контейнеры для хранения контролов с формы
        /// </summary>
        public CustomControl() 
        {
            textBoxesList = new List<Control>();
            labelList = new List<Control>();
        }
        /// <summary>
        /// Инициализация. Сохраняет форму. Получает последние контролы с формы. Проверяет на максимум элементов. Добавляет контролы на форму.
        /// </summary>
        /// <param name="form"></param>
        public void Init(Form form)
        {
            this.form = form;
            GetLastControls();
            if (CheckForMax())
            {
                MessageBox.Show("Maximum 7 elements");
                return;
            }
            AddControlToWindow(CreateCustomLabel(), CreateCustomTextBox());
        }
        /// <summary>
        /// Создание тексбокса для заполнения ответа
        /// </summary>
        /// <returns>Контрол типа TextBox</returns>
        private Control CreateCustomTextBox()
        {
            TextBox textBox = new()
            {
                Location = new Point(getLastTextBox.Location.X, getLastTextBox.Location.Y + 29),
                Size = getLastTextBox.Size
            };
            AddTextBoxToList(textBox);
            return textBox;
        }
        /// <summary>
        /// Проверка на максимум ответов
        /// </summary>
        /// <returns></returns>
        private bool CheckForMax() => getLastLabel?.Text == "7";
        /// <summary>
        /// Создание label для подписания элементов формы
        /// </summary>
        /// <returns>Контрол типа Label</returns>
        private Control CreateCustomLabel()
        {
            Label label = new()
            {
                Text = (Convert.ToInt16(getLastLabel?.Text) + 1).ToString(),
                Location = new Point(getLastLabel.Location.X, getLastLabel.Location.Y + 29),
                Size = getLastLabel.Size
            };
            AddLabelToList(label);
            return label;
        }
        /// <summary>
        /// Получает последние контролы типа TextBox и Label по максимальной координате Y
        /// </summary>
        private void GetLastControls()
        {
            getLastTextBox = form?.Controls.OfType<TextBox>().ToList().MaxBy(x => x.Location.Y);
            getLastLabel = form?.Controls.OfType<Label>().ToList().MaxBy(x => x.Location.Y);
        }
        /// <summary>
        /// Добавлет контролы на форму
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="label"></param>
        private void AddControlToWindow(Control textBox, Control label)
        {
            form?.Controls.Add(textBox);
            form?.Controls.Add(label);
        }
        /// <summary>
        /// Кидаем в контейнер добавленные контролы
        /// </summary>
        /// <param name="textBox"></param>
        private void AddTextBoxToList(Control textBox)
        {
            textBoxesList?.Add(textBox);
        }
        /// <summary>
        /// Кидаем в контейнер добавленные контролы
        /// </summary>
        /// <param name="textBox"></param>
        private void AddLabelToList(Control label)
        {
            labelList?.Add(label);
        }
        /// <summary>
        /// Удаляем с формы все варианты ответов
        /// </summary>
        private void RemoveBoxex()
        {
            foreach (Control control in textBoxesList)
                form?.Controls.Remove(control);
        }
        /// <summary>
        /// Удаляем с формы все подписи контролов
        /// </summary>
        private void RemoveLabels()
        {
            foreach (Control control in labelList)
                form?.Controls.Remove(control);
        }
        /// <summary>
        /// Метод очистки формы
        /// </summary>
        public void Clear()
        {
            RemoveBoxex();
            RemoveLabels();
            textBoxesList?.Clear();
            labelList?.Clear();
        }
    }
}
