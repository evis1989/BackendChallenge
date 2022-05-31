using System;

namespace Application.Responses
{
    public class BaseCommandResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public string Errors { get; set; }
    }
}
