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
    public class CustomerLedgerController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public CustomerLedgerController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ledgers = await _context.CustomerLedger
                .Select(c => new CustomerLedgerDTO
                {
                    ID = c.ID,
                    CustomerId = c.CustomerId,
                    ChallanNo = c.ChallanNo,
                    SupplierCompanyID = c.SupplierCompanyID,
                    CustomerLedgerNo = c.CustomerLedgerNo,
                    BillAmt = c.BillAmt,
                    PayAmt = c.PayAmt,
                    PayModeID = c.PayModeID,
                    BankName = c.BankName,
                    CHK_NO = c.CHK_NO,
                    CheckDate = c.CheckDate,
                    Reason = c.Reason,
                    InvoiceNo = c.InvoiceNo,
                    Comments = c.Comments,
                    CreateBy = c.CreateBy,
                    CreateDate = c.CreateDate,
                    UpdateBy = c.UpdateBy,
                    UpdateDate = c.UpdateDate
                })
                .ToListAsync();

            return Ok(ledgers);
        }


        #region IntID Search
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerLedgerDTO>> GetById(int id)
        {
            try
            {
                var ledger = await _context.CustomerLedger.FindAsync(id);
                if (ledger == null)
                    return NotFound(new { Message = "CustomerLedger not found!" });

                var result = new CustomerLedgerDTO
                {
                    ID = ledger.ID,
                    CustomerId = ledger.CustomerId,
                    ChallanNo = ledger.ChallanNo,
                    SupplierCompanyID = ledger.SupplierCompanyID,
                    CustomerLedgerNo = ledger.CustomerLedgerNo,
                    BillAmt = ledger.BillAmt,
                    PayAmt = ledger.PayAmt,
                    PayModeID = ledger.PayModeID,
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
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        #endregion

        #region stringID serach

        //[HttpGet("{customerId}")]
        //public async Task<ActionResult<CustomerLedgerDTO>> GetByCustomerId(string customerId)
        //{
        //    try
        //    {
        //        var ledger = await _context.CustomerLedger
        //            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        //        if (ledger == null)
        //            return NotFound(new { Message = "CustomerLedger not found for the given CustomerId!" });

        //        var result = new CustomerLedgerDTO
        //        {
        //            ID = ledger.ID,
        //            CustomerId = ledger.CustomerId,
        //            ChallanNo = ledger.ChallanNo,
        //            SupplierCompanyID = ledger.SupplierCompanyID,
        //            CustomerLedgerNo = ledger.CustomerLedgerNo,
        //            BillAmt = ledger.BillAmt,
        //            PayAmt = ledger.PayAmt,
        //            PayModeID = ledger.PayModeID,
        //            BankName = ledger.BankName,
        //            CHK_NO = ledger.CHK_NO,
        //            CheckDate = ledger.CheckDate,
        //            Reason = ledger.Reason,
        //            InvoiceNo = ledger.InvoiceNo,
        //            Comments = ledger.Comments,
        //            CreateBy = ledger.CreateBy,
        //            CreateDate = ledger.CreateDate,
        //            UpdateBy = ledger.UpdateBy,
        //            UpdateDate = ledger.UpdateDate
        //        };

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return StatusCode(500, "Internal server error. Please try again later.");
        //    }
        //}
        #endregion

        #region CreateMethod
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerLedgerDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                CustomerLedger entity = new CustomerLedger();

                // Auto generate CustomerId 
                if (string.IsNullOrWhiteSpace(model.CustomerId))
                {
                    var lastCustomer = await _context.CustomerLedger
                        .OrderByDescending(c => c.CustomerId)
                        .FirstOrDefaultAsync();

                    string newCustomerId = "CUST001";
                    if (lastCustomer != null)
                    {
                        var match = Regex.Match(lastCustomer.CustomerId ?? "CUST000", @"\d+$");
                        int lastNum = match.Success ? int.Parse(match.Value) : 0;
                        string prefix = match.Success ? lastCustomer.CustomerId.Substring(0, match.Index) : "CUST";
                        newCustomerId = $"{prefix}{(lastNum + 1):D3}";
                    }

                    entity.CustomerId = newCustomerId;
                }
                else
                {
                    entity.CustomerId = model.CustomerId; 
                }

                if (string.IsNullOrWhiteSpace(model.CustomerLedgerNo))
                {
                    var lastLedger = await _context.CustomerLedger
                        .OrderByDescending(c => c.CustomerLedgerNo)
                        .FirstOrDefaultAsync();

                    string newLedgerNo = "CL001";
                    if (lastLedger != null)
                    {
                        var match = Regex.Match(lastLedger.CustomerLedgerNo ?? "CL000", @"\d+$");
                        int lastNum = match.Success ? int.Parse(match.Value) : 0;
                        string prefix = match.Success ? lastLedger.CustomerLedgerNo.Substring(0, match.Index) : "CL";
                        newLedgerNo = $"{prefix}{(lastNum + 1):D3}";
                    }

                    entity.CustomerLedgerNo = newLedgerNo;
                }
                else
                {
                    entity.CustomerLedgerNo = model.CustomerLedgerNo;
                }

                entity.ChallanNo = model.ChallanNo;
                entity.SupplierCompanyID = model.SupplierCompanyID;
                entity.BillAmt = model.BillAmt;
                entity.PayAmt = model.PayAmt;
                entity.PayModeID = model.PayModeID;
                entity.BankName = model.BankName;
                entity.CHK_NO = model.CHK_NO;
                entity.CheckDate = model.CheckDate;
                entity.Reason = model.Reason;
                entity.InvoiceNo = model.InvoiceNo;
                entity.Comments = model.Comments;
                entity.CreateBy = model.CreateBy;
                entity.CreateDate = model.CreateDate ?? DateTime.Now;
                entity.UpdateBy = model.UpdateBy;
                entity.UpdateDate = model.UpdateDate;

                await _context.CustomerLedger.AddAsync(entity);
                await _context.SaveChangesAsync();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerLedgerDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingLedger = await _context.CustomerLedger.FindAsync(id);
                if (existingLedger == null)
                    return NotFound(new { Message = "CustomerLedger not found!" });

                if (!string.IsNullOrWhiteSpace(model.CustomerId))
                    existingLedger.CustomerId = model.CustomerId;

                existingLedger.CustomerId = model.CustomerId;
                existingLedger.ChallanNo = model.ChallanNo;
                existingLedger.SupplierCompanyID = model.SupplierCompanyID;
                existingLedger.CustomerLedgerNo = model.CustomerLedgerNo;
                existingLedger.BillAmt = model.BillAmt;
                existingLedger.PayAmt = model.PayAmt;
                existingLedger.PayModeID = model.PayModeID;
                existingLedger.BankName = model.BankName;
                existingLedger.CHK_NO = model.CHK_NO;
                existingLedger.CheckDate = model.CheckDate;
                existingLedger.Reason = model.Reason;
                existingLedger.InvoiceNo = model.InvoiceNo;
                existingLedger.Comments = model.Comments;
                existingLedger.CreateBy = model.CreateBy;
                existingLedger.CreateDate = model.CreateDate;
                existingLedger.UpdateBy = model.UpdateBy;
                existingLedger.UpdateDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return Ok(new { Ledger = existingLedger, Message = "CustomerLedger Updated Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ledger = await _context.CustomerLedger.FindAsync(id);
                if (ledger == null)
                    return NotFound(new { Message = "CustomerLedger not found!" });

                _context.CustomerLedger.Remove(ledger);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "CustomerLedger deleted successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }
    }
}

