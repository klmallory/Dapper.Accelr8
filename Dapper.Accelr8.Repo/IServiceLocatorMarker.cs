using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo
{
    public interface IServiceLocatorMarker
    {
        void Debug(Type type);
        void Dispose();
        void Register(Type type, Type concreteType, bool rebind = false);
        void Register(Type type, Type concreteType, object instance, bool rebind = false);
        void Register(Type type, Type concreteType, string name, bool rebind = false);
        void Register<I, T>(string name, bool rebind = false) where T : I;
        void Register<I, T>(T instance, bool rebind = false) where T : I;
        void Register<LookupType, RegisteredType>(bool rebind = false) where RegisteredType : LookupType;
        void RegisterSingleton(Type type, Type concreteType, object instance, bool rebind = false);
        void RegisterSingleton<I, T>(T instance, bool rebind = false) where T : I;
        void RegisterWithConstructor<I, T>(System.Collections.Generic.IDictionary<string, object> constructorArgs, bool rebind = false) where T : I;
        void RegisterWithConstructor<I, T>(System.Collections.Generic.IDictionary<string, object> constructorArgs, System.Collections.Generic.IDictionary<string, object> propertyArgs, bool rebind = false) where T : I;
        void Remove(Type type);
        void Remove<I>();
        object Resolve(Type type);
        object Resolve(Type type, string name);
        I Resolve<I>();
        I Resolve<I>(string name);
        System.Collections.Generic.IList<object> ResolveAll(Type type);
        System.Collections.Generic.IList<I> ResolveAll<I>();
        object TryResolve(Type type);
        object TryResolve(Type type, string name);
        I TryResolve<I>();
        I TryResolve<I>(string name);
    }
}
