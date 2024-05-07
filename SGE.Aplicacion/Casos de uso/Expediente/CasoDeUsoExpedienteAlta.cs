namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repoExpediente)
{


    public void Ejecutar(Expediente e)
    {
        e.FechaCreacion = DateTime.Now;
        e.FechaModificacion = DateTime.Now;
        repoExpediente.ExpedienteAlta(e);
    }

}
