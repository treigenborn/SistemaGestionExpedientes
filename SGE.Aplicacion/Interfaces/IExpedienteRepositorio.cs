namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void ExpedienteAlta(Expediente expAlta, int IdUsuario);
    void ExpedienteBaja(int idBaja); 
    void ExpedienteModificacion(Expediente expModificacion, int IdUsuario);
    Expediente ExpedienteConsultaPorId(int IdExpediente);
    List<Expediente> ExpedienteConsultaTodos();
    Expediente ExpedienteConTramitesAsociados(int IdExpediente); 
}
