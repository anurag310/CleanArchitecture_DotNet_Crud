using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrudCleanArchitectureWithMediator.Application.Common.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            ApplyMappingFormAssembly(Assembly.GetExecutingAssembly());
        }
        private void ApplyMappingFormAssembly(Assembly assembly)
        {
            var mapFormType = typeof(IMapperForm<>);

            var mappingMethodName = nameof(IMapperForm<object>.Mapping);
            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFormType;

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();
            var arguementTypes = new Type[] { typeof(Profile) };
            foreach ( var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mappingMethodName);
                if(methodInfo != null )
                {
                    methodInfo.Invoke(instance, new object[] {this});
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();
                    if(interfaces.Count() > 0 )
                    {
                        foreach ( var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName,arguementTypes);
                            interfaceMethodInfo?.Invoke(instance, new object[] {this});
                        }
                    }
                }
            }

        }
    }
}
