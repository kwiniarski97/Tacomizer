using Tacomizer.Model;

namespace Tacomizer.Extensions
{
    public static class ResponseExtensions
    {
        public static bool IsNull(this Response response)
        {
            return response == null;
        }
    }
}