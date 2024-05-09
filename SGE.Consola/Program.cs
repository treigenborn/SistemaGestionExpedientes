using SGE.Aplicacion;
using SGE.Repositorios;
using System;

namespace SGE.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Gestión de Expedientes");

            Expediente expediente = new Expediente();
            expediente.Caratula = "Caratula";
                      
        }
    }
}