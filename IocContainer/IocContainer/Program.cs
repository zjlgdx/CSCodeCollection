using System;

namespace IocContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new Resolver();
            resolver.Register<Shopper, Shopper>();
            //resolver.Register<ICreditCard, MasterCard>();
            resolver.Register<ICreditCard, Visa>();
            var shopper = resolver.Resolve<Shopper>();
            shopper.Charge();
            Console.Read();
        }
    }
}
