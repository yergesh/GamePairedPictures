using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePairedPictures
{
    public partial class Form1 : Form
    {
        public bool easyChecked = false, mediumChecked = false, hardChecked = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EasyUpdate();
            easyChecked = true;
            mediumChecked = hardChecked = false;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediumUpdate();
            mediumChecked = true;
            hardChecked = easyChecked = false;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HardUpdate();
            mediumChecked = easyChecked = false;
            hardChecked = true;
        }

        private void easyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            easyToolStripMenuItem.CheckOnClick = !easyToolStripMenuItem.CheckOnClick;
            
        }

        private void EasyUpdate()
        {
            EasyUserControl easyUserControl = new EasyUserControl();
            if (!panel1.Controls.Contains(easyUserControl.Instance))
            {
                panel1.Controls.Add(easyUserControl.Instance);
                easyUserControl.Instance.Dock = DockStyle.Fill;
                easyUserControl.Instance.BringToFront();
            }
            else
                easyUserControl.Instance.BringToFront();
        }

        private void MediumUpdate()
        {
            MediumUserControl mediumUserControl = new MediumUserControl();
            if (!panel1.Controls.Contains(mediumUserControl.Instance))
            {
                panel1.Controls.Add(mediumUserControl.Instance);
                mediumUserControl.Instance.Dock = DockStyle.Fill;
                mediumUserControl.Instance.BringToFront();
            }
            else
                mediumUserControl.Instance.BringToFront();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(AboutUserControl.Instance))
            {
                panel1.Controls.Add(AboutUserControl.Instance);
                AboutUserControl.Instance.Dock = DockStyle.Fill;
                AboutUserControl.Instance.BringToFront();
            }
            else
                AboutUserControl.Instance.BringToFront();
        }

        private void HardUpdate()
        {
            HardUserControl hardUserControl = new HardUserControl();
            if (!panel1.Controls.Contains(hardUserControl.Instance))
            {
                panel1.Controls.Add(hardUserControl.Instance);
                hardUserControl.Instance.Dock = DockStyle.Fill;
                hardUserControl.Instance.BringToFront();
            }
            else
                hardUserControl.Instance.BringToFront();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = "Хотите начать новую игру?";
            string caption = "";
            result = MessageBox.Show(this, message, caption, buttons);

            if (easyChecked)
            {
                if (result == DialogResult.Yes)
                {
                    EasyUpdate();
                }
            }
            if (mediumChecked)
            {
                if (result == DialogResult.Yes)
                {
                    MediumUpdate();
                }
            }

            if (hardChecked)
            {
                if (result == DialogResult.Yes)
                {
                    HardUpdate();
                }
            }
                
        }
    }
}
