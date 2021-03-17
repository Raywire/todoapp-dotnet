using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapp_dotnet.Data;
using todoapp_dotnet.Models;
using todoapp_dotnet.Models.DTOs.Requests;

namespace todoapp_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private IMapper _mapper;

        public TodoController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(TodoCreateDto data)
        {
            if(ModelState.IsValid)
            {
                var todoModel = _mapper.Map<ItemData>(data);
                await _context.Items.AddAsync(todoModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItem", new {todoModel.Id}, data);
            }

            return new JsonResult("Data is not valid") {StatusCode = 422};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemData item)
        {
            if(id != item.Id)
                return BadRequest();

            var itemExists = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(itemExists == null)
                return NotFound();
            itemExists.Title = item.Title;
            itemExists.Description = item.Description;
            itemExists.Done = item.Done;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var itemExists = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(itemExists == null)
                return NotFound();

            _context.Items.Remove(itemExists);
            await _context.SaveChangesAsync();
            
            return Ok(itemExists);
        }
    }
}