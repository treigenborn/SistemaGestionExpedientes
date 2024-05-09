namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(
    IExpedienteRepositorio repoExpediente,
    IServicioAutorizacion autorizador
)
{
    public void Ejecutar(int idBaja, int IdUsuario)
    {
        if (autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteBaja))
        {
            repoExpediente.ExpedienteBaja(idBaja);
        }
    }
}
