namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConTramitesAsociados(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente Ejecutar(int idExpediente)
    {
        Expediente exp = repoExpediente.ExpedienteConsultaPorId(idExpediente));
        exp.listaDeTramites = repoTramite.TramiteConsultaPorIdExpediente(idExpediente);
        return exp;
    }
}
