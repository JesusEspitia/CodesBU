    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;
using System.IO;
using OfficeOpenXml;
using Microsoft.Office.Interop.Excel;

namespace Monotoring.Controllers
{
    public class WorkOrdenController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: WorkOrden
        public ActionResult Index()
        {
            var orden = context.WorkOrden.Include("Catalog").ToList();
            return View(orden);
        }

        // GET: WorkOrden/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkOrden/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogNo");
            return View(new WorkOrden());
        }

        // POST: WorkOrden/Create
        [HttpPost]
        public ActionResult Create(WorkOrden orden)
        {
            try
            {
                ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ValidBatch(orden.BatchOrden) == false)
                    {
                        context.WorkOrden.Add(orden);
                        context.SaveChanges();
                        return RedirectToAction("Index");   
                    }
                    else
                    {
                        ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
                        this.ModelState.AddModelError(string.Empty, "Esta orden ya se encuentra registrada.");
                        return View();
                    }
                }
                else
                {
                    ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkOrden/Edit/5
        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
            WorkOrden orden = context.WorkOrden.Find(id);
            return View(orden);
        }

        // POST: WorkOrden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WorkOrden orden)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    if (ValidBatch(orden.BatchOrden) == false)
                    {
                        ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
                        context.Entry(orden).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else

                    {
                        ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
                        this.ModelState.AddModelError(string.Empty, "El número de la orden ya se encuentra registrado");
                        return View();
                    }
                }
                else
                {
                    ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkOrden/Delete/5

        public ActionResult Delete(int id=0)
        {
            var orden = context.WorkOrden.Find(id);
            ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogDescrip");
            return View(orden);
        }

        // POST: WorkOrden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedComfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var orden = context.WorkOrden.Find(id);
                    context.WorkOrden.Remove(orden);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult History()
        {
            try
            {
                var model = context.WorkOrden.Include("Catalog").Where(w => w.dateFinish != null).OrderBy(w=>w.dateFinish).ToList();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidBatch(string batch)
        {
            var query = from w in context.WorkOrden
                        where w.BatchOrden == batch
                        select w;
            var lst = query.ToList();
            if (lst.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public ActionResult Generate()
        {
            var model = context.WorkOrden.Include("Catalog").Where(o => o.dateStart == null).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["fileUp"];
                string filename = System.IO.Path.GetFileName(file.FileName);
                string path = Server.MapPath("~/TempFile/"+filename);
                file.SaveAs(path);
                
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = Server.MapPath("~/TempFile/" + filename);
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    //using(var package= new ExcelPackage(file.InputStream))
                    //{
                    //    var currentSheet = package.Workbook.Worksheets;
                    //    var workSheet = currentSheet.First();
                    //    var noOfCol = workSheet.Dimension.End.Column;
                    //    var noOfRow = workSheet.Dimension.End.Row;
                    //    for(int rowIterator = 2; rowIterator == noOfRow; rowIterator++)
                    //    {
                    //        string x = workSheet.Cells[rowIterator, 2].Value.ToString();
                    //    }
                    //}
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(fileName);
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Microsoft.Office.Interop.Excel.Range range;
                    range = xlWorkSheet.Range["A:A"];
                    int catId=0;
                    int itera = 0;
                    foreach (Microsoft.Office.Interop.Excel.Range r in range)
                    {
                        if (Convert.ToString(r.Cells[1, 1].Value) == "" || Convert.ToString(r.Cells[1, 1].Value)==null)
                        {
                            break;
                        }
                        else
                        {
                            if (itera > 0)
                            {
                                if (ValidBatch(Convert.ToString(r.Cells[1, 3].Value)) == false)
                                {
                                    string catNo = Convert.ToString(r.Cells[1, 2].Value);

                                    var q = from c in context.Catalog
                                            where c.CatalogNo == catNo
                                            select c;

                                    var lst = q.ToList();
                                    foreach (var item in lst)
                                    {
                                        catId = (int)item.CatalogId;
                                    }
                                    WorkOrden orden = new WorkOrden()
                                    {
                                        BatchOrden = Convert.ToString(r.Cells[1, 3].Value),
                                        CatalogId = catId,
                                        quantityOrden = Convert.ToInt32(r.Cells[1, 8].Value),
                                        dateRegistry = DateTime.Now
                                    };
                                    context.WorkOrden.Add(orden);
                                }

                            }
                            itera = 1;
                        }
                    }
                    xlWorkBook.Close(false);
                    context.SaveChanges();
                }

                System.IO.File.Delete(path);
                return RedirectToAction("Generate");
            }
            else
            {
                return RedirectToAction("Generate");
            }
        }

    }
}
