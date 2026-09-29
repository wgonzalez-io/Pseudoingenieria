using System.Linq.Expressions;
using System.Text.RegularExpressions;
bool valid = true;
string nombre;
int edadV;
bool edad;
do{
Console.WriteLine("\nIngrese su nombre completo: ");
nombre = (Console.ReadLine() ?? "").Trim();
if (nombre.Length >= 15 && !string.IsNullOrWhiteSpace(nombre) && Regex.IsMatch(nombre, @"^[\p{L} ]+$"))
{
   Console.WriteLine($"Hola, {nombre}");
    valid = true;
}
else
{
    Console.WriteLine("Error, solo puede ingresar letras, minimo 15\n");
    valid = false;
}
}while(!valid);

do{
Console.WriteLine("Ingresa tu edad: ");
edad = int.TryParse(Console.ReadLine(), out edadV);
    if (edad)
    {
        if(edadV>0 && edadV<120){
        Console.WriteLine($"Su edad es: {edadV}");
        valid=true;
        }
        else
        {
            Console.WriteLine("Solo puedes igresar numeros entre 0 y 120");
            valid = false;
        }
    }
    else
    {
        Console.WriteLine("Solo puedes ingresar numeros");
        valid=false;
    }
}while(!valid);