using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC
{
    public class Resolver
    {
        // public ICreditCard ResolveCreditCard()
        // {
        //     if (new Random().Next(2) == 1)
        //         return new Visa();
        //     return new MasterCard();
        // }

        private readonly Dictionary<Type, Type> _dependancyMap = new Dictionary<Type, Type>();
        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public void Register<TContract, TImplementation>()
        {
            _dependancyMap.Add(typeof(TContract), typeof(TImplementation));
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
            if (constructorParameters.Length != 0)
                return firstConstructor.Invoke(
                    constructorParameters.Select(
                        parametersInfo => Resolve(parametersInfo.ParameterType)
                    ).ToArray()
                );
            return Activator.CreateInstance(resolveType);
        }

    }
}