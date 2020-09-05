namespace what_am_i_eating.Models
{
    public class ServiceResponse<T> 
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}