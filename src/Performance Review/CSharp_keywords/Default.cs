using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_Review.CSharp_keywords
{
    /* 
     * the Default can be used in a switch statement or it can be used in generic code
     * 
     */

    public class Default
    {
        public void Example()
        {
            SwitchStatementExample();
            GenericExample();
        }

        private void SwitchStatementExample()
        {
            // simple and uninteresting example
            // default specifies a case that will match if any other case doesn't 
            int value = 1;
            switch (value)
            {
                case 10:
                    Console.WriteLine("10");
                    break;

                case 20:
                    Console.WriteLine("20");
                    break;

                case 30:
                    Console.WriteLine("30");
                    break;

                default:
                    Console.WriteLine("This will be called");
                    break;
            }
        }

        private void GenericExample()
        {
            // the C# compiler will complain if trying to assign null to a type that actually accepts a null reference.
            // int x = null; => this fails because value types cannot be assigned to null; Only reference types can be assigned to null;
            // defaults for value types such as int and double, the default value type is usually a zero but you cannot be sure. 

            // constraints
            //  "class" or "struct" must come first in the list of constrains else compiler error
            //  You either want to force T to be a value type using struct or 
            //  you want to force it to be a reference type using class

            // Constraint Description
            //where T: struct => The type argument must be a value type.Any value type except Nullable can be specified.See Using Nullable Types for more information.
            //where T : class => The type argument must be a reference type; this applies also to any class, interface, delegate, or array type.
            //where T : new() => the type argument must have a public parameterless constructor.When used together with other constraints, the new() constraint must be specified last.
            //where T : <base class name> => The type argument must be or derive from the specified base class.
            //where T : <interface name>  => The type argument must be or implement the specified interface. Multiple interface constraints can be specified.The constraining interface can also be generic.
            //where T : U => The type argument supplied for T must be or derive from the argument supplied for U.

            // out: is a generic modifier, it makes a parameter covariant
            // if it has no generic modifier, this is what we call an invariant generic type parameter, as 
            //  the name implies, there is no variance. there's no wiggle room. The generic type used as an argument is
            //  the type we have to use.

            // in order to treat an IRepository<Employee> as an IRepository<Person> requires covariance and this 'out' modifier

            // covariance allows for some wiggle room. the methods inside the interface are allowed to return a type that
            // is more derived than the type specified by the generic type parameter, more derived. 
            // In other words, a covariant interface like IEnumerable would allow GetEnumerator to return IEnumerator<Employee> 
            //  even when T is type Person. Employee is more derived than Person.
            // Covariance only works with delegates and interfaces
            
            // Covariance is only supported when you have methods returning the covariant type parameter

            /* One concern arises when determining defaults of generic types where given one of two conditions can happen.
                 Whether T will be a reference type or a value type.
                 If T is a value type, whether it will be a numberic value or a struct   */
        }
    }
}
