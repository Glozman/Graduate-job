using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    //Класс хранения таблиц БД в виде списков
    class clsList
    {
        public static IList<NewItem> LstItem = new List<NewItem>();
        public static IList<clsWorker> WrkList = new List<clsWorker>();
        public static IList<clsJobs> JobList = new List<clsJobs>();
        public static IList<ReportCls> RepList = new List<ReportCls>();
        public static IList<string> Mounths = new List<string> {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
    }
}
