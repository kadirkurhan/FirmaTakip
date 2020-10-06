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
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public IActionResult Index()
        {
            return View(_noteRepository.GetAll());
        }
        public IActionResult Delete(int id)
        {
            _noteRepository.Delete(new Note { Id = id });
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {

            return View(new NoteModel());
        }
        [HttpPost]
        public IActionResult Create(NoteModel model)
        {
            if (ModelState.IsValid)
            {
                NoteModel note = new NoteModel();

                _noteRepository.Add(new Note
                {
                    Id = model.Id,
                    Subject = model.Subject,
                    Content = model.Content,
                    Date = DateTime.Now
                });




                return RedirectToAction("index");
            }
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var UNote = _noteRepository.GetwithId(id);

            NoteModel guncellenecekVeri = new NoteModel
            {
                Id = UNote.Id,
                Subject = UNote.Subject,
                Content = UNote.Content,
                Date = DateTime.Now


            };
            return View(guncellenecekVeri);
        }


        [HttpPost]
        public IActionResult Update(NoteModel model)
        {

            if (ModelState.IsValid)
            {
                var updateNote = _noteRepository.GetwithId(model.Id);


                updateNote.Id = model.Id;
                updateNote.Subject = model.Subject;
                updateNote.Content = model.Content;
                updateNote.Date = DateTime.Now;


                _noteRepository.Update(updateNote);
                return RedirectToAction("index");

            }


            return View(model);

        }
    }
}