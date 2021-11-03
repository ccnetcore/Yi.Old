using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Yi.Framework.Common.Helper
{
    public class ExcelHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList">数据</param>
        /// <param name="headers">表头</param>
        /// <returns></returns>
        public static string CreateExcelFromList<T>(List<T> dataList, List<string> headers,string evn)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string sWebRootFolder = Path.Combine($"{evn}", "wwwroot/Excel");//如果用浏览器url下载的方式  存放excel的文件夹一定要建在网站首页的同级目录下！！！
            if (!Directory.Exists(sWebRootFolder))
            {
                Directory.CreateDirectory(sWebRootFolder);
            }
            string sFileName = $@"Excel_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            var path = Path.Combine(sWebRootFolder, sFileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(path);
            }
            using (ExcelPackage package = new(file))
            {
                //创建sheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("sheet1");
                worksheet.Cells.LoadFromCollection(dataList, true);
                //表头字段
                for (int i = 0; i < headers.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }
                for (int i = 0; i < headers.Count + 1; i++)
                {//删除不需要的列
                    string aa = worksheet.Cells[1, i + 1].Value.ToString();
                    if (aa == "总行数")
                    {
                        worksheet.DeleteColumn(i + 1);
                    }
                }
                package.Save();
            }
            //return path;//这是返回文件的方式
            return sFileName;    //如果用浏览器url下载的方式  这里直接返回生成的文件名就可以了
        }
    }
}
