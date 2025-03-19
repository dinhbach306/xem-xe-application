using System.Text.Json.Serialization;

namespace XemXe.Application.DTOs.Responses;

public class ApiResponse<T>
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T Value { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Error { get; set; }

    // Constructor cho thành công
    public static ApiResponse<T> Success(T value, string message = "Thành công", int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            Message = message,
            StatusCode = statusCode,
            Value = value,
            Error = null
        };
    }

    // Constructor cho thất bại
    public static ApiResponse<T> Failure(string error, string message = "Thất bại", int statusCode = 400)
    {
        return new ApiResponse<T>
        {
            Message = message,
            StatusCode = statusCode,
            Value = default,
            Error = error
        };
    }
}