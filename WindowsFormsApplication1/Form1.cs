using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        NORTHWNDEntities ctx = new NORTHWNDEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
                refreshDataGrid();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var srs = metroGrid1.SelectedRows;

            if (srs.Count < 1)
                return;

            if (MessageBox.Show("Biztos törölni szeretnéd?", 
                "tuti?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var sr in srs)
                {
                    ctx.Customers.Remove(
                        (Customers)(((DataGridViewRow)sr).DataBoundItem));
                }

                ctx.SaveChanges();
                refreshDataGrid();
            }
        }

        void refreshDataGrid()
        {
            if (metroTextBox1.Text == "")
                metroGrid1.DataSource = ctx.Customers.ToList();
            else
            {
                metroGrid1.DataSource =
                     (from c in ctx.Customers
                     where c.CompanyName.Contains(metroTextBox1.Text)
                     select c).ToList();
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }
    }
}
