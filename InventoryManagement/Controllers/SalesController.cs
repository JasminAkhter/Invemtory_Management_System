using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public SalesController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _context.Sales
                .Select(s => new SalesDTO
                {
                    SalesID = s.SalesID,
                    InvoiceNo = s.InvoiceNo,
                    SalesDate = s.SalesDate,
                    SalesTime = s.SalesTime,
                    OrderNo = s.OrderNo,
                    OrderDate = s.OrderDate,
                    ItemID = s.ItemID,
                    ProductInfo = s.ProductInfo,
                    PBarocde = s.PBarocde,
                    CustomerID = s.CustomerID,
                    SupplierCompanyID = s.SupplierCompanyID,
                    SalesQty = s.SalesQty,
                    SalesReturnQty = s.SalesReturnQty,
                    MRP = s.MRP,
                    TotalMRP = s.TotalMRP,
                    SalesPrice = s.SalesPrice,
                    TotalSalesPrice = s.TotalSalesPrice,
                    PurchasePrice = s.PurchasePrice,
                    TotalPurchasePrice = s.TotalPurchasePrice,
                    ItemVatPercent = s.ItemVatPercent,
                    Vat = s.vat,
                    DiscountPercentPerItem = s.DiscountPercentPerItem,
                    DiscountAmountPerItem = s.DiscountAmountPerItem,
                    TotalDiscountAmt = s.TotalDiscountAmt,
                    ChargeAmount = s.ChargeAmount,
                    NetAmount = s.NetAmount,
                    PaidAmount = s.PaidAmount,
                    ReturnAmount = s.ReturnAmount,
                    CreateBy = s.CreateBy,
                    CreateDate = s.CreateDate,
                    UpdateBy = s.UpdateBy,
                    UpdateDate = s.UpdateDate,
                    IsSalesVoid = s.IsSalesVoid,
                    CustomerPreviousDue = s.CustomerPerviousDue,
                    IsFree = s.IsFree,
                    NetSalesAmount = s.NetSalesAmount,
                    ConeQty = s.ConeQty
                })
                .ToListAsync();

            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return NotFound(new { Message = "Sale not found!" });

            var result = new SalesDTO
            {
                SalesID = sale.SalesID,
                InvoiceNo = sale.InvoiceNo,
                SalesDate = sale.SalesDate,
                SalesTime = sale.SalesTime,
                OrderNo = sale.OrderNo,
                OrderDate = sale.OrderDate,
                ItemID = sale.ItemID,
                ProductInfo = sale.ProductInfo,
                PBarocde = sale.PBarocde,
                CustomerID = sale.CustomerID,
                SupplierCompanyID = sale.SupplierCompanyID,
                SalesQty = sale.SalesQty,
                SalesReturnQty = sale.SalesReturnQty,
                MRP = sale.MRP,
                TotalMRP = sale.TotalMRP,
                SalesPrice = sale.SalesPrice,
                TotalSalesPrice = sale.TotalSalesPrice,
                PurchasePrice = sale.PurchasePrice,
                TotalPurchasePrice = sale.TotalPurchasePrice,
                ItemVatPercent = sale.ItemVatPercent,
                Vat = sale.vat,
                DiscountPercentPerItem = sale.DiscountPercentPerItem,
                DiscountAmountPerItem = sale.DiscountAmountPerItem,
                TotalDiscountAmt = sale.TotalDiscountAmt,
                ChargeAmount = sale.ChargeAmount,
                NetAmount = sale.NetAmount,
                PaidAmount = sale.PaidAmount,
                ReturnAmount = sale.ReturnAmount,
                CreateBy = sale.CreateBy,
                CreateDate = sale.CreateDate,
                UpdateBy = sale.UpdateBy,
                UpdateDate = sale.UpdateDate,
                IsSalesVoid = sale.IsSalesVoid,
                CustomerPreviousDue = sale.CustomerPerviousDue,
                IsFree = sale.IsFree,
                NetSalesAmount = sale.NetSalesAmount,
                ConeQty = sale.ConeQty
            };

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SalesDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new Sales
            {
                InvoiceNo = model.InvoiceNo,
                SalesDate = model.SalesDate ?? DateTime.Now,
                SalesTime = model.SalesTime ?? DateTime.Now,
                OrderNo = model.OrderNo,
                OrderDate = model.OrderDate,
                ItemID = model.ItemID,
                ProductInfo = model.ProductInfo,
                PBarocde = model.PBarocde,
                CustomerID = model.CustomerID,
                SupplierCompanyID = model.SupplierCompanyID,
                SalesQty = model.SalesQty,
                SalesReturnQty = model.SalesReturnQty,
                MRP = model.MRP,
                TotalMRP = model.TotalMRP,
                SalesPrice = model.SalesPrice,
                TotalSalesPrice = model.TotalSalesPrice,
                PurchasePrice = model.PurchasePrice,
                TotalPurchasePrice = model.TotalPurchasePrice,
                ItemVatPercent = model.ItemVatPercent,
                vat = model.Vat,
                DiscountPercentPerItem = model.DiscountPercentPerItem,
                DiscountAmountPerItem = model.DiscountAmountPerItem,
                TotalDiscountAmt = model.TotalDiscountAmt,
                ChargeAmount = model.ChargeAmount,
                NetAmount = model.NetAmount,
                PaidAmount = model.PaidAmount,
                ReturnAmount = model.ReturnAmount,
                CreateBy = model.CreateBy,
                CreateDate = DateTime.Now,
                UpdateBy = model.UpdateBy,
                UpdateDate = DateTime.Now,
                IsSalesVoid = model.IsSalesVoid,
                CustomerPerviousDue = model.CustomerPreviousDue,
                IsFree = model.IsFree,
                NetSalesAmount = model.NetSalesAmount,
                ConeQty = model.ConeQty
            };

            await _context.Sales.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.SalesID }, entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SalesDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingSale = await _context.Sales.FindAsync(id);
            if (existingSale == null)
                return NotFound(new { Message = "Sale not found!" });

            existingSale.InvoiceNo = model.InvoiceNo;
            existingSale.SalesDate = model.SalesDate;
            existingSale.SalesTime = model.SalesTime;
            existingSale.OrderNo = model.OrderNo;
            existingSale.OrderDate = model.OrderDate;
            existingSale.ItemID = model.ItemID;
            existingSale.ProductInfo = model.ProductInfo;
            existingSale.PBarocde = model.PBarocde;
            existingSale.CustomerID = model.CustomerID;
            existingSale.SupplierCompanyID = model.SupplierCompanyID;
            existingSale.SalesQty = model.SalesQty;
            existingSale.SalesReturnQty = model.SalesReturnQty;
            existingSale.MRP = model.MRP;
            existingSale.TotalMRP = model.TotalMRP;
            existingSale.SalesPrice = model.SalesPrice;
            existingSale.TotalSalesPrice = model.TotalSalesPrice;
            existingSale.PurchasePrice = model.PurchasePrice;
            existingSale.TotalPurchasePrice = model.TotalPurchasePrice;
            existingSale.ItemVatPercent = model.ItemVatPercent;
            existingSale.vat = model.Vat;
            existingSale.DiscountPercentPerItem = model.DiscountPercentPerItem;
            existingSale.DiscountAmountPerItem = model.DiscountAmountPerItem;
            existingSale.TotalDiscountAmt = model.TotalDiscountAmt;
            existingSale.ChargeAmount = model.ChargeAmount;
            existingSale.NetAmount = model.NetAmount;
            existingSale.PaidAmount = model.PaidAmount;
            existingSale.ReturnAmount = model.ReturnAmount;
            existingSale.UpdateBy = model.UpdateBy;
            existingSale.UpdateDate = DateTime.Now;
            existingSale.IsSalesVoid = model.IsSalesVoid;
            existingSale.CustomerPerviousDue = model.CustomerPreviousDue;
            existingSale.IsFree = model.IsFree;
            existingSale.NetSalesAmount = model.NetSalesAmount;
            existingSale.ConeQty = model.ConeQty;

            await _context.SaveChangesAsync();

            return Ok(new { Sale = existingSale, Message = "Sale updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSale = await _context.Sales.FindAsync(id);
            if (existingSale == null)
                return NotFound(new { Message = "Sale not found!" });

            _context.Sales.Remove(existingSale);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Sale deleted successfully!" });
        }
    }
}
