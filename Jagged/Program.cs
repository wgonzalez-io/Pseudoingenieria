public class Jagged
{
    static void Main (String [] args)
    {
        Console.WriteLine("\n---REGISTRO DE DEPARTAMENTOS Y SUS MUNICIPIOS---");
        DepartamentosMunicipios();
    }

    static void DepartamentosMunicipios()
    {
        int CantidadDepartamentos, CantidadMunicipios;
        bool validar = true;
        do
        {
            Console.Write("Ingrese la cantidad de departamentos a registrar: ");
            bool V = int.TryParse(Console.ReadLine()?.Trim()?? "", out CantidadDepartamentos);
            if (V)
            {
                if (CantidadDepartamentos>0)
                {
                    Console.WriteLine("Cantidad registrada con éxito");
                    validar=true;
                }
                else
                {
                    Console.WriteLine("ERROR: Debes ingresar un número mayor que cero\n");
                    validar=false;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Solo puedes ingresar numeros enteros\n");
                validar=false;
            }
        }while(!validar);

        //Este es el arreglo para almacenar los departamentos 
        string [] departamentos = new string [CantidadDepartamentos];

        //Inicialicemos el jagged para almacenar todo
        string [][] jagged = new string [CantidadDepartamentos][];

        for(int i=0; i<departamentos.Length; i++)
        {
            Console.Write($"\nIngrese el nombre del departamento {i+1}: ");
            departamentos[i] = Console.ReadLine()?.Trim()?? "";
            
            do
        {
            Console.Write($"Ingrese la cantidad de municipos de {departamentos[i]}: ");
            bool V = int.TryParse(Console.ReadLine()?.Trim()?? "", out CantidadMunicipios);
            if (V)
            {
                if (CantidadMunicipios>0)
                {
                    Console.WriteLine("Cantidad registrada con éxito\n");
                    validar=true;
                }
                else
                {
                    Console.WriteLine("ERROR: Debes ingresar un número mayor que cero\n");
                    validar=false;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Solo puedes ingresar numeros enteros\n");
                validar=false;
            }
        }while(!validar);
        jagged[i] = new string [CantidadMunicipios];

        for(int j=0; j<jagged[i].Length; j++){
                Console.Write($"Ingrese el nombre del municipio {j+1} de {departamentos[i]}: ");
                jagged [i][j] = Console.ReadLine()?.Trim() ?? "";
            }
        }

        Console.WriteLine("\n---DEPARTAMENTOS Y SUS MUNICIPIOS---");
        for(int i=0; i<departamentos.Length; i++)
        {
            Console.WriteLine($"\nDepartamento: {departamentos[i]}");
            for(int j=0; j<jagged[i].Length; j++)
            {
                Console.WriteLine($"Municipio {j+1}: {jagged[i][j]}");
            }
        }


    }
}

