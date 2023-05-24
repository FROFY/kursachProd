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
        private Form form;
        private Control? getLastTextBox;
        private Control? getLastLabel;
        public CustomControl(Form form) 
        {
            this.form = form;
        }
        public void Init()
        {
            GetLastControls();
            AddControlToWindow(CreateCustomLabel(), CreateCustomTextBox());
        }
        private Control CreateCustomTextBox()
        {
            TextBox textBox = new()
            {
                Location = new Point(getLastTextBox.Location.X, getLastTextBox.Location.Y + 29),
                Size = getLastTextBox.Size
            };
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
    }
}
