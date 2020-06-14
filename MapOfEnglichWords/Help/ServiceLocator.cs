using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace MapOfEnglishWords.Help
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Dictionary = new Dictionary<Type, object>();

        public static void Register<T>(object o)
        {
            Dictionary.Add(typeof(T), o);
        }

        public static T GetService<T>()
        {
            return (T) Dictionary[typeof(T)];
        }
    }
}