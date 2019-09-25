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
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            Repository.LoadData(this.listBox1, "https://xml.meteoservice.ru/export/gismeteo/point/17990.xml", false);

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new Form2(listBox1.SelectedItem as CityModel).Show();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutTheProgram()).Show();
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            var list =  new List<CityModel>();
            foreach(var item in listBox1.Items)
            {
                if (item is CityModel)
                    list.Add(item as CityModel);
            }
            Save_Load.SaveAsXmlCollectionFormat(list, saveFileDialog1.FileName);
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            var list = Save_Load.LoadFromXmlCollectionFormat(openFileDialog1.FileName);

            listBox1.Items.Clear();
            foreach (var item in list)            
                listBox1.Items.Add(item);            
        }

        private void КонвертироватьCSVВXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            Save_Load.ConvertCSVtoXML(openFileDialog2.FileName);
        }

        private void OpenFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
