using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirmaTakip.Models;
using FirmaTakip.Repositories;
using Microsoft.AspNetCore.Authorization;
using FirmaTakip.Interfaces;
using FirmaTakip.Entities;

namespace FirmaTakip.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ICompanyRepository _companyRepository;
        public HomeController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public IActionResult Index(string q)
        {
            
            //CompanyRepository companyRepository = new CompanyRepository();
            //return View(companyRepository.GelAll());
            List<Company> liste = _companyRepository.GetAll();
            if (!string.IsNullOrEmpty(q))
            {
                liste = liste.Where(i => i.CompanyName.ToLower().Contains(q.ToLower())).ToList();
            }
            return View(liste);
        }

        public IActionResult CreateCompany()
        {
            return View(new AddCompanyModel());
        }
        [HttpPost]
        public IActionResult CreateCompany(AddCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company();
                company.CompanyName = model.CompanyName;
                company.CompanyCountry = model.CompanyCountry;
                company.CompanyCity = model.CompanyCity;
                company.CompanyTown = model.CompanyTown;
                company.CompanyAddress = model.CompanyAddress;
                company.PhoneNumber = model.PhoneNumber;

                _companyRepository.Add(company);
                return RedirectToAction("index","home");
            }
            return View(model);
        }

        



        public IActionResult DeleteCompany(int id) {
            _companyRepository.Delete(new Company { CompanyId = id });
            return RedirectToAction("index");
        }
        public IActionResult CompanyDetails(int id)
        {
            
            return View(_companyRepository.GetwithId(id));
        }
        public IActionResult Update(int id)
        {
            var comingCompany = _companyRepository.GetwithId(id);

            UpdateCompanyModel guncellenecekVeri = new UpdateCompanyModel
            {
                CompanyId       = comingCompany.CompanyId,
                CompanyName = comingCompany.CompanyName,
                CompanyCountry = comingCompany.CompanyCountry,
                CompanyCity = comingCompany.CompanyCity,
                CompanyTown = comingCompany.CompanyTown,
                CompanyAddress = comingCompany.CompanyAddress,
                PhoneNumber = comingCompany.PhoneNumber

            };
            return View(guncellenecekVeri);
        }


        [HttpPost]
        public IActionResult Update(UpdateCompanyModel model)
        {

            if (ModelState.IsValid)
            {
                var company = _companyRepository.GetwithId(model.CompanyId);


                company.CompanyId = model.CompanyId;
                company.CompanyName = model.CompanyName;
                company.CompanyCountry = model.CompanyCountry;
                company.CompanyCity = model.CompanyCity;
                company.CompanyTown = model.CompanyTown;
                company.CompanyAddress = model.CompanyAddress;
                company.PhoneNumber = model.PhoneNumber;


                _companyRepository.Update(company);
                return RedirectToAction("index", "home");

            }


            return View(model);

        }


    }
}
