using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace IRAP.Client.GUI.BatchSystem
{
    public class ExcelHelper : IDisposable
    {
        private string fileName = null;             // 文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return "";
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    short format = cell.CellStyle.DataFormat;
                    switch (format)
                    {
                        case 14:
                        case 178:
                        case 179:
                            return cell.DateCellValue;
                        default:
                            return cell.NumericCellValue;
                    }
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Formula:
                default:
                    return "=" + cell.CellFormula;
            }
        }

        /// <summary>
        /// 将 DataTable 数据导入到 Excel 中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="sheetName">Excel 文件工作表的名称</param>
        /// <param name="isColumnWritten">是否导入 DatatTable 的列名</param>
        /// <returns>导入的数据行数（包括列名)</returns>
        public int DataTableToExcel(
            DataTable data,
            string sheetName,
            bool isColumnWritten)
        {
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            if (fileName.ToLower().IndexOf(".xlsx") > 0)
                workbook = new XSSFWorkbook();
            else if (fileName.ToLower().IndexOf(".xls") > 0)
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                    sheet = workbook.CreateSheet(sheetName);
                else
                    throw new Exception("无法根据文件的扩展名区别 Excel 的版本，创建 Excel 工作簿失败");

                // 写入 DataTable 的
                if (isColumnWritten)
                {
                    IRow row = sheet.CreateRow(0);
                    for (int j = 0; j < data.Columns.Count; j++)
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    count = 1;
                }
                else
                    count = 0;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(count);
                    for (int j = 0; j < data.Columns.Count; j++)
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    count++;
                }

                workbook.Write(fs);     // 写入到 Excel
                return count;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 将 Excel 中的数据导入到 DataTable 中
        /// </summary>
        /// <param name="sheetName">工作表名称</param>
        /// <param name="isFirstRowColumn">第一行是否是标题列</param>
        /// <returns>返回的 DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.ToLower().IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.ToLower().IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook == null)
                    throw new Exception("无法根据文件的扩展名区别 Excel 的版本，创建 Excel 工作簿失败");

                if (sheetName != "")
                {
                    sheet = workbook.GetSheet(sheetName);
                }
                else
                    sheet = workbook.GetSheetAt(0);

                if (sheet == null)
                {
                    if (sheetName == "")
                        throw new Exception(
                            string.Format(
                                "文件 [{0}] 中没有任何工作表",
                                fileName));
                    else
                        throw new Exception(
                            string.Format(
                                "文件 [{0}] 中没有找到名为 [{1}] 的工作表",
                                fileName,
                                sheetName));
                }

                IRow firstRow = sheet.GetRow(0);
                int cellCount = firstRow.LastCellNum;       // 一行最后一个 Cell 的编号，就是总的列数

                if (isFirstRowColumn)
                {
                    for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                    {
                        ICell cell = firstRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }
                    startRow = sheet.FirstRowNum + 1;
                }
                else
                    startRow = sheet.FirstRowNum;

                // 最后一行的标号
                int rowCount = sheet.LastRowNum;
                for (int i = startRow; i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)                        // 没有数据的行默认是 null
                        continue;

                    DataRow dataRow = data.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                        if (row.GetCell(j) != null)
                            dataRow[j] = GetValueType(row.GetCell(j)).ToString();
                    data.Rows.Add(dataRow);
                }

                return data;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取 Excel 中的工作表名列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetExcelSheetNames()
        {
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.ToLower().IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.ToLower().IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);
                if (workbook == null)
                    throw new Exception("无法根据文件的扩展名区别 Excel 的版本，创建 Excel 工作簿失败");

                List<string> sheetNames = new List<string>();
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                    sheetNames.Add(workbook.GetSheetName(i));

                return sheetNames;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && fs != null)
                    fs.Close();

                fs = null;
                disposed = true;
            }
        }
    }
}
