class Program
{
    static void Main(String [] args)
    {
        int [,] inventario = PedirDatos();
        MostrarInventario(inventario);
        SumaProductosEspecificos(inventario);
        MayorStock(inventario);
    }

    static int ValidarCantidad()
    {
        int cantidad;
        do
        {
            bool validar = int.TryParse(Console.ReadLine()?.Trim()?? "", out cantidad);
            if (!validar)
            {
                Console.Write("Solo puedes ingresar números enteros: ");
                cantidad = -1;
            }
            else if (cantidad < 0)
            {
                Console.Write("Debes ingresar una cantidad mayor o igual que cero: ");
            }
        }while(cantidad<0);
        Console.WriteLine("Cantidad registrada con éxito\n");
        return cantidad;
    }

    static int [,] PedirDatos()
    {
        int cantidad;
        int [,] inventario = new int [5,3];
        Console.WriteLine("---REGISTRO DE PRODUCTOS---\n");
        for(int j=0; j < inventario.GetLength(1); j++)
        {
            Console.WriteLine($"Bodega {j+1}");
            for(int i=0; i<inventario.GetLength(0); i++)
            {
                Console.Write($"Ingrese la cantidad del producto {i+1}: ");
                cantidad = ValidarCantidad();
                inventario [i,j] = cantidad;
            }
        }
    return inventario;
    }

    static void MostrarInventario(int [,] inventario)
    {
        Console.WriteLine("---INVENTARIO---");
        for(int j=0; j<inventario.GetLength(1); j++)
        {
            int suma = 0;
            Console.WriteLine($"\nBodega {j+1}");
            for(int i=0; i<inventario.GetLength(0); i++)
            {
                Console.WriteLine($"Cantidad registrada del producto {i+1}: {inventario[i,j]}");
                suma+= inventario[i,j];
            }
            Console.WriteLine($"Cantidad total de productos: {suma}");
        }
    }

    static void SumaProductosEspecificos(int [,] inventario)
    {
        Console.WriteLine("\n---TOTAL DE PRODUCTOS EN LAS BODEGAS---\n");
        for(int i=0; i<inventario.GetLength(0); i++)
        {
            int suma=0;
            for(int j=0; j<inventario.GetLength(1); j++)
            {
                suma+=inventario[i,j];
                
            }
            Console.WriteLine($"Total del producto {i+1}: {suma}");
        }
    }

    static void MayorStock(int [,] inventario)
    {
        int maximo = -1;
        int productoStock = 0;
        for(int i=0; i<inventario.GetLength(0); i++)
        {
            int suma = 0;
            for(int j=0; j<inventario.GetLength(1); j++)
            {
              suma+=inventario[i,j];
                if (suma > maximo)
                {
                    maximo=suma;
                    productoStock=i+1;
                }
            }
        }
        Console.WriteLine($"\nEl producto {productoStock} tiene la mayor cantidad de stock: {maximo}");
    }
}