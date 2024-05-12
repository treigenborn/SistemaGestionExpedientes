namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(Tramite t, int IdUsuario);
    void TramiteBaja(int idTramite); 
    void TramiteModificacion(Tramite t, int IdUsuario);
    List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite e);
    List<Tramite> TramiteConsultaPorIdExpediente(int IdExpediente);
    Tramite TramiteConsultaUltimo();
    void eliminarTramitesAsociados(int idExpediente);
}
