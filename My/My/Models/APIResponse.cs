using System.Net;

namespace Table_Tennis_UK.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMassages { get; set; }
        public object Result { get; set; }
    }
}
