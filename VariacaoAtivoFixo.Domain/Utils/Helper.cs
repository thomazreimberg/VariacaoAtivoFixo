namespace VariacaoAtivoFixo.Domain.Utils
{
    public static class Helper
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp) =>
            DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
    }
}
