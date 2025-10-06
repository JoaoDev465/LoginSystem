using System.Text.Json.Serialization;
using Core.ValueObject.ResponseObject;

namespace Core.Response;

public class ResponseModel<T>
{

    [JsonConstructor]
    public ResponseModel(){}
    
    public  ResponseModel(T? data, string? message, Code? code)
    {
        Data = data;
        Message = message;
        Code = code;
    }

    public static ResponseModel<T> Success(T? data) =>
        new ResponseModel<T>(data, "Ok", Code.Ok);
    
    public static ResponseModel<T> Created(T? data) =>
        new ResponseModel<T>(data, "Created", Code.Created);
    
    
    public static ResponseModel<T> BadRequest(T? data,string? message) =>
        new ResponseModel<T>(data, "Bad request", Code.BadRequest);
    
    public static ResponseModel<T> NotFound(T? data, string? message) =>
        new ResponseModel<T>(data, "Not Found", Code.NotFound);
    
    public static ResponseModel<T> InternalError(T? data) =>
        new ResponseModel<T>(data, "Internal Server Error", Code.InternalError);


    
    public string? Message { get; set; }
    public T? Data { get; set; }
    public Code? Code { get; set; }
    
    
}