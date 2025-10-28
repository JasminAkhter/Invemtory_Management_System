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
    public class ItemController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public ItemController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.Item
                .Select(i => new ItemDTO
                {
                    Item_Id = i.Item_Id,
                    ItemName = i.ItemName,
                    CategoryID = i.CategoryID,
                    ModelID = i.ModelID,
                    BrandID = i.BrandID,
                    SizeID = i.SizeID,
                    ColorID = i.ColorID,
                    UomID = i.UomID,
                    SupplierCompanyID = i.SupplierCompanyID,
                    ProductBarcode = i.ProductBarcode,
                    BarCode1 = i.BarCode1,
                    Barcode2 = i.Barcode2,
                    PurchasePrice = i.PurchasePrice,
                    SalesPrice = i.SalesPrice,
                    WholeSalesPrice = i.WholeSalesPrice,
                    DiscountPersent = i.DiscountPersent,
                    TradePrice = i.TradePrice,
                    ProfitPersent = i.ProfitPersent,
                    ProfitAmt = i.ProfitAmt,
                    CREATE_BY = i.CREATE_BY,
                    CREATE_DATE = i.CREATE_DATE,
                    UPDATE_BY = i.UPDATE_BY,
                    UPDATE_DATE = i.UPDATE_DATE,
                    InActive = i.InActive,
                    OpeningStock = i.OpeningStock,
                    MinimumAlertQty = i.MinimumAlertQty
                })
                .ToListAsync();

            return Ok(items);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
                return NotFound(new { Message = "Item not found!" });

            var result = new ItemDTO
            {
                Item_Id = item.Item_Id,
                ItemName = item.ItemName,
                CategoryID = item.CategoryID,
                ModelID = item.ModelID,
                BrandID = item.BrandID,
                SizeID = item.SizeID,
                ColorID = item.ColorID,
                UomID = item.UomID,
                SupplierCompanyID = item.SupplierCompanyID,
                ProductBarcode = item.ProductBarcode,
                BarCode1 = item.BarCode1,
                Barcode2 = item.Barcode2,
                PurchasePrice = item.PurchasePrice,
                SalesPrice = item.SalesPrice,
                WholeSalesPrice = item.WholeSalesPrice,
                DiscountPersent = item.DiscountPersent,
                TradePrice = item.TradePrice,
                ProfitPersent = item.ProfitPersent,
                ProfitAmt = item.ProfitAmt,
                CREATE_BY = item.CREATE_BY,
                CREATE_DATE = item.CREATE_DATE,
                UPDATE_BY = item.UPDATE_BY,
                UPDATE_DATE = item.UPDATE_DATE,
                InActive = item.InActive,
                OpeningStock = item.OpeningStock,
                MinimumAlertQty = item.MinimumAlertQty
            };

            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new Item();

            if (string.IsNullOrWhiteSpace(model.Item_Id))
            {
                var lastItem = await _context.Item
                    .OrderByDescending(i => i.Item_Id)
                    .FirstOrDefaultAsync();

                string newId = "IT001";
                if (lastItem != null && !string.IsNullOrEmpty(lastItem.Item_Id))
                {
                    var match = Regex.Match(lastItem.Item_Id, @"\d+$");
                    if (match.Success)
                    {
                        int lastNum = int.Parse(match.Value);
                        string prefix = lastItem.Item_Id.Substring(0, match.Index);
                        newId = $"{prefix}{(lastNum + 1):D3}";
                    }
                }

                entity.Item_Id = newId;
            }
            else
            {
                entity.Item_Id = model.Item_Id;
            }

            entity.ItemName = model.ItemName;
            entity.CategoryID = model.CategoryID;
            entity.ModelID = model.ModelID;
            entity.BrandID = model.BrandID;
            entity.SizeID = model.SizeID;
            entity.ColorID = model.ColorID;
            entity.UomID = model.UomID;
            entity.SupplierCompanyID = model.SupplierCompanyID;
            entity.ProductBarcode = model.ProductBarcode;
            entity.BarCode1 = model.BarCode1;
            entity.Barcode2 = model.Barcode2;
            entity.PurchasePrice = model.PurchasePrice;
            entity.SalesPrice = model.SalesPrice;
            entity.WholeSalesPrice = model.WholeSalesPrice;
            entity.DiscountPersent = model.DiscountPersent;
            entity.TradePrice = model.TradePrice;
            entity.ProfitPersent = model.ProfitPersent;
            entity.ProfitAmt = model.ProfitAmt;
            entity.CREATE_BY = model.CREATE_BY;
            entity.CREATE_DATE = model.CREATE_DATE ?? DateTime.Now;
            entity.UPDATE_BY = model.UPDATE_BY;
            entity.UPDATE_DATE = model.UPDATE_DATE ?? DateTime.Now;
            entity.InActive = model.InActive;
            entity.OpeningStock = model.OpeningStock;
            entity.MinimumAlertQty = model.MinimumAlertQty;

            await _context.Item.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ItemDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingItem = await _context.Item.FindAsync(id);
            if (existingItem == null)
                return NotFound(new { Message = "Item not found!" });

            existingItem.ItemName = model.ItemName;
            existingItem.CategoryID = model.CategoryID;
            existingItem.ModelID = model.ModelID;
            existingItem.BrandID = model.BrandID;
            existingItem.SizeID = model.SizeID;
            existingItem.ColorID = model.ColorID;
            existingItem.UomID = model.UomID;
            existingItem.SupplierCompanyID = model.SupplierCompanyID;
            existingItem.ProductBarcode = model.ProductBarcode;
            existingItem.BarCode1 = model.BarCode1;
            existingItem.Barcode2 = model.Barcode2;
            existingItem.PurchasePrice = model.PurchasePrice;
            existingItem.SalesPrice = model.SalesPrice;
            existingItem.WholeSalesPrice = model.WholeSalesPrice;
            existingItem.DiscountPersent = model.DiscountPersent;
            existingItem.TradePrice = model.TradePrice;
            existingItem.ProfitPersent = model.ProfitPersent;
            existingItem.ProfitAmt = model.ProfitAmt;
            existingItem.CREATE_BY = existingItem.CREATE_BY;
            existingItem.CREATE_DATE = existingItem.CREATE_DATE;
            existingItem.UPDATE_BY = model.UPDATE_BY;
            existingItem.UPDATE_DATE = model.UPDATE_DATE ?? DateTime.Now;
            existingItem.InActive = model.InActive;
            existingItem.OpeningStock = model.OpeningStock;
            existingItem.MinimumAlertQty = model.MinimumAlertQty;

            await _context.SaveChangesAsync();

            return Ok(new { Item = existingItem, Message = "Item Updated Successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
                return NotFound(new { Message = "Item not found!" });

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Item deleted successfully!" });
        }

    }
}
