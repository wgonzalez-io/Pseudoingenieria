using System.Text.RegularExpressions;
float salario;
string nombre, respuesta;
bool activo = false, pago, valid = true;

Console.WriteLine("Registro de trabajador\n");

do{
    Console.WriteLine("Ingrese su nombre completo: ");
    nombre = (Console.ReadLine()?.Trim() ?? "");
if(Regex.IsMatch(nombre, @"^[\p{L} ]+$") && nombre.Length>=15)
{
    Console.WriteLine("Nombre registrado con éxito\n");
    valid=true;
}
else
{
    Console.WriteLine("Solo puedes ingresar letras, minimo 15\n");
    valid=false;
}
}while(!valid);

do
{
    Console.WriteLine("Ingrese su salario $:");
    pago = float.TryParse(Console.ReadLine()?.Trim() ?? "0", out salario);
    if (pago)
    {
        if(salario<=0 || salario > 100000)
        {
            Console.WriteLine("Solo puedes ingresar numeros mayores que 0 y menores que 100000\n");
            valid=false;
        }
        else
        {
            Console.WriteLine("Salario registrado con éxito\n");
            valid=true;
        }
    }
    else
    {
        Console.WriteLine("Solo puedes ingresar numeros\n");
        valid=false;
    }
}while(!valid);

do
{
    Console.WriteLine("¿Usted es trabajador activo?  si/no");
    respuesta = (Console.ReadLine()?.Trim().ToLower() ?? "");
    if (respuesta.Equals("si"))
    {
        activo=true;
        valid=true;
    }
    else if (respuesta.Equals("no"))
    {
        activo=false;
        valid=true;
    }
    else
    {
        Console.WriteLine("Ingrese solamente (si)/(no)\n");
        valid=false;
    }
}while(!valid);

Console.WriteLine("-------Datos del trabajador-------");
Console.WriteLine($"Nombre: {nombre}");
Console.WriteLine($"Salario: ${salario}");
Console.WriteLine($"Está activo en la empresa: {activo}");

