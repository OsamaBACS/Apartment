using System.Text.Json;

namespace BackEnd.Errors
{
    public class ApiError
    {
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
            return JsonSerializer.Serialize(this);
        }
    }
}