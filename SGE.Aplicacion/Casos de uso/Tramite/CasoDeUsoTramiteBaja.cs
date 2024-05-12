namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(
    ITramiteRepositorio repoTramite,
    IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado
)
{
    public void Ejecutar(int idTramite, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.TramiteBaja))
            {
                Tramite t = repoTramite.TramiteConsultaUltimo();
                repoTramite.TramiteBaja(idTramite);
                if (t.IdTramite == idTramite)
                {
                    actualizacionEstado.actualizacionEstadoExpediente(t.ExpedienteID, t.TipoTramite);
                }
            }
            else
                throw new AutorizacionException();
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
