namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta (ITramiteRepositorio repoTramite, IServicioAutorizacion autorizador,ServicioActualizacionEstado actualizacionEstado)
{
    public void Ejecutar (Tramite t, int IdUsuario)
    {
        if(autorizador.TienePermiso(IdUsuario, Permiso.TramiteAlta)) {
        t.FechaCreacion = DateTime.Now;
        t.FechaUltModificacion = DateTime.Now;
        repoTramite.TramiteAlta(t, IdUsuario); 
        actualizacionEstado.actualizacionEstadoExpediente(t.IdExpediente, t.EtiquetaTramite);
        }
    } 
    
}
