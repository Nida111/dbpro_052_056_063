﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using foodcorner.Models;

namespace foodcorner.Controllers
{
    public class SuppliersController : Controller
    {
        private DB22Entities3 db = new DB22Entities3();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }
<<<<<<< HEAD
        public ActionResult Welcome(string id)
        {

            Supplier sp = new Supplier();
            sp.SupplierId = db.Suppliers.FirstOrDefault(x => x.Id.Equals(id)).SupplierId;
            return View(sp);
        }
            

        public ActionResult ViewMenu(string id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            return View(supplier);
        }
=======
        public ActionResult welcome()
        {
            return View(db.SupplierCategories.ToList());
        }
        public ActionResult ViewCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
>>>>>>> 218c2c703ed5a227653c587ea102c023694c0360

            Supplier cat = db.Suppliers.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
        public ActionResult ViewItems(int? id, int? idd)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                SupplierCategory cat = db.SupplierCategories.Find(idd);
                Supplier sup = db.Suppliers.Find(id);
                SupplierItem itemsDetail = db.SupplierItems.Find(id);
                itemsDetail.CatId = cat.CatId;
                if (itemsDetail == null)
                {
                    return HttpNotFound();
                }
                
                return View(itemsDetail);
            
        }
        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,Id,Name")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,Id,Name")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
