using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCrm.Core.Model;

namespace TcrmApi.Services
{
    public interface IExcelIO
    {
        List<Customer> ReadExcel(string filename);
    }
}
