using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Web2.Contracts;
using Web2.Models;

namespace Web2.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        const string JSON_PATH = @"C:\Users\I44099\OneDrive - Verisk Analytics\Documents\LemonCode\C#\Ejercicios\Test Unitario\Web2\Web2\Resources\Almacen.json";

        public void AddProduct(Productos nuevoArticulo)
        {
            var productos = GetProductsFromFile();
            productos.Add(nuevoArticulo);
            File.WriteAllText(JSON_PATH, JsonConvert.SerializeObject(productos));
        }

        public void DecreaseQuantity(int id, int cantidad)
        {
            var productos = GetProductsFromFile();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                throw new KeyNotFoundException();
            if (producto.Cantidad < cantidad)
                throw new InvalidOperationException("No hay suficiente cantidad en el almacen");
            producto.Cantidad -= cantidad;
            File.WriteAllText(JSON_PATH, JsonConvert.SerializeObject(productos));
        }

        public void IncreaseQuantity(int id, int cantidad)
        {
            var productos = GetProductsFromFile();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                throw new KeyNotFoundException();
            producto.Cantidad += cantidad;
            File.WriteAllText(JSON_PATH, JsonConvert.SerializeObject(productos));
        }

        private List<Productos> GetProductsFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return JsonConvert.DeserializeObject<List<Productos>>(json);
        }
    }
}
