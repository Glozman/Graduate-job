using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Diplom
{
    //Главный класс, в котором пользователь начинает работу, инициализируется и реализует нужные ему действия
    public partial class MainDisplay : Form
    {
        
        public MainDisplay()
        {
            InitializeComponent();
            listdev.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            JobsBox.Visible = false;
            WorkerBox.Visible = false;
            mounths.Visible = false;
            AddToolStrip.Enabled = false;
            CreateToolStrip.Enabled = false;
            DeleteToolStrip.Enabled = false;
            adddevbtn.Visible = false;
            deletebtn.Visible = false;
        }

        //Создание соединения с БД
        public static string dlmconnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Diplom2.mdb";
        private OleDbConnection myConnection;

        private void MainDisplay_Load(object sender, EventArgs e)
        {
            JobsBox.SelectedIndex = -1;
            listdev.SelectedIndex = -1;
            WorkerBox.SelectedIndex = -1;
            mounths.SelectedIndex = -1;
        }

        //Метод загрузки всей БД в С#
        public void initlist()
        {
            clsList.LstItem.Clear();
            clsList.WrkList.Clear();
            clsList.JobList.Clear();
            bool flgDetect;
            int tmpInx;

            //Команда загрузки таблицы WorkersTab БД
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM WorkersTab;", myConnection);
            DataTable TabWorkers = new DataTable();
            DataTable TabItems = new DataTable();
            adapter.Fill(TabWorkers);

            //Цикл заполнения списка, соответствуюзего таблице WorkersTab БД, данными из таблицы
            for (int i = 0; i < TabWorkers.Rows.Count; i++)
            {
                clsWorker worker = new clsWorker();
                
                worker.WorkerID = TabWorkers.Rows[i][0].ToString();
                worker.FIO = TabWorkers.Rows[i][1].ToString();
                
                clsList.WrkList.Add(worker);
            }

            //Команда загрузки таблицы JobPeriod БД
            adapter.SelectCommand = new OleDbCommand("SELECT * FROM JobPeriod;", myConnection);
            DataTable TabPer = new DataTable();
            List<clsDateTime> timeper = new List<clsDateTime>();
            adapter.Fill(TabPer);

            //Цикл заполнения списка, соответствуюзего таблице JobPeriod БД, данными из таблицы
            for (int i = 0; i < TabPer.Rows.Count; i++)
            {
                clsDateTime period = new clsDateTime();
                period.DatePeriod = TabPer.Rows[i][0].ToString();
                timeper.Add(period);
            }

            //Команда загрузки таблицы JobList БД
            adapter.SelectCommand = new OleDbCommand("SELECT * FROM JobList;", myConnection);
            DataTable TabJobs = new DataTable();
            adapter.Fill(TabJobs);

            //Цикл заполнения списка, соответствуюзего таблице JobList БД, данными из таблицы
            for (int i = 0; i < TabJobs.Rows.Count; i++)
            {
                clsJobs job = new clsJobs();
                clsDateTime date = new clsDateTime();
                int j = 0;

                job.pTP = TabJobs.Rows[i][0].ToString();
                job.JobName = TabJobs.Rows[i][1].ToString();
               
                foreach (clsDateTime d in timeper)
                {
                    if (TabJobs.Rows[i][2].Equals(d.DatePeriod))
                    {
                        j++;
                        break;
                    }
                }
                job.JobPeriod = timeper[j];
                clsList.JobList.Add(job);
            }

            //Команда загрузки таблицы DevList БД
            adapter.SelectCommand = new OleDbCommand("SELECT * FROM DevList;", myConnection);
            adapter.Fill(TabItems);

            //Цикл заполнения списка, соответствуюзего таблице DevList БД, данными из таблицы
            for (int i = 0; i < TabItems.Rows.Count; i++)
            {
                NewItem Item = new NewItem();

                Item.Code = Convert.ToInt32(TabItems.Rows[i][0].ToString());

                flgDetect = false;
                tmpInx = 0;
                for (int j = 0; j < clsList.WrkList.Count; j++)
                {
                    if (TabItems.Rows[i][3].Equals(clsList.WrkList[j].WorkerID))
                    {
                        flgDetect = true;
                        tmpInx = j;
                        break;
                    }
                }

                if (flgDetect)
                {
                    Item.MetroWorker = clsList.WrkList[tmpInx];
                    flgDetect = false;
                }
                else
                    Item.MetroWorker = null;

                for (int j = 0; j < clsList.JobList.Count; j++)
                {
                    if (TabItems.Rows[i][2].Equals(clsList.JobList[j].pTP))
                    {
                        flgDetect = true;
                        tmpInx = j;
                        break;
                    }
                }

                if (flgDetect)
                {
                    Item.Job = clsList.JobList[tmpInx];
                }
                else
                    Item.Job = null;

                Item.Device = TabItems.Rows[i][1].ToString();
                clsList.LstItem.Add(Item);
            }

            //Команда загрузки таблицы Report БД
            adapter.SelectCommand = new OleDbCommand("SELECT * FROM Report;", myConnection);
            DataTable TabRep = new DataTable();
            adapter.Fill(TabRep);

            //Цикл заполнения списка, соответствуюзего таблице Report БД, данными из таблицы
            for (int i = 0; i < TabRep.Rows.Count; i++)
            {
                NewItem item = new NewItem();
                clsJobs job = new clsJobs();
                clsWorker worker = new clsWorker();
                clsDateTime time = new clsDateTime();
                ReportCls report = new ReportCls();

                    report.Code = Convert.ToInt32(TabRep.Rows[i][0].ToString());
                try
                {
                    time.PlanTime = Convert.ToDateTime(TabRep.Rows[i][1].ToString());
                    time.CheckTime = Convert.ToDateTime(TabRep.Rows[i][2].ToString());
                }
                catch { }
                    job.pTP = TabRep.Rows[i][3].ToString();
                    item.Device = TabRep.Rows[i][4].ToString();
                    worker.FIO = TabRep.Rows[i][5].ToString();

                report.AllDates = time;
                report.pTP = job;
                report.device = item;
                report.FIO = worker;

                clsList.RepList.Add(report);
            }
        }

        //Метод перехода в окно CheckingForm при выборе устройства
        private void listdevSelect(object sender, EventArgs e)
        {
            CheckingForm ChForm = new CheckingForm(ref listdev, ref WorkerBox, ref JobsBox);
            ChForm.Text = listdev.SelectedItem.ToString();
            ChForm.Owner = this;
            ChForm.Show();
        }

        //Заполнение listdev данными из LstItem при выборе ID работника
        private void WorkerSelect(object sender, EventArgs e)
        {
            selectdev();

            if (WorkerBox.SelectedIndex > -1)
            {
                label4.Visible = true;
                mounths.Visible = true;
            }
        }

        //Заполнение listdev данными из LstItem при выборе вида работ
        private void JobsSelect(object sender, EventArgs e)
        {
            selectdev();
        }

        //Метод заполнения listdev
        public void selectdev()
        {
            listdev.Items.Clear();

            //Условие заполнения listdev, только если выбрана работа
            if (JobsBox.SelectedIndex > -1)
            {
                listdev.Visible = true;
                listdev.Items.Clear();
                adddevbtn.Visible = true;
                deletebtn.Visible = true;

                foreach (NewItem item in clsList.LstItem)
                {
                    try
                    {
                        //Условие вывода данных в listdev
                        if ((WorkerBox.SelectedItem.ToString() == item.MetroWorker.WorkerID) && (JobsBox.SelectedItem.ToString() == item.Job.JobName))
                        {
                            listdev.Items.Add(item.Device);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("В строке " + item.Code + " отсутствует значение одного из столбцов. Проверьте Ваши данные в таблице DevList.");
                    }
                }   
            }
        }

        private void mounthselect(object sender, EventArgs e)
        {
            if (mounths.SelectedIndex > -1)
            {
                label1.Visible = true;
                JobsBox.Visible = true;
                AddToolStrip.Enabled = true;
            }
        }

        //Метод нажания на кнопку начала работы
        public void StartStrip_Click(object sender, EventArgs e)
        {
            WorkerBox.Items.Clear();
            listdev.Items.Clear();
            mounths.Items.Clear();
            JobsBox.Items.Clear();

            myConnection = new OleDbConnection(dlmconnection); // открываем соединение с БД
            myConnection.Open();

            initlist();

            label3.Visible = true;
            WorkerBox.Visible = true;

            //Заполнение данными элементов граффического интерфейса
            foreach (clsWorker worker in clsList.WrkList)
                WorkerBox.Items.Add(worker.WorkerID);
            foreach (clsJobs job in clsList.JobList)
                JobsBox.Items.Add(job.JobName);
            foreach (string s in clsList.Mounths)
                mounths.Items.Add(s);

            myConnection.Close();

            CreateToolStrip.Enabled = true;
            DeleteToolStrip.Enabled = true;
            StartStrip.Enabled = false;
        }

        //Метод открытия ГТП
        private void CreateGTPStrip_Click(object sender, EventArgs e)
        {
            object ObjMissing = Missing.Value;

            Excel._Application ObjExel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjExel.Workbooks.Add(Missing.Value);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1];
            ExcelGTP newexcel = new ExcelGTP();
            newexcel.excelCore(ObjExel, ObjMissing);
        }

        private void CloseStrip_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            DeleteDevForm devForm = new DeleteDevForm(ref listdev, ref WorkerBox, ref JobsBox);
            devForm.DeleteReport();
        }

        //Метод открытия таблицы DevList
        private void AllDevToolStrip_Click(object sender, EventArgs e)
        {
            AllDevices allDevices = new AllDevices();
            allDevices.Show();
        }
        //Метод открытия отчета о выполненной работе
        private void ReportStrip_Click(object sender, EventArgs e)
        {
            object ObjMissing = Missing.Value;

            Excel._Application ObjExel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjExel.Workbooks.Add(Missing.Value);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1];
            ExcelChecking excelCheck = new ExcelChecking();
            excelCheck.excelCore(ObjExel, ObjMissing);
        }

        //Метод открытия нового окна добавления нового устройства
        private void adddevbtn_Click(object sender, EventArgs e)
        {
            AddElement newelement = new AddElement(ref WorkerBox);
            newelement.Owner = this;
            newelement.Show();
        }

        //Метод открытия окна удаления устройства
        private void deletebtn_Click(object sender, EventArgs e)
        {
            DeleteDevForm deleteitem = new DeleteDevForm(ref listdev, ref WorkerBox, ref JobsBox);
            deleteitem.ShowDialog();
            selectdev();
        }
    }
}


