using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TablePerHierarchy.VehicleDBEntities();
            var q = (from c in db.Vehicles.OfType<TablePerHierarchy.Car>()
                             select c);

            var r = q.ToList();
        }
    }
}
