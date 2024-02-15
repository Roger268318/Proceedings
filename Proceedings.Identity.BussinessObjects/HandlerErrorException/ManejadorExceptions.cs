namespace Proceedings.Identity.BussinessObjects.HandlerErrorException
{
    public class ManejadorExceptions : Exception
    {
        public HttpStatusCode Codigo { get; }
        public object Errores { get; }

        public ManejadorExceptions(HttpStatusCode codigo, object errores = null)
        {
            Codigo = codigo;
            Errores = errores;
        }
    }
}
