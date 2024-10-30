namespace AMVA.REDRIO.Core
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string MessageError { get; set; } = string.Empty;
        public object Result { get; set; } = null!;
        public object Error { get; set; } = string.Empty;
    }
}
