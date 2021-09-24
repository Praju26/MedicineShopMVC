using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShopMVC.Models
{
    public interface IPatientRepository
    {
        public List<Patient> GetAllPatients();
        public Patient GetPatientById(int Id);
        public bool CreatePatient(Patient patient);
        public bool UpdatePatient(Patient patient);
        public bool DeletePatient(int id);
    }
}
