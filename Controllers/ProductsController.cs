using Kolokwium.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(ApplicationDbContext context) : base(context)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var persons = await context.Products.ToListAsync();

                return Ok(persons);

            }
            catch
            {
                return this.Problem(
                    detail: "Bład po",
                    title: "Błąd"
                    );
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var person = await context.Products.SingleOrDefaultAsync(p => p.Id == id);

                if (person == null)
                    return NotFound($"Nie znaleziono produkyu o id = {id}");
                else
                    return Ok(person);
            }
            catch
            {
                return this.Problem(
                    detail: "Bład po",
                    title: "Błąd"
                    );
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            catch
            {
                return this.Problem(
                    detail: "Bład po",
                    title: "Błąd"
                    );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct([FromBody] Product product, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var editedProduct = await context.Products.SingleOrDefaultAsync(p => p.Id == id);

                if (editedProduct == null)
                    return NotFound($"Nie znaleziono produkyu o id = {id}");
                else
                {
                    editedProduct.Name = product.Name;
                    editedProduct.Price = product.Price;
                    editedProduct.Type = product.Type;

                    context.Update(editedProduct);
                    await context.SaveChangesAsync();

                    return Ok(editedProduct);
                }
            }
            catch
            {
                return this.Problem(
                    detail: "Bład po",
                    title: "Błąd"
                    );
            }
        }
    }
}
