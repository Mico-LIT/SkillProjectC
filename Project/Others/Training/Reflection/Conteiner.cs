using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Reflection
{
    public class Conteiner
    {
        Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public Conteiner()
        {
        }

        public ContainerBuilder For<TSourse>()
        {
            return this.For(typeof(TSourse));
        }

        public ContainerBuilder For(Type type)
        {
            return new ContainerBuilder(this, type);
        }

        public TSourse Resolve<TSourse>()
        {
            return (TSourse)this.Resolve(typeof(TSourse));
        }

        public object Resolve(Type type)
        {
            if (_map.ContainsKey(type))
            {
                var destinationsType = _map[type];
                return CreateInstance(destinationsType);
            }
            else if (type.IsGenericType && _map.ContainsKey(type.GetGenericTypeDefinition()))
            {
                var destinanion = _map[type.GetGenericTypeDefinition()];
                var clouseDestination = destinanion.MakeGenericType(type.GetGenericArguments());
                return CreateInstance(clouseDestination);
            }
            else if (!type.IsAbstract)
            {
                return CreateInstance(type);
            }
            else
            {
                throw new InvalidOperationException("Could not resolve" + type.FullName);
            }
        }

        private object CreateInstance(Type destinationsType)
        {
            var param = destinationsType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Count())
                .First()
                .GetParameters()
                .Select(x => Resolve(x.ParameterType))
                .ToArray();

            return Activator.CreateInstance(destinationsType, param);
        }

        public class ContainerBuilder
        {
            private readonly Conteiner conteiner;
            private readonly Type typeSourse;

            public ContainerBuilder(Conteiner conteiner, Type typeSourse)
            {
                this.conteiner = conteiner;
                this.typeSourse = typeSourse;
            }

            public ContainerBuilder Use<TDestination>()
            {
                return this.Use(typeof(TDestination));
            }

            public ContainerBuilder Use(Type typeDestination)
            {
                conteiner._map.Add(typeSourse, typeDestination);
                return this;
            }
        }
    }
}
