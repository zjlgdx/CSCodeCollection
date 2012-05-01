using System;
using System.Collections.Generic;
using System.Linq;

namespace IocContainer
{
    public class Resolver
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType = null;
            resolvedType = _dependencyMap[typeToResolve];

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            
            if (!constructorParameters.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }

            IList<object> parameters = constructorParameters.Select(constructorParameter => Resolve(constructorParameter.ParameterType)).ToList();

            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }
    }
}