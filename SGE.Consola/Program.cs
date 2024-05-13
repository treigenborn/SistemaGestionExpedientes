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

        CasoDeUsoExpedienteAlta CUEAlta = new CasoDeUsoExpedienteAlta(repoExpediente, servicioAutorizacion);
        CasoDeUsoExpedienteBaja CUEBaja = new CasoDeUsoExpedienteBaja(repoExpediente, servicioAutorizacion, repoTramite);
        CasoDeUsoExpedienteModificacion CUEModificacion = new CasoDeUsoExpedienteModificacion(repoExpediente, servicioAutorizacion);
        CasoDeUsoExpedienteConsultaPorId CUEConsultaPorId = new CasoDeUsoExpedienteConsultaPorId(repoExpediente);
        CasoDeUsoExpedienteConsultaTodos CUEConsultaTodos = new CasoDeUsoExpedienteConsultaTodos(repoExpediente);
        CasoDeUsoExpedienteConTramitesAsociados CUEConTramitesAsociados = new CasoDeUsoExpedienteConTramitesAsociados(repoExpediente, repoTramite);

        CasoDeUsoTramiteAlta CUTAlta = new CasoDeUsoTramiteAlta(repoTramite, servicioAutorizacion, servActEstado);
        CasoDeUsoTramiteBaja CUTBaja = new CasoDeUsoTramiteBaja(repoTramite, servicioAutorizacion, servActEstado);
        CasoDeUsoTramiteModificacion CUTModificacion = new CasoDeUsoTramiteModificacion(repoTramite, servicioAutorizacion, servActEstado);
        CasoDeUsoTramiteConsultaPorEtiqueta CUTConsultaPorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(repoTramite);




        Console.WriteLine("Sistema de Gestión de Expedientes");

        Expediente e1 = new Expediente("Caratula1234");


        Console.WriteLine(e1.Caratula);
        Console.WriteLine(e1.FechaCreacion);

        Console.WriteLine("\n\n");
        Tramite t1 = new Tramite(1, EtiquetaTramite.PaseAEstudio, "Contenido tramite");

        //Tramite t2 = new Tramite();
        //Console.WriteLine(t2.TipoTramite);
        //Console.WriteLine(t2.ContenidoTramite);

        Console.WriteLine("\n\n");

        // creamos los expedientes
        //CUEAlta.Ejecutar(e1,1);
        //CUEAlta.Ejecutar(new Expediente ("CaratulaNueva"),1);

        // creamos los tramites
        //CUTAlta.Ejecutar(t1,1);
        //CUTAlta.Ejecutar(new Tramite (2,EtiquetaTramite.PaseAEstudio,"Contenido tramite 2"),1);
        
        Expediente? e = CUEConTramitesAsociados.Ejecutar(1);

        Console.WriteLine(e?.listaDeTramites?.Count);

    }
}
