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
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        NORTHWNDEntities ctx = new NORTHWNDEntities();
        String CustomerId;

        public Form3(String CustomerId)
        {
            this.CustomerId = CustomerId;
            InitializeComponent();
        }

        void refreshGrid()
        {
            metroGrid1.DataSource =
                     (from c in ctx.Orders
                      where c.CustomerID.Equals(CustomerId)
                      select c).ToList();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }
    }
}
