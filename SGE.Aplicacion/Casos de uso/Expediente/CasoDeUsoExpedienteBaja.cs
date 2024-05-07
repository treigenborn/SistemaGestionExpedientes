namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar (int  idBaja){
        repoExpediente.ExpedienteBaja(idBaja);
    }
}
