class Progra
{

static void  Main()

{
    Directory.CreateDirectory("C:/LaboratorioAvengers/Backup");
    Directory.CreateDirectory("C:/LaboratorioAvengers/ArchivosClasificados");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\t\u001b[34mBienvenido Tony Stark\u001b[0m");
        Console.ResetColor();
        Console.WriteLine("___________________________________");
        int opcion;
        
        do
        {
            Console.WriteLine("\t\u001b[97m===============================\u001b[0m");
            Console.WriteLine("\t\u001b[91m ¿Qué deseas hacer hoy\u001b[0m?");
            Console.WriteLine("\t===============================\n");
            Console.WriteLine("1. Crear Archivo");
            Console.WriteLine("2. Agregar inventario");
            Console.WriteLine("3. Leer documento línea por línea");
            Console.WriteLine("4. Leer todo el texto");
            Console.WriteLine("5. Copiar Archivo");
            Console.WriteLine("6. Mover Archivo");
            Console.WriteLine("7. Crear carpeta");
            Console.WriteLine("8. Listar archivos y carpetas");
            Console.WriteLine("9. Salir");
            Console.Write("\n Elige una opción: ");

            // Validamos que el usuario ingrese un número
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("-----------------------------------------------");

                switch (opcion)
                {
                    case 1:
                        CrearArchivo();
                        Console.WriteLine("Archivo creado con éxito.");
                        break;

                    case 2:
                        AgregarInventos();
                        Console.WriteLine("Inventos agregados correctamente.");
                        break;

                    case 3:
                        LeerLineaPorLinea();
                        Console.WriteLine("Lectura completada.");
                        break;

                    case 4:
                        leerTodoElTexto();
                        Console.WriteLine("Texto leído completamente.");
                        break;

                    case 5:
                        copiarArchivo();
                        Console.WriteLine(" Archivo copiado con éxito.");
                        break;

                    case 6:
                       
                        if (VerificarExistenciaArchivo()) {
                            MoverArchivo();
                            Console.WriteLine(" Archivo movido correctamente.");
                             }
                        break;

                    case 7:
                        CrearCarpeta();
                        Console.WriteLine("Carpeta creada correctamente.");
                        break;

                    case 8:
                        ListadoArchivosYCarpetas();
                        Console.WriteLine("Listado de archivos y carpetas mostrado.");
                        break;

                    case 9:
                        Console.WriteLine(" Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine(" Opción no válida. Intente de nuevo.");
                        break;
                }

                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
                opcion = 0; // Evita que el programa termine si el usuario ingresa texto
            }

        } while (opcion != 9); // Repite hasta que el usuario elija salir


        void CrearArchivo()
{
    string path = "C:/LaboratorioAvengers/Inventos.txt";
    string contenido = "Archivo creado para Tony Stark\n";
    File.WriteAllText(path, contenido);
    Console.WriteLine("El archivo fue creado con éxito\t");
}

void AgregarInventos()
{
    Console.WriteLine("¿Cuántos inventos desea agregar?");
    int cantidad = int.Parse(Console.ReadLine()); // Convertir la entrada a número

    if (cantidad < 1)
    {
        Console.WriteLine(" No se pueden agregar 0 inventos.");
        return;
    }

    string path = "C:/LaboratorioAvengers/Inventos.txt";

    for (int i = 0; i < cantidad; i++)  // se creo un blucle for para poder pedirle al ususario que ingrese cuantos inventos quiere agregar 
    {
        Console.Write($"Ingrese el invento {i + 1}: ");
        string contenido = Console.ReadLine();
        File.AppendAllText(path, contenido + Environment.NewLine);
    }

    Console.WriteLine(" Los inventos se agregaron con éxito.");
}

void LeerLineaPorLinea()
{
    int contador  = 0; // Variable para contar el número de línea
            string path = "C:/LaboratorioAvengers/Inventos.txt";// Ruta del archivo a leer
            string[] lineas = File.ReadAllLines(path);// Leer todas las líneas del archivo y almacenarlas en un array de strings
            foreach (string linea in lineas) // Recorrer cada línea del archivo
            {
        contador ++; // Incrementar el contador de líneas
                Console.WriteLine("Linea:" + contador  + " " + linea);// Imprimir número de línea y su contenido
            }
}

void leerTodoElTexto()
{
    string path = "C:/LaboratorioAvengers/Inventos.txt";
    string directory = Path.GetDirectoryName(path);

    // Verifica si el directorio existe
    if (!Directory.Exists(directory))
    {
        Console.WriteLine("El directorio no existe: " + directory);
        return;
    }

    // Verifica si el archivo existe antes de leerlo
    if (!File.Exists(path))
    {
        Console.WriteLine("El archivo Inventos.txt no existe. ¡Ultron debe haberlo eliminado!\n");
        return;
    }

    try
    {
        string contenido = File.ReadAllText(path);
        Console.WriteLine("Los Artículos son:");
        Console.WriteLine(contenido);
    }
    catch (Exception err)
    {
        Console.WriteLine("Otro error inesperado: " + err.Message);
    }
}

void copiarArchivo()

{
    string origen = "C:/LaboratorioAvengers/inventos.txt";
    string destino = "C:/Backup/inventos.txt(copi)";

    if (File.Exists(origen))
    {
        // Copiar el archivo a la nueva ubicación
        File.Copy(origen, destino, true);
        Console.WriteLine("Archivo copiado exitosamente a 'Backup'.");

        // Eliminar el archivo original después de copiarlo
        File.Delete(origen);
        Console.WriteLine(" Archivo original eliminado.");
    }
    else
    {
        Console.WriteLine("Peligro el archivo 'inventos.txt' No esta creado todavia.");
    }
}


void MoverArchivo ()
{
    string origen = "C:/LaboratorioAvengers/inventos.txt";
    string destino = "C:/ArchivosClasificados/inventos.txt";
    File.Move(origen, destino);
    Console.WriteLine("Archivo movido exitosamente a la carpeta ArchivosClasificados.\n");
}

void CrearCarpeta()
{
    string path = "C:/LaboratorioAvengers/ProyectosSecretos";
    Directory.CreateDirectory(path);
    Console.WriteLine("la carpeta fue creada con existente\n");

}

void ListadoArchivosYCarpetas()
{
    string path = "C:/LaboratorioAvengers";

    if (Directory.Exists(path))
    {
        // Obtener todas las carpetas dentro del directorio
        string[] carpetas = Directory.GetDirectories(path);
        // Obtener todos los archivos dentro del directorio
        string[] archivos = Directory.GetFiles(path);

        Console.WriteLine("Contenido de la carpeta 'LaboratorioAvengers :");

        // Mostrar las carpetas
        Console.WriteLine("\nCarpetas:");
        foreach (string carpeta in carpetas)
        {
            Console.WriteLine( Path.GetFileName(carpeta));
        }

        // Mostrar los archivos
        Console.WriteLine("\n Archivos:");
        foreach (string archivo in archivos)
        {
            Console.WriteLine( Path.GetFileName(archivo));
        }
    }
    else
    {
        Console.WriteLine("La carpeta 'LaboratorioAvengers' no existe.");
    }
}

static bool VerificarExistenciaArchivo()
{
    string path = "c:/LaboratorioAvengers/inventos.txt";

    if (File.Exists(path))
    {
        return true;
    }
    else
    {
        // Comentario interactivo cuando el archivo no existe
        Console.WriteLine("El archivo 'inventos' no esta en existencia pueda ser que lo a olvidado Tony Stark ");
        return false;
    }
    }
    }
}
