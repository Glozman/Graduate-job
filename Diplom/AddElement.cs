using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    //Класс довления нового устройства
    public partial class AddElement : Form
    {
        //Создание переменных для присваиваивания ссылочных объектов
        ComboBox workerbox;
        public AddElement(ref ComboBox lst)
        {
            InitializeComponent();
            workerbox = lst;
            jobscol.SelectedIndex = -1;
            btnadd.Enabled = false;

            //Заполнение элемента графичекого интерфейса видами работ
            foreach (clsJobs job in clsList.JobList)
                jobscol.Items.Add(job.pTP + " - " + job.JobName);
        }

        //Кнопка добавления нового устройства
        private void btnadd_Click(object sender, EventArgs e)
        {
            bool flg = true;
            foreach (NewItem tmpitem in clsList.LstItem)
            {
                //Условие проверк уникальности нового устройства в списке утройств
                if ((newdev.Text.Equals(tmpitem.Device)) && (clsList.JobList[jobscol.SelectedIndex].pTP.Equals(tmpitem.Job.pTP)))
                {
                    MessageBox.Show("Такой элемент уже существует. Измените вид работ или название устройства.");
                    flg = false;
                    break;
                }
            }
            if (flg)
            {
                addel();
                Close();
            }
        }

        //Созлание соединения с БД
        public static string dlmconnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Diplom2.mdb";
        private OleDbConnection myConnection;

        //Метод добавления устройства в список устройств и таблицу DevList БД
        public void addel()
        {
            if ((newdev != null) && (jobscol.SelectedIndex > -1))
            {
                //Создание нужных объектов
                NewItem item = new NewItem();
                clsJobs j = new clsJobs();
                clsWorker w = new clsWorker();

                //Присваивание выбранных значений объектам
                item.Code = clsList.LstItem.Count + 1;
                item.Device = newdev.Text;
                j.JobName = clsList.JobList[jobscol.SelectedIndex].JobName;
                j.pTP = clsList.JobList[jobscol.SelectedIndex].pTP;
                j.JobPeriod = clsList.JobList[jobscol.SelectedIndex].JobPeriod;
                w.WorkerID = workerbox.SelectedItem.ToString();
                foreach (clsWorker wr in clsList.WrkList)
                {
                    if (w.WorkerID.Equals(wr.WorkerID))
                    {
                        w.FIO = wr.FIO;
                        break;
                    }
                }
                item.MetroWorker = w;
                item.Job = j;

                //Добавление созданного устройства в список
                clsList.LstItem.Add(item);
                
                //Добавление устройства в таблицу DevLIst БД
                myConnection = new OleDbConnection(dlmconnection); // открываем соединение с БД
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("INSERT INTO DevList (Код, Устройство, Вид_работы, Ответственный) VALUES('" + item.Code + "', '" + item.Device +"', '"+ item.Job.pTP +"', '"+ item.MetroWorker.WorkerID +"');", myConnection);
                command.ExecuteNonQuery();

                myConnection.Close();
            }
            else
                btnadd.Enabled = false;
        }

        private void selectjob(object sender, EventArgs e)
        {
            //Условие доступности кнопки добавления устройства
            if ((newdev != null) && (jobscol.SelectedIndex > -1))
                btnadd.Enabled = true;
        }
    }
}
