using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemReceiveController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public ItemReceiveController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itemReceives = await _context.ItemReceive
                .Select(ir => new ItemReceiveDTO
                {
                    Id = ir.id,
                    ChalanNo = ir.ChalanNo,
                    SupplierCompanyID = ir.SupplierCompanyID,
                    ItemID = ir.ItemID,
                    PurchasePrice = ir.purchasePrice,
                    TotalPurchasePrice = ir.TotalPurchasePrice,
                    SalesPrice = ir.SalesPrice,
                    TotalSalesPrice = ir.TotalSalesPrice,
                    WholeSalesPrice = ir.WholeSalesPrice,
                    DiscountPercent = ir.DiscountPersent,
                    TradePrice = ir.TradePrice,
                    ProfitPercent = ir.ProfitPersent,
                    ProfitAmt = ir.ProfitAmt,
                    ReceiveDate = ir.ReceiveDate,
                    ReceiveQTY = ir.ReceiveQTY,
                    TotalRecQty = ir.TotalRecQty,
                    TotalAmount = ir.TotalAmount,
                    ItemInfo = ir.ItemInfo,
                    CreateBy = ir.CREATE_BY,
                    CreateDate = ir.CREATE_DATE,
                    UpdateBy = ir.UPDATE_BY,
                    UpdateDate = ir.UPDATE_DATE,
                    MemoNo = ir.MemoNo
                })
                .ToListAsync();

            return Ok(itemReceives);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ir = await _context.ItemReceive.FindAsync(id);
            if (ir == null)
                return NotFound(new { Message = "Item Receive record not found!" });

            var dto = new ItemReceiveDTO
            {
                Id = ir.id,
                ChalanNo = ir.ChalanNo,
                SupplierCompanyID = ir.SupplierCompanyID,
                ItemID = ir.ItemID,
                PurchasePrice = ir.purchasePrice,
                TotalPurchasePrice = ir.TotalPurchasePrice,
                SalesPrice = ir.SalesPrice,
                TotalSalesPrice = ir.TotalSalesPrice,
                WholeSalesPrice = ir.WholeSalesPrice,
                DiscountPercent = ir.DiscountPersent,
                TradePrice = ir.TradePrice,
                ProfitPercent = ir.ProfitPersent,
                ProfitAmt = ir.ProfitAmt,
                ReceiveDate = ir.ReceiveDate,
                ReceiveQTY = ir.ReceiveQTY,
                TotalRecQty = ir.TotalRecQty,
                TotalAmount = ir.TotalAmount,
                ItemInfo = ir.ItemInfo,
                CreateBy = ir.CREATE_BY,
                CreateDate = ir.CREATE_DATE,
                UpdateBy = ir.UPDATE_BY,
                UpdateDate = ir.UPDATE_DATE,
                MemoNo = ir.MemoNo
            };

            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemReceiveDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ItemReceive
            {
                ChalanNo = model.ChalanNo,
                SupplierCompanyID = model.SupplierCompanyID,
                ItemID = model.ItemID,
                purchasePrice = model.PurchasePrice,
                TotalPurchasePrice = model.TotalPurchasePrice,
                SalesPrice = model.SalesPrice,
                TotalSalesPrice = model.TotalSalesPrice,
                WholeSalesPrice = model.WholeSalesPrice,
                DiscountPersent = model.DiscountPercent,
                TradePrice = model.TradePrice,
                ProfitPersent = model.ProfitPercent,
                ProfitAmt = model.ProfitAmt,
                ReceiveDate = model.ReceiveDate,
                ReceiveQTY = model.ReceiveQTY,
                TotalRecQty = model.TotalRecQty,
                TotalAmount = model.TotalAmount,
                ItemInfo = model.ItemInfo,
                CREATE_BY = model.CreateBy,
                CREATE_DATE = model.CreateDate ?? DateOnly.FromDateTime(DateTime.Now),
                UPDATE_BY = model.UpdateBy,
                UPDATE_DATE = model.UpdateDate ?? DateOnly.FromDateTime(DateTime.Now),
                MemoNo = model.MemoNo
            };

            await _context.ItemReceive.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Item Receive record created successfully!", entity });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ItemReceiveDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.ItemReceive.FindAsync(id);
            if (existing == null)
                return NotFound(new { Message = "Item Receive record not found!" });

            existing.ChalanNo = model.ChalanNo;
            existing.SupplierCompanyID = model.SupplierCompanyID;
            existing.ItemID = model.ItemID;
            existing.purchasePrice = model.PurchasePrice;
            existing.TotalPurchasePrice = model.TotalPurchasePrice;
            existing.SalesPrice = model.SalesPrice;
            existing.TotalSalesPrice = model.TotalSalesPrice;
            existing.WholeSalesPrice = model.WholeSalesPrice;
            existing.DiscountPersent = model.DiscountPercent;
            existing.TradePrice = model.TradePrice;
            existing.ProfitPersent = model.ProfitPercent;
            existing.ProfitAmt = model.ProfitAmt;
            existing.ReceiveDate = model.ReceiveDate;
            existing.ReceiveQTY = model.ReceiveQTY;
            existing.TotalRecQty = model.TotalRecQty;
            existing.TotalAmount = model.TotalAmount;
            existing.ItemInfo = model.ItemInfo;
            existing.UPDATE_BY = model.UpdateBy;
            existing.UPDATE_DATE = model.UpdateDate ?? DateOnly.FromDateTime(DateTime.Now);
            existing.MemoNo = model.MemoNo;

            await _context.SaveChangesAsync();

            return Ok(new { Message = "Item Receive record updated successfully!", existing });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _context.ItemReceive.FindAsync(id);
                if (record == null)
                    return NotFound(new { Message = "Item Receive record not found!" });

                _context.ItemReceive.Remove(record);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Item Receive record deleted successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
