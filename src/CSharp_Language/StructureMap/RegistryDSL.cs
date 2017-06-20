using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Shouldly;
using StructureMap;
using Xunit;

namespace IoC.Tests
{
    public class SimpleRegistration
    {
        public interface ITestTest
        {
        }
        public class Test : ITestTest
        {
            
        }

        public class Test2 : ITestTest
        {
            
        }

        public interface IService
        {
            
        }

        public class IntWiget : IService
        {
        }

        public class StringWiget : IService
        {
        }

        public class DoubleWiget : IService
        {
        }

        public interface IPerson
        {
            string Name { get; set; }
        }

        public class Person : IPerson
        {
            public string Name { get; set; }

            public Person() { }

            public Person(string name)
            {
                Name = name;
            }
        }

        public class MyRegistry : Registry
        {
            public MyRegistry()
            {
                For<IPerson>().Use<Person>();
            }
        }

        [Fact]
        public void SimpleClassRegistration()
        {
            var registry = new Registry();
            registry.IncludeRegistry<MyRegistry>();
            
            var container = new Container(registry);
            container.GetInstance<IPerson>()
                .ShouldBeOfType<Person>();
        }

        [Fact]
        public void structureMapTesting()
        {
            var container = new Container(_ =>
            {
                _.ForSingletonOf<ITestTest>().Use<Test>();
            });
            var test = container.GetInstance<ITestTest>();
            Assert.True(test.GetType() == typeof(Test));
            Assert.True(test.GetType() != typeof(Test2));
            
            container.Configure(_ =>
            {
                _.ForSingletonOf<ITestTest>().Use<Test2>();
            });

            test = container.GetInstance<ITestTest>();
            Assert.True(test.GetType() != typeof(Test));
            Assert.True(test.GetType() == typeof(Test2));
        }

        [Fact]
        public void NamedInstance()
        {
            var container = new Container(x =>
            {
                x.For<ITestTest>().Add<Test>().Named("Test");
                x.For<ITestTest>().Add<Test2>().Named("Test2");
            });

            var test = container.GetInstance<ITestTest>("Test2");
            Assert.True(test.GetType() != typeof(Test));
            Assert.True(test.GetType() == typeof(Test2));
        }

        [Fact]
        public void InlineConstructorDefinition()
        {
            var container = new Container(x =>
            {
                x.For<IPerson>().Use<Person>().Ctor<string>().Is("Bob");
            });
            var person = container.GetInstance<IPerson>();
            person.Name.ShouldBe("Bob");
        }

        class SettersRegistry : Registry
        {
            public SettersRegistry()
            {
                For<IPerson>().Use<Person>().Setter(x => x.Name).Is("Joe");
            }
        }

        [Fact]
        public void SettersExample()
        {
            var container = new Container(_ =>
            {
                _.IncludeRegistry<SettersRegistry>();
            });
            var person = container.GetInstance<IPerson>();
            person.Name.ShouldBe("Joe");
        }

        [Fact]
        public void AddRegistryExample()
        {
            var container = new Container(_ =>
            {
                _.For<IService>().Add<IntWiget>();
                _.For<IService>().Add<DoubleWiget>();
                _.For<IService>().Add<StringWiget>();
            });

            container.GetAllInstances<IService>()
                .Count()
                .ShouldBe(3);
        }
    }
}