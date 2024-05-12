namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(
    IExpedienteRepositorio repoExpediente,
    IServicioAutorizacion autorizador,
    ITramiteRepositorio repoTramite
)
{
    public void Ejecutar(int idBaja, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteBaja))
            {
                repoExpediente.ExpedienteBaja(idBaja);
                repoTramite.eliminarTramitesAsociados(idBaja);
            }
            else{
                throw new AutorizacionException();
            }
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message); 
        }
    }
}
