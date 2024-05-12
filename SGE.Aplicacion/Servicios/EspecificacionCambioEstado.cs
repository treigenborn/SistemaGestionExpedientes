namespace SGE.Aplicacion;

public class EspecificacionCambioEstado
{
    public EstadoExpediente cambioEstadoExpediente(EtiquetaTramite etiqueta, EstadoExpediente e)
    {
        switch (etiqueta)
        {
            case EtiquetaTramite.Resolucion:
                return EstadoExpediente.ConResolucion;
                break;
            case EtiquetaTramite.PaseAEstudio:
                return EstadoExpediente.ParaResolver;
                break;
            case EtiquetaTramite.PaseAlArchivo:
                return EstadoExpediente.Finalizado;
                break;
            default: 
               return e;
        }
    }
}
