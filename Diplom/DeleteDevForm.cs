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
    //Класс удаления устройства из таблицы устройств
    public partial class DeleteDevForm : Form
    {
        //Создание переменных для присваиваивания ссылочных объектов
        ListBox ref_listdev;
        ComboBox ref_wrklist, ref_jobslist;
        public DeleteDevForm(ref ListBox tmp1, ref ComboBox tmp2, ref ComboBox tmp3)
        {
            ref_listdev = tmp1;
            ref_wrklist = tmp2;
            ref_jobslist = tmp3;
            InitializeComponent();
        }

        //Создание соединения с БД
        public static string dlmconnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Diplom2.mdb";
        private OleDbConnection myConnection;

        private void DeleteDevForm_Load(object sender, EventArgs e)
        {
            //Заполнение Combobox из списка устройств для выбранной работы
            for (int i = 0; i < ref_listdev.Items.Count; i++)
                DevicesBox.Items.Add(ref_listdev.Items[i]);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();       
        }

        //Метод удаления устройства из списка устройств
        private void deletebtn_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(dlmconnection); // открываем соединение с БД
            myConnection.Open();

            foreach (NewItem it in clsList.LstItem)
                //Условие проверки уникальности удаляемого устройства
                if (ref_wrklist.SelectedItem.Equals(it.MetroWorker.WorkerID) && ref_jobslist.SelectedItem.Equals(it.Job.JobName) && DevicesBox.SelectedItem.Equals(it.Device))
                {
                    //Удаление элемента из списка и из таблицы DevList БД
                    clsList.LstItem.RemoveAt(it.Code - 1);

                    OleDbCommand command = new OleDbCommand("DELETE FROM DevList WHERE Код = " + it.Code + ";", myConnection);
                    command.ExecuteNonQuery();

                    DevicesBox.Items.RemoveAt(DevicesBox.SelectedIndex);
                    DevicesBox.Text = null;

                    break;
                }

            if (clsList.LstItem[0].Code != 1)
            {
                clsList.LstItem[0].Code--;

                OleDbCommand command = new OleDbCommand("UPDATE DevList SET Код = " + clsList.LstItem[0].Code + " WHERE Код = " + (clsList.LstItem[0].Code + 1) + "; ", myConnection);
                command.ExecuteNonQuery();
            }
            //Цикл реиндексации
            for (int i = 0; i < clsList.LstItem.Count - 1; i++)
                if (clsList.LstItem[i + 1].Code - clsList.LstItem[i].Code > 1)
                {
                    clsList.LstItem[i + 1].Code--;

                    OleDbCommand command = new OleDbCommand("UPDATE DevList SET Код = " + clsList.LstItem[i + 1].Code + " WHERE Код = " + (clsList.LstItem[i + 1].Code + 1) + "; ", myConnection);
                    command.ExecuteNonQuery();
                }

            myConnection.Close();
        }

        public void DeleteReport()
        {
            if (clsList.RepList.Count != 0)
            {
                myConnection = new OleDbConnection(dlmconnection); // открываем соединение с БД
                myConnection.Open();

                int i = 0;
                do
                {
                    clsList.RepList.RemoveAt(0);

                    OleDbCommand command = new OleDbCommand("DELETE FROM Report WHERE Код = " + (i + 1) + ";", myConnection);
                    command.ExecuteNonQuery();

                    i++;
                }
                while (clsList.RepList.Count > 0);

                myConnection.Close();
            }
        }
    }
}
