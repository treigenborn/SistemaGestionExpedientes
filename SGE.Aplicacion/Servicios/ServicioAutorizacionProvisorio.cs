namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio
{
  public bool TienePermiso(int IdUsuario, Permiso permiso)
    {   
        try
        {
        if (IdUsuario == 1)
        {
            return true;
        }
            throw new AutorizacionException();            
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}
