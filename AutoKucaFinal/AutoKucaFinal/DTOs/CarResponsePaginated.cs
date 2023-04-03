namespace AutoKucaFinal.DTOs
{
    public class CarResponsePaginated
    {
        public List<CarResponse> cars { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
