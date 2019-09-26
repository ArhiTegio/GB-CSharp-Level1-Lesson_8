using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_WinBelieveUnbelievers
{
    public partial class AboutTheProgram : Form
    {
        public AboutTheProgram()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutTheProgram_Load(object sender, EventArgs e)
        {
            richTextBox2.Text = "Кузнецов C# Уровень 1. Задание 8.1." + Environment.NewLine +
                "Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю»." + Environment.NewLine +
                "" + Environment.NewLine +
                "Игра создана учеником Кузнецовым В.В.GeekBrains под предводительством Сергея Камянецкого и непосредственным содействие Антоном Алиевым." + Environment.NewLine +
                "" + Environment.NewLine +
                "Copyright © Все права защищены согласно статье 1271 ГК РФ, а также ГОСТ Р 7.0.1 - 2003."; 
        }
    }
}
