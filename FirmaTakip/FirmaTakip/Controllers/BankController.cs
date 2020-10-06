using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Carbon.Json;
using FirmaTakip.Entities;
using FirmaTakip.Interfaces;
using FirmaTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirmaTakip.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankRepository _bankRepository;
        public BankController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
        public IActionResult Index()
        {
            
            return View(_bankRepository.GetAll());
        }
        
        public IActionResult Delete(int id)
        {
            _bankRepository.Delete(new Bank { Id = id });
            return RedirectToAction("index");
        }
        public IActionResult CreateBank()
        {

            return View(new AddBankModel());
        }
        [HttpPost]
        public IActionResult CreateBank(AddBankModel model)
        {
            if (ModelState.IsValid)
            {
                AddBankModel bank = new AddBankModel();

                _bankRepository.Add(new Bank
                {
                    Id = model.Id,
                    BankName = model.BankName,
                    CardNo = model.CardNo,
                    Iban = model.Iban,
                    Password = model.Password,
                    SKT = model.SKT,
                    CVVB = model.CVVB,
                    CVVK = model.CVVK,
 
                });

                return RedirectToAction("index", "bank");
            }
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var bank = _bankRepository.GetwithId(id);

            UpdateBankModel guncellenecekVeri = new UpdateBankModel
            {
                Id = bank.Id,
                BankName = bank.BankName,
                CardNo = bank.CardNo,
                Iban = bank.Iban,
                Password = bank.Password,
                SKT = bank.SKT,
                CVVB = bank.CVVB,
                CVVK = bank.CVVK,


            };
            return View(guncellenecekVeri);
        }


        [HttpPost]
        public IActionResult Update(UpdateBankModel model)
        {

            if (ModelState.IsValid)
            {
                var Ubank = _bankRepository.GetwithId(model.Id);


                Ubank.Id = model.Id;
                Ubank.BankName = model.BankName;
                Ubank.CardNo = model.CardNo;
                Ubank.Iban = model.Iban;
                Ubank.Password = model.Password;
                Ubank.SKT = model.SKT;
                Ubank.CVVB = model.CVVB;
                Ubank.CVVK = model.CVVK;


                _bankRepository.Update(Ubank);
                return RedirectToAction("index");

            }


            return View(model);

        }

    }
}