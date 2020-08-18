using ActiveServicesEntity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveServicesDriver
{
    public class OneShotImpl : OneShotApplicationBase
    {
        private ActiveServicesContext _context;
        public OneShotImpl(ILogger<OneShotImpl> logger, IConfiguration config, IHostApplicationLifetime lifetime, ActiveServicesContext context) : base(logger, config, lifetime)
        {
            _context = context;
        }

        public override void SingletonTask()
        {
            var hosts = _context.Hosts;

            Console.WriteLine("Lets check the state of the table prior to doing anything");
            foreach (var h in hosts)
            {
                Console.WriteLine($"Host(hostname:={h.Hostname},id:={h.Id})");
            }

            string toAdd = "P3NWVPWEB099";//need to conver this to an argument 

            var hostEntry = _context.Hosts.Where(h => h.Hostname == toAdd).FirstOrDefault();
            if ( hostEntry == null)
            {
                Console.WriteLine($"Entry for {toAdd} not found, adding");
                hostEntry = new Hosts { Hostname = toAdd };

                _context.Hosts.Add(hostEntry);
                _context.SaveChanges();
            }

            hostEntry = _context.Hosts.Where(h => h.Hostname == toAdd).FirstOrDefault();
            Console.WriteLine($"Host(hostname:={hostEntry.Hostname},id:={hostEntry.Id}");

            Console.WriteLine("Now lets delete it!");
            _context.Hosts.Remove(hostEntry);
            _context.SaveChanges();

            Console.WriteLine("Lets check the hosts table once again");
            foreach (var h in hosts)
            {
                Console.WriteLine($"Host(hostname:={h.Hostname},id:={h.Id})");
            }          
        }
        public override void Dispose()
        {
            //NO!!!
            // according to https://softwareengineering.stackexchange.com/questions/359667/is-it-ok-to-create-an-entity-framework-datacontext-object-and-dispose-it-in-a-us#:~:text=Don't%20dispose%20DbContext%20objects,the%20database%20connection%20for%20you.
            // the service layer will handle this for you
            //_context.Dispose();
            base.Dispose();
        }
    }
}
