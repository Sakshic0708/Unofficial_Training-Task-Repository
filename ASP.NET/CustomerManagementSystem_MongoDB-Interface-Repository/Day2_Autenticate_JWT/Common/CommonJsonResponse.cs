namespace MongoDBInterfaceRepository.Common
{
    public class CommonJsonResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic data { get; set; }
    }

    public class LoginResponse : CommonJsonResponse
    {
        public string access_tocken { get; set; }
        public string tocken_type { get; set; }
    }
}
