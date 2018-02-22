using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        NORTHWNDEntities ctx = new NORTHWNDEntities();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Customers c = new Customers();
            c.CompanyName = metroTextBox2.Text;
            c.CustomerID = metroTextBox1.Text;

            ctx.Customers.Add(c);
            ctx.SaveChanges();

            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
