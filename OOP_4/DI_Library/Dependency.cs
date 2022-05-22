using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class Dependency
    {
        public Type type { get; set; }
        public Type interfaceType { get; set; }
        public DependencyLifeTime lifeTime { get; set; }
        public object Implementation { get; set; }
        public bool Implemented { get; set; }

        public Dependency(Type t,Type interf, DependencyLifeTime lifetime)
        {
            type = t;
            lifeTime = lifetime;
            interfaceType = interf;
        }

        public void AddImplementation(object obj)
        {
            Implementation = obj;
            Implemented = true;
        }
    }
}
