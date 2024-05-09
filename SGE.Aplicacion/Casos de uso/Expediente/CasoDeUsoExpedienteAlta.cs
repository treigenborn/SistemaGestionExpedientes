namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repoExpediente, IServicioAutorizacion autorizador)
{


    public void Ejecutar(Expediente e, int IdUsuario)
    {
        if(autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteAlta)){

        e.FechaCreacion = DateTime.Now;
        e.FechaModificacion = DateTime.Now;
        repoExpediente.ExpedienteAlta(e, IdUsuario);
        }
    }

}
