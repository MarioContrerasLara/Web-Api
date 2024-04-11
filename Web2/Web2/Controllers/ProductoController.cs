using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Web2.Contracts;
using Web2.Repositories;
using Web2.Models;

namespace Web2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpPost]
        public IActionResult AddProduct(Productos nuevoArticulo)
        {
            try
            {
                _productoRepository.AddProduct(nuevoArticulo);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/increase")]
        public IActionResult IncreaseQuantity(int id, int cantidad)
        {
            try
            {
                _productoRepository.IncreaseQuantity(id, cantidad);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/decrease")]
        public IActionResult DecreaseQuantity(int id, int cantidad)
        {
            try
            {
                _productoRepository.DecreaseQuantity(id, cantidad);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException)
            {
                return BadRequest("No hay suficiente cantidad en el almacen");
            }
        }
    }
}
