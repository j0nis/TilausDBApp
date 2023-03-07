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
            List<ProductSalesClass> CategorySalesList = new List<ProductSalesClass>();

            var categorySalesData = from cs in db.Top_10_sales
                                    select cs;
            foreach (Top_10_sales salerfor1997 in categorySalesData)
            {
                ProductSalesClass OneSalesRow = new ProductSalesClass();
                OneSalesRow.ProductName = salerfor1997.Nimi;
                OneSalesRow.ProductSales = (int)salerfor1997.ProductSales;
                CategorySalesList.Add(OneSalesRow);
            }

            productNameList = "'" + string.Join("','", CategorySalesList.Select(n => n.ProductName).ToList()) + "'";
            productSalesList = string.Join(",", CategorySalesList.Select(n => n.ProductSales).ToList());

            ViewBag.categoryName = productNameList;
            ViewBag.categorySales = productSalesList;

            return View();
        }
    }
}