using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShopMVC.Models
{
    public class PatientRepository : IPatientRepository
    {
        public List<Patient> patients = new List<Patient>()
        {
            new Patient { ID = 1, Name = "Atharva", Address = "Talegaon Dabhade", Phone = "9405402638", TotalBill = 5000.00M },
            new Patient { ID = 2, Name = "Tanmay", Address = "Pune", Phone = "8087548493", TotalBill = 1500.50M },
            new Patient { ID = 3, Name = "Vinayak", Address = "Undri", Phone = "8975615130", TotalBill = 5200.00M },
            new Patient { ID = 4, Name = "Veena", Address = "Pune", Phone = "7775079541", TotalBill = 3000.80M },
            new Patient { ID = 5, Name = "Prajakta", Address = "Pune", Phone = "9293574985", TotalBill = 2300.00M },
            new Patient { ID = 6, Name = "Sumeet", Address = "Talegaon Dabhade", Phone = "8934572346", TotalBill = 500.15M },
            new Patient { ID = 7, Name = "Omkar", Address = "Talegaon Dabhade", Phone = "7263492594", TotalBill = 9000.60M },
            new Patient { ID = 8, Name = "Aditya", Address = "Bangalore", Phone = "9823576734", TotalBill = 8700.20M },
            new Patient { ID = 9, Name = "Amit", Address = "Pune", Phone = "9287357235", TotalBill = 3400.00M },
            new Patient { ID = 10, Name = "Yash", Address = "Talegaon Dabhade", Phone = "89234674347", TotalBill = 7000.00M }
        };

        public List<Patient> GetAllPatients()
        {
            return Patients;
        }

        public Patient GetPatientById(int Id)
        {
            var patient = patients.FirstOrDefault(item => item.ID == Id); //Returns the first element with matching value in a collection or a default value.
            //var patient = patients.First(item => item.ID == Id) //Returns the first element with matching value in a collection.
            //var patient = patients.DefaultIfEmpty(); //Returns all elements in a collection or Default if empty.
            //var patient = patients.LastOrDefault(); //Returns the last element of a collection or a default value if empty.
            return patient;
        }

        public bool CreatePatient(Patient patient)
        {
            try
            {
                patient.ID = patients.Select(item => item.ID).Max() + 1;
                patients.Add(patient);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdatePatient(Patient patient)
        {
            try
            {
                var _patient = GetPatientById(patient.ID);
                _patient.Name = patient.Name;
                _patient.Phone = patient.Phone;
                _patient.Address = patient.Address;
                _patient.TotalBill = patient.TotalBill;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeletePatient(int id)
        {
            try
            {
                patients.Remove(GetPatientById(id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
