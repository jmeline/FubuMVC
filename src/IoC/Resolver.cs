using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC
{
    public class Resolver
    {
//        public ICreditCard ResolveCreditCard()
//        {
//            if (new Random().Next(2) == 1)
//                return new Visa();
//            return new MasterCard();
//        }
        
        private readonly Dictionary<Type, Type> _dependancyMap = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public void Register<TFrom, TTo>()
        {
            _dependancyMap.Add(typeof(TFrom), typeof(TTo));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolveType;
            try
            {
                resolveType = _dependancyMap[typeToResolve];
            }
            catch
            {
                throw new Exception($"Could not resolve type {typeToResolve.FullName}");
            }

            var firstConstructor = resolveType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(resolveType);
            }

            IList<object> parameters = new List<object>();
            foreach (var parameter in constructorParameters)
            {
                parameters.Add(Resolve(parameter.ParameterType));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }

    }
}