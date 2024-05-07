namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    
    void ExpedienteAlta(Expediente expAlta);
    void ExpedienteBaja(int idBaja); 
    void ExpedienteModificacion(Expediente expModificacion);
}
