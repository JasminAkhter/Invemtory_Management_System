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
    public class UOMController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public UOMController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var uoms = await _context.UOM
                .Select(u => new UOMDTO
                {
                    UomID = u.UomID,
                    UOMName = u.UOMName,
                    Description = u.Description,
                    CreateBy = u.CreateBy,
                    CreateDate = u.CreateDate,
                    UpdateBy = u.UpdateBy,
                    UpdateDate = u.UpdateDate
                })
                .ToListAsync();

            return Ok(uoms);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var uom = await _context.UOM.FindAsync(id);
            if (uom == null)
                return NotFound(new { Message = "UOM not found!" });

            var result = new UOMDTO
            {
                UomID = uom.UomID,
                UOMName = uom.UOMName,
                Description = uom.Description,
                CreateBy = uom.CreateBy,
                CreateDate = uom.CreateDate,
                UpdateBy = uom.UpdateBy,
                UpdateDate = uom.UpdateDate
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UOMDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new UOM();

            if (string.IsNullOrWhiteSpace(model.UomID))
            {
                var lastUom = await _context.UOM
                    .OrderByDescending(u => u.UomID)
                    .FirstOrDefaultAsync();

                string newId = "U001";
                if (lastUom != null && !string.IsNullOrEmpty(lastUom.UomID))
                {
                    var match = Regex.Match(lastUom.UomID, @"\d+$");
                    if (match.Success)
                    {
                        int lastNum = int.Parse(match.Value);
                        string prefix = lastUom.UomID.Substring(0, match.Index);
                        newId = $"{prefix}{(lastNum + 1):D3}";
                    }
                }

                entity.UomID = newId;
            }
            else
            {
                entity.UomID = model.UomID;
            }

            entity.UOMName = model.UOMName;
            entity.Description = model.Description;
            entity.CreateBy = model.CreateBy;
            entity.CreateDate = model.CreateDate ?? DateTime.Now;
            entity.UpdateBy = model.UpdateBy;
            entity.UpdateDate = model.UpdateDate ?? DateTime.Now;

            await _context.UOM.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(new { UOM = entity, Message = "UOM created successfully!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UOMDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUom = await _context.UOM.FindAsync(id);
            if (existingUom == null)
                return NotFound(new { Message = "UOM not found!" });

            existingUom.UOMName = model.UOMName;
            existingUom.Description = model.Description;
            existingUom.UpdateBy = model.UpdateBy;
            existingUom.UpdateDate = model.UpdateDate ?? DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new { UOM = existingUom, Message = "UOM updated successfully!" });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUom(string id)
        {
            try
            {
                var uom = await _context.UOM.FindAsync(id);
                if (uom == null)
                    return NotFound(new { Message = "UOM not found!" });

                _context.UOM.Remove(uom);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "UOM deleted successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

    }
}
