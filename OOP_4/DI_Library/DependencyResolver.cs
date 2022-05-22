using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class DependencyResolver
    {
        DependencyContainer container;
        public DependencyResolver(DependencyContainer container)
        {
            this.container = container;
        }
        public T GetService<T>()
        {
            return (T)GetService(typeof(T),true);//type - interface type
        }

        public object GetService(Type type, bool isInterface) 
        {
            Dependency dependency;
            if (isInterface == true)
            {
                dependency = container.GetDependencyFromInterface(type);
            }else
            {
                dependency = container.GetDependencyFromClass(type);
            }
            
            try
            {
                var constructor = dependency.type.GetConstructors().Single();
                var parameters = constructor.GetParameters().ToArray();
                if (parameters.Length > 0)
                {
                    var parameterImplementations = new object[parameters.Length];

                    for (int i = 0; i < parameters.Length; i++)
                    {
                       // Type objInterface = parameters[i].ParameterType;
                        parameterImplementations[i] = GetService(parameters[i].ParameterType,false);  
                    }
                    return CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations));
                   
                }
                return CreateImplementation(dependency, t=> Activator.CreateInstance(t));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public object CreateImplementation(Dependency dependency, Func<Type, object> factory)
        {
            if (dependency.Implemented)
            {
                return dependency.Implementation;
            }

            var implementation = factory(dependency.type);//Activator.CreateInstance(dependency.type);
            if (dependency.lifeTime == DependencyLifeTime.SINGLETON)
            {

                dependency.AddImplementation(implementation);
            }

            return implementation;
        }
    }
}
