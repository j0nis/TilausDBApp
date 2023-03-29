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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
                string weekdayNameList;
                string perdaySalesList;
                List<SalesPerDay> ProductSalesList = new List<SalesPerDay>();

                var perdaySalesData = from cs in db.Salesperday
                                      select cs;
                foreach (Salesperday salesforalltime in perdaySalesData)
                {
                    SalesPerDay OneSalesRow = new SalesPerDay();
                    OneSalesRow.weekdayName = salesforalltime.Weekday;
                    OneSalesRow.perdaySales = (int)salesforalltime.NumOrders;
                    ProductSalesList.Add(OneSalesRow);
                }

                weekdayNameList = "'" + string.Join("','", ProductSalesList.Select(n => n.weekdayName).ToList()) + "'";
                perdaySalesList = string.Join(",", ProductSalesList.Select(n => n.perdaySales).ToList());

                ViewBag.weekdayName = weekdayNameList;
                ViewBag.perdaySales = perdaySalesList;

                return View();
            }
        }

        public ActionResult Top10sales()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
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
}