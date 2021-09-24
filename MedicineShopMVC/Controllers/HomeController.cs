using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstCoreAppUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Patient> patients = new List<Patient>();
        private readonly IPatientRepository _repository = null;

        public HomeController(ILogger<HomeController> logger, IPatientRepository repository)
        {
            patients.Add(new Patient { ID = 101, Name = "Meera", Address = "Sangali", Phone = "1234567893", TotalBill = 5796M });
            patients.Add(new Patient { ID = 102, Name = "Ram", Address = "Satara", Phone = "2314569875", TotalBill = 45789M });
            patients.Add(new Patient { ID = 103, Name = "Jenny", Address = "Pune", Phone = "34567892157", TotalBill = 57894M });
            patients.Add(new Patient { ID = 104, Name = "Advik", Address = "Pune", Phone = "4561237890", TotalBill = 54789M });
            patients.Add(new Patient { ID = 105, Name = "Avnish", Address = "Karad", Phone = "5421360789", TotalBill = 24578M });
            patients.Add(new Patient { ID = 106, Name = "Om", Address = "Sangali", Phone = "6457892150", TotalBill = 54789M });
            patients.Add(new Patient { ID = 107, Name = "Guru", Address = "Palus", Phone = "7896541230", TotalBill = 57896M });
            patients.Add(new Patient { ID = 108, Name = "Priya", Address = "PimpariChinchwad", Phone = "2587456310", TotalBill = 25478M });
            patients.Add(new Patient { ID = 109, Name = "Vallabh", Address = "Shirawal", Phone = "578962140", TotalBill = 965478M });
            patients.Add(new Patient { ID = 110, Name = "Vedant", Address = "Karad", Phone = "5678941025", TotalBill = 245789M });
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Patient> patientList = _repository.GetAllPatients();
            ViewBag.patientList = patientList;
            ViewData["PatientList"] = patientList;

            return View(patientList);
        }

        public IActionResult Patients()
        {
            return View(patients);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
