namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio repo, IServicioAutorizacion autorizador)
{
    public void Ejecutar (Expediente e, int IdUsuario)
    {
        try
        {
            if(autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteModificacion)){
            e.FechaModificacion = DateTime.Now;
            repo.ExpedienteModificacion(e);
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
