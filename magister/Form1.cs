using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace magister
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        private Thread IP_Received_Thread;
        private Thread IP_Sent_Thread;
        private double[] IP_Received_Array = new double[100];
        private double[] IP_Sent_Array = new double[100];

        private void getPerfomanceCounter()
        {
            var IP_Received = new PerformanceCounter("IPv4", "Datagrams Received/sec");
            var IP_Sent = new PerformanceCounter("IPv4", "Datagrams Sent/sec");

            while (true)
            {
                IP_Received_Array[IP_Received_Array.Length - 1] = Math.Round(IP_Received.NextValue(), 0);
                IP_Sent_Array[IP_Sent_Array.Length - 1] = Math.Round(IP_Sent.NextValue(), 0);

                Array.Copy(IP_Received_Array, 1, IP_Received_Array, 0, IP_Received_Array.Length - 1);
                Array.Copy(IP_Sent_Array, 1, IP_Sent_Array, 0, IP_Sent_Array.Length - 1);

                if (this.IP_Received.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateChart(); });
                }
                if (this.IP_Sent.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { IP_SentChart(); });
                }

                Thread.Sleep(1000);
            }
        }

        private void UpdateChart() {
            IP_Received.Series["Series1"].Points.Clear();
            for (int i = 0; i < IP_Received_Array.Length - 1; ++i){
                IP_Received.Series["Series1"].Points.Add(IP_Received_Array[i]);
            }
        }
        private void IP_SentChart()
        {
            IP_Sent.Series["Series1"].Points.Clear();
            for (int i = 0; i < IP_Sent_Array.Length - 1; ++i)
            {
                IP_Sent.Series["Series1"].Points.Add(IP_Sent_Array[i]);
            }
        }

        public Form1() // действия на загрузку формы
        {
            InitializeComponent();
            IP_Received_Thread = new Thread(new ThreadStart(this.getPerfomanceCounter));
            IP_Received_Thread.IsBackground = true;           
            IP_Sent_Thread = new Thread(new ThreadStart(this.getPerfomanceCounter));
            IP_Sent_Thread.IsBackground = true;

            IP_Sent_Thread.Start();
            IP_Received_Thread.Start();
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
            label2.Text = "Загрузка ЦП: " +proc.ToString() + "%";
            var memory_free = (Memory_Available * 100) / GetTotalMemoryInBytes();
            var memory_use = 100 - Math.Round(memory_free, 0);

            metroProgressBar1.Value = proc;
            metroProgressBar2.Value = (int)memory_use;
            label3.Text = "Отброшенные пакеты:" + Outbound_Discarded.ToString();
            label4.Text = "Пакеты которые не нашли маршрут:" + Outbound_No_Route.ToString();
            label5.Text = "Пакеты которые не отправленны из-за недопустимых ip адресов:" + Received_Address_Errors.ToString();
            label6.Text = "Пакеты отброшенные из-за ошибок в заголовках ip:" + Received_Header_Errors.ToString();
            label7.Text = "Пакеты обработанные,но отброшенные из-за неизвестного протокола:" + Received_Unknown_Protocol.ToString();
            label8.Text = "Скорость с которой пакеты поступают:" + Received_Sec.ToString();
            label9.Text = "Скорость с которой пакеты отправляются:" + Sent_Sec.ToString();
            label10.Text = "Доступно памяти:" + Memory_Available.ToString();
            label11.Text = "Свободной Памяти:" + Memory_Free.ToString();
            label12.Text = "Текущий IP адрес: "+GetIP();
            label13.Text = "Версия ОС: "+GetWinName()+GetOSBit() +" Сборка " + Environment.OSVersion.Version.ToString();
            label14.Text = "Имя компьютера: "+GetName() ;
            label15.Text = "Количество ядер: " + System.Environment.ProcessorCount;
            label16.Text = "Всего памяти: "+ GetTotalMemoryInBytes();

            label17.Text ="Используется памяти " + memory_use.ToString() + "%";
        }

        static string GetWinName()
        {
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (regKey != null)
                {
                    try
                    {
                        string name = regKey.GetValue("ProductName").ToString();
                        if (name == "") return "значение отсутствует";
                        if (name.Contains("XP"))
                            return "XP";
                        else if (name.Contains("7"))
                            return "Windows 7";
                        else if (name.Contains("8"))
                            return "Windows 8";
                        else
                            return "неизвестная версия Windows";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                    return "Не удалось получить значение ключа в реестре";
            }
        }
        static  string GetOSBit()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return " x64";
            }
            else
            {
                return " x32";
            }
        }
        static string GetIP() {
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0];
            return ip.ToString();
        }
        static string GetName() {
            String host = System.Net.Dns.GetHostName();
            return host.ToString();
        }

        public static string GetWorkGroup()
        {
            return "0";
        }
        static float GetTotalMemoryInBytes()
        {
            var kb = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            var mb = kb / (1024 * 1024);
            return mb ;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
