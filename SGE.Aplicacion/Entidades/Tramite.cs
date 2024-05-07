using System.Dynamic;
using System.Text.RegularExpressions;

namespace SGE.Aplicacion;

public class Tramite
{
    public int IdTramite{get; set;}
    public int ExpedienteID{get; set;}
    public  EtiquetaTramite TipoTramite {get; set;}
    public string ContenidoTramite {get ; set; } 
    public DateTime FechaCreacion {get; set;}
    public DateTime FechaUltModificacion {get; set; }
    public int UsuarioUltModificacion{get ; set;} 
}
