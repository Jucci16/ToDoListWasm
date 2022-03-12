using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListWasm.Data;
using ToDoListWasm.Dto;
using ToDoListWasm.Model;

namespace ToDoListWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IMapper _mapper;

        public ToDoItemController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itemModels = await _dbContext.ToDoItems.OrderByDescending(t => t.ModifiedDate).ToListAsync();
            var itemDtos = _mapper.Map<List<ToDoItemDto>>(itemModels);
            return Ok(itemDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var itemModel = await _dbContext.ToDoItems.FindAsync(id);
            var item = itemModel is null ? null : _mapper.Map<ToDoItemDto>(itemModel);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoItemDto item)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var model = _mapper.Map<ToDoItemModel>(item);
            model.ModifiedDate = DateTime.Now;

            var result = await _dbContext.AddAsync(model);

            return CreatedAtAction(nameof(Get), new { Id = result.Entity.Id }, item);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] ToDoItemDto item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<ToDoItemModel>(item);
            model.ModifiedDate = DateTime.Now;

            _dbContext.Update(model);
            var result = await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _dbContext.ToDoItems.FindAsync(id);
            if (model is null)
                return BadRequest("To Do Item was not found.");

             var result = _dbContext.ToDoItems.Remove(model);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
