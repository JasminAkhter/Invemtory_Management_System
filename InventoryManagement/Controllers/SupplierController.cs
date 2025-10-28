using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public SupplierController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _context.SupplierCompany
                .Select(s => new SupplierDTO
                {
                    SupplierCompanyID = s.SupplierCompanyID,
                    SupplierCompanyName = s.SupplierCompanyName,
                    Address = s.Address,
                    Phone = s.Phone,
                    Mobile = s.Mobile,
                    Fax = s.Fax,
                    CreateDate = s.CreateDate,
                    CreateBy = s.CreateBy,
                    UpdateBy = s.UpdateBy,
                    UpdateDate = s.UpdateDate,
                    Logo = s.Logo,
                    IsCashBack = s.IsCashBack,
                    OpeningAmt = s.OpeningAmt
                })
                .ToListAsync();

            return Ok(suppliers);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            var supplier = await _context.SupplierCompany.FindAsync(id);
            if (supplier == null)
                return NotFound(new { Message = "Supplier not found!" });

            var result = new SupplierDTO
            {
                SupplierCompanyID = supplier.SupplierCompanyID,
                SupplierCompanyName = supplier.SupplierCompanyName,
                Address = supplier.Address,
                Phone = supplier.Phone,
                Mobile = supplier.Mobile,
                Fax = supplier.Fax,
                CreateDate = supplier.CreateDate,
                CreateBy = supplier.CreateBy,
                UpdateBy = supplier.UpdateBy,
                UpdateDate = supplier.UpdateDate,
                Logo = supplier.Logo,
                IsCashBack = supplier.IsCashBack,
                OpeningAmt = supplier.OpeningAmt
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SupplierCompany();

            if (string.IsNullOrWhiteSpace(model.SupplierCompanyID))
            {
                var lastSupplier = await _context.SupplierCompany
                    .OrderByDescending(s => s.SupplierCompanyID)
                    .FirstOrDefaultAsync();

                string newId = "SUP001";
                if (lastSupplier != null && !string.IsNullOrEmpty(lastSupplier.SupplierCompanyID))
                {
                    var match = Regex.Match(lastSupplier.SupplierCompanyID, @"\d+$");
                    if (match.Success)
                    {
                        int lastNum = int.Parse(match.Value);
                        string prefix = lastSupplier.SupplierCompanyID.Substring(0, match.Index);
                        newId = $"{prefix}{(lastNum + 1):D3}";
                    }
                }

                entity.SupplierCompanyID = newId;
            }
            else
            {
                entity.SupplierCompanyID = model.SupplierCompanyID;
            }

            entity.SupplierCompanyName = model.SupplierCompanyName;
            entity.Address = model.Address;
            entity.Phone = model.Phone;
            entity.Mobile = model.Mobile;
            entity.Fax = model.Fax;
            entity.CreateBy = model.CreateBy;
            entity.CreateDate = model.CreateDate ?? DateTime.Now;
            entity.UpdateBy = model.UpdateBy;
            entity.UpdateDate = model.UpdateDate ?? DateTime.Now;
            entity.Logo = model.Logo;
            entity.IsCashBack = model.IsCashBack;
            entity.OpeningAmt = model.OpeningAmt;

            await _context.SupplierCompany.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SupplierDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingSupplier = await _context.SupplierCompany.FindAsync(id);
            if (existingSupplier == null)
                return NotFound(new { Message = "Supplier not found!" });

            existingSupplier.SupplierCompanyName = model.SupplierCompanyName;
            existingSupplier.Address = model.Address;
            existingSupplier.Phone = model.Phone;
            existingSupplier.Mobile = model.Mobile;
            existingSupplier.Fax = model.Fax;
            existingSupplier.CreateBy = existingSupplier.CreateBy;
            existingSupplier.CreateDate = existingSupplier.CreateDate;
            existingSupplier.UpdateBy = model.UpdateBy;
            existingSupplier.UpdateDate = model.UpdateDate ?? DateTime.Now;
            existingSupplier.Logo = model.Logo;
            existingSupplier.IsCashBack = model.IsCashBack;
            existingSupplier.OpeningAmt = model.OpeningAmt;

            await _context.SaveChangesAsync();

            return Ok(new { Supplier = existingSupplier, Message = "Supplier Updated Successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(string id)
        {
            try
            {
                var supplier = await _context.SupplierCompany.FindAsync(id);
                if (supplier == null)
                    return NotFound(new { Message = "Supplier not found!" });

                _context.SupplierCompany.Remove(supplier);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Supplier deleted successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
