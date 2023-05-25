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
        public CustomControl() 
        {
            textBoxesList = new List<Control>();
            labelList = new List<Control>();
        }
        public void Init(Form form)
        {
            this.form = form;
            GetLastControls();
            if (getLastLabel.Text == "7")
            {
                MessageBox.Show("Maximum 7 elements");
                return;
            }
            AddControlToWindow(CreateCustomLabel(), CreateCustomTextBox());
        }
        private Control CreateCustomTextBox()
        {
            TextBox textBox = new()
            {
                Location = new Point(getLastTextBox.Location.X, getLastTextBox.Location.Y + 29),
                Size = getLastTextBox.Size
            };
            addTextBoxToList(textBox);
            return textBox;
        }
        private Control CreateCustomLabel()
        {
            Label label = new()
            {
                Text = (Convert.ToInt16(getLastLabel?.Text) + 1).ToString(),
                Location = new Point(getLastLabel.Location.X, getLastLabel.Location.Y + 29),
                Size = getLastLabel.Size
            };
            addLabelToList(label);
            return label;
        }
        private void GetLastControls()
        {
            if (form != null)
            {
                getLastTextBox = form.Controls.OfType<TextBox>().ToList().MaxBy(x => x.Location.Y);
                getLastLabel = form.Controls.OfType<Label>().ToList().MaxBy(x => x.Location.Y);
            }
        }
        private void AddControlToWindow(Control textBox, Control label)
        {
            form.Controls.Add(textBox);
            form.Controls.Add(label);
        }
        private void addTextBoxToList(Control textBox)
        {
            textBoxesList.Add(textBox);
        }
        private void addLabelToList(Control label)
        {
            labelList.Add(label);
        }
        private void RemoveBoxex()
        {
            foreach (Control control in textBoxesList)
                form.Controls.Remove(control);
        }
        private void RemoveLabels()
        {
            foreach (Control control in labelList)
                form.Controls.Remove(control);
        }
        public void Clear()
        {
            RemoveBoxex();
            RemoveLabels();
            textBoxesList?.Clear();
            labelList?.Clear();
        }
    }
}
