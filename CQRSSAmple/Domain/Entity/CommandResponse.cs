using System;

namespace CQRSSAmple.Domain.Entity
{
    public class CommandResponse
    {
        public Guid ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}