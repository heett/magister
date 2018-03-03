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
            //Показывает количество отброшенных IP-дейтаграмм, потому что не удалось найти маршрут для передачи их в пункт назначения. Этот счетчик включает любые пакеты, подсчитанные в дейтаграммах Forwarded / sec, которые соответствуют этому критерию «без маршрута».
            int Outbound_No_Route = (int)(performanceCounter3.NextValue());
            //Показывает количество входящих IP-дейтаграмм, которые были отброшены, поскольку IP-адрес в поле назначения заголовка IP недействителен для компьютера. Этот счет включает недопустимые адреса (например, 0.0 0.0) и адреса неподдерживаемых классов (например, класс E). Для объектов, которые не являются шлюзами IP и не пересылают датаграммы, этот счетчик включает датаграммы, отбрасываемые, поскольку адрес назначения не был локальным адресом.
            int Received_Address_Errors = (int)(performanceCounter4.NextValue());
            //Показывает количество входных IP-дейтаграмм, которые были отброшены из-за ошибок в заголовках IP, включая неправильные контрольные суммы, несоответствие номера версии, другие ошибки формата, время жизни, ошибки, обнаруженные при обработке их IP-параметров, и так далее.
            int Received_Header_Errors = (int)(performanceCounter5.NextValue());
            //Показывает количество успешно обработанных датаграмм, но отбрасывается из-за неизвестного или неподдерживаемого протокола
            int Received_Unknown_Protocol = (int)(performanceCounter6.NextValue());
            //Показывает скорость, с которой IP-датаграммы поступают с интерфейсов, в том числе с ошибками.Полученные дейтаграммы / сек - это подмножество IP \ Datagrams / sec.
            int Received_Sec = (int)(performanceCounter7.NextValue());
            //Показывает скорость передачи IP-дейтаграмм для передачи по локальным IP - протоколам пользователя(включая ICMP)
            int Sent_Sec = (int)(performanceCounter8.NextValue());
            // Доступная память
            int Memory_Available = (int)(performanceCounter9.NextValue());
            // Доступная память
            int Memory_Free = (int)(performanceCounter10.NextValue())/(1024*1000);
            label2.Text = proc.ToString();

            metroProgressBar1.Value = proc;
            label3.Text = "Отброшенные пакеты:" + Outbound_Discarded.ToString();
            label4.Text = "Пакеты которые не нашли маршрут:" + Outbound_No_Route.ToString();
            label5.Text = "Пакеты которые не отправленны из-за недопустимых ip адресов:" + Received_Address_Errors.ToString();
            label6.Text = "Пакеты отброшенные из-за ошибок в заголовках ip:" + Received_Header_Errors.ToString();
            label7.Text = "Пакеты обработанные,но отброшенные из-за неизвестного протокола:" + Received_Unknown_Protocol.ToString();
            label8.Text = "Скорость с которой пакеты поступают:" + Received_Sec.ToString();
            label9.Text = "Скорость с которой пакеты отправляются:" + Sent_Sec.ToString();
            label10.Text = "Доступно памяти:" + Memory_Available.ToString();
            label11.Text = "Свободной Памяти:" + Memory_Free.ToString();
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
