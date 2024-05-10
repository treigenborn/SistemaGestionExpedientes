namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConTramitesAsociados(IExpedienteRepositorio repoExpediente)
{
    public Expediemte Ejecutar(int idExpediente)
    {
        return repoExpediente.ExpedienteConTramitesAsociados(idExpediente));
    }
}
