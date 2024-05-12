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
            e.UsuarioUltModificacion = IdUsuario;
            repoExpediente.ExpedienteAlta(e);
            }
            else
            {
                throw new AutorizacionException();
            }
        }

        catch (AutorizacionException error)
        {
            Console.WriteLine(error.Message); 
        }
    }

}
