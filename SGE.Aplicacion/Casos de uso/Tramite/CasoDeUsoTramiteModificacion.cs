namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion (ITramiteRepositorio repoTramite)
{
    public void Ejecutar(Tramite t)
    {
        repoTramite.TramiteModificacion(t); 
    }
}
