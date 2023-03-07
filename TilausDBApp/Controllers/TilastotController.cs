using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TilausDBApp.Models;
using TilausDBApp.ViewModels;

namespace TilausDBApp.Controllers
{
    public class TilastotController : Controller
    {
        // GET: Tilastot

        private TilausDBEntities2 db = new TilausDBEntities2();

        public ActionResult Salesperday()
        {
            return View();
        }

        public ActionResult Top10sales()
        {
            string productNameList;
            string productSalesList;
            List<ProductSalesClass> ProductSalesList = new List<ProductSalesClass>();

            var productSalesData = from cs in db.Top_10_sales
                                    select cs;
            foreach (Top_10_sales salesforalltime in productSalesData)
            {
                ProductSalesClass OneSalesRow = new ProductSalesClass();
                OneSalesRow.ProductName = salesforalltime.Nimi;
                OneSalesRow.ProductSales = (int)salesforalltime.ProductSales;
                ProductSalesList.Add(OneSalesRow);
            }

            productNameList = "'" + string.Join("','", ProductSalesList.Select(n => n.ProductName).ToList()) + "'";
            productSalesList = string.Join(",", ProductSalesList.Select(n => n.ProductSales).ToList());

            ViewBag.productName = productNameList;
            ViewBag.productSales = productSalesList;

            return View();
        }
    }
}