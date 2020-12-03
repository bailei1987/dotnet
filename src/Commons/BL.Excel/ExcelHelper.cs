using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BL.Excel
{
    public static class ExcelHelper
    {
        public static void Init()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static List<Dictionary<string, object>> GetDatas(Stream stream)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                int row = 0;
                var columns = new List<string>();
                do
                {
                    while (reader.Read())
                    {
                        if (row == 0)
                        {
                            var fieldsCount = reader.FieldCount;
                            for (int i = 0; i < fieldsCount; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(reader.GetString(i))) columns.Add(reader.GetString(i));
                                else break;
                            }
                        }
                        else
                        {
                            if (reader.FieldCount == -1) continue;
                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            for (int i = 0; i < columns.Count; i++)
                            {
                                dic.Add(columns[i], reader.GetValue(i));
                            }
                            if (dic.Values.Any(x => x != null && !string.IsNullOrWhiteSpace(Convert.ToString(x)))) list.Add(dic);
                        }
                        row++;
                    }
                } while (reader.NextResult());

            }
            return list;
        }
    }
}
