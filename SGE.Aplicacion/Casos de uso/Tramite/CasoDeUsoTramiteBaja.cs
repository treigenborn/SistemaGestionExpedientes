namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja (ITramiteRepositorio repoTramite, IServicioAutorizacion autorizador, ServicioActualizacionEstado actualizacionEstado) 
{
    public void Ejecutar (int idTramite, int IdUsuario)
    {
        if(autorizador.TienePermiso(IdUsuario, Permiso.TramiteBaja)){ 
        repoTramite.TramiteBaja(idTramite); 
        actualizacionEstado.actualizacionEstadoExpediente(t.IdExpediente, t.EtiquetaTramite);
        }
    }

}
