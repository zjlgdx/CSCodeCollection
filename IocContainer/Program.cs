using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IocContainer
{
    class Program
    {
        static void Main(string[] args)
        {


            var resolver = new Resolver();
            //var shopper = new Shopper(resolver.ResolveCreditCard());
            resolver.Register<Shopper, Shopper>();
            //resolver.Register<ICreditCard, MasterCard>();
            resolver.Register<ICreditCard, Visa>();
            var shopper = resolver.Resolve<Shopper>();
            shopper.Charge();
            Console.Read();
        }
    }

    public class Resolver
    {
        private Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = dependencyMap[typeToResolve];
            }
            catch (Exception)
            {

                throw;
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            if (constructorParameters.Count() == 0)
            {
                return Activator.CreateInstance(resolvedType);
            }

            IList<object> parameters = new List<object>();
            foreach (var constructorParameter in constructorParameters)
            {
                parameters.Add(Resolve(constructorParameter.ParameterType));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<TFrom, TTo>()
        {
            dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }
    }

    public class Visa : ICreditCard
    {
        public string Charge()
        {
            return "charging with the visa";
        }
    }

    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Swiping hte MasterCard!";
        }
    }

    public class Shopper
    {
        private readonly ICreditCard creditCard;

        public Shopper(ICreditCard creditCard)
        {
            this.creditCard = creditCard;
        }

        public void Charge()
        {
            var chargeMessage = creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }
    
    public interface ICreditCard
    {
        string Charge();
    }
}
