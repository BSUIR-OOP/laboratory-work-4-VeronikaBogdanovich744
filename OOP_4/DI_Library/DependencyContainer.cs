using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class DependencyContainer
    {
        List<Dependency> dependencies;

        public DependencyContainer()
        {
            dependencies = new List<Dependency>();
        }
        public void AddSingletonDependency<T, TInterface>()
        {
            dependencies.Add(new Dependency(typeof(T),typeof(TInterface),DependencyLifeTime.SINGLETON));
        }

        public void AddTransientDependency<T, TInterface>()
        {
            dependencies.Add(new Dependency(typeof(T), typeof(TInterface), DependencyLifeTime.TRANSIENT));
        }

        public Dependency GetDependencyFromInterface(Type inerfaceType)
        {
            return dependencies.FirstOrDefault(x => x.interfaceType == inerfaceType);
        }

        public Dependency GetDependencyFromClass(Type type)
        {
            return dependencies.FirstOrDefault(x => x.type.Name == type.Name);
        }
    }
}
