using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
int [,] ventas = solicitardatos();
    mostrarmatriz(ventas);
    calcularTotalProductoDia(ventas);
    TotalGeneral(ventas);


static int [,] solicitardatos()
{
    int [,] ventas = new int [4,3];
    //Empezamos a pedir las ventas de cada dia y sus productos, mediante un método//
    Console.WriteLine("---REGISTRO DE VENTAS---");
    ObtenerCantidad(ventas);
    return ventas;
}

static void ObtenerCantidad(int [,] ventas)
{
    int cantidad;
    for(int i=0; i<ventas.GetLength(0); i++)
    {
        Console.WriteLine($"\n Día {i+1}");

        for(int j=0; j<ventas.GetLength(1); j++)
        {
            Console.Write($"Ingrese la cantidad vendida del producto {j+1}: ");
            cantidad=ValidarCantidad();
            ventas[i,j] = cantidad;
        }
    }
}

static int ValidarCantidad()
{
   int cantidad;

do
{
    bool validar = int.TryParse(Console.ReadLine()?.Trim() ?? "",out cantidad);

    if (!validar)
    {
        Console.Write("Solo puedes ingresar numeros enteros: ");
        cantidad = -1;
    }
    else if (cantidad < 0)
    {
        Console.Write("La cantidad debe ser mayor o igual a cero: ");
    }

} while (cantidad < 0);

Console.WriteLine("Venta registrada con éxito.\n");
return cantidad;
}

static void mostrarmatriz(int [,] ventas)
{
    Console.WriteLine("\n---DATOS ALMACENADOS---");
    for(int i=0; i < ventas.GetLength(0); i++)
    {
        Console.WriteLine($"\nVentas del dia {i+1}");
        for(int j=0; j<ventas.GetLength(1); j++){
            Console.WriteLine($"Cantidad vendida del producto {j+1}: {ventas[i,j]}");
        }
    }
}

static void calcularTotalProductoDia(int [,]ventas)
{
    int suma=0;
    Console.WriteLine("\n---PRODUCTOS VENDIDOS POR DIA");
    for(int i=0; i < ventas.GetLength(0); i++)
    {
        Console.WriteLine($"Dia {i+1}");
        for(int j=0; j<ventas.GetLength(1); j++)
        {
            if (ventas[i,j] > 0)
            {
            suma += ventas[i,j];
            }
        }
        Console.WriteLine($"Cantidad de producto vendido: {suma}\n");
        suma=0;
    }
}

static void TotalGeneral(int [,] ventas)
{
    Console.WriteLine("\n---TOTAL VENDIDO EN 4 DIAS---");

        for(int j=0; j<ventas.GetLength(1); j++)
        {
            int total=0;
            for(int i=0; i<ventas.GetLength(0); i++)
        {
            if (ventas[i, j] > 0)
            {
                total+=ventas[i,j];
            }
        } 
        Console.WriteLine($"Total vendido del producto {j+1}: {total}\n");
    }
    
}