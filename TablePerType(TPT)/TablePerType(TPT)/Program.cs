using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TablePerType_TPT_
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TablePerType.VehicleDBEntities();
            var query = (from c in db.Vehicles.OfType<TablePerType.Car>()
                             select c).ToList(); 
        }
    }
}
