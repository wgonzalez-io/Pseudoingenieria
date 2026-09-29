Console.WriteLine("¡Bienvenido al Sistema de Calificaiones de estudiantes!");
//A continuación se declara el float "promediofinal", a la cual se le asgina lo que retorna el método "calcularpromedio", método el cual
//necesita como argumento al método "capturardatos", es decir, a continuación se presencia un encapsulamiento de métodos, para no estar
//haciendo más variables que pueden llegar a ser innecesarias, y en un largo plazo, inefeciente el programa(si se llega a trabjar más, claro)
float promediofinal = calcularpromedio(capturardatos());
Console.WriteLine(" ");
mostrarresultado(promediofinal);
Console.WriteLine("¡Gracias por haber usado el sistema!");



//el tipo de dato de retorno que se declara es un array de tipo int, ya que es el argumento que se le dará
//al método calcular promedio para que pueda realizar dicho proceso. Se usa un array porque es mas eficiente que estar haciendo
//variables para cada califación
static int[] capturardatos()
{
    //Se declaran 2 variables boolean para realizar validaciones, "comprobar" se utiliza para la validación más externa, por asi llamarle,
    //la cual se utiliza en las condiciones de los ciclos do-while, y la variable "valid" para "validaciones" internas por asi llamarle,
    //que dicha variable se utiliza cuando se manda a pedir el número de calificaciones a ingresar
    Boolean comprobar = true, valid = false;
    int calificaciones = 0;
    do
    {
        Console.WriteLine(" ");
        Console.WriteLine("Ingrese el nombre completo del estudiante:");
    string nombre = Console.ReadLine();
    //A continuación, se valida el nombre por medio de algunos métodos
    if (!string.IsNullOrEmpty(nombre) && nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) && nombre.Length >= 15 )
    {
        Console.WriteLine("Nombre registrado correctamente!");
        comprobar = false;
    }
    else if (string.IsNullOrEmpty(nombre)){
        Console.WriteLine("Debe ingresar el nombre del estudiante, no puede dejar espacios vacíos. Intente de nuevo");
        comprobar = true;
    }
    else if(!nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))){
        Console.WriteLine("Solo puede ingresar letras. Intente de nuevo");
        comprobar = true;
    }
    else
    {
        Console.WriteLine("El mínimo de letras que debe tener el nombre es de 15. Intente de nuevo.");
        comprobar = true;
    }
    } while (comprobar);

    do
    {
        Console.WriteLine(" ");
        Console.WriteLine("¿Cuántas calificaciones va a ingresar?");
    valid = int.TryParse(Console.ReadLine(), out calificaciones);
    if (valid)
    {
        if (calificaciones >= 1)     
    {
        Console.WriteLine("Cantidad registrada existosamente");
        comprobar = false;
    } else
    {
        Console.WriteLine("No puede ingresar cantidades menor a 1");
        comprobar = true;
    }
    }
        else {
            Console.WriteLine("Solo puede ingresar números enteros. Ejemplo: 1,2,10");
        comprobar = true;
        }
    } while (comprobar);
    //Se inicializa el array luego de pedir las calificaciones, puesto que no se puede hacer antes porque no se sabe de que dimensión será
    //y todo array siempre debe declararse desde su concepción con su respectiva dimensión
    int [] notas = new int[calificaciones];
    for (int i = 0; i < calificaciones; i++)
    {
        do
        {
            Console.WriteLine(" ");
          Console.WriteLine($"Ingrese la califación n° {i+1} :");
        valid = int.TryParse(Console.ReadLine(), out notas[i]);
        if (valid)
        {
            if(notas[i] >= 0 && notas[i] <= 100)
            {
                Console.WriteLine("Nota registrada correctamente");
                comprobar = false;
            }
            else
            {
                Console.WriteLine("Debe ingresar una nota válida dentro del rango de 0 a 100.");
                comprobar = true;
            }
        }
        else
        {
            Console.WriteLine("Solo puede ingresar números enteros. Por ejemplo: 10, 35. 74");
            comprobar = true;
        }  
        } while (comprobar);
        
    }
    return notas;

    }
    //se declara el metodo con un tipo de dato de retorno de float, porque es la variable que usará el método "mostrarresultado"
    //para mostrar lo realizado
    static float calcularpromedio(int[] notas)
{
    //se inicializa una variable de tipo int llamada suma para poder hacer la suma de todas las notas para posteriormente sacar
    //el promedio
    //la variable "suma" se declara como int porque siempre guardará datos enteros, por como se definió el tipo de califación
    //apoyandose del sistema educativo nicaraguense, en cambio, la variable promedio se declara como float porque ella si puede llegar
    //a tener números decimales
    int suma = 0;
    float promedio = 0;
    for (int i = 0; i < notas.Length; i++)
    { 
        suma += notas[i];
    }
    //se escribe float antes de suma para obligar al lenguaje a dividir con decimales, y así no perder promedios como "65.6" o "59.4"
    //esta caracteristica es propia de los lenguajes de la familia de C(C, C++, Java, C#)
    promedio = (float)suma / notas.Length;
    return promedio;

}
static void mostrarresultado(float promediofinal)
{
    //Se escribe "$" al inicio de la sentencia para poder escribir con mayor facilidad las variables que se mandarán a mostrar
    Console.WriteLine($"El promedio obtenido fue de: {promediofinal}");
}