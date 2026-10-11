
float[] temperaturas = new float[15];

float suma = 0;
float promedio;
float maxima, minima;
int DiasSobre = 0;

//Acá se mandan a pedir las temperaturas con un bucle for
Console.WriteLine("\n---REGISTRO DE TEMPERATURAS---\n");
for (int i = 0; i<temperaturas.Length; i++)
{
    temperaturas[i] = RegistrarTemp(i + 1);
}

//Acá se muestran las temperaturas registradas mediante un bucle for
Console.WriteLine("---TEMPERATURAS REGISTRADAS---\n");
for(int i=0; i<temperaturas.Length; i++)
{
    Console.WriteLine($"La temperatura del dia {i+1} es de: {temperaturas[i]}°C");
    suma += temperaturas[i];
}

//Calculamos el promedio porque lo vamos a utilizar pronto
promedio=suma/temperaturas.Length;


//Obtenemos las temperaturas maximas y minimas
    maxima = ObtenerMax(temperaturas);
    minima = ObtenerMin(temperaturas);


//Ahora contamos cuantos dias están por encima del promedio
for(int i=0; i<temperaturas.Length; i++)
{
    if (temperaturas[i] > promedio)
    {
        DiasSobre++;
    }
}

//Mostremos los datos que acabamos de conseguir
Console.WriteLine("\n---DATOS GENERALES DE SUS TEMPERATURAS---");
Console.WriteLine($"Temperatura máxima registrada: {maxima}°C");
Console.WriteLine($"Temperatura mínima registrada: {minima}°C");
Console.WriteLine($"Temperatura promedio de los 15 días: {promedio}°C");
Console.WriteLine($"Dias con temperatura mayor al promedio: {DiasSobre}\n");


//Ahora pedimos para ver si la registramos anteriormente

float temp;
bool validar = false;

do
{
    Console.Write("Ingrese una temperatura para buscar: ");

    bool t = float.TryParse(
        Console.ReadLine()?.Trim() ?? "", out temp);

    if (t)
    {
        bool encontrada = false;

        for (int i = 0; i < temperaturas.Length; i++)
        {
            if (temp == temperaturas[i])
            {
                Console.WriteLine($"Temperatura encontrada en el dia: {i+1}, posicion dentro del arreglo: {i}");

                encontrada = true;
            }
        }

        if (!encontrada)
        {
            Console.WriteLine(
                "Temperatura no encontrada dentro del arreglo.");
        }

        validar = true;
    }
    else
    {
        Console.WriteLine("Solo puedes ingresar números.\n");
        validar = false;
    }

} while (!validar);

















static bool ValidarTemp(float temperatura)
{
    if (temperatura >= -20 && temperatura <= 50)
    {
        return true;
    }

    Console.WriteLine(
        "La temperatura debe estar entre -20 °C y 50 °C.\n");

    return false;
}

static float RegistrarTemp(int dia)
{
    float temperatura;
    bool valido = false;

    do
    {
        Console.Write($"Ingrese la temperatura del día {dia}: ");

        bool dato = float.TryParse(Console.ReadLine()?.Trim() ?? "", out temperatura);

        if (!dato)
        {
            Console.WriteLine("Solo puedes ingresar números.\n");
        }
        else if (ValidarTemp(temperatura))
        {
            Console.WriteLine("Temperatura registrada con éxito.\n");
            valido = true;
        }

    } while (!valido);

    return temperatura;
}

static float ObtenerMax(float[] temperaturas)
{
   float maxima = temperaturas[0];
    for(int i=0; i<temperaturas.Length; i++)
    {
          if (temperaturas[i] > maxima)
    {
        maxima=temperaturas[i];
    } 
    }
  return maxima;
}

static float ObtenerMin(float[] temperaturas)
{
    float minima = temperaturas[0];
    for(int i=0; i<temperaturas.Length; i++)
    {
        if (temperaturas[i] < minima)
    {
        minima=temperaturas[i];
    }
    }
    return minima;
}