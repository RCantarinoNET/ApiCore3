using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetContoso.Data;
using PetContoso.Models;

namespace PetContoso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ContosoPetsContext _petsContext;
        public ProductsController( ContosoPetsContext petsContext)
        {
            _petsContext = petsContext;

        }

        [HttpGet]
        public async Task<List<Product>> GetAll() => await _petsContext.Products.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(long id)
        {
            var _produto = await _petsContext.Products.FindAsync(id);
            if (_produto == default) return NotFound();

            return _produto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            _petsContext.Products.Add(product);
            await _petsContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById) , new { id  = product.Id} , product);
        }
        
        [HttpPut]
        public async Task<ActionResult<Product>> Update(long id, Product product)
        {
            if (id != product.Id) return BadRequest();

            _petsContext.Entry(product).State = EntityState.Modified;
            await _petsContext.SaveChangesAsync();
            return NoContent();
        }
        
        
        [HttpDelete]
        public async Task<ActionResult<Product>> Delete(long id)
        {
            var _produto = await _petsContext.Products.FindAsync(id);
            if (_produto == default) return NotFound();

            _petsContext.Entry(_produto).State = EntityState.Deleted;
            await _petsContext.SaveChangesAsync();

            return NoContent();
        }
    }
}