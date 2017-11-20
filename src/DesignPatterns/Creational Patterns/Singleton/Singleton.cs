
namespace DesignPatterns.Creational_Patterns.Singleton
{
    /// <summary>
    /// Ensure a class has only one instance and provide a global point of access to it
    /// 
    /// Frequency of use: 4/5
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static T _instance; 

        public static T Instance() => _instance ?? (_instance = new T());
    }
}
