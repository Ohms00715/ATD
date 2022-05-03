using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATD
{
    public partial class UCT : UserControl
    {
        public UCT()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("MAS100");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
