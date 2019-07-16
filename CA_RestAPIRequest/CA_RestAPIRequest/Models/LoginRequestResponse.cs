namespace CA_RestAPIRequest
{
    public class LoginRequestResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }

    public class LoginErrorResponse
    {
        public string Error { get; set; }
    }
}
