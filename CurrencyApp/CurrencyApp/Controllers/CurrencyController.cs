﻿using CurrencyApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CurrencyApp.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyRepository _currRep;

        public CurrencyController(ICurrencyRepository currRep)
        {
            _currRep = currRep;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _currRep.getAllCurrencies();
            return View(model);
        }



        [HttpGet]
        public IActionResult create()
        {
            CurrencyModel cm = new CurrencyModel();
            return View(cm);
        }


        [HttpPost]
        public IActionResult create(CurrencyModel currencyModel)
        {
            if (ModelState.IsValid)
            {
                CurrencyModel cm = _currRep.create(currencyModel);
                return RedirectToAction("Index", "Currency");
            }
            return View();
        }

        [HttpGet]
        public IActionResult update(int Id)
        {
            CurrencyModel cm = _currRep.getCurr(Id);
            System.Diagnostics.Debug.WriteLine(Id);
            return View(cm);
        }

        [HttpPost]
        public IActionResult update(CurrencyModel currencyModel)
        {
            if (ModelState.IsValid)
            {
                _currRep.update(currencyModel);
                return RedirectToAction("Index", "Currency");
            }
            return View();

        }

        [HttpGet]
        public IActionResult delete(int id)
        {
            _currRep.delete(id);
            return RedirectToAction("Index", "Currency");
        }
    }


}