namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja (ITramiteRepositorio repoTramite) 
{
    public void Ejecutar (int idTramite)
    {
        repoTramite.TramiteBaja(idTramite); 
    }

}
