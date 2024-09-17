namespace CrossCutting.DTO
{
    public class StatusResponse {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

    }


    public class StatusResponse<T> : StatusResponse
    {
      
        public T Data { get; set; }
       
        public StatusResponse(T data)
        {
            Data = data;
        }
    }
}
