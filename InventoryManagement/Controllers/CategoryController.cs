using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly inventoryManagementContext _context;

        public CategoryController(inventoryManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 5;

                IQueryable<Category> query = _context.Category;

                int totalCount = await query.CountAsync();

                var categories = await query
                    .OrderBy(c => c.CategoryID)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new CategoryDTO
                    {
                        CategoryID = c.CategoryID,
                        CategoryName = c.CategoryName,
                        Description = c.Description,
                        Vat = c.Vat,
                        CreateBy = c.CreateBy,
                        CreateDate = c.CreateDate,
                        UpdateBy = c.UpdateBy,
                        UpdateDate = c.UpdateDate
                    }).
                    ToListAsync();
                return Ok(new
                {
                    Data = categories,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
                return NotFound(new { Message = "Category not found!" });

            var result = new CategoryDTO
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Vat = category.Vat,
                CreateBy = category.CreateBy,
                CreateDate = category.CreateDate,
                UpdateBy = category.UpdateBy,
                UpdateDate = category.UpdateDate
            };

            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //var entity = new Category();

                if (string.IsNullOrWhiteSpace(entity.CategoryID))
                {
                    var lastCategory = await _context.Category
                        .OrderByDescending(c => c.CategoryID)
                        .FirstOrDefaultAsync();

                    string newId = "CT001";
                    if (lastCategory != null)
                    {
                        var match = Regex.Match(lastCategory.CategoryID, @"\d+$");
                        int lastNum = match.Success ? int.Parse(match.Value) : 0;
                        string prefix = match.Success ? lastCategory.CategoryID.Substring(0, match.Index) : "CT";
                        newId = $"{prefix}{(lastNum + 1):D3}";
                    }

                    entity.CategoryID = newId;
                }
                else
                {
                    entity.CategoryID = entity.CategoryID;
                }

                entity.CategoryName = entity.CategoryName;
                entity.Description = entity.Description;
                entity.Vat = entity.Vat;
                entity.CreateBy = entity.CreateBy ?? "System";
                entity.CreateDate = DateTime.Now;
                //entity.UpdateBy = model.UpdateBy;
                //entity.UpdateDate = DateTime.Now;

                await _context.Category.AddAsync(entity);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Category created successfully!", Category = entity });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CategoryDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingCategory = await _context.Category.FindAsync(id);
                if (existingCategory == null)
                    return NotFound(new { Message = "Category not found!" });

                existingCategory.CategoryName = model.CategoryName;
                existingCategory.Description = model.Description;
                existingCategory.Vat = model.Vat ?? 0;
                existingCategory.UpdateBy = model.UpdateBy ?? "System";
                existingCategory.UpdateDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Category updated successfully!", Category = existingCategory });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                var category = await _context.Category.FindAsync(id);
                if (category == null)
                    return NotFound(new { Message = "Category not found!" });

                _context.Category.Remove(category);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Category deleted successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
