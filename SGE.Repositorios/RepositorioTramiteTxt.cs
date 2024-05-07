using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramiteTxt
{
     static int contadorTramites = contadorActual();
     static readonly string _nombreArch ="Tramites.txt"; 
      public void TramiteAlta (Tramite t)
    {
        try
        {
            TramiteValidador.Validar(t); 
            using var sw = new StreamWriter(_nombreArch,true);
            t.IdTramite = ++contadorTramites; // teniendo en cuenta que en el main nos llega un id 0
            escribirValores(t,sw); 
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }

    // poner excepcion 
    public void ExpedienteBaja (int idBorrarTramite)
    {   
        try
        {
            bool encontre = false; 
            List<Tramite> listaTramite = new List<Tramite>();  
            using var sr = new StreamReader(_nombreArch,true);
            while (!sr.EndOfStream)
            {
                Tramite tActual = leerTramite(sr); // nos traemos el expediente actual
                if (tActual.IdTramite != idBorrarTramite) 
                    listaTramite.Add(tActual);        
                else
                    encontre = true;        
            }
            if (encontre) actualizarArchivo(listaTramite);
            else throw new RepositorioException ("La entidad que se intenta eliminar no existe."); 
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public void TramiteModificacion (Tramite tModificar ) 
    {

        try 
        {
            bool encontre = false; 
            List<Tramite> listaTramites = new List<Tramite>();  
            using var sr = new StreamReader(_nombreArch,true);
            while (!sr.EndOfStream)
            {
                Tramite tActual = leerTramite(sr); // nos traemos el expediente actual
                if (tActual.IdTramite == tModificar.IdTramite)
                {
                tActual.ExpedienteID = tModificar.ExpedienteID;
                tActual.FechaUltModificacion = DateTime.Now;
                tActual.TipoTramite = tModificar.TipoTramite;
                tActual.ContenidoTramite = tModificar.ContenidoTramite;
                // tActual.usuarioUltModificacion = id Usuario que moddifica ; 
                encontre = true;
                }
            }
            if (encontre) actualizarArchivo(listaTramites);
        }
        catch (RepositorioException e)
        {
             Console.WriteLine(e.Message);
        }
    }

//==================== metodos privados 
    private void escribirValores (Tramite t, StreamWriter sw)
    {
            sw.WriteLine(t.IdTramite);
            sw.WriteLine(t.ExpedienteID);
            sw.WriteLine(t.TipoTramite);
            sw.WriteLine(t.ContenidoTramite);
            sw.WriteLine(t.FechaCreacion);
            sw.WriteLine(t.FechaUltModificacion); 
            sw.WriteLine(t.UsuarioUltModificacion);
    }

    private Tramite leerTramite(StreamReader sr) {
            Tramite t= new Tramite(); 
            t.IdTramite = int.Parse(sr.ReadLine() ?? "");
            t.ExpedienteID = int.Parse(sr.ReadLine()?? "");
            t.TipoTramite = Enum.Parse<EtiquetaTramite>(sr.ReadLine()?? "");
            t.ContenidoTramite =(sr.ReadLine() ?? "");
            t.FechaCreacion = DateTime.Parse(sr.ReadLine()?? "");
            t.FechaUltModificacion = DateTime.Parse(sr.ReadLine()?? "");
            t.UsuarioUltModificacion =int.Parse(sr.ReadLine() ?? "");
            return t;
    }

    private void actualizarArchivo(List <Tramite> listaTramites)
    {
        try
        {
            if (File.Exists(_nombreArch))
            {
                File.Delete(_nombreArch); 
                using var sw = new StreamWriter(_nombreArch,true);
                foreach(Tramite t in listaTramites)
                {
                    escribirValores(t,sw);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al actualizar el archivo. Error "+e.Message); 
        }
    }

    private static int contadorActual ()
    {
        using var sr = new StreamReader(_nombreArch,true);
        if (sr.ReadLine() == null) return 0;
        else
        {
            int ultimoId = 0;
            while (!sr.EndOfStream)
            {
                ultimoId = int.Parse(sr.ReadLine() ?? "");
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();     
            }
            return ultimoId;
        }
    }

     public void eliminarTramitesAsociados (int IdExpediente)
    {
        List<Tramite> listaTramites = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch,true);
        while(!sr.EndOfStream)
        {
            Tramite t = leerTramite(sr);
            if (t.ExpedienteID != IdExpediente)
            {
                listaTramites.Add(t);
            }
        }
        actualizarArchivo(listaTramites);
    }

}
