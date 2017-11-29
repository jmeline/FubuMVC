using System;

namespace DesignPatterns.Creational_Patterns.Singleton
{
    /// <summary>
    /// Ensure a class has only one instance and provide a global point of access to it
    /// 
    /// The singleton pattern is a software design pattern that restricts the instantiation
    /// of a class to one object. 
    /// 
    /// This is useful when exactly one object is needed to coordinate actions across the system.
    /// Frequency of use: 4/5
    /// </summary>
    public sealed class NaiveNotThreadSafeBadSingletonExample<T> where T : class, new()
    {
        private static T _instance;

        public static T Instance() => _instance ?? (_instance = new T());
    }

    public sealed class SimpleThreadSafeSingleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object Padlock = new object();

        public static T Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new T());
                }
            }
        }
    }

    public sealed class NotSoGreatThreadSafeUsingDoubleCheckLocking<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object Padlock = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Padlock)
                    {
                        _instance = new T();
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class ThreadSafeWithoutLocks<T> where T : class, new()
    {
        static ThreadSafeWithoutLocks() { }
        public static T Instance { get; } = new T();
    }

    public sealed class FullyLazyInstantiation<T> where T : class, new()
    {
        private FullyLazyInstantiation() { }

        public static T Instance => Nested.Instance;

        private class Nested
        {
            static Nested() { }
            internal static readonly T Instance = new T();
        }
    }

    public sealed class Net4LazySingleton<T> where T: class, new()
    {
        private Net4LazySingleton() { }
        private static readonly Lazy<T> Lazy = new Lazy<T>(() => new T());
        public static T Instance => Lazy.Value;
    }
}