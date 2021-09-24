using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicineShopManagement.DAL.Data;
using MedicineShopManagement.DAL.Data.Model;
using MedicineShopManagement.Services.Services;
using MedicineShopManagement.Services.ViewModel;

namespace MedicineShopManagement.Controllers
{
    public class DisplayMedicineController : Controller
    {
        private readonly MEDDbContext _context;
        private readonly IDisplayMedicineService _DisplayMedicineService;

        public DisplayMedicineController(MEDDbContext context, IDisplayMedicineService displayMedicineService)
        {
            _context = context;
            _displayMedicineService = displayMedicineService;
        }

        // GET: DisplayMedicines
        public async Task<IActionResult> Index(string searchQuery, int pageChange = 0, int pageNumber = 1, int pageSize = 3)
        {
            var currentPage = pageNumber + pageChange;
            ViewData["PerPage"] = pageSize;
            ViewData["PageNum"] = currentPage;

            if (currentPage == 1)
            {
                ViewData["PrevBtn"] = "disabled";
            }

            var medicines = new List<DisplayMedicine>();
            if (searchQuery == null)
            {
                medicines = await _displayMedicineService.GetAllMedicines();
            }
            else
            {
                ViewData["searchQuery"] = searchQuery;
                var result = await _displayMedicineService.GetAllMedicines();
                medicines = result.Where(a => a.Name.ToLower().Contains(searchQuery.ToLower())
                || a.MedicineType.Type.ToLower().Contains(searchQuery.ToLower())).ToList();
            }
            var values = medicines.OrderBy(o => o.MedicineType.Type);

            int take = Convert.ToInt32(ViewData["PerPage"]);
            int skip = (currentPage - 1) * take;
            int totalResults = values.Count();

            ViewData["TotalResults"] = totalResults;
            if (skip + take >= totalResults)
            {
                ViewData["NextBtn"] = "disabled";
            }

            return View(values.Skip(skip).Take(take));
        }   

        //Multiple Route using attribute routing
        [Route("DisplayMedicines/Details")]
        [Route("Details")]
        // GET: DisplayMedicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var displayMedicineInfo = await _displayMedicineService.GetMedicineById(id);
            if (displayMedicineInfo == null)
            {
                return NotFound();
            }

            return View(displayMedicineInfo);
        }

        // GET: DisplayMedicines/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.MedicineType, "Id", "Type");
            return View();
        }

        // POST: DisplayMedicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Name,Type,Quantity,Price,Cost_Price,MedicineCode_Code,CreatedOn,UpdatedOn")] vwAdvProductInfo vwAdvProductInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = await _displayMedicineService.CreateMedicine(medDisplayMedicineInfo);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["TypeId"] = new SelectList(_context.MedicineTypes, "Id", "Type", medDisplayMedicineInfo.CategoryId);
            return View(meddisplayMedicineInfo);
        }

        // GET: DisplayMedicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var displayMedicineInfo = await _displayMedicineService.GetMedicineById(id);
            if (displayMedicineInfo == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.MedicineType, "Id", "Type", displayMedicineInfo.TypeId);
            return View(displayMedicineInfo);
        }

        // POST: DisplayMedicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Name,Quantity,Price,Cost_Price,MedicineCode_Code,CreatedOn,UpdatedOn")] AdvProduct advProduct)
        {
            if (id != displayMedicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _displayMedicineService.UpdateMedicine(displayMedicine);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisplayMedicineExists(displayMedicine.Id))
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
            ViewData["TypeId"] = new SelectList(_context.MedicineTypes, "Id", "Type", displayMedicine.TypeId);
            return View(displayMedicine);
        }

        // GET: DisplayMedicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _displayMedicineService.GetMedicineById(id);
            var displayMedicine = new DisplayMedicine()
            {
                Id = result.Id,
                TypeId = result.TypeId,
                Cost_Price = result.Cost_Price,
                CreatedOn = result.CreatedOn,
                MedicineCode_Code = result.MedicineCode_Code;
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity,
                UpdatedOn = result.UpdatedOn
            };

            if (displayMedicine == null)
            {
                return NotFound();
            }

            return View(displayMedicine);
        }

// POST: DisplayMedicines/Delete/5
[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _displayMedicineService.GetMedicineById(id);
            var displayMedicine = new DisplayMedicine()
            {
                Id = result.Id,
                TypeId = result.TypeId,
                Cost_Price = result.Cost_Price,
                CreatedOn = result.CreatedOn,
                MedicineCode_Code = result.MedicineCode_Code,
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity,
                UpdatedOn = result.UpdatedOn
            };

            await _displayMedicineService.DeleteMedicine(displayMedicine);
            return RedirectToAction(nameof(Index));
        }

        private bool DisplayMedicineExists(int id)
        {
            return _displayMedicineService.MExist(id);
        }
    }
}
