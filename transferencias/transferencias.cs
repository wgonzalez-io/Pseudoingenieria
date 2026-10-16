using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;


string name ="";
string titular = "";
string contraseña ="";
string cuentaC = "150208";
string cuentaD = "202605";
string tarjetaC = "4026 8303 0011 1192";
float saldoC = 10000;
float saldoD = 200;

Ingreso(ref name, cuentaC, cuentaD, ref titular, ref contraseña, ref saldoC, ref saldoD, tarjetaC);

static void Ingreso(ref string name, string cuentaC, string cuentaD, ref string titular, ref string contraseña, ref float saldoC, ref float saldoD, string tarjeta)
{
    int opcion;
    do
    {
        Console.WriteLine("---Banca en Línea---");
        Console.WriteLine("1. Iniciar sesión");
        Console.WriteLine("2. Crear cuenta");
        Console.WriteLine("3. Salir");
        opcion = Seleccion();
        switch (opcion)
        {
            case 1:
            InicioSesion(name, cuentaC, ref saldoC, cuentaD, ref saldoD, contraseña, titular, tarjeta);
            break;

            case 2:
            CrearCuenta(ref name, ref titular, ref contraseña);
            break;

            case 3:
            Console.WriteLine("Saliendo...\n");
            break;
            
            default:
            Console.WriteLine("Ingrese una opcion válida\n");
            break;
        }
    }while(opcion!=3);
    
}

static void Banco(string name, string titular, string cuentaC, ref float saldoC, string cuentaD, ref float saldoD, string tarjeta)
{
    int opcion;
    do
    {
        Console.WriteLine("\n---Banca en Línea---");
        Console.WriteLine("1. Consultar información de la cuenta");
        Console.WriteLine("2. Transferencias entre cuentas propias");
        Console.WriteLine("3. Transferencias a terceros");
        Console.WriteLine("4. Historial de transacciones");
        Console.WriteLine("5. Informacion de la tarjeta");
        Console.WriteLine("6. Cerrar sesión");
        opcion = Seleccion();
        switch (opcion)
        {
            case 1:
            MostrarInformacion(name, cuentaC, saldoC, cuentaD, saldoD, titular);
            break;

            case 2:
            TransferenciaPropia(ref saldoC, ref saldoD);
            break;

            case 5:
            MostrarTrajeta(tarjeta);
            break;

            case 6:
            Console.WriteLine("Cerrando sesión...\n");
            break;

            default:
            Console.WriteLine("Ingrese una opción válida\n");
            break;
        }
    }while(opcion!=6);
    
    
}


static int Seleccion()
{
    int opcion;
    do{
    Console.Write("Seleccione la operación a realizar: ");
    if(int.TryParse(Console.ReadLine()?.Trim()?? "", out opcion))
            {
                return opcion;
            }
        else
        {
            Console.WriteLine("Solo puedes ingresar números\n");
        }
  
    }while(true);
}


static void CrearCuenta(ref string name,ref string titular, ref string contraseña)
{
    string verificar;
    bool valido = true;
    Console.WriteLine("\n---Crear cuenta---");
    do{
    Console.Write("Ingrese un nombre de usuario: ");
    name = Console.ReadLine()?.Trim()?? "";
    if (name.Length >= 4)
    {
        Console.WriteLine("Nombre de usuario registrado correctamente\n");
        valido = true;
        }
        else
        {
            valido=false;
        }
    }while(!valido);

    do
    {
        Console.Write("Ingrese su nombre completo: ");
        titular = Console.ReadLine()?.Trim()??"";
        if(Regex.IsMatch(titular, @"^[\p{L} ]+$") && titular.Length>=15)
        {
            Console.WriteLine("Nombre registrado con éxito\n");
            valido=true;
        }
        else if (titular.Length < 15)
        {
            Console.WriteLine("Debe ingresar al menos 15 letras\n");
            valido=false;
        }
        else
        {
            Console.WriteLine("Solo puedes ingresar letras\n");
            valido=false;
        }
    }while(!valido);


    do
    {
        Console.Write("Ingrese una contraseña (8 carácteres minimo): ");
        contraseña = Console.ReadLine()?.Trim()?? "";

        if (contraseña.Length >= 8)
        {
            do
            {
                Console.Write("Ingrese su contraseña nuevamente para confirmarla:");
                verificar = Console.ReadLine()?.Trim()?? "";
                if (verificar == contraseña)
                {
                    Console.WriteLine("Contraseña registrada con éxito\n");
                    valido=true;
                }
                else
                {
                    Console.WriteLine("Error: Las contraseñas no coinciden\n");
                    valido=false;
                }
            }while(!valido);
        }
        else
        {
            Console.WriteLine("Error: Debe ingresar 8 carácteres como mínimo\n");
            valido=false;
        }
    }while(!valido);
}

