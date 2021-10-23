using System.Text.Json;

namespace BackEnd.Errors
{
    public class ApiError
    {
        public ApiError(){}

        public ApiError(int errorCode, string errorMessage, string errorDetailes = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetailes = errorDetailes;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetailes { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}