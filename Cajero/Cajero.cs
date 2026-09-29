/*Vamos a suponer que el numero de cuenta es 15020826 y su saldo inicial es de C$10000, sin limites
ni para cantidad de deposito ni de maximo de saldo, esto no lo dice el ejercicio, pero lo haremos así*/

float saldo = 10000;
 Menu(ref saldo); //El ref significa que no usaremos copia de variable saldo, sino la variable original, esto para poder modificarla


static void Menu(ref float saldo){
    int opcion;
do
{
    Console.WriteLine("------ATM------");
    Console.WriteLine("1. Consultar saldo");
    Console.WriteLine("2. Depositar dinero");
    Console.WriteLine("3. Retirar dinero");
    Console.WriteLine("4. Información de la cuenta");
    Console.WriteLine("5. Salir");
    Console.WriteLine("Seleccione la operación a realizar: ");
    bool op = int.TryParse(Console.ReadLine()?.Trim() ?? "", out opcion);
    if (!op)
    {
        Console.WriteLine("Solo puede ingresar numeros\n");
    }
    else
    {
        switch (opcion)
        {
            case 1:
            ConsultarSaldo(saldo);
            break;

            case 2:
            Deposito(ref saldo);
            break;

            case 3:
            RetiroDinero(ref saldo);
            break;

            case 4:
            ConsultarInfo(saldo);
            break;

            case 5: 
            Console.WriteLine("Gracias por usar el ATM!");
            break;

            default:
            Console.WriteLine("Ingrese una opción mostrada en el menú\n");
            break;
            

        }
    }
}while(opcion != 5);
}


static void ConsultarInfo( float saldo) //en estos metodos, no alteramos el valor del saldo, por ende el ref no es necesario
{
    Console.WriteLine("\n------Información de la cuenta------");
    string cuenta = "15020826";
    Console.WriteLine($"Su número de cuenta es: {cuenta}");
    Console.WriteLine($"Su saldo disponible es: C${saldo}\n");
}


static void ConsultarSaldo( float saldo)
{
    Console.WriteLine("\n------Consulta de saldo------");
    Console.WriteLine($"Su saldo disponible: C${saldo}\n");
}


static void Deposito(ref float saldo)
{
    bool valido = true;
    do{
    float deposito;
   Console.WriteLine("\n------Depósito------");
    Console.WriteLine("Ingrese la cantidad que desea depositar C$:");
    bool dp = float.TryParse(Console.ReadLine()?.Trim() ?? "", out deposito);
        if (dp)
        {
            if(deposito<=0){
                Console.WriteLine("Debe ingresar un número mayor que cero\n");
                valido = false;
            }
            else
            {
                Console.WriteLine("Depósito realizado con éxito");
                saldo += deposito;
                Console.WriteLine($"Saldo actualizado: C${saldo}\n");
                valido = true;
            }
        }
        else
        {
            Console.WriteLine("Solo puedes ingresar valores numericos\n");
            valido = false;
        }
    }while(valido != true);
}
    static void RetiroDinero(ref float saldo)
    {
        bool valido = true;
        Console.WriteLine("\n------Retiro de dinero------");
        Console.WriteLine($"Saldo disponible: C${saldo} ");
        if(saldo>0){
        do{
        Console.WriteLine("Ingrese la cantidad que desea retirar C$: ");
        bool cant = float.TryParse(Console.ReadLine()?.Trim()?? "", out float retiro);
        if (cant)
        {
            if (retiro <= saldo && retiro>0)
            {
                saldo -= retiro;
                Console.WriteLine("Su retiro se ha realizado con éxito.");
                Console.WriteLine($"Saldo restante: C${saldo}\n");
                valido = true;
                
            }
            else if (retiro <= 0)
                {
                    Console.WriteLine("Debe ingresar una cantidad mayor que cero\n");
                    valido = false;
                }
            else
            {
                Console.WriteLine("La cantidad ingresada es mayor a su saldo disponible\n");
                valido=false;
            }
        }
        else
        {
            Console.WriteLine("Solo puede ingresar valores numéricos\n");
            valido=false;
        }
        }while(!valido);
    }
    else
    {
        Console.WriteLine("No tiene saldo disponible\n");
    }
    }