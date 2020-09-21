using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace Diplom
{
    class ExcelChecking
    {
        //Метод создания наименования таблицы
        public void Header(int j, Excel.Range range)
        {
            switch (j)
            {
                case 0:
                    range.Cells[1, 1] = "ПЛАН-ГРАФИК";
                    break;
                case 1:
                    range.Cells[1, 1] = "Выполнения технологического процесса на Ноябрь 2018г.";
                    break;
                case 2:
                    range.Cells[1, 1] = "Участок Спартак";
                    break;
            }
        }
        //Метод создания шапки таблицы
        public void Descrip(int j, Excel.Range range, object ObjMissing, Excel._Application arg2, Excel.Workbook arg3, Excel.Worksheet arg4)
        {
            switch (j)
            {
                case 0:
                    range.UnMerge();
                    range.Cells[1, 1] = "Дата";
                    range.Cells[2, 1] = "План";
                    range.ColumnWidth = 20;
                    break;
                case 1:
                    range.UnMerge();
                    range.Cells[2, 1] = "Факт.";
                    range.ColumnWidth = 20;
                    Excel.Range cells = arg4.get_Range(ExcelGTP.ExcelCellTranslator(4, 1), ExcelGTP.ExcelCellTranslator(4, 2));
                    cells.Select();
                    cells.Merge();
                    cells.Borders.Weight = 2;

                    break;
                case 2:
                    range.Cells[1, 1] = "ПтП";
                    break;
                case 3:
                    range.Cells[1, 1] = "Устройства (стативы, рц, стрелки, ПЯ, ДТМ, и т.д.), станция";
                    range.WrapText = true;
                    range.ColumnWidth = 25;
                    break;
                case 4:
                    range.Cells[1, 1] = "Фамилия исполнителя";
                    range.WrapText = true;
                    range.ColumnWidth = 13;
                    break;
                case 5:
                    range.Cells[1, 1] = "Подпись";
                    break;
                case 6:
                    range.Cells[1, 1] = "Примечание";
                    range.ColumnWidth = 13;
                    break;
            }
        }
        //Метод выгрузки данных
        public void Data(int j, Excel.Range range)
        {
            switch (j)
            {
                case 0:
                    for (int k = 0; k < clsList.RepList.Count; k++)
                    {
                        range.Cells[k + 1, 1] = clsList.RepList[k].AllDates.PlanTime.ToLongDateString();
                        range.Cells[k + 1, 2] = clsList.RepList[k].AllDates.CheckTime.ToLongDateString();
                        range.Cells[k + 1, 3] = clsList.RepList[k].pTP.pTP;
                        range.Cells[k + 1, 4] = clsList.RepList[k].device.Device;
                        range.Cells[k + 1, 5] = clsList.RepList[k].FIO.FIO;
                        range.HorizontalAlignment = Excel.Constants.xlCenter;
                    }
                    break;
            }
        }
        //основной месяц
        public void excelCore(Excel._Application arg1, object arg2)
        {
            //Создание Excel документа
            object ObjMissing = Missing.Value;
            Excel._Application ObjExel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjExel.Workbooks.Add(Missing.Value);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1];
            // ObjExel.Visible = true;
            int rows = 3;
            int count = 1;

            //Оформление наименования таблицы с последующим ее заполнением
            for (int i = 0; i < rows; i++)
            {
                try
                {
                    {
                        Excel.Range cells = ObjWorkSheet.get_Range(ExcelGTP.ExcelCellTranslator(count, 1), ExcelGTP.ExcelCellTranslator(count, 7));
                        cells.Select();
                        cells.Merge();
                        Header(i, cells);
                        cells.HorizontalAlignment = Excel.Constants.xlCenter;
                        cells.VerticalAlignment = Excel.Constants.xlCenter;
                        cells.Orientation = Excel.XlOrientation.xlHorizontal;
                        ObjWorkSheet.get_Range(ExcelGTP.ExcelCellTranslator(count, 1), ExcelGTP.ExcelCellTranslator(count, 7)).Interior.Color = Color.Yellow;
                        count++;
                    }
                }
                catch { }

                count = 1;
                int cols = 7;
                //Оформление шапки таблицы с последующим ее заполнением
                for (i = 0; i < cols; i++)
                {
                    try
                    {
                        {
                            Excel.Range cells = ObjWorkSheet.get_Range(ExcelGTP.ExcelCellTranslator(4, count), ExcelGTP.ExcelCellTranslator(5, count));
                            cells.Select();
                            cells.Merge();
                            Descrip(i, cells, ObjMissing, ObjExel, ObjWorkBook, ObjWorkSheet);
                            cells.HorizontalAlignment = Excel.Constants.xlCenter;
                            cells.VerticalAlignment = Excel.Constants.xlCenter;
                            cells.Orientation = Excel.XlOrientation.xlHorizontal;
                            cells.Borders.Weight = 2;
                            ObjWorkSheet.get_Range(ExcelGTP.ExcelCellTranslator(4, count), ExcelGTP.ExcelCellTranslator(5, count)).Interior.Color = Color.GreenYellow;
                            count++;
                        }
                    }
                    catch { }
                }

                count = 0;
                //Оформление полей таблицы с последующим ее заполнением
                try
                {
                    Excel.Range cells = ObjWorkSheet.get_Range(ExcelGTP.ExcelCellTranslator(6, 1), ExcelGTP.ExcelCellTranslator(5 + clsList.RepList.Count, 7));
                    cells.Select();
                    cells.Borders.Weight = 2;
                    Data(count, cells);
                    cells.HorizontalAlignment = Excel.Constants.xlCenter;

                    count++;

                }
                catch { }

                //Появление информационного окна, с последующим набором действий
                DialogResult res = MessageBox.Show("Экспорт завершен. Нажмите ОК, чтобы сохранить файл.", "Экспорт в Excel", MessageBoxButtons.OKCancel);

                //Просмотр и сохранение документа
                if (res == DialogResult.OK)
                {
                //    ObjExel.Visible = true;
                    string fileName = String.Empty;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FileName = "План-График";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    if (res == DialogResult.Cancel)
                    {
                    }
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveFileDialog1.FileName;
                    }
                    else
                        return;
                    //сохраняем Workbook
                    ObjWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    saveFileDialog1.Dispose();
                }
            }
        }
    }
}

