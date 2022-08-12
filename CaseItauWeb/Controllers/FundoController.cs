using CaseItauWeb.DAL;
using CaseItauWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Controllers
{
    public class FundoController : Controller
    {
        private readonly FundoDAL _fundoDAL = new FundoDAL();
        public ActionResult Index()
        {
            try
            {
                var getFundos = _fundoDAL.GetAllFundos();
                return View(getFundos);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FundoModel fundo)
        {
            _fundoDAL.RegisterFundo(fundo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FundoModel fundo)
        {
            try
            {

                _fundoDAL.UpdateFundo(id.ToString(), fundo);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditPatrimony(int id)
        {
            var result = _fundoDAL.GetFundo(id.ToString());
            return View(result);
        }
        [HttpPost]
        public ActionResult EditPatrimony(int id, FundoModel value)
        {
            try
            {
                _fundoDAL.MovePatrimony(id.ToString(), value);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        // GET: FundoController/Delete/5
        public ActionResult Delete(int id)
        {
            _fundoDAL.RemoveFundo(id.ToString());
            return RedirectToAction("Index");
        }

        // POST: FundoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
