namespace DF_Project_APIs.Models.ReponseModel
{
    public class ResponseForGetAccounHolderById<T> : ResponseDto
    {
        public T AccounHolderData { get; set; }
    }
}
