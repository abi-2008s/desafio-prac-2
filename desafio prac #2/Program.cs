using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace desafio_prac__2
{
    internal class Program
    {
            // =======================
            // Variables globales
            // =======================

            static string[] nombres = new string[20];
            static string[] carnets = new string[20];
            static double[] parcial1 = new double[20];
            static double[] parcial2 = new double[20];
            static double[] parcial3 = new double[20];
            static double[] parcialfinal = new double[20];
            static double[] promedios = new double[20];
            static int totalestudiantes = 0;  //contador


            static void Main(string[] args)
            {
                // ================================================
                // Requerimientos de pantalla (Interfaz de Consola)
                // ================================================

                Console.Title = "Sistema de Gestión Académica - Colegio Don Bosco";
                Console.SetWindowSize(90, 25);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                // Llamada procedimiento de bienvenida
                MostrarBienvenida();

                bool centinela = true;
                int opcion = 0;

                //Llamada proced. menu
                MostrarMenu();

                // Empieza do-while para menú CICLO PRINCIPAL
                do
                {
                    try
                    {
                        Console.Clear();
                        MostrarMenu();

                        Console.Write("\n  Seleccione una opción:  ");
                        opcion = int.Parse(Console.ReadLine());

                        //Logica opciones con SWITCH
                        switch (opcion)
                        {
                            case 1:
                                if (totalestudiantes < 20)
                                {
                                    RegistrarEstudiante(totalestudiantes);
                                    totalestudiantes++;
                                    Console.WriteLine("\n[PROXIMAMENTE] Registro de estudiantes...");
                                }
                                else
                                {
                                    Console.WriteLine("\n   ERROR: El sistema está lleno (Máximo 20).");
                                }
                                break;

                            case 2:  // Reporte individual
                            if (totalestudiantes > 0)
                            {
                                Console.Write("\n\t Ingrese el número de registro del estudiante (1 - " + totalestudiantes + ") : ");
                                int indice = int.Parse(Console.ReadLine()) - 1;
                                if (indice >= 0 && indice < totalestudiantes)
                                {
                                    MostrarReporte(indice);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t ERROR: El número de registro no existe.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\t ERROR : No hay estudiantes registrados aún.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;

                            case 3: // Lista Completa
                                if (totalestudiantes > 0)
                                {
                                    MostrarListaCompleta(totalestudiantes);
                                }
                                else
                                {
                                    Console.WriteLine("\n   ERROR: No hay datos para mostrar.");
                                }
                            break;
                            case 4:
                                if (totalestudiantes > 0)
                                {
                                    MostrarEstadisticas(totalestudiantes);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n   ERROR: No hay estudiantes registrados para generar estadísticas.");
                                    Console.ResetColor();
                                }
                            break;
                        case 5:
                                //opcion salir
                                centinela = false;
                                Console.WriteLine("\n   Saliendo del sistema");
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n  ERROR: opción fuera de rango (1-5) ");
                                Console.ResetColor();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        //captura de errores de formato
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n   ERROR: Por favor, ingrese solo números enteros.");
                        Console.ResetColor();
                    }

                    // Pausa para que el usuario pueda leer antes de que el Console.Clear() borre todo
                    if (centinela)
                    {
                        Console.WriteLine("\n   Presione ENTER para continuar...");
                        Console.ReadKey();
                    }

                } while (centinela);

                Console.WriteLine("\n   Programa finalizado. ¡Ten un buen día!");

            }

            // ============================================================
            // PROCEDIMIENTOS OBLIGATORIOS (VOID, SIN RETORNO)
            // ============================================================
            static void MostrarBienvenida()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t\t\t");
                Console.WriteLine("===========================================");
                Console.WriteLine("\t\t\tBienvenido al sistema del Colegio Don Bosco");
                Console.WriteLine("\t\t\t===========================================");

                Console.ResetColor();
                Console.WriteLine("\n\t\t\tPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            static void MostrarMenu()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t╔════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t║             MENÚ PRINCIPAL             ║");
                Console.WriteLine("\t\t\t╚════════════════════════════════════════╝");
                Console.ResetColor();

                Console.WriteLine("\n\t\t\t1. Registrar Estudiantes");
                Console.WriteLine("\t\t\t2. Ver Reporte Individual");
                Console.WriteLine("\t\t\t3. Mostrar Lista Completa");
                Console.WriteLine("\t\t\t4. Ver Estadísticas");
                Console.WriteLine("\t\t\t5. Salir del Sistema");
            }

            static void RegistrarEstudiante(int pos)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t╔════════════════════════════════════════╗");
                Console.WriteLine($"\t\t\t║       REGISTRO DEL ESTUDIANTE #{pos + 1}       ║");
                Console.WriteLine("\t\t\t╚════════════════════════════════════════╝");
                Console.ResetColor();

                Console.Write("\n   Nombre completo: ");
                nombres[pos] = Console.ReadLine();

                Console.Write("\n   Carnet: ");
                carnets[pos] = Console.ReadLine();

                // PIDE y VALIDA NOTAS (while + esnotavalida)

                // nota 1
                Console.Write("\n   Nota Parcial 1 (20%): ");
                parcial1[pos] = double.Parse(Console.ReadLine());
                while (!EsNotaValida(parcial1[pos]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   ERROR: Nota fuera de rango (0-10). Intente de nuevo:");
                    Console.ResetColor();
                    parcial1[pos] = double.Parse(Console.ReadLine());
                }

                // nota 2
                Console.Write("\n   Nota Parcial 2 (25%): ");
                parcial2[pos] = double.Parse(Console.ReadLine());
                while (!EsNotaValida(parcial2[pos]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   ERROR: Nota fuera de rango (0-10). Intente de nuevo:");
                    Console.ResetColor();
                    parcial2[pos] = double.Parse(Console.ReadLine());
                }

                // nota 3
                Console.Write("\n   Nota Parcial 3 (25%): ");
                parcial3[pos] = double.Parse(Console.ReadLine());
                while (!EsNotaValida(parcial3[pos]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   ERROR: Nota fuera de rango (0-10). Intente de nuevo:");
                    Console.ResetColor();
                    parcial3[pos] = double.Parse(Console.ReadLine());
                }

                // NOTA FINAL
                Console.Write("\n   Nota Parcial Final (30%): ");
                parcialfinal[pos] = double.Parse(Console.ReadLine());
                while (!EsNotaValida(parcialfinal[pos]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   ERROR: Nota fuera de rango (0-10). Intente de nuevo: ");
                    Console.ResetColor();
                    parcialfinal[pos] = double.Parse(Console.ReadLine());
                }

                promedios[pos] = CalcularPromedio(parcial1[pos], parcial2[pos], parcial3[pos], parcialfinal[pos]);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n   >> ¡Datos guardados exitosamente!");
                Console.ResetColor();
            }

        // ============================================================
        // REPORTE INDIVIDUAL DE CADA ESTUDIANTE Y ESTADO ACADÉMICO
        // ============================================================
        static void MostrarReporte(int pos)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t╔════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║           REPORTE INDIVIDUAL           ║");
            Console.WriteLine("\t\t\t╚════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"\n\t Nombre del Estudiante : {nombres[pos]}");
            Console.WriteLine($"\t Número de Carnet :      {carnets[pos]}");
            Console.WriteLine("\t ------------------------------------------------");
            Console.WriteLine($"\t Nota Parcial 1 (20%) :    {parcial1[pos]}");
            Console.WriteLine($"\t Nota Parcial 2 (25%) :    {parcial2[pos]}");
            Console.WriteLine($"\t Nota Parcial 3 (25%) :    {parcial3[pos]}");
            Console.WriteLine($"\t Nota Parcial Final(30%):  {parcialfinal[pos]}");
            Console.WriteLine("\t ------------------------------------------------");

            double prom = promedios[pos];
            Console.WriteLine($"\t PROMEDIO FINAL :          {prom:F2}");

            // Determinar el color según el estado
            string estado = DeterminarEstado(prom);
            if (estado == "APROBADO")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t ESTADO ACADÉMICO:      {estado}");
                Console.ResetColor();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t ESTADO ACADÉMICO:      {estado}");
                Console.ResetColor();
            }
        }


        //===============================
        // LISTA COMPLETA DE ESTUDIANTES
        //===============================
        static void MostrarListaCompleta(int total)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t╔════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║      LISTA GENERAL DE ESTUDIANTES      ║");
            Console.WriteLine("\t\t\t╚════════════════════════════════════════╝");
            Console.ResetColor();

            // Encabezados de la tabla
            Console.WriteLine("\n\t{0,-5} {1,-20} {2,-12} {3,-10} {4,-10}", "No.", "Nombre", "Carnet", "Promedio", "Estado");
            Console.WriteLine("\t----------------------------------------------------------------------");

            for (int i = 0; i < total; i++)
            {
                string estado = DeterminarEstado(promedios[i]);
                Console.WriteLine("\t{0,-5} {1,-20} {2,-12} {3,8:F2}   {4,-10}",
                    (i + 1),
                    nombres[i],
                    carnets[i],
                    promedios[i],
                    estado);
            }
        }

        //=======================
        // ESTADÍSTICAS GRUPALES
        //=======================
        
        static void MostrarEstadisticas(int total)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t╔════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║          ESTADÍSTICAS GRUPALES         ║");
            Console.WriteLine("\t\t\t╚════════════════════════════════════════╝");
            Console.ResetColor();

            // Llamada de las funciones lógicas para cálculos estadísticos 
            double promedioG = CalcularPromedioGrupal(promedios, total);
            double notaAlta = ObtenerMayor(promedios, total);
            double notaBaja = ObtenerMenor(promedios, total);

            // Cálculo de porcentajes
            int aprobados = 0;
            for (int i = 0; i < total; i++)
            {
                if (promedios[i] >= 6.0) aprobados++;
            }
            double porcAprobados = (double)aprobados / total * 100;
            double porcReprobados = 100 - porcAprobados;

            // Impresión de resultados
            Console.WriteLine($"\n\t Registros procesados: {total}");
            Console.WriteLine("\t ------------------------------------------------");
            Console.WriteLine($"\t Promedio General del Grupo:  {promedioG:F2}");
            Console.WriteLine($"\t Nota más Alta registrada:    {notaAlta:F2}");
            Console.WriteLine($"\t Nota más Baja registrada:    {notaBaja:F2}");
            Console.WriteLine("\t ------------------------------------------------");
            Console.WriteLine($"\t Porcentaje de Aprobados:     {porcAprobados:F2}%");
            Console.WriteLine($"\t Porcentaje de Reprobados:    {porcReprobados:F2}%");
        }
        // ============================================================
        // FUNCIONES OBLIGATORIAS (RETORNAN VALOR)
        // ============================================================

        static double CalcularPromedio(double p1, double p2, double p3, double pf)
            {
                // Pesos según imagen del examen: 20%, 25%, 25%, 30%
                return (p1 * 0.20) + (p2 * 0.25) + (p3 * 0.25) + (pf * 0.30);
            }

            static bool EsNotaValida(double nota)
            {
                if (nota >= 0 && nota <= 10.0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        static string DeterminarEstado(double promedio)
        {
            return (promedio >= 6.0) ? "APROBADO" : "REPROBADO";
        }

        static double ObtenerMayor(double[] datos, int n)
        {
            double m = datos[0];
            for (int i = 1; i < n; i++) if (datos[i] > m) m = datos[i];
            return m;
        }

        static double ObtenerMenor(double[] datos, int n)
        {
            double m = datos[0];
            for (int i = 1; i < n; i++) if (datos[i] < m) m = datos[i];
            return m;
        }

        static double CalcularPromedioGrupal(double[] datos, int n)
        {
            double s = 0;
            for (int i = 0; i < n; i++) s += datos[i];
            return s / n;
        }
    }
}



