using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TcrmApi.Services;
using TinyCrm.Core;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;

namespace TcrmApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class TinyCrmController : ControllerBase
    {
       
        private readonly ICustomerService _custService ;
        private readonly IProductService _prodServ;
        private readonly IExcelIO _excelIO;
        private readonly ILogger<TinyCrmController> _logger;

        public TinyCrmController(ILogger<TinyCrmController> logger 
            ,ICustomerService custService, IProductService prodServ,
            IExcelIO excelIO
            )
        {
            _logger = logger;
           _custService = custService;
           _prodServ = prodServ;
            _excelIO = excelIO;
        }

        [HttpGet]
        public String GetInfo()
        {
            return "TinyCrmApi";
        }


        [HttpGet("customers")]
        public List<Customer> GetCustomers()
        {
            return _custService.GetCustomers(20).Data;
        }


        [HttpGet("customer/{id}")]
        public  Customer  GetCustomer(int id)
        {
            return _custService.GetCustomerById(id).Data;
        }

        [HttpPost("customer")]
        public Customer CreateCustomer(
            [FromBody] CreateCustomerOptions options)
        {
            return _custService.Create(options).Data;
        }

        [HttpPut("customer/{id}")]
        public Customer UpdateCustomer([FromRoute] int id,
            [FromBody] CreateCustomerOptions options)
        {
            return _custService.Update(id, options).Data;
        }

        [HttpGet("customer")]
        public List<Customer> getCustomerby(
             [FromQuery] int id,
            [FromQuery] string vat, [FromQuery]string email, [FromQuery] string name)
        {
            SearchCustomerOptions options = new SearchCustomerOptions
            {
                Email = email,
                FistName = name,
                VatNumber = vat,
                Id = id
            };
            return _custService.Search(options).Data.ToList();
        }


        [HttpPost("customer/search")]
        public List<Customer> getCustomerby2(
            [FromBody] SearchCustomerOptions options)
        {

            return _custService.Search(options).Data.ToList();
        }


        /////////////////////////////////
        ///Product controller
        ///

        [HttpPost("product")]
        public Product AddProduct(AddProductOptions options)
        {
            return _prodServ.AddProduct( options).Data;
        }

        [HttpPut("product/{productId}")]
        public bool UpdateProduct(Guid productId, UpdateProductOptions options)
        {
            return _prodServ.UpdateProduct(productId, options);
        }

         [HttpGet("product/{productId}")]
        public Product GetProductById(Guid productId )
        {
            return _prodServ.GetProductById(productId ).Data;
        }

        [HttpGet("productStock")]
        public int SumOfStocks( )
        {
            return _prodServ.SumOfStocks();
        }

        [HttpPost("SearchProduct")]
        public List<Product> SearchProduct(SearchProductOptions options)
        {
            return _prodServ.SearchProduct(options).ToList();
        }


        [HttpGet("customers/excel/{filename}")]
        public List<Customer> GetCustomersFromExcel([FromRoute] string filename)
        {
  
            return _excelIO.ReadExcel(filename);
        }


        


    }
}
