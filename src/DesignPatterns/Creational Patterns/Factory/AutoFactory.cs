using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPatterns.Creational_Patterns.Factory
{
    public class AutoFactory
    {
        public Dictionary<string, Type> Autos;
        private bool _isSet;

        public AutoFactory()
        {
            LoadTypesICanReturn();
        }

        private void LoadTypesICanReturn()
        {
            // factories in .Net heavily use reflection 
            if (_isSet) return;
            Autos = new Dictionary<string, Type>();
            var typesInThisAssembly = 
                Assembly.GetExecutingAssembly().GetTypes().ToList();
            foreach (var type in typesInThisAssembly
                .Where(type => type.GetInterface(typeof(IAuto).ToString()) != null))
                Autos.Add(type.Name.ToLower(), type);
            _isSet = true;
        }

        public IAuto CreateInstance(string carName)
        {
            Type t = GetCarType(carName);
            return t == null 
                ? new NullCar() 
                : Activator.CreateInstance(t) as IAuto;
        }

        private Type GetCarType(string carName)
        {
            Func<KeyValuePair<string, Type>, bool> findCar = 
                pair => pair.Key.Contains(carName.ToLower());
            return Autos.FirstOrDefault(findCar).Value;
        }
    }
}
