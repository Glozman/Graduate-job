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
    //Класс отображения таблицы DevList БД
    public partial class AllDevices : Form
    {
        public AllDevices()
        {
            InitializeComponent();
        }

        private void DeleteDeviceForm_Load(object sender, EventArgs e)
        {
            foreach (NewItem it in clsList.LstItem)
                DeleteTable.Rows.Add(it.Code, it.Device, it.Job.pTP, it.MetroWorker.WorkerID);
        }
    }
}
