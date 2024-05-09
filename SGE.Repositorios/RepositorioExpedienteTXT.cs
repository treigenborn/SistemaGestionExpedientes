using System.Numerics;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    static int contadorExpedientes = contadorActual();
    static readonly string _nombreArch = "Expedientes.txt";

    public void ExpedienteAlta(Expediente e)
    {
        // modificar para lanzar la excepcion aca.
        try
        {
            ExpedienteValidador.Validar(e);
            using var sw = new StreamWriter(_nombreArch, true);
            e.IdExpediente = ++contadorExpedientes; // teniendo en cuenta que en el main nos llega un id 0
            sw.WriteLine(e.IdExpediente);
            sw.WriteLine(e.IdTramite);
            sw.WriteLine(e.FechaCreacion);
            sw.WriteLine(e.FechaModificacion);
            sw.WriteLine(e.Caratula);
            sw.WriteLine(e.Estado);
            sw.WriteLine(e.UsuarioUltModificacion);
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }

    // tener en cuenta: al dar de baja un expediente, se deben eliminar también todos los trámites asociados.
    public void ExpedienteBaja(int idBorrarExpediente)
    {
        try
        {
            bool encontre = false;
            List<Expediente> listaExpediente = new List<Expediente>();
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Expediente eActual = leerExpediente(sr); // nos traemos el expediente actual
                if (eActual.IdExpediente != idBorrarExpediente)
                    listaExpediente.Add(eActual);
                else
                    encontre = true;
            }
            if (encontre)
            {
                actualizarArchivo(listaExpediente);
                RepositorioTramiteTxt repoTramite = new RepositorioTramiteTxt();
                repoTramite.eliminarTramitesAsociados(idBorrarExpediente);
            }
            else
                throw new RepositorioException("La entidad que se intenta eliminar no existe.");
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ExpedienteModificacion(Expediente eModificar)
    {
        try
        {
            bool encontre = false;
            List<Expediente> listaExpediente = new List<Expediente>();
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Expediente eActual = leerExpediente(sr); // nos traemos el expediente actual
                if (eActual.IdExpediente == eModificar.IdExpediente)
                {
                    eActual.FechaModificacion = DateTime.Now;
                    eActual.Caratula = eModificar.Caratula;
                    eActual.Estado = eModificar.Estado;
                    // eActual.usuarioUltModificacion = id Usuario que moddifica ;
                    encontre = true;
                }
            }
            if (encontre)
                actualizarArchivo(listaExpediente);
            else
                throw new RepositorioException("La entidad que se intenta modificar no existe.");
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public Expediente ExpedienteConsultaPorId(int IdExpediente)
    {
        Expediente resultado = new Expediente();
        using var sr = new StreamReader(_nombreArch, true);
        resultado = leerExpediente(sr);
        while (!sr.EndOfStream || resultado.IdExpediente != IdExpediente)
        {
            resultado = leerExpediente(sr);
        }
        return resultado;
    }

    public List<Expediente> ExpedienteConsultaTodos() {
        List<Expediente> expedientes = new List<Expediente>
        using var sr = new StreamReader(_nombreArch, true);
        while (!sr.EndOfStream)
        {
             expedientes.Add(leerExpediente(sr));
        }
        return expedientes;
    }

    //==================== metodos privados
    private Expediente leerExpediente(StreamReader sr)
    {
        Expediente e = new Expediente();
        e.IdExpediente = int.Parse(sr.ReadLine() ?? "");
        e.IdTramite = int.Parse(sr.ReadLine() ?? "");
        e.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        e.FechaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        e.Caratula = sr.ReadLine() ?? "";
        e.Estado = Enum.Parse<EstadoExpediente>(sr.ReadLine() ?? "");
        e.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
        return e;
    }

    private void actualizarArchivo(List<Expediente> listaExpedientes)
    {
        try
        {
            if (File.Exists(_nombreArch))
            {
                File.Delete(_nombreArch);
                foreach (Expediente e in listaExpedientes)
                {
                    ExpedienteAlta(e);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al actualizar el archivo. Error " + e.Message);
        }
    }

    private static int contadorActual()
    {
        using var sr = new StreamReader(_nombreArch, true);
        if (sr.ReadLine() == null)
            return 0;
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
}
