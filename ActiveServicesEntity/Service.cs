using System;
using System.Collections.Generic;

namespace ActiveServicesEntity
{
    public partial class Service
    {
        public Service()
        {
            ServiceMessage = new HashSet<ServiceMessage>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<ServiceMessage> ServiceMessage { get; set; }
    }
}
