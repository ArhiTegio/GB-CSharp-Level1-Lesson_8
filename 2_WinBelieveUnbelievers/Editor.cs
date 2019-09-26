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
    public partial class Editor : Form
    {
        TrueFalse database;
        public Editor(TrueFalse database)
        {
            this.database = database;
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            while(database.Count != 0)            
                database.Remove(0);

            var t = dataGridView1[1, 0].Value.ToString();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                if (dataGridView1[0, i].Value != null && dataGridView1[1, i].Value != null)
                    database.Add(dataGridView1[0, i].Value.ToString(), (dataGridView1[1, i].Value.ToString() == "Да")?true:false);

            database.Save();
            Close();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            foreach(var index in database.GetAllQuestuon())            
                dataGridView1.Rows.Add(index.text, index.trueFalse?"Да":"Нет");            
        }
    }
}
