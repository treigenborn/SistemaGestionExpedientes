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

        // damos de alta expedientes 
        //CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"),1);
        //CUEAlta.Ejecutar(new Expediente("Caratula Expediente 2 "),1);



        //Damos de alta tramites, y lo asociamos a los expedientes.
        //Tramite t1 = new Tramite(1,EtiquetaTramite.Resolucion,"Contenidooooooo");
        


        //CUTBaja.Ejecutar(1,1);
        
        repoTramite.eliminarTramitesAsociados(1);

        //CUEBaja.Ejecutar(1,1);











        /*

        Expediente? e = CUEConTramitesAsociados.Ejecutar(1);    
        if (e?.listaDeTramites != null){
            foreach (Tramite t in e.listaDeTramites){
                Console.WriteLine(t.ToString());
            }
        }

        List<Expediente> listaExpedientes = CUEConsultaTodos.Ejecutar();
        Console.WriteLine(listaExpedientes.Count());
        */
    }
}
