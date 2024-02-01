namespace CityBike.Service.src.Shared
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }

        public CustomException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public static CustomException NotAvailable(string message)
        {
            return new CustomException(400, message);
        }

        public static CustomException NotFound(string msg = "Not found.")
        {
            return new CustomException(404, msg);
        }

        public static CustomException NotAllowed(string message = "Not allowed.")
        {
            return new CustomException(405, message);
        }

    }
}