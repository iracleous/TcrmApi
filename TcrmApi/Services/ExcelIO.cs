using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TinyCrm.Core.Model;

namespace TcrmApi.Services
{
    public class ExcelIO: IExcelIO
    {
        public List<Customer> ReadExcel(string filename)
        {
            XSSFWorkbook hssfwb;
            try {
            using (FileStream file = new FileStream(filename, 
                FileMode.Open, FileAccess.Read)) { 
                hssfwb = new XSSFWorkbook(file); }
            ISheet sheet = hssfwb.GetSheet("Customer");
            List<Customer> customers = new List<Customer>();
            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) 
                    //null is when the row only contains empty cells               
                {
                    Customer c = new Customer {
                     FirstName= sheet.GetRow(row).GetCell(0).StringCellValue,
                     Email =  sheet.GetRow(row).GetCell(2).StringCellValue
                 };

                    customers.Add(c);
                }         
            }
             return customers;
 }catch(Exception e)
            {
                return null;
            }

        }


    }
}
