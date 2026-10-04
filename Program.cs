
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
        for (int i = 0; i < productos.Count; i++)
        {
            if (productos[i].Codigo == codigo)
            {
                Producto productoEliminado = productos[i];
                productos.RemoveAt(i);
                return productoEliminado;
            }
        }
        throw new Exception("El producto no se encuentra en el almacén.");
    }
}
static class Program
{
    static void Main(string[] args)
    {
        Almacen almacen = new Almacen();
        try
        {
            Producto producto1 = new Producto("Figura de gojo", "40251478", 1500);
            almacen.AgregarProducto(producto1);
            Console.WriteLine("Producto agregado: " + producto1.Nombre);
            Producto producto2 = almacen.ObtenerProducto("40251478");
            Console.WriteLine("Producto obtenido: " + producto2.Nombre);
            Producto producto3 = almacen.BuscarProducto("Poster de hanako");
            Console.WriteLine("Producto encontrado: " + producto3.Nombre);
            Producto producto4 = almacen.EliminarProducto("40251478");
            Console.WriteLine("Producto eliminado: " + producto4.Nombre);
            Producto producto5 = almacen.ObtenerProducto("18654321");
            Console.WriteLine("Producto obtenido: " + producto5.Nombre);


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

