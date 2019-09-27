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
    public partial class Form2 : Form
    {
        /// <summary>
        /// Заполнение данными
        /// </summary>
        /// <param name="model"></param>
        public Form2(CityModel model)
        {
            InitializeComponent();
            
            this.Text = $"Погода {model.Date.ToString()}";

            var column1 = new DataGridViewColumn();
            column1.Width = 300;
            column1.ReadOnly = true; //значение в этой колонке нельзя править
            column1.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.Width = 140;
            column2.Name = "price";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Rows.Add("Город", model.Name);
            dataGridView1.Rows.Add("Максимальная температура", $"{ model.TemperatureMax}°C");
            dataGridView1.Rows.Add("Минимальная температура", $"{ model.TemperatureMin}°C");
            dataGridView1.Rows.Add("Максимальное давление", $"{ model.PressureMax} мм.рт.ст.");
            dataGridView1.Rows.Add("Минимальное давление", $"{ model.PressureMin} мм.рт.ст.");
            dataGridView1.Rows.Add("Облачность", $"{ model.СloudinessWeather}");
            dataGridView1.Rows.Add("Осадки", $"{ model.PrecipitationWeather}");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
