using SGE.Aplicacion;
using SGE.Repositorios;
using System;

namespace SGE.Consola;
{
    class Program
    {
        static void Main(string[] args)
        {
            IExpedienteRepositorio repoExpediente = new RepositorioExpedienteTXT();
            ITramiteRepositorio repoTramite = new RepositorioTramiteTxt();
            IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
            ExpedienteValidador expedienteValidador = new ExpedienteValidador();
            TramiteValidador tramiteValidador = new TramiteValidador();
            ServicioActualizacionEstado servActEstado = new ServicioActualizacionEstado();



            Console.WriteLine("Sistema de Gestión de Expedientes");

            Expediente expediente = new Expediente();
            expediente.Caratula = "Caratula";
                      
        }
    }
}