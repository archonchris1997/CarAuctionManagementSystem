namespace CarAuctionManagementSystem.Utils;

public class OperationResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";

    // API-friendly: devolve lista de erros em JSON
    public List<string> Errors { get; set; } = new List<string>();
}

public class OperationResult<T> : OperationResult
{
    public T? Data { get; set; }
}