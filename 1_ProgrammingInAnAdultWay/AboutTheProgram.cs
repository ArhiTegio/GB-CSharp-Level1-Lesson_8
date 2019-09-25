using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8_1
{
    public partial class AboutTheProgram : Form
    {
        public AboutTheProgram()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AboutTheProgram_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Кузнецов C# Уровень 1. Задание 8.1." + Environment.NewLine +
                "1.а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок(не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.)." + Environment.NewLine +
                "б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение." + Environment.NewLine +
                "в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.)." + Environment.NewLine +
                "г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос." + Environment.NewLine +
                "д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog)." + Environment.NewLine +
                "3. *Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).";
        }
    }
}
