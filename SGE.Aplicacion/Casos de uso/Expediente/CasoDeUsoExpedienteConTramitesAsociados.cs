namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConTramitesAsociados(IExpedienteRepositorio repoExpediente)
{
    public List<Expediente> Ejecutar()
    {
        return repoExpediente.ExpedienteConTramitesAsociados();
    }
}
