using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplierLedgerController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public SuplierLedgerController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ledgers = await _context.SupplierLedger
                .Select(sl => new SupplierLedgerDTO
                {
                    ID = sl.ID,
                    SupplierId = sl.SupplierId,
                    ChallanNo = sl.ChallanNo,
                    CustomerLedgerNo = sl.CustomerLedgerNo,
                    BillAmt = sl.BillAmt,
                    PayAmt = sl.PayAmt,
                    PayModeID = sl.PayModeID,
                    AmountAdd = sl.AmountAdd,
                    AmountOut = sl.AmountOut,
                    BankName = sl.BankName,
                    CHK_NO = sl.CHK_NO,
                    CheckDate = sl.CheckDate,
                    Reason = sl.Reason,
                    InvoiceNo = sl.InvoiceNo,
                    Comments = sl.Comments,
                    CreateBy = sl.CreateBy,
                    CreateDate = sl.CreateDate,
                    UpdateBy = sl.UpdateBy,
                    UpdateDate = sl.UpdateDate
                })
                .ToListAsync();

            return Ok(ledgers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ledger = await _context.SupplierLedger.FindAsync(id);
            if (ledger == null)
                return NotFound(new { Message = "Supplier Ledger not found!" });

            var result = new SupplierLedgerDTO
            {
                ID = ledger.ID,
                SupplierId = ledger.SupplierId,
                ChallanNo = ledger.ChallanNo,
                CustomerLedgerNo = ledger.CustomerLedgerNo,
                BillAmt = ledger.BillAmt,
                PayAmt = ledger.PayAmt,
                PayModeID = ledger.PayModeID,
                AmountAdd = ledger.AmountAdd,
                AmountOut = ledger.AmountOut,
                BankName = ledger.BankName,
                CHK_NO = ledger.CHK_NO,
                CheckDate = ledger.CheckDate,
                Reason = ledger.Reason,
                InvoiceNo = ledger.InvoiceNo,
                Comments = ledger.Comments,
                CreateBy = ledger.CreateBy,
                CreateDate = ledger.CreateDate,
                UpdateBy = ledger.UpdateBy,
                UpdateDate = ledger.UpdateDate
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierLedgerDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string newSupplierId = $"SUP-{new Random().Next(1000, 9999)}";

            var entity = new SupplierLedger
            {
                SupplierId = newSupplierId,
                ChallanNo = model.ChallanNo,
                CustomerLedgerNo = model.CustomerLedgerNo,
                BillAmt = model.BillAmt ?? 0,
                PayAmt = model.PayAmt ?? 0,
                PayModeID = model.PayModeID,
                AmountAdd = model.AmountAdd ?? 0,
                AmountOut = model.AmountOut ?? 0,
                BankName = model.BankName,
                CHK_NO = model.CHK_NO,
                CheckDate = model.CheckDate,
                Reason = model.Reason,
                InvoiceNo = model.InvoiceNo,
                Comments = model.Comments,
                CreateBy = model.CreateBy ?? "System",
                CreateDate = model.CreateDate ?? DateTime.Now,
                UpdateBy = model.UpdateBy ?? "System",
                UpdateDate = model.UpdateDate ?? DateTime.Now
            };

            await _context.SupplierLedger.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.ID }, new
            {
                Message = "Supplier Ledger created successfully!",
                entity
            });
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierLedgerDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingLedger = await _context.SupplierLedger.FindAsync(id);
            if (existingLedger == null)
                return NotFound(new { Message = "Supplier Ledger not found!" });

            existingLedger.SupplierId = model.SupplierId;
            existingLedger.ChallanNo = model.ChallanNo;
            existingLedger.CustomerLedgerNo = model.CustomerLedgerNo;
            existingLedger.BillAmt = model.BillAmt;
            existingLedger.PayAmt = model.PayAmt;
            existingLedger.PayModeID = model.PayModeID;
            existingLedger.AmountAdd = model.AmountAdd;
            existingLedger.AmountOut = model.AmountOut;
            existingLedger.BankName = model.BankName;
            existingLedger.CHK_NO = model.CHK_NO;
            existingLedger.CheckDate = model.CheckDate;
            existingLedger.Reason = model.Reason;
            existingLedger.InvoiceNo = model.InvoiceNo;
            existingLedger.Comments = model.Comments;
            existingLedger.CreateBy = existingLedger.CreateBy;
            existingLedger.CreateDate = existingLedger.CreateDate;
            existingLedger.UpdateBy = model.UpdateBy;
            existingLedger.UpdateDate = model.UpdateDate ?? DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new { Ledger = existingLedger, Message = "Supplier Ledger Updated Successfully!" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingLedger = await _context.SupplierLedger.FindAsync(id);
            if (existingLedger == null)
                return NotFound(new { Message = "Supplier Ledger not found!" });

            _context.SupplierLedger.Remove(existingLedger);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Supplier Ledger deleted successfully!" });
        }
    }
}

