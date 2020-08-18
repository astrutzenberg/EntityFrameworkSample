using System;
using System.Collections.Generic;

namespace ActiveServicesEntity
{
    public partial class ServiceMessage
    {
        public int Id { get; set; }
        public int HostId { get; set; }
        public int ServiceId { get; set; }
        public string Message { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }

        public virtual Hosts Host { get; set; }
        public virtual Service Service { get; set; }
    }
}
