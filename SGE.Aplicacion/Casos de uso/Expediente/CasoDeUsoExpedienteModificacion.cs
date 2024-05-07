namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio repo)
{
    public void Ejecutar (Expediente e)
    {
        e.FechaModificacion = DateTime.Now;
        repo.ExpedienteModificacion(e);
    }
}
