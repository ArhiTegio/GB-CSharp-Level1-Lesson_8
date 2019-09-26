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
    public partial class Form1 : Form
    {
        // База данных с вопросами
        TrueFalse database;
        bool Answer = false;
        int RightAnswer = 0;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database = new TrueFalse("quest.sv");
            database.Load();
            index = 0;
            int RightAnswer = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            richTextBox1.Text = "";
            richTextBox1.Enabled = false;
        }

        private void РедактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Editor(database)).Show();
            index = 0;
            int RightAnswer = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            richTextBox1.Text = "";
            richTextBox1.Enabled = false;

        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void НоваяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 0;
            RightAnswer = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            richTextBox1.Enabled = true;
            Following();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(Answer)
            {
                index++;
                RightAnswer++;
            }
            else
                index++;
            Following();
        }

        private void Following()
        {
            if (database.Count > index)
            {
                richTextBox1.Text = database[index].text;
                Answer = database[index].trueFalse;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                richTextBox1.Text = "";
                richTextBox1.Enabled = false;
                MessageBox.Show($"Вы ответили правильно на {RightAnswer} из {database.Count}", "Поздравляю", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!Answer)
            {
                index++;
                RightAnswer++;
            }
            else
                index++;
            Following();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutTheProgram()).Show();
        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
