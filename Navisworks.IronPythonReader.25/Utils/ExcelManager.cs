using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Navisworks.IronPythonReader.Utils
{
    public class ExcelManager
    {
        public static DataTableCollection GetAllDataTables(string path)
        {
            return ReadDataSet(path).Tables;
        }

        public static DataTable GetDataTable(string path, string tableName)
        {

            DataTableCollection tables = ReadDataSet(path).Tables;

            foreach (DataTable table in tables)
            {
                if (table != null && table.TableName == tableName)
                {
                    return table;
                }
            }

            return null;
        }

        public static List<string> GetTableHeaders(string path, string tableName)
        {

            DataTableCollection tables = ReadDataSet(path).Tables;

            foreach (DataTable table in tables)
            {
                if (table != null && table.TableName == tableName)
                {
                    return table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
                }
            }

            return null;

        }

        private static DataSet ReadDataSet(string path)
        {
            ExcelDataTableConfiguration config = new ExcelDataTableConfiguration() { UseHeaderRow = true };

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (IExcelDataReader) => config,
                    });

                    return result;
                }
            }
        }
    }
}
