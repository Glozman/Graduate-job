using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace Diplom
{
    class ExcelGTP : MainDisplay
    {
        //Метод выгрузки элементов, исходя из их описания
        public void Elm(int i, Excel.Range range, ref int count)
        {
            int j = 0;
            count = 1;

            for (int dscr = 0; dscr < clsList.JobList.Count; dscr++)
            {
                for (i = 0; i < clsList.LstItem.Count;)
                {
                    if (clsList.LstItem[i].Job.JobName.Equals(clsList.JobList[dscr].JobName))
                    {
                        if (clsList.LstItem[i].MetroWorker.WorkerID.Equals(clsList.WrkList[j].WorkerID))
                        {
                            range.Cells[count, j + 1] = clsList.LstItem[i].Device;

                            for (int k = j + 2; k <= clsList.WrkList.Count - 1; k++)
                            {
                                range.Cells[count, k] = "-";
                            }
                            i++;
                            j = 0;
                            count++;
                        }
                        else
                        {
                            range.Cells[count, j + 1] = "-";
                            j++;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        //метод выгрузки описания работ
        public void descrip(Excel.Range range, object ObjMissing, Excel._Application arg2, Excel.Workbook arg3, Excel.Worksheet arg4)
        {
            int dscr;
            int count = 0;
            int rem_st = 0;
            int rem_en = 0;

            for (dscr = 0; dscr < clsList.JobList.Count; dscr++)
            {

                for (int i = 0; i < clsList.LstItem.Count;)
                {

                    if (clsList.LstItem[i].Job.JobName.Equals(clsList.JobList[dscr].JobName))
                    {
                        range.Cells[count + 1, 2] = clsList.JobList[dscr].JobName;
                        range.Cells[count + 1, 1] = clsList.JobList[dscr].pTP;
                        range.WrapText = true;
                        i++;
                        count++;
                    }
                    else
                        i++;
                }
            }

            int row = 5;
            //Определение идентичных описаний и их обьединение
            while (arg4.get_Range("B" + row).Value2 != null)
            {
                if (arg4.get_Range("B" + row).Value2 == arg4.get_Range("B" + (row + 1)).Value2)
                {
                    arg4.get_Range("B" + row).Value2 = "";
                    arg4.get_Range("A" + row).Value2 = "";
                    if (rem_st == 0)
                    {
                        rem_st = row;
                    }
                    row++;
                }
                else
                {
                    rem_en = row;
                    if (rem_st == 0)
                    {
                        rem_st = rem_en;
                    }

                    for (int j = 1; j <= 2; j++)
                    {
                        range = arg4.get_Range(ExcelCellTranslator(rem_st, j), ExcelCellTranslator(rem_en, j));
                        range.Select();
                        range.Merge();
                    }
                    rem_st = 0;
                    rem_en = 0;
                    row++;
                }
            }
        }
        //Метод создания шапки таблицы
        public void Header(ref int i, Excel.Range range, object ObjMissing, Excel._Application arg2, Excel.Workbook arg3, Excel.Worksheet arg4)
        {
            switch (i)
            {

                case 0:
                    range.Cells[1, 1] = "пТп";
                    range.HorizontalAlignment = Excel.Constants.xlCenter;
                    range.VerticalAlignment = Excel.Constants.xlCenter;
                    range.Orientation = Excel.XlOrientation.xlHorizontal;
                    range.Borders.Weight = 2;
                    break;
                case 1:
                    range.Columns[i].ColumnWidth = 25;
                    range.Cells[1, 1] = "Наименование работы";
                    range.HorizontalAlignment = Excel.Constants.xlCenter;
                    range.VerticalAlignment = Excel.Constants.xlCenter;
                    range.Orientation = Excel.XlOrientation.xlHorizontal;
                    range.Borders.Weight = 2;
                    break;
                case 2:
                    int j = 0;
                    int cols = 63;
                    for (int k = 3; k < cols; k++)
                    {
                        range = arg4.get_Range(ExcelCellTranslator(4, k), ExcelCellTranslator(4, k));
                        range.Columns[i - 1].ColumnWidth = 15;
                        range.Cells[1, 1] = clsList.WrkList[j].WorkerID;
                        range.Borders.Weight = 2;
                        range.HorizontalAlignment = Excel.Constants.xlCenter;
                        j++;
                        arg4.get_Range(ExcelCellTranslator(4, k), ExcelCellTranslator(4, k)).Interior.Color = Color.AliceBlue;
                        if (j == clsList.WrkList.Count - 1)
                            j = 0;
                    }
                    break;
            }
        }
        //метод создания переодичности работ и выгрузка месяцев
        public void Work(ref int i, Excel.Range range, object ObjMissing, Excel._Application arg2, Excel.Workbook arg3, Excel.Worksheet arg4)
        {
            switch (i)
            {
                case 0:
                    range = arg4.get_Range("A2", "B3");
                    range.Select();
                    range.Merge();
                    range.Cells[1, 1] = "1 раз в месяц";
                    range.HorizontalAlignment = Excel.Constants.xlCenter;
                    range.VerticalAlignment = Excel.Constants.xlCenter;
                    range.Orientation = Excel.XlOrientation.xlHorizontal;
                    range.Borders.Weight = 2;
                    arg4.get_Range("A2", "B3").Interior.Color = Color.Yellow;
                    break;
                case 1:
                    int j = 0;
                    int cols = 60;
                    for (int k = 3; k < cols; k = k + 5)
                    {
                        range = arg4.get_Range(ExcelCellTranslator(2, k), ExcelCellTranslator(3, k + 4));
                        range.Select();
                        range.Merge(Type.Missing);

                        range.Cells[1, 1] = clsList.Mounths[j];
                        j++;
                        range.HorizontalAlignment = Excel.Constants.xlCenter;
                        range.VerticalAlignment = Excel.Constants.xlCenter;
                        range.Orientation = Excel.XlOrientation.xlHorizontal;
                        range.Borders.Weight = 2;
                        arg4.get_Range(ExcelCellTranslator(2, k), ExcelCellTranslator(3, k + 4)).Interior.Color = Color.Yellow;
                    }
                    break;
            }
        }
        //основной метод
        public void excelCore(Excel._Application arg1, object arg2)
        {
            //Открытие формы полосы загрузки 
            Bar newForm = new Bar();
            newForm.Show();
            newForm.progressBar1.Maximum = 1;
            newForm.progressBar1.Maximum = 100;
            newForm.progressBar1.Value = 0;
            int count = 0;
            int flg = 0;

            try
            {
                //Создание Excel документа
                object ObjMissing = Missing.Value;
                Excel._Application ObjExel = new Excel.Application();
                Excel.Workbook ObjWorkBook = ObjExel.Workbooks.Add(Missing.Value);
                Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1];
                // ObjExel.Visible = true;
                int shift = 1;

                //Создание названия таблицы
                Excel.Range cells = ObjWorkSheet.get_Range("A1", "BJ1");
                cells.Select();
                cells.Merge();
                cells.Cells[1, 1] = "График технического процесса участка СПАРТАК 2019 год.";
                ObjWorkSheet.get_Range("A1", "BJ1").Interior.Color = Color.Yellow;
                cells.HorizontalAlignment = Excel.Constants.xlCenter;
                cells.VerticalAlignment = Excel.Constants.xlCenter;
                cells.Borders.Weight = 2;
                newForm.progressBar1.Value += 21;

                int clmns = 3;
                //Оформление шапки таблицы с последующим ее заполнением
                for (int i = 0; i < clmns; i++)
                {
                    cells = ObjWorkSheet.get_Range(ExcelCellTranslator(3 + shift, i + shift), ExcelCellTranslator(3 + shift, i + shift));
                    cells.Select();
                    cells.Merge();
                    Header(ref i, cells, ObjMissing, ObjExel, ObjWorkBook, ObjWorkSheet);
                    ObjWorkSheet.get_Range(ExcelCellTranslator(3 + shift, i + shift), ExcelCellTranslator(3 + shift, i + shift)).Interior.Color = Color.AliceBlue;
                    newForm.progressBar1.Value += 5;
                }

                for (int i = 0; i < clmns; i++)
                {

                    Work(ref i, cells, ObjMissing, ObjExel, ObjWorkBook, ObjWorkSheet);

                    newForm.progressBar1.Value += 5;
                }

                int mnth = 0;
                count = 0;

                //Оформление полей для выгрузки элементов с последующим ее заполнением
                for (int i = 0; i < clsList.Mounths.Count; i++)
                {
                    try
                    {
                        cells = ObjWorkSheet.get_Range(ExcelCellTranslator(5, 3 + mnth), ExcelCellTranslator(4 + clsList.LstItem.Count, 7 + mnth));
                        cells.Select();
                        cells.HorizontalAlignment = Excel.Constants.xlCenter;
                        cells.VerticalAlignment = Excel.Constants.xlCenter;
                        cells.Orientation = Excel.XlOrientation.xlHorizontal;
                        cells.Borders.Weight = 2;
                        Elm(i, cells, ref count);
                        newForm.progressBar1.Value += 4;
                        count++;
                    }
                    catch { }
                    count = 0;
                    mnth = mnth + 5;
                }
                count = 0;
                //Оформление полей для выгрузки наименований работ с последующим ее заполнением
                try
                {
                    cells = ObjWorkSheet.get_Range(ExcelCellTranslator(5, 1), ExcelCellTranslator(5 + clsList.LstItem.Count - 1, 2));
                    cells.Select();
                    cells.HorizontalAlignment = Excel.Constants.xlCenter;
                    cells.VerticalAlignment = Excel.Constants.xlCenter;
                    cells.Orientation = Excel.XlOrientation.xlHorizontal;
                    cells.Borders.Weight = 2;
                    descrip(cells, ObjMissing, ObjExel, ObjWorkBook, ObjWorkSheet);
                    newForm.progressBar1.Value += 1;

                }
                catch { }

                //Закрытие полосы загрузки
                newForm.Close();
                //Появление информационного окна, с последующим набором действий
                DialogResult res = MessageBox.Show("Экспорт завершен. Нажмите ОК, чтобы сохранить и посмотреть файл.", "Экспорт в Excel", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                {
                    //Просмотр и сохрание документа
                  //  ObjExel.Visible = true;
                    string fileName = String.Empty;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FileName = "ГТП";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveFileDialog1.FileName;
                    }
                    else
                        return;
                    //сохраняем Workbook
                    ObjWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    saveFileDialog1.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка " + flg.ToString());
            }
        }
        //Метод перевода столбцов из буквенного в цифры
        public static string Alphabet(int Num)
        {
            string cell = "";
            switch (Num)
            {
                case 1:
                    cell = "A";
                    break;
                case 2:
                    cell = "B";
                    break;
                case 3:
                    cell = "C";
                    break;
                case 4:
                    cell = "D";
                    break;
                case 5:
                    cell = "E";
                    break;
                case 6:
                    cell = "F";
                    break;
                case 7:
                    cell = "G";
                    break;
                case 8:
                    cell = "H";
                    break;
                case 9:
                    cell = "I";
                    break;
                case 10:
                    cell = "J";
                    break;
                case 11:
                    cell = "K";
                    break;
                case 12:
                    cell = "L";
                    break;
                case 13:
                    cell = "M";
                    break;
                case 14:
                    cell = "N";
                    break;
                case 15:
                    cell = "O";
                    break;
                case 16:
                    cell = "P";
                    break;
                case 17:
                    cell = "Q";
                    break;
                case 18:
                    cell = "R";
                    break;
                case 19:
                    cell = "S";
                    break;
                case 20:
                    cell = "T";
                    break;
                case 21:
                    cell = "U";
                    break;
                case 22:
                    cell = "V";
                    break;
                case 23:
                    cell = "W";
                    break;
                case 24:
                    cell = "X";
                    break;
                case 25:
                    cell = "Y";
                    break;
                case 26:
                    cell = "Z";
                    break;
                case 27:
                    cell = "AA";
                    break;
                case 28:
                    cell = "AB";
                    break;
                case 29:
                    cell = "AC";
                    break;
                case 30:
                    cell = "AD";
                    break;
                case 31:
                    cell = "AE";
                    break;
                case 32:
                    cell = "AF";
                    break;
                case 33:
                    cell = "AG";
                    break;
                case 34:
                    cell = "AH";
                    break;
                case 35:
                    cell = "AI";
                    break;
                case 36:
                    cell = "AJ";
                    break;
                case 37:
                    cell = "AK";
                    break;
                case 38:
                    cell = "AL";
                    break;
                case 39:
                    cell = "AM";
                    break;
                case 40:
                    cell = "AN";
                    break;
                case 41:
                    cell = "AO";
                    break;
                case 42:
                    cell = "AP";
                    break;
                case 43:
                    cell = "AQ";
                    break;
                case 44:
                    cell = "AR";
                    break;
                case 45:
                    cell = "AS";
                    break;
                case 46:
                    cell = "AT";
                    break;
                case 47:
                    cell = "AU";
                    break;
                case 48:
                    cell = "AV";
                    break;
                case 49:
                    cell = "AW";
                    break;
                case 50:
                    cell = "AX";
                    break;
                case 51:
                    cell = "AY";
                    break;
                case 52:
                    cell = "AZ";
                    break;
                case 53:
                    cell = "BA";
                    break;
                case 54:
                    cell = "BB";
                    break;
                case 55:
                    cell = "BC";
                    break;
                case 56:
                    cell = "BD";
                    break;
                case 57:
                    cell = "BE";
                    break;
                case 58:
                    cell = "BF";
                    break;
                case 59:
                    cell = "BG";
                    break;
                case 60:
                    cell = "BH";
                    break;
                case 61:
                    cell = "BI";
                    break;
                case 62:
                    cell = "BJ";
                    break;
            }
            return cell;
        }

        public static string ExcelCellTranslator(int i, int j)
        {
            string cell = "";
            int x;
            int lose;

            x = j;
            if (x < 16384)
            {
                lose = (x - 1) / 676;
                if (lose > 0)
                {
                    cell += Alphabet(lose);
                    x = x - (26 * lose);
                }
                cell += Alphabet(x);
            }
            else
            {
                cell += "XFD";
            }
            cell += i.ToString();
            return cell;
        }

    }
}

