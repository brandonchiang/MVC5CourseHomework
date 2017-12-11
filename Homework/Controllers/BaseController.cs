using ClosedXML.Excel;
using Homework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class BaseController:Controller
    {
        protected 客戶資料Repository repo客戶資料 = RepositoryHelper.Get客戶資料Repository();

        protected 客戶銀行資訊Repository repo客戶銀行資訊 = RepositoryHelper.Get客戶銀行資訊Repository();

        protected 客戶聯絡人Repository repo客戶聯絡人 = RepositoryHelper.Get客戶聯絡人Repository();

        protected FileResult Export(DataTable dt,string fileName)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(dt, fileName);
            var outputfile = Server.MapPath($"~/App_Data/{fileName}.xlsx");
            workbook.SaveAs(outputfile);
            return File(outputfile, "application/vnd.ms-excel", $"{fileName}.xlsx");
        }

        public DataTable ToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        protected override void HandleUnknownAction(string actionName)
        {
            //base.HandleUnknownAction(actionName);
            this.Redirect("/").ExecuteResult(this.ControllerContext);
        }
    }
}