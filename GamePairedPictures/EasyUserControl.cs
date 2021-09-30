﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePairedPictures
{
    public partial class EasyUserControl : UserControl
    {
        private EasyUserControl _instance;

        public EasyUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EasyUserControl();
                return _instance;
            }
        }


        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "Б","Б"
        };
        Label f, s;
        public EasyUserControl()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (f != null && s != null) return;

            Label Click_Label = sender as Label;
            if (Click_Label == null) return;

            if (Click_Label.ForeColor == Color.Black) return;


            if (f == null)
            {
                f = Click_Label;
                f.ForeColor = Color.Black;
                return;
            }
            s = Click_Label;
            s.ForeColor = Color.Black;

            IsWin();
            if (f.Text == s.Text)
            {
                f = s = null;
            }
            else timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            f.ForeColor = s.ForeColor = f.BackColor;
            f = s = null;

        }

        private void IsWin()
        {
            Label label;
            foreach (var item in tableLayoutPanel1.Controls)
            {
                label = item as Label;
                if (label != null && label.ForeColor == label.BackColor) return;
            }

            MessageBox.Show("Вы сопоставили все изображения. Поздравляю!");
        }

        public void AssignIconsToSquares()
        {
            Label label;
            int rNumber;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                rNumber = random.Next(0, icons.Count - 1);
                label.Text = icons[rNumber];
                icons.RemoveAt(rNumber);
            }
        }
    }
}
