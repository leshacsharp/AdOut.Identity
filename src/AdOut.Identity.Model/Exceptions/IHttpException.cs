namespace AdOut.Identity.Model.Exceptions
{
    public interface IHttpException
    {
        int HttpStatusCode { get; }
    }
}
