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
    public class ToDoCollectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public ToDoCollectionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _context.ToDoCollections.OrderByDescending(c => c.ModifiedDate).Include(c => c.Items).ToListAsync();
            var dtos = _mapper.Map<List<ToDoCollectionDto>>(models);

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var model = await _context.ToDoCollections.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);
            var dto = model is null ? null : _mapper.Map<ToDoCollectionDto>(model);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoCollectionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<ToDoCollectionModel>(dto);
            model.ModifiedDate = DateTime.Now;

            var result = await _context.ToDoCollections.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { Id = result.Entity.Id }, dto);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(ToDoCollectionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<ToDoCollectionModel>(dto);
            model.ModifiedDate = DateTime.Now;

            _context.Update(model);
            var result = await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.ToDoCollections.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);
            if (model is null) 
                return BadRequest("Collection does not exist with provided id: " + id);

            var result = _context.ToDoCollections.Remove(model);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
