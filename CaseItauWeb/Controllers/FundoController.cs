using CaseItauWeb.DAL;
using CaseItauWeb.Models;
using CaseItauWeb.Utils;
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
            catch (ArgumentException ex)
            {
                ViewBag.Alert = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Alert = Constants.Error();
                return View();
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
            try
            {
                if (!ModelState.IsValid)
                    return View();
                _fundoDAL.RegisterFundo(fundo);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ViewBag.Alert = ex.Message;
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Alert = Constants.Error();
                return View("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var result = _fundoDAL.GetFundo(id.ToString());
                return View(result);
            }
            catch (ArgumentException ex)
            {
                ViewBag.Alert = ex.Message;
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Alert = Constants.Error();
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FundoModel fundo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if (_fundoDAL.UpdateFundo(id.ToString(), fundo))
                    return RedirectToAction("Index");
                else
                    throw new ArgumentException(Constants.FundsNotUpdate());
            }
            catch (ArgumentException ex)
            {
                ViewBag.Alert = ex.Message;
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Alert = Constants.Error();
                return View("Index");
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
                if (!ModelState.IsValid)
                    return View();
                if (_fundoDAL.MovePatrimony(id.ToString(), value))
                    return RedirectToAction("Index");
                else
                    throw new ArgumentException(Constants.ValueNotUpdate());

            }
            catch (ArgumentException ex)
            {
                ViewBag.Alert = ex.Message;
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Alert = Constants.Error();
                return View("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if (_fundoDAL.RemoveFundo(id.ToString()))
                    return RedirectToAction("Index");
                else
                    throw new ArgumentException(Constants.FundNotRemove());
            }
            catch (ArgumentException ex)
            {
                ViewBag.Alert = ex.Message;
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Alert = Constants.Error();
                return View("Index");
            }
        }
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
