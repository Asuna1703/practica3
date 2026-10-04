
using System;
using System.Collections.Generic;
class Producto
{
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public int Precio { get; set; }
    public Producto(string nombre, string codigo, int precio)
    {
        Nombre = nombre;
        Codigo = codigo;
        Precio = precio;
    }
    public override string ToString()
    {
        return $"Nombre: {Nombre}, Codigo: {Codigo}, Precio: {Precio}";
    }
}
class Almacen
{
  Producto [] productos = {
        new Producto("Figura de gojo", "40251478", 1500),
        new Producto("Poster de hanako", "18654321", 100),
        new Producto("Llavero de kirito", "54987654", 250),
        new Producto("Figura de aome", "20211479", 1350),
        new Producto("Figura de naruto", "10235479", 1650 )};


    public Producto AgregarProducto(Producto producto)
    {
        foreach (var p in productos)
        {
            if (p.Codigo == producto.Codigo)
            {
                throw new Exception("El producto ya existe en el almacén.");
            }
        }
  
        return producto;
    }
    public Producto ObtenerProducto(string codigo)
    {
        foreach (var p in productos)
        {
            if (p.Codigo == codigo)
            {
                return p;
            }
        }
        throw new Exception("El producto no se encuentra en el almacén.");

    }
    public Producto BuscarProducto(string nombre)
    {
        foreach (var p in productos)
        {
            if (p.Nombre == nombre)
            {
                return p;
            }
        }
        throw new Exception("El producto no se encuentra en el almacén.");
    }
    public Producto EliminarProducto(string codigo)
    {
        for (int i = 0; i < productos.Length; i++)
        {
            if (productos[i].Codigo == codigo)
            {
                Producto productoEliminado = productos[i];
                
                return productoEliminado;
            }
        }
        throw new Exception("El producto no se encuentra en el almacén.");
    }

    public void MostrarProductos()
    {
        Console.WriteLine("\nEstado actual del almacén:");

        foreach (Producto producto in productos)
        {
            Console.WriteLine(producto); // Usa ToString() automáticamente
        }

        if (productos.Length == 0)
        {
            Console.WriteLine("El almacén está vacío.");
        }
    }

}

static class Program
{
    static void Main(string[] args)
    {
        Almacen almacen = new Almacen();
        try
        {
            Producto producto1 = new Producto("coco", "40451478", 1500);
            almacen.AgregarProducto(producto1);
            Console.WriteLine("Producto agregado: " + producto1);
            Producto producto2 = almacen.ObtenerProducto("40251478");
            Console.WriteLine("Producto obtenido: " + producto2);
            Producto producto3 = almacen.BuscarProducto("Poster de hanako");
            Console.WriteLine("Producto encontrado: " + producto3);
            Producto producto4 = almacen.EliminarProducto("10235479");
            Console.WriteLine("Producto eliminado: " + producto4);
            almacen.MostrarProductos();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

