using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using CRUDdapperDemo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CRUDdapperDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> CustomerList = new List<Customer>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                CustomerList = db.Query<Customer>("SELECT * FROM [CustomerTB]").ToList();
            }
            return View(CustomerList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer _customer = new Customer();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                _customer = db.Query<Customer>("Select * From [CustomerTB] " +
                                       "WHERE [CustomerID] =" + id, new { id }).SingleOrDefault();
            }
                return View(_customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer _customer)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string SqlQuery="Insert into [CustomerTB] ([Name], [Address], [Country], [City], [phoneno] ) values("+_customer.Name+","+_customer.Address+","+_customer.Country+","+_customer.City+","+_customer.Phoneno+")";
                int rowsAffected = db.Execute(SqlQuery);
            }
                return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer _customer = new Customer();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                _customer = db.Query<Customer>("Select * from [CustomerTB]" +
                                      "Where [CustomerID] =" + id, new { id }).SingleOrDefault();
            }
                return View(_customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer _customer)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string SqlQuery = "update [CustomerTB] set [Name]='"+_customer.Name+"',[Address]='"+_customer.Address+"',[Country]='"+_customer.Country+"',[City]='" + _customer.City + "',[Phoneno]='" + _customer.Phoneno + "' where [CustomerID]=" + _customer.CustomerID;
                int rowsAffected = db.Execute(SqlQuery);
            }
                return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer _customer = new Customer();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                _customer=db.Query<Customer>("Select * from [CustomerTB]"+
                                    "where [CustomerID]= "+id, new { id}).SingleOrDefault();
            }
                return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer _customer)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string SqlQuery = "Delete from [CustomerTB] where CustomerID=" + id;
                int rowsAffected = db.Execute(SqlQuery);
            }
                return RedirectToAction("Index");
        }
    }
}
