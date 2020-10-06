using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirmaTakip.Entities;
using FirmaTakip.Interfaces;
using FirmaTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirmaTakip.Controllers
{
    public class MailAccountController : Controller
    {
        private readonly IMailAccountRepository _mailAccountRepository;
        public MailAccountController(IMailAccountRepository mailAccountRepository)
        {
            _mailAccountRepository = mailAccountRepository;
        }
        public IActionResult Index()
        {
            return View(_mailAccountRepository.GetAll());
        }
        public IActionResult Delete(int id)
        {
            _mailAccountRepository.Delete(new MailAccount { Id = id });
            return RedirectToAction("index");
        }
        public IActionResult CreateMailAccount()
        {

            return View(new AddMailAccountModel());
        }
        [HttpPost]
        public IActionResult CreateMailAccount(AddMailAccountModel model)
        {
            if (ModelState.IsValid)
            {
                AddMailAccountModel bank = new AddMailAccountModel();

                _mailAccountRepository.Add(new MailAccount
                {
                    Id = model.Id,
                    Name = model.Name,
                    Password = model.Password
                });




                return RedirectToAction("index");
            }
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var mail = _mailAccountRepository.GetwithId(id);

            UpdateMailAccountModel guncellenecekVeri = new UpdateMailAccountModel
            {
                Id = mail.Id,
                Name = mail.Name,
                Password = mail.Password

            };
            return View(guncellenecekVeri);
        }


        [HttpPost]
        public IActionResult Update(UpdateMailAccountModel model)
        {

            if (ModelState.IsValid)
            {
                var mail = _mailAccountRepository.GetwithId(model.Id);


                mail.Id = model.Id;
                mail.Name = model.Name;
                mail.Password = model.Password;



                _mailAccountRepository.Update(mail);
                return RedirectToAction("index");

            }


            return View(model);

        }
    }
}