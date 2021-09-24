using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicineShopManagement.DAL.Data;
using MedicineShopManagement.DAL.Data.Model;
using MedicineShopManagement.Services.Services;
using MedicineShopManagement.ViewModel;

namespace MedicineShopManagement.Controllers
{
    [Authorize]
    public class MedicinesController : Controller
    {
        private readonly MEDDbContext _context;
        private readonly IMedicineService _medicineService;
        public MedicinesController(MEDDbContext context, IMedicineService medicineService)
        {
            _context = context;
            _medicineService = medicineService;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            ViewBag.MedicineCount = _context.Medicines.Count(); //Passed data from controller to view using ViewBag
            return View(await _medicineService.GetAllMedicines());
        }

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var medicine = await _context.Medicines
            //    .FirstOrDefaultAsync(m => m.Id == id);

            //var medicineDetailInfo = await _context.MedicineDetailInfos
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var medicine = await _medicineService.GetMedicineById(id);
            var medicineDetailInfo = await _medicineService.GetMedicineInfoById(id);

            ViewData["MedicineId"] = id;   //Used ViewData to pass data from controller to view

            if (medicine == null || medicineDetailInfo == null)
            {
                return NotFound();
            }

            MedicineDetailViewModel medicineDetailViewModel = new MedicineDetailViewModel();
            MedicineDetailViewModel.Medicine = medicine;
            medicineDetailViewModel.MedicineDetailInfo = medicineDetailInfo;

            return View(medicineDetailViewModel);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Medicine_Name,Medicine_Type,Medicine_Quantity,Medicine_Price")] Medicine medicine,
            [Bind("Id,Medicine_Cost_Price,MedicineCode_Code")] MedicineDetailInfo medicineDetailInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = await _medicineService.CreateMedicine(medicine, medicineDetailInfo);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            MedicineDetailViewModel medicineDetailViewModel = new MedicineDetailViewModel();
            medicineDetailViewModel.Medicine = medicine;
            medicineDetailViewModel.MedicineDetailInfo = medicineDetailInfo;
            return View(medicineDetailViewModel);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _medicineService.GetMedicineById(id);
            var medicineDetailInfo = await _medicineService.GetMedicineInfoById(id);
            if (medicine == null || medicineDetailInfo == null)
            {
                return NotFound();
            }

            MedicineDetailViewModel medicineDetailViewModel = new MedicineDetailViewModel();
            medicineDetailViewModel.Mdicine = medicine;
            medicineDetailViewModel.MedicineDetailInfo = medicineDetailInfo;

            return View(medicineDetailViewModel);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Medicine_Name,Medicine_Type,Medicine_Quantity,Medicine_Price")] Medicine medicine,
            [Bind("Id,Medicine_Cost_Price,MedicineCode_Code")] MedicineDetailInfo medicineDetailInfo)
        {
            if (id != medicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(medicine);
                    //_context.Update(medicineDetailInfo);
                    //await _context.SaveChangesAsync();
                    await _medicineService.UpdateMedicine(medicine, medicineDetailInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            MedicineDetailViewModel medicineDetailViewModel = new MedicineDetailViewModel();
            medicineDetailViewModel.Medicine = medicine;
            medicineDetailViewModel.MedicineDetailInfo = medicineDetailInfo;
            return View(medicineDetailViewModel);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _medicineService.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var medicine = await _context.Medicines.FindAsync(id);
            //_context.Medicines.Remove(medicine);
            //await _context.SaveChangesAsync();
            await _medicineService.DeleteMedicine(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
            //return _context.Medicines.Any(e => e.Id == id);
            return _medicineService.MedicineExist(id);
        }
    }
}