static void InicioSesion(string name, string cuentaC, ref float saldoC, string cuentaD, ref float saldoD, string contraseña, string titular, string tarjeta)
{
    string ID;
    string pass;
    bool valido = true;
    Console.WriteLine("\n---Inicio de sesión---");
    do
    {
        Console.Write("Ingrese su usuario: ");
        ID = Console.ReadLine()?.Trim()?? "";
        if (ID == name)
        {
            do{
            Console.Write("Ingrese su contraseña: ");
            pass = Console.ReadLine()?.Trim()?? "";
            

           
            if(pass == contraseña)
            {
                Console.WriteLine("Inicio de sesión realizado con éxito\n");
                Banco(name, titular, cuentaC, ref saldoC, cuentaD, ref saldoD, tarjeta);
                valido=true;

            }
            else
            {
                Console.WriteLine("Contraseña incorrecta, intenta de nuevo\n");
                valido = false;
            }
            }while(!valido);
        }
        else
        {
            Console.WriteLine("Usuario incorrecto, intenta de nuevo\n");
            valido = false;
        }
    }while(!valido);
}

 static void MostrarInformacion(string name, string cuentaC, float saldoC, string cuentaD, float saldoD, string titular)
 {
    Console.WriteLine("\n---Informacion de la cuenta---");
    Console.WriteLine($"Titular: {titular}");
    Console.WriteLine($"Número de cuenta córdobas: {cuentaC}");
    Console.WriteLine($"Su saldo disponible: C${saldoC}\n");
    Console.WriteLine($"Número de cuenta dólares: {cuentaD}");
    Console.WriteLine($"Su saldo disponible: ${saldoD}\n");
}

static void MostrarTrajeta(string tarjeta)
{
    Console.WriteLine("\n---Información de la tarjtea");
    Console.WriteLine($"Su número de tarjeta: {tarjeta}\n");
}

static void TransferenciaPropia(ref float saldoC, ref float saldoD)
{
    int opcion;
    bool valido;
    float cantidad;
    Console.WriteLine("\n---Transferencia entre cuentas---");
    Console.WriteLine("1. Cuenta en córdobas");
    Console.WriteLine("2. Cuenta en dólares");
    Console.WriteLine("3. Regresar al menú");
    opcion = Seleccion();
    switch (opcion)
    {
        case 1:
        Console.WriteLine("\nSe realizará la transferencia de cordobas a dolares");
            do
            {
                Console.Write("Digite cuando desea transferir en cordobas: C$");
                bool t = float.TryParse(Console.ReadLine(), out cantidad);
                if (t)
                {
                    if (cantidad > 0 && cantidad <saldoC)
                    {
                        float cantidadD = cantidad/36.7f;
                        Console.WriteLine($"La conversión a dólares: ${cantidadD}");
                        saldoD += cantidadD;
                        saldoC -=cantidad;
                        Console.WriteLine("Transferencia exitosa, su saldo ha sido actualizado\n");
                        valido=true;
                    }
                    else if (cantidad > saldoC)
                    {
                        Console.WriteLine("No tienes saldo suficiente\n");
                        valido=false;
                    }
                    else
                    {
                        Console.WriteLine("No puedes ingresar menos de 1\n");
                        valido=false;
                    }
                }
                else
                {
                    Console.WriteLine("Solo puede ingresar numeros\n");
                    valido=false;
                }
            }while(!valido);
        break;
        
        case 2:   
        Console.WriteLine("\nSe realizará la transferencia de dolares a cordobas");
            do
            {
                Console.Write("Digite cuando desea transferir en dolares: $");
                bool t1 = float.TryParse(Console.ReadLine(), out cantidad);
                if (t1)
                {
                    if (cantidad > 0 && cantidad<saldoD)
                    {
                        float cantidadC = cantidad*36.7f;
                        Console.WriteLine($"La conversión a córdobas: C${cantidadC}");
                        saldoD -= cantidad;
                        saldoC +=cantidadC;
                        Console.WriteLine("Transferencia exitosa, su saldo ha sido actualizado\n");
                        valido=true;
                    }
                    else if (cantidad > saldoD)
                    {
                        Console.WriteLine("No tienes saldo suficiente\n");
                        valido=false;
                    }
                    else
                    {
                        Console.WriteLine("No puedes ingresar menos de 1\n");
                        valido=false;
                    }
                }
                else
                {
                    Console.WriteLine("Solo puede ingresar numeros\n");
                    valido=false;
                }
            }while(!valido);
        break;

        case 3: 
        Console.WriteLine("Regresando al menú...\n");
        break;

        default:
        Console.WriteLine("Ingresa una opción válida");
        break;

    }
    
}