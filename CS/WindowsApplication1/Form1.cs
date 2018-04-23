using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SkinName = SkinManager.Default.Skins[r.Next(SkinManager.Default.Skins.Count)].SkinName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}