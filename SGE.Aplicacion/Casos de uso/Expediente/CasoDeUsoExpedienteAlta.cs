namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repoExpediente, IServicioAutorizacion autorizador)
{

// lanzar excepcion si no tiene permiso
    public void Ejecutar(Expediente e, int IdUsuario)
    {
        try 
        {
            if(autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteAlta)){
            e.FechaCreacion = DateTime.Now;
            e.FechaModificacion = DateTime.Now;
            repoExpediente.ExpedienteAlta(e, IdUsuario);
            }
            else
            {
                throw new AutorizacionException();
            }
        }

        catch (AutorizacionException e)
        {
            console.WriteLine(e.Message); 
        }
    }

}
