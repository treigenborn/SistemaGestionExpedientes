namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    // ?????? Aca se debe tener el id de la persona que modifica el tramite
    void TramiteAlta(Tramite t, int IdUsuario);
    void TramiteBaja(int idTramite); 
    void TramiteModificacion(Tramite t, int IdUsuario);
    List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite e);
}
