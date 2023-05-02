namespace customerManagementSystem.Common
{
    public class CommonJsonResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic data { get; set; }
    }
}
