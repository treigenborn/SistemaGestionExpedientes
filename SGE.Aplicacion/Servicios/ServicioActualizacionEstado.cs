namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(EspecificacionCambioEstado especificacionCambioEstado, IExpedienteRepositorio repoExpediente)
{
    public void actualizacionEstadoExpediente(int IdExpediente, EtiquetaTramite etiqueta, int IdUsuario) {
       Expediente exp = repoExpediente.ExpedienteConsultaPorId(IdExpediente);
       exp.Estado = especificacionCambioEstado.cambioEstadoExpediente(etiqueta, exp.Estado);
       repoExpediente.ExpedienteModificacion(exp, IdUsuario);
    }
}
