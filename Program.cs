using System;
using System.Collections.Generic;

namespace Reporteria
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una lista para almacenar los productos de la reportaría
            List<Producto> reporteria = new List<Producto>();

            // Iniciamos un ciclo infinito para que la aplicación siga ejecutándose hasta que el usuario decida salir
            while (true)
            {
                // Mostramos un menú de opciones
                Console.WriteLine("Bienvenido a la reportaría.");
                Console.WriteLine("Por favor seleccione una opción:");
                Console.WriteLine("1. Agregar un producto");
                Console.WriteLine("2. Listar productos");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Actulizar");
                Console.WriteLine("5. salir");

                // Leemos la opción elegida por el usuario
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Pedimos al usuario que ingrese los detalles del producto
                        Console.WriteLine("Ingrese el nombre del producto:");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el precio del producto:");
                        decimal precio = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Ingrese la cantidad del producto:");
                        int cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese la descripción del producto:");
                        string descripcion = Console.ReadLine();

                        // Creamos un nuevo producto
                        Producto producto = new Producto(nombre, precio, cantidad, descripcion);

                        // Agregamos el producto a la lista
                        reporteria.Add(producto);

                        // Mostramos un mensaje de confirmación
                        Console.WriteLine("Producto agregado con éxito.");
                        break;

                    case 2:
                        // Mostramos la lista de productos
                        Console.WriteLine("Productos en la reportaría:");

                        for (int i = 0; i < reporteria.Count; i++)
                        {
                            Console.WriteLine($"Producto #{i + 1}");
                            Console.WriteLine($"Nombre: {reporteria[i].Nombre}");
                            Console.WriteLine($"Precio: {reporteria[i].Precio:C}");
                            Console.WriteLine($"Cantidad: {reporteria[i].Cantidad}");
                            Console.WriteLine($"Descripción: {reporteria[i].Descripcion}");
                            Console.WriteLine();
                        }

                        break;
                    case 3:
                        // Pedimos al usuario que ingrese el índice del producto que desea eliminar
                        Console.WriteLine("Ingrese el índice del producto que desea eliminar:");
                        int indiceEliminar = Convert.ToInt32(Console.ReadLine());

                        // Verificamos si el índice es válido
                        if (indiceEliminar >= 0 && indiceEliminar < reporteria.Count)
                        {
                            // Eliminamos el producto de la lista
                            reporteria.RemoveAt(indiceEliminar);

                            // Mostramos un mensaje de confirmación
                            Console.WriteLine("Producto eliminado con éxito.");
                        }
                        else
                        {
                            // Mostramos un mensaje de error si el índice no es válido
                            Console.WriteLine("Índice inválido. Por favor seleccione un índice válido.");
                        }

                        break;

                    case 4:
                        // Pedimos al usuario que ingrese el índice del producto que desea actualizar
                        Console.WriteLine("Ingrese el índice del producto que desea actualizar:");
                        int indiceActualizar = Convert.ToInt32(Console.ReadLine());

                        // Verificamos si el índice es válido
                        if (indiceActualizar >= 0 && indiceActualizar < reporteria.Count)
                        {
                            // Mostramos los detalles del producto actual
                            Console.WriteLine($"Producto #{indiceActualizar + 1}");
                            Console.WriteLine($"Nombre: {reporteria[indiceActualizar].Nombre}");
                            Console.WriteLine($"Precio: {reporteria[indiceActualizar].Precio:C}");
                            Console.WriteLine($"Cantidad: {reporteria[indiceActualizar].Cantidad}");
                            Console.WriteLine($"Descripción: {reporteria[indiceActualizar].Descripcion}");
                            Console.WriteLine();

                            // Pedimos al usuario que ingrese los nuevos detalles del producto
                            Console.WriteLine("Ingrese el nuevo nombre del producto (o deje en blanco para mantener el nombre actual):");
                            string nuevoNombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el nuevo precio del producto (o deje en blanco para mantener el precio actual):");
                            string nuevoPrecioString = Console.ReadLine();
                            decimal nuevoPrecio = reporteria[indiceActualizar].Precio;
                            if (!string.IsNullOrEmpty(nuevoPrecioString))
                            {
                                nuevoPrecio = Convert.ToDecimal(nuevoPrecioString);
                            }

                            Console.WriteLine("Ingrese la nueva cantidad del producto (o deje en blanco para mantener la cantidad actual):");
                            string nuevaCantidadString = Console.ReadLine();
                            int nuevaCantidad = reporteria[indiceActualizar].Cantidad;
                            if (!string.IsNullOrEmpty(nuevaCantidadString))
                            {
                                nuevaCantidad = Convert.ToInt32(nuevaCantidadString);
                            }

                            Console.WriteLine("Ingrese la nueva descripción del producto (o deje en blanco para mantener la descripción actual):");
                            string nuevaDescripcion = Console.ReadLine();

                            // Actualizamos el producto
                            if (!string.IsNullOrEmpty(nuevoNombre))
                            {
                                reporteria[indiceActualizar].Nombre = nuevoNombre;
                            }
                            reporteria[indiceActualizar].Precio = nuevoPrecio;
                            reporteria[indiceActualizar].Cantidad = nuevaCantidad;
                            if (!string.IsNullOrEmpty(nuevaDescripcion))
                            {
                                reporteria[indiceActualizar].Descripcion = nuevaDescripcion;
                            }

                            // Mostramos un mensaje de confirmación
                            Console.WriteLine("Producto actualizado con éxito.");
                        }
                        else
                        {
                            // Mostramos un mensaje de error si el índice no es válido
                            Console.WriteLine("Índice inválido. Por favor seleccione un índice válido.");
                        }

                        break;


                    case 5:
                        // Salimos de la aplicación
                        Console.WriteLine("Gracias por usar la reportaría. ¡Hasta luego!");
                        return;

                    default:
                        // Mostramos un mensaje de error si la opción seleccionada no es válida
                        Console.WriteLine("Opción inválida. Por favor seleccione una opción válida.");
                        break;
                }

                Console.WriteLine(); // Salto de línea para separar las ejecuciones de las opciones
            }
        }
    }

    // Clase para representar un producto
    class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }

        public Producto(string nombre, decimal precio, int cantidad, string descripcion)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Descripcion = descripcion;
        }
    }
}