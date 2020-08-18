using System;
using System.Collections.Generic;

namespace ActiveServicesEntity
{
    public partial class Hosts
    {
        public Hosts()
        {
            ServiceMessage = new HashSet<ServiceMessage>();
        }

        public int Id { get; set; }
        public string Hostname { get; set; }

        public virtual ICollection<ServiceMessage> ServiceMessage { get; set; }
    }
}
