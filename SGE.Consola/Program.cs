using System;
using SGE.Aplicacion;
using SGE.Repositorios;

namespace SGE.Consola;

class Program
{
    static void Main(string[] args)
    {
        IExpedienteRepositorio repoExpediente = new RepositorioExpedienteTXT();
        ITramiteRepositorio repoTramite = new RepositorioTramiteTxt();
        IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
        EspecificacionCambioEstado espCambioEstado = new EspecificacionCambioEstado();
        ServicioActualizacionEstado servActEstado = new ServicioActualizacionEstado(espCambioEstado, repoExpediente);

        Console.WriteLine("Sistema de Gestión de Expedientes");

        Expediente expediente = new Expediente();
        expediente.Caratula = "Caratula";
    }
}
