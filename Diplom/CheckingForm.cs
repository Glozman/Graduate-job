using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;

namespace Diplom
{
    //Класс добавления записи в отчет о выполненных работах
    public partial class CheckingForm : Form
    {
        //Создание переменных для присваиваивания ссылочных объектов
        ListBox dubl_listdev;
        ComboBox workerCB;
        ComboBox jobbox;
        public CheckingForm(ref ListBox lst1, ref ComboBox lst2, ref ComboBox lst3)
        {
            dubl_listdev = lst1;
            workerCB = lst2;
            jobbox = lst3;
            InitializeComponent();
            checkJob.Visible = false;
        }

        //Метод выбора даты выполнения работы в календаре
        private void DateSelect(object sender, DateRangeEventArgs e)
        {
            checkJob.Visible = true;
            //Увеличпение значения месяца для отображения плановой даты выполнения следующей работы
            JobTime.SelectionStart = JobTime.SelectionStart.AddMonths(1);
        }

        //Создание соединения с БД
        public static string dlmconnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Diplom2.mdb";
        private OleDbConnection myConnection;

        //Метод нажатия на кнопку "Добавить в отчет"
        private void btnRepClick(object sender, EventArgs e)
        {
            //Условия срабатывания кнопки по CheckBox
            if (checkJob.Checked)
            {
                //Создание нужных объектов
                NewItem item = new NewItem();
                clsJobs job = new clsJobs();
                clsWorker worker = new clsWorker();
                clsDateTime time = new clsDateTime();
                //Создание объекта-строчки для финального отчета
                ReportCls report = new ReportCls();

                //Присваивание значение созданным объектам
                report.Code = clsList.RepList.Count + 1;
                time.PlanTime = JobTime.SelectionStart.Date;
                time.CheckTime = JobTime.SelectionStart.AddMonths(-1);
                foreach (clsJobs j in clsList.JobList)
                    if (jobbox.SelectedItem.Equals(j.JobName))
                    {
                        job.pTP = j.pTP;
                        break;
                    }
                item.Device = dubl_listdev.SelectedItem.ToString();
                foreach (clsWorker w in clsList.WrkList)
                    if (workerCB.SelectedItem.Equals(w.WorkerID))
                    {
                        worker.FIO = w.FIO;
                        break;
                    }

                report.AllDates = time;
                report.pTP = job;
                report.device = item;
                report.FIO = worker;

                //Добавление объекта в список / добавление записи в отчет
                clsList.RepList.Add(report);

                //Добавление строки в таблицу Report БД
                myConnection = new OleDbConnection(dlmconnection); // открываем соединение с БД
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("INSERT INTO Report (Код, План_дата, Факт_дата, пТП, Устройства, ФИО_исполн) VALUES('"+ report.Code +"', '" + report.AllDates.PlanTime.ToShortDateString() + "', '" + report.AllDates.CheckTime.ToShortDateString() + "', '" + report.pTP.pTP + "', '" + report.device.Device + "', '"+ report.FIO.FIO +"');", myConnection);
                command.ExecuteNonQuery();

                myConnection.Close();


                Close();
            }
            //Действие, если условие false
            else
            {
                MessageBox.Show("Поставьте подпись");
            }
        }

        //Метод отображения подсказки для прользователя после того как ChrckBox checked
        private void checkJob_CheckedChanged(object sender, EventArgs e)
        {
            if (checkJob.Checked)
                meslab.Text = "Дата следующей проверки " + JobTime.SelectionStart.ToShortDateString();
        }
    }

}
    


    



