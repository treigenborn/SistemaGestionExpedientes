namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio
{
  public bool TienePermiso(int IdUsuario, Permiso permiso)
    {   
        return IdUsuario == 1; 
    }
}
