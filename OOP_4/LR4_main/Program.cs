using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI_Library;
//using LR4_main.Classes;

namespace LR4_main
{
    class Program
    {
        static void Main(string[] args)
        {
 
            var container = new DependencyContainer();
            var error = new CycleError();
            string err = error.CheckForCycles(typeof(NumberService));
            if (err != null)
            {
                Console.WriteLine(err);
                Console.Read();
                return;
            }
            container.AddTransientDependency<NumberService, IService>();
            container.AddSingletonDependency<NumberServiceConsumer, INumberServiceConsumer>();

            var resolver = new DependencyResolver(container);

            //singleton
            IService numberService = resolver.GetService<IService>();
            numberService.Print();
            var numberService2 = resolver.GetService<IService>();
            numberService2.Print();
            var numberService3 = resolver.GetService<IService>();
            numberService3.Print();
            
            err = error.CheckForCycles(typeof(NumberService));
            if (err != null)
            {
                Console.WriteLine(err);
                Console.Read();
                return;
            }

            //transient
            var serviceConsumer = resolver.GetService<INumberServiceConsumer>();
            serviceConsumer.Print();
            var serviceConsumer2 = resolver.GetService<INumberServiceConsumer>();
            serviceConsumer2.Print();
            var serviceConsumer3 = resolver.GetService<INumberServiceConsumer>();
            serviceConsumer3.Print();

            Console.Read();
        }
    }
}
