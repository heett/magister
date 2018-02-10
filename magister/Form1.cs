using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magister
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {
          
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void updater_Tick(object sender, EventArgs e)
        {
            


            label1.Text = DateTime.Now.ToString("(время HH:mm:ss)");
            int proc = (int)(performanceCounter2.NextValue());
            //Показывает количество выведенных IP-дейтаграмм, которые были отброшены, даже если не было обнаружено никаких проблем, чтобы предотвратить их передачу в пункт назначения (например, из-за отсутствия буферного пространства). 
            int Outbound_Discarded = (int)(performanceCounter1.NextValue());
            label2.Text = proc.ToString();
            metroProgressBar1.Value = proc;
            label3.Text = "Отброшенные пакеты:"+ Outbound_Discarded.ToString();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
