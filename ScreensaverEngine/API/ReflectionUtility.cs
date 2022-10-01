using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ScreensaverEngine
{
    internal static class ReflectionUtility
    {
        internal static Type[] GetTypesFromAssembly<T>(Assembly assembly, bool subclassesOnly = false)
        {
            var types = assembly.GetTypes();
            
            Type[] filteredTypes = types.Where(t =>
            {
                return subclassesOnly ? t.IsSubclassOf(typeof(T)) : t.IsAssignableTo(typeof(T));
            }
            ).ToArray();

            return filteredTypes;
        }

        internal static T[] GetInstancedTypesFromAssembly<T>(Assembly assembly, bool subclassesOnly)
        {
            Type[] types = GetTypesFromAssembly<T>(assembly, false);

            var instances = new List<T>();

            for (int i = 0; i < types.Length; i++)
            {
                try
                {
                    instances.Add((T)Activator.CreateInstance(types[i]));

                    Debug.Log($"Created instance of type {types[i]}");
                }
                catch
                {
                    Debug.Log($"Type {types[i]} is not instantiatable, skipping!");
                }
            }

            return instances.ToArray();
        }


        ///// <summary>
        ///// Gets all methods within the specified assembly with the specified attribute. 
        ///// </summary>
        //internal static MethodInfo[] GetMethodsWithAttribute<T>(Assembly assembly) where T : Attribute
        //{
        //    List<MethodInfo> methods = new List<MethodInfo>();

        //    Type[] types = assembly.GetTypes();

        //    foreach (var type in types)
        //    {
        //        var allMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        //        foreach (var method in allMethods)
        //        {
        //            var attribute = method.GetCustomAttribute(typeof(T));

        //            if (attribute == null)
        //                continue;

        //            methods.Add(method);
        //        }
        //    }

        //    return methods.ToArray();
        //}

        ///// <summary>
        ///// Invokes every method within the specified array. 
        ///// </summary>
        //internal static void CallMethods(MethodInfo[] methods)
        //{
        //    foreach (var method in methods)
        //    {
        //        method.Invoke(null, null);
        //    }
        //}
    }
}