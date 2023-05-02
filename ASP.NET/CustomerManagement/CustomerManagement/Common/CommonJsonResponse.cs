namespace CustomerManagement.Common
{
    public class CommonJsonResponse
    {
        public int Status { get; set; }
        //1=success,2=warining,0=failed
        public string Message { get; set; }
        public dynamic data { get; set; }
    }
}
