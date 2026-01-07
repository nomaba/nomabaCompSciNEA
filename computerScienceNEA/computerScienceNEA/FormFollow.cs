using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerScienceNEA
{
    public partial class FormFollow : Form
    {
        public FormFollow()
        {
            InitializeComponent();
        }

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            this.Close();
            Home.Show();
        }

        private void FormFollow_Load(object sender, EventArgs e)
        {

        }
    }
}
