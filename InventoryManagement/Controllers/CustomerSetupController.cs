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
    public class CustomerSetupController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public CustomerSetupController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.CustomerSetup
                .Select(c => new CustomerSetupDTO
                {
                    CustomerID = c.CustomerID,
                    CustomerName = c.CustomerName,
                    ContactName = c.ContactName,
                    DealerBussinessName = c.DealerBussinessName,
                    Address = c.Address,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Mobile1 = c.Mobile1,
                    Mobile2 = c.Mobile2,
                    DueLimit = c.DueLimit,
                    Gread = c.Gread,
                    CREATE_BY = c.CREATE_BY,
                    CREATE_DATE = c.CREATE_DATE,
                    UPDATE_BY = c.UPDATE_BY,
                    UPDATE_DATE = c.UPDATE_DATE,
                    InActive = c.InActive,
                    AdvanceAmt = c.AdvanceAmt,
                    DueAmount = c.DueAmount
                })
                .ToListAsync();

            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _context.CustomerSetup.FindAsync(id);
            if (customer == null)
                return NotFound(new { Message = "Customer not found!" });

            var result = new CustomerSetupDTO
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                ContactName = customer.ContactName,
                DealerBussinessName = customer.DealerBussinessName,
                Address = customer.Address,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Mobile1 = customer.Mobile1,
                Mobile2 = customer.Mobile2,
                DueLimit = customer.DueLimit,
                Gread = customer.Gread,
                CREATE_BY = customer.CREATE_BY,
                CREATE_DATE = customer.CREATE_DATE,
                UPDATE_BY = customer.UPDATE_BY,
                UPDATE_DATE = customer.UPDATE_DATE,
                InActive = customer.InActive,
                AdvanceAmt = customer.AdvanceAmt,
                DueAmount = customer.DueAmount
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerSetupDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CustomerSetup();

            if (string.IsNullOrWhiteSpace(model.CustomerID))
            {
                var lastCustomer = await _context.CustomerSetup
                    .OrderByDescending(c => c.CustomerID)
                    .FirstOrDefaultAsync();

                string newId = "CU001";
                if (lastCustomer != null && !string.IsNullOrEmpty(lastCustomer.CustomerID))
                {
                    var match = Regex.Match(lastCustomer.CustomerID, @"\d+$");
                    if (match.Success)
                    {
                        int lastNum = int.Parse(match.Value);
                        string prefix = lastCustomer.CustomerID.Substring(0, match.Index);
                        newId = $"{prefix}{(lastNum + 1):D3}";
                    }
                }

                entity.CustomerID = newId;
            }
            else
            {
                entity.CustomerID = model.CustomerID;
            }

            entity.CustomerName = model.CustomerName;
            entity.ContactName = model.ContactName;
            entity.DealerBussinessName = model.DealerBussinessName;
            entity.Address = model.Address;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Mobile1 = model.Mobile1;
            entity.Mobile2 = model.Mobile2;
            entity.DueLimit = model.DueLimit;
            entity.Gread = model.Gread;
            entity.CREATE_BY = model.CREATE_BY;
            entity.CREATE_DATE = model.CREATE_DATE ?? DateTime.Now;  
            entity.UPDATE_BY = model.UPDATE_BY;
            entity.UPDATE_DATE = model.UPDATE_DATE ?? DateTime.Now;  
            entity.InActive = model.InActive;
            entity.AdvanceAmt = model.AdvanceAmt;
            entity.DueAmount = model.DueAmount;

            await _context.CustomerSetup.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CustomerSetupDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCustomer = await _context.CustomerSetup.FindAsync(id);
            if (existingCustomer == null)
                return NotFound(new { Message = "Customer not found!" });

            existingCustomer.CustomerName = model.CustomerName;
            existingCustomer.ContactName = model.ContactName;
            existingCustomer.DealerBussinessName = model.DealerBussinessName;
            existingCustomer.Address = model.Address;
            existingCustomer.Email = model.Email;
            existingCustomer.PhoneNumber = model.PhoneNumber;
            existingCustomer.Mobile1 = model.Mobile1;
            existingCustomer.Mobile2 = model.Mobile2;
            existingCustomer.DueLimit = model.DueLimit;
            existingCustomer.Gread = model.Gread;
            existingCustomer.CREATE_BY = model.CREATE_BY;
            existingCustomer.CREATE_DATE = model.CREATE_DATE ?? existingCustomer.CREATE_DATE ?? DateTime.Now;
            existingCustomer.UPDATE_BY = model.UPDATE_BY;
            existingCustomer.UPDATE_DATE = DateTime.Now;  
            existingCustomer.InActive = model.InActive;
            existingCustomer.AdvanceAmt = model.AdvanceAmt;
            existingCustomer.DueAmount = model.DueAmount;

            await _context.SaveChangesAsync();

            return Ok(new { Customer = existingCustomer, Message = "Customer Updated Successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                var customer = await _context.CustomerSetup.FindAsync(id);
                if (customer == null)
                    return NotFound(new { Message = "Customer not found!" });

                _context.CustomerSetup.Remove(customer);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Customer deleted successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
