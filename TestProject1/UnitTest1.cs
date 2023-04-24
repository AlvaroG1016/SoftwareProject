using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ReactVentas.Controllers;
using ReactVentas.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly ProductoController _controller;
        private readonly DBREACT_VENTAContext _context;
        private readonly RolController _rolcontroller;
        private readonly CategoriaController _categoriacontroller;

        public UnitTest1()
        {
            _context = new DBREACT_VENTAContext() ;
            _controller = new ProductoController(_context);
            _rolcontroller = new RolController(_context);
            _categoriacontroller = new CategoriaController(_context);   

        }

        [Fact]
        public void Quantity_Products()
        {   
            //validamos si existen Productos
            var result = _context.Productos;
            Assert.True(result != null);
        }
        [Fact]
        public void Quantity_Rol()
        {
            //validamos si existen Roles
            var result = _rolcontroller.Lista().Result;
            Assert.True(result != null);
        }
        [Fact]
        public void Quantity_Categorias()
        {
            //validamos si existen CATEGORIAS   
            var result = _categoriacontroller.Lista().Result;
            Assert.True(result != null);
        }
        [Fact]
        public void IsType()
        {
            //Prueba para validar si el tipo de productos que recibimos es el esperado
            var res = _controller.Lista().Result;
            Assert.IsType<ObjectResult>(res);
         
        }
        [Fact]
        public void sd()
        {
            //Prueba para validar si recibimos el mismo codigo
            int id = 1;
            var res = (ObjectResult)_controller.Lista().Result;
            var prd = Assert.IsType<Producto>(res?.Value);

            Assert.True(prd.Codigo == "2");

        }
    }
}