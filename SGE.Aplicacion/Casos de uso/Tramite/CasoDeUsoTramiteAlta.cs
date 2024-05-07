namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta (ITramiteRepositorio repoTramite)
{
    public void Ejecutar (Tramite t)
    {
        t.FechaCreacion = DateTime.Now;
        t.FechaUltModificacion = DateTime.Now;
        repoTramite.TramiteAlta(t); 
    } 
    
}
