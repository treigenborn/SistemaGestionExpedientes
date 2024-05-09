namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(
    ITramiteRepositorio repoTramite,
    IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado
)
{
    public void Ejecutar(Tramite t, int IdUsuario)
    {
        if (autorizador.TienePermiso(IdUsuario, Permiso.TramiteModificacion))
        {
            repoTramite.TramiteModificacion(t, IdUsuario);
            actualizacionEstado.actualizacionEstadoExpediente(t.IdExpediente, t.EtiquetaTramite);
        }
    }
}
