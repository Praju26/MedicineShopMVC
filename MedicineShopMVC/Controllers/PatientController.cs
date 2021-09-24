using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreAppUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShopMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _repository = null;

        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }
        // GET: PatientController
        public ActionResult Index()
        {
            //PatientRepository PatientRepository = new PatientRepository();
            TempData["PatientName"] = "Meera";
            ViewBag.Patient = "Meera";
            ViewData["PatientName"] = "Meera";
           
            var result = _repository.GetAllPatients();
            return View(result);
        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            //PatientRepository patientRepository = new PatientRepository();
            var result = _repository.GetPatientById(id);
            return View(result);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            //PatientRepository patientRepository = new PatientRepository();
            var result = _repository.CreatePatient(patient);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            var patient = _repository.GetPatientById(id);
            return View(Patient);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient patient)
        {
            var result = _repository.UpdatePatient(patient);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            var patient = _repository.GetPatientById(id);
            return View(Patient);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Patient, Patient)
        {
            var result = _repository.DeletePatient(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
