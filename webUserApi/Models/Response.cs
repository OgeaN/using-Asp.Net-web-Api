namespace webApi.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public String StatusMessage { get; set; }

        public userModel userModel { get; set; }
        public List<userModel> users { get; set; }
    }
}
