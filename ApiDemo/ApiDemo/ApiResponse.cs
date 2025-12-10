namespace ApiDemo
{
    public class ApiResponse<T >
    {
        public required string Message { get; set; }
 
        public  T? Data { get; set; }
    }
}
