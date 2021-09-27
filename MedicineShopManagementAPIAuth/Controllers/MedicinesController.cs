using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicineShopManagement.DAL.Data.Model;
using MedicineShopManagement.Services.Services;
using MedicineShopManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineShopManagementAPIAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IDisplayMedicineService _displayMedicineService;
        public MedicinesController(IDisplayMedicineService displyMedicineService)
        {
            _displayMedicineService = displayMedicineService;
        }
        // GET: api/<MedicinesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _displayMedicineService.GetAllMedicines());
        }

        // GET api/<MedicinesController>/5
        [HttpGet("{id}")]
        public async Task<medDisplayMedicineInfo> Get(int id)
        {
            return await _displayMedicineService.GetMedicineById(id);
        }

        // POST api/<MedicinesController>
        [HttpPost]
        public async void Post([FromBody] medDisplayMedicineInfo medDisplayMedicineInfo)
        {
            await _displayMedicineService.CreateMedicine(medDisplayMedicineInfo);
        }

        // PUT api/<MedicinesController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] DisplayMedicine displayMedicine)
        {
            await _displayMedicineService.UpdateMedicine(displayMedicine);
        }

        // DELETE api/<MedicinesController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var medicine = await _displayMedicineService.GetDisplayMedicineById(id);
            await _displayMedicineService.DeleteMedicine(medicine);
        }
    }
}
