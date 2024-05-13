﻿using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramiteTxt : ITramiteRepositorio
{
    static readonly string _nombreArch = "Tramites.txt";
    static int contadorTramites = contadorActual();

    public void TramiteAlta(Tramite t)
    {
        try
        {
            TramiteValidador.Validar(t);
            using var sw = new StreamWriter(_nombreArch, true);
            t.IdTramite = ++contadorTramites;
            escribirValores(t, sw);
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }

    public void TramiteBaja(int idBorrarTramite)
    {
        try
        {
            bool encontre = false;
            List<Tramite> listaTramite = new List<Tramite>();
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Tramite tActual = leerTramite(sr);
                if (tActual.IdTramite != idBorrarTramite)
                    listaTramite.Add(tActual);
                else
                    encontre = true;
            }
            if (encontre)
            {
                sr.Dispose();
                actualizarArchivo(listaTramite);
            }
                
            else
                throw new RepositorioException("El tramite que se intenta eliminar no existe.");
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void TramiteModificacion(Tramite tModificar)
    {
        try
        {
            bool encontre = false;
            List<Tramite> listaTramites = new List<Tramite>();
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Tramite tActual = leerTramite(sr);
                if (tActual.IdTramite == tModificar.IdTramite)
                {
                    tActual.ExpedienteID = tModificar.ExpedienteID;
                    tActual.FechaUltModificacion = DateTime.Now;
                    tActual.TipoTramite = tModificar.TipoTramite;
                    tActual.ContenidoTramite = tModificar.ContenidoTramite;
                    tActual.UsuarioUltModificacion = tModificar.UsuarioUltModificacion;
                    encontre = true;
                }
            }
            if (encontre) 
            {
                sr.Dispose();
                actualizarArchivo(listaTramites);
            }         
            else
                 throw new RepositorioException();
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    /* 
        Evaluar el caso en el que no se encuentre el tramite, que se devuelve? 
    */
    public List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        List<Tramite> listaTramites = new List<Tramite>();

        using var sr = new StreamReader(_nombreArch, true);

        while (!sr.EndOfStream)
        {
            Tramite tActual = leerTramite(sr);
            if (tActual.TipoTramite == etiqueta)
            {
                listaTramites.Add(tActual);
            }
        }
        return listaTramites;
    }

    public List<Tramite> TramiteConsultaPorIdExpediente(int idExpediente)
    {
        List<Tramite> listaTramites = new List<Tramite>();

        using var sr = new StreamReader(_nombreArch, true);

        while (!sr.EndOfStream)
        {
            Tramite tActual = leerTramite(sr);
            if (tActual.ExpedienteID == idExpediente)
            {
                listaTramites.Add(tActual);
            }
        }
        return listaTramites;
    }

    public Tramite TramiteConsultaUltimo()
    {
        Tramite t = new Tramite();
        using var sr = new StreamReader(_nombreArch, true);

        while (!sr.EndOfStream)
        {
            t = leerTramite(sr);
        }
        return t;
    }

    //==================== metodos privados
    private void escribirValores(Tramite t, StreamWriter sw)
    {
        sw.WriteLine(t.IdTramite);
        sw.WriteLine(t.ExpedienteID);
        sw.WriteLine(t.TipoTramite);
        sw.WriteLine(t.ContenidoTramite);
        sw.WriteLine(t.FechaCreacion);
        sw.WriteLine(t.FechaUltModificacion);
        sw.WriteLine(t.UsuarioUltModificacion);
    }

    private Tramite leerTramite(StreamReader sr)
    {
        Tramite t = new Tramite();
        t.IdTramite = int.Parse(sr.ReadLine() ?? "");
        t.ExpedienteID = int.Parse(sr.ReadLine() ?? "");
        t.TipoTramite = Enum.Parse<EtiquetaTramite>(sr.ReadLine() ?? "");
        t.ContenidoTramite = (sr.ReadLine() ?? "");
        t.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        t.FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        t.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
        return t;
    }

    private void actualizarArchivo(List<Tramite> listaTramites)
    {
        try
        {
            if (File.Exists(_nombreArch))
            {
                File.Delete(_nombreArch);
                using var sw = new StreamWriter(_nombreArch, true);
                foreach (Tramite t in listaTramites)
                {
                    escribirValores(t, sw);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al actualizar el archivo. Error " + e.Message);
        }
    }



// modificar desp
    private static int contadorActual()
    {
        using var sr = new StreamReader(_nombreArch, true);
        int ultimoId = 0;
            while (!sr.EndOfStream)
            {      
                string? id = sr.ReadLine();
                if (!String.IsNullOrEmpty(id))
                {
                    ultimoId = Int32.Parse(id);
                    for (int i=1; i<7; i++){
                        sr.ReadLine(); 
                    }
                }
            }
        return ultimoId; 
    }


    public void eliminarTramitesAsociados(int IdExpediente)
    {
        try
        {
            bool encontre = false;
            List<Tramite> listaTramites = new List<Tramite>();
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Tramite t = leerTramite(sr);
                if (t.ExpedienteID != IdExpediente)
                {
                    listaTramites.Add(t);
                    encontre = true;
                }
            }
            if (encontre)
            {
                actualizarArchivo(listaTramites);
            }
            else
                throw new RepositorioException("La entidad que se intenta eliminar no existe.");
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
