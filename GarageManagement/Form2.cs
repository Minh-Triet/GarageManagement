using GarageManagement.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GarageManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GarageManagementEntities db = new GarageManagementEntities();
            dataGridView1.DataSource = db.Admins.ToList();
            for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = dataGridView1.Columns[i].Width;
                //remove autosizing
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                dataGridView1.Columns[i].Width = colw;
            }
        }
    }
}
