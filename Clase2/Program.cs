﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Clase2.DAL;

namespace Clase2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //gestion del producto 
            ServicioDeProductos servicioProducto = new ServicioDeProductos();
            NuevoProducto nuevoProducto = new NuevoProducto();
            nuevoProducto.Nombre = "produto 2";
            nuevoProducto.CantidadMinima = 10;
            nuevoProducto.StockActual = 20;
            servicioProducto.CrearUnNuevoProducto(nuevoProducto);

            //imprimir en consola lista de productos
            servicioProducto.ListarTodosLosProductos().ForEach(producto => Console.WriteLine(producto.Nombre));
            Console.ReadKey();*/


            //gestion del usuario 
            ServicioDeUsuario servicioUsuario = new ServicioDeUsuario();
            /*NuevoUsuario nuevoUsuario = new NuevoUsuario();
            nuevoUsuario.Nombre = "jose";
            nuevoUsuario.Clave = "pepe";
            nuevoUsuario.habilitado = false;
            servicioUsuario.CrearUnNuevoUsuario(nuevoUsuario);*/

            servicioUsuario.BorrarUsuario(3);




            //imprimir en consola lista de usuarios
            servicioUsuario.ListarTodosLosUsuarios().ForEach(usuario => Console.WriteLine(usuario.Nombre));
            Console.ReadKey();
        }
    }
}
