using System.Text.RegularExpressions; //Se usa para usar el REGEX, nos permite hacer validaciones de nombres con el Is.Match
class Program
{
    static void Main()
    {
        int CantidadRegistro;
        Console.WriteLine("\n-----------------REGISTRO DE UNIDADES PRODUCIDAS-----------------");
        Console.Write("Ingrese la cantidad de tipos de muebles a registrar: "); //Solicitamos primero la cantidad para luego inicializar nuestros arrays
        CantidadRegistro = ValidarCantidad();
        string [][] Muebles = new string [CantidadRegistro][];
        int [][] Cantidades = new int [CantidadRegistro][];
        string [] TipoMuebles = new string [CantidadRegistro];
        RegistroTipoMueble(TipoMuebles, Muebles, Cantidades, CantidadRegistro); //Mandamos a llamar al método de registro
        MostrarReporte(TipoMuebles, Muebles, Cantidades, CantidadRegistro); //Mandamos a llamar el reporte en formato de tabla
        MostrarMayorProduccion(TipoMuebles, Muebles, Cantidades, CantidadRegistro);

    }

    static int ValidarCantidad()
    {
        int cantidad;
        do
        {
            try
            {
                cantidad = int.Parse(Console.ReadLine()?.Trim()?? "");
                if (cantidad <= 0)
                {
                Console.Write("Debes ingresar una cantidad mayor que cero: ");
                }
            }
            catch (FormatException)
            {
                Console.Write("Solo puedes ingresar números enteros: ");
                cantidad = -1;
            }
            catch (OverflowException)
            {
                Console.Write("Ingresó una cantidad demasiado grande. Ingrese una más aterrizada: ");
                cantidad = -1;
            }
        }while(cantidad<=0);
        Console.WriteLine("Cantidad registrada con éxito\n");
        return cantidad;
    }

    static void RegistroTipoMueble(string [] TipoMuebles, string [][] Muebles, int [][] Cantidades, int CantidadRegistro)
    {
        for(int i=0; i < CantidadRegistro; i++)
        {
            Console.Write($"Ingrese el tipo de mueble {i+1}: ");
            TipoMuebles[i] = ValidarNombre();

            Console.Write($"Digite cuantas modelos de {TipoMuebles[i]} fabricará: ");
            int CantidadTipo = ValidarCantidad();
            //Guardamos los modelos en los jagged, usamos dos porque se solicitan bastantes datos y asi los ordenamos de mejor manera
            Muebles[i] = new string [CantidadTipo];
            Cantidades[i] = new int [CantidadTipo];

            for(int j=0; j<CantidadTipo; j++)
            {
                Console.Write($"Ingrese el código del modelo {j+1}: ");
                string codigo = Console.ReadLine()?.Trim()?? "";
                Muebles[i][j] = codigo;

                Console.Write($"Ingrese la cantidad de unidades fabricadas de {TipoMuebles[i]} {Muebles[i][j]}: ");
                Cantidades[i][j]=ValidarCantidad();
            }
        }
    }

    static string ValidarNombre()
    {
        bool valid;
        string Mueble;
        do
        {
        Mueble = Console.ReadLine()?.Trim()?? "";
        if(Regex.IsMatch(Mueble, "^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$"))
        {
            valid = true;
        }
        else if(string.IsNullOrWhiteSpace(Mueble))
        {
            Console.Write("El tipo de mueble no puede estar vacío. Ingrese un tipo válido: ");
            valid = false;
        }
        else
        {
            Console.Write("Ingrese un mueble válido (solo letras y espacios): ");
            valid = false;
        }
        }while(!valid);
       return Mueble;
    }

    static void MostrarReporte(string[] TipoMuebles, string[][] Muebles, int[][] Cantidades, int CantidadRegistro)
    {
        Console.WriteLine("\n----------REPORTE DE PRODUCCION----------");
        for(int i=0; i<CantidadRegistro; i++)
        {
            // Esto es para que se vea como una tabla
            int TotalTipoMueble=0;
            Console.WriteLine($"\nTipo de mueble: {TipoMuebles[i]}");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{"Código del modelo",-20} {"Unidades fabricadas",20}"); //Los numeros son el espacio que van a ocupar
            Console.WriteLine("-----------------------------------------");
            //Iniciamos el for para mostrar los codigos y cantidades
            for(int j=0; j<Muebles[i].Length; j++) //Se usa Muebles[i] para acceder al arreglo de los tipos de mueble (Dolor de cabeza)
            {
                Console.WriteLine($"{Muebles[i][j], -20} {Cantidades[i][j], 20}");
                TotalTipoMueble += Cantidades[i][j]; //Este es el contador de las unidades de cada tipo de mueble 
            }
            Console.WriteLine($"Total de unidades de {TipoMuebles[i]}: {TotalTipoMueble}");  //Mostramos el total de cada tipo de mueble 
             Console.WriteLine("-----------------------------------------");
        }
    }

    
static void MostrarMayorProduccion(string[] TipoMuebles, string[][] Muebles, int[][] Cantidades, int CantidadRegistro)
{
    int MayorProduccion = 0;
    string MuebleMayor = "";

    for (int i = 0; i < CantidadRegistro; i++)
    {
        int TotalTipoMueble = 0;

        for (int j = 0; j < Muebles[i].Length; j++)
        {
            TotalTipoMueble += Cantidades[i][j];
        }

        if (TotalTipoMueble > MayorProduccion)
        {
            MayorProduccion = TotalTipoMueble;
            MuebleMayor = TipoMuebles[i];
        }
    }

    Console.WriteLine("\n---------- MAYOR PRODUCCIÓN ----------");
    Console.WriteLine($"Tipo de mueble: {MuebleMayor}");
    Console.WriteLine($"Unidades producidas: {MayorProduccion}");
}
}