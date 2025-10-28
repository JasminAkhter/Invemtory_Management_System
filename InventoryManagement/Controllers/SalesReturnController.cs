using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReturnController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public SalesReturnController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesReturns = await _context.SalesReturn
                .Select(sr => new SalesReturnDTO
                {
                    ID = sr.ID,
                    ReturnInvoiceNo = sr.ReturnInvoiceNo,
                    InvoiceNo = sr.InvoiceNo,
                    ReturnDate = sr.ReturnDate,
                    ItemID = sr.ItemID,
                    CustomerID = sr.CustomerID,
                    RQty = sr.RQty,
                    SalesQty = sr.SalesQty,
                    SalesPrice = sr.SalesPrice,
                    TotalTotalPrice = sr.TotalTotalPrice,
                    vat = sr.vat,
                    NetAmount = sr.NetAmount,
                    ReturnAmount = sr.ReturnAmount,
                    CustomerPayment = sr.CustomerPayment,
                    CreateBy = sr.CreateBy,
                    CreateDate = sr.CreateDate
                })
                .ToListAsync();

            return Ok(salesReturns);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(decimal id)
        {
            var salesReturn = await _context.SalesReturn.FindAsync(id);
            if (salesReturn == null)
                return NotFound(new { Message = "SalesReturn not found!" });

            var result = new SalesReturnDTO
            {
                ID = salesReturn.ID,
                ReturnInvoiceNo = salesReturn.ReturnInvoiceNo,
                InvoiceNo = salesReturn.InvoiceNo,
                ReturnDate = salesReturn.ReturnDate,
                ItemID = salesReturn.ItemID,
                CustomerID = salesReturn.CustomerID,
                RQty = salesReturn.RQty,
                SalesQty = salesReturn.SalesQty,
                SalesPrice = salesReturn.SalesPrice,
                TotalTotalPrice = salesReturn.TotalTotalPrice,
                vat = salesReturn.vat,
                NetAmount = salesReturn.NetAmount,
                ReturnAmount = salesReturn.ReturnAmount,
                CustomerPayment = salesReturn.CustomerPayment,
                CreateBy = salesReturn.CreateBy,
                CreateDate = salesReturn.CreateDate
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SalesReturnDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SalesReturn
            {
                ReturnInvoiceNo = model.ReturnInvoiceNo,
                InvoiceNo = model.InvoiceNo,
                ReturnDate = model.ReturnDate,
                ItemID = model.ItemID,
                CustomerID = model.CustomerID,
                RQty = model.RQty,
                SalesQty = model.SalesQty,
                SalesPrice = model.SalesPrice,
                TotalTotalPrice = model.TotalTotalPrice,
                vat = model.vat,
                NetAmount = model.NetAmount,
                ReturnAmount = model.ReturnAmount,
                CustomerPayment = model.CustomerPayment,
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate ?? DateOnly.FromDateTime(DateTime.Now)
            };

            await _context.SalesReturn.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.ID }, entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(decimal id, [FromBody] SalesReturnDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingReturn = await _context.SalesReturn.FindAsync(id);
            if (existingReturn == null)
                return NotFound(new { Message = "SalesReturn not found!" });

            existingReturn.ReturnInvoiceNo = model.ReturnInvoiceNo;
            existingReturn.InvoiceNo = model.InvoiceNo;
            existingReturn.ReturnDate = model.ReturnDate;
            existingReturn.ItemID = model.ItemID;
            existingReturn.CustomerID = model.CustomerID;
            existingReturn.RQty = model.RQty;
            existingReturn.SalesQty = model.SalesQty;
            existingReturn.SalesPrice = model.SalesPrice;
            existingReturn.TotalTotalPrice = model.TotalTotalPrice;
            existingReturn.vat = model.vat;
            existingReturn.NetAmount = model.NetAmount;
            existingReturn.ReturnAmount = model.ReturnAmount;
            existingReturn.CustomerPayment = model.CustomerPayment;
            existingReturn.CreateBy = existingReturn.CreateBy;
            existingReturn.CreateDate = existingReturn.CreateDate;

            await _context.SaveChangesAsync();

            return Ok(new { SalesReturn = existingReturn, Message = "SalesReturn updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(decimal id)
        {
            var existingReturn = await _context.SalesReturn.FindAsync(id);
            if (existingReturn == null)
                return NotFound(new { Message = "SalesReturn not found!" });

            _context.SalesReturn.Remove(existingReturn);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "SalesReturn deleted successfully!" });
        }
    }
}
