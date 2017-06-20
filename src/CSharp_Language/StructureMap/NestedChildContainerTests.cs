using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using StructureMap;
using Xunit;

namespace IoC.Tests
{
    public class NestedChildContainerTests
    {
        public static bool isDisposed;
        public static bool isCalled;

        public enum LifeCycles 
        {
            Transient, 
            Singleton,
            ContainerScoped,
            AlwaysUnique,
        }

        public interface ITester
        {
            void Test();
        }

        public class FoodTester : ITester, IDisposable
        {
            public void Test() { }

            public void Dispose()
            {
                isDisposed = true;
            }
        }

        public void NestedContainerHelper(IContainer container, bool firstCondition, bool secondCondition)
        {
            if (firstCondition)
            {
                container
                    .GetInstance<ITester>()
                    .ShouldBeSameAs(container.GetInstance<ITester>());
            }
            else
            {
                container
                    .GetInstance<ITester>()
                    .ShouldNotBeSameAs(container.GetInstance<ITester>());
            }
            using (var nested = container.GetNestedContainer())
            {
                if (secondCondition)
                {
                    nested
                        .GetInstance<ITester>()
                        .ShouldBeSameAs(nested.GetInstance<ITester>());
                }
                else
                {
                    nested
                        .GetInstance<ITester>()
                        .ShouldNotBeSameAs(nested.GetInstance<ITester>());
                }
            }
        }


        [Fact]
        public void NestedContainerLifeCycleEffects()
        {
            Func<LifeCycles, IContainer> createContainer = lifeCycle =>
            {
                Action<ConfigurationExpression> expression;
                switch (lifeCycle)
                {
                    case LifeCycles.Transient: expression = _ => _.For<ITester>().Use<FoodTester>().Transient(); break;
                    case LifeCycles.Singleton: expression = _ => _.For<ITester>().Use<FoodTester>().Singleton(); break;
                    case LifeCycles.ContainerScoped: expression = _ => _.For<ITester>().Use<FoodTester>().ContainerScoped(); break;
                    case LifeCycles.AlwaysUnique: expression = _ => _.For<ITester>().Use<FoodTester>().AlwaysUnique(); break;
                    default: throw new ArgumentOutOfRangeException(nameof(lifeCycle), lifeCycle, null);
                }
                return new Container(expression);
            };

            //                              same object before nested?      same object in nested?
            // transient:                              false                          true 
            // Singleton:                              true                           true 
            // ContainerScoped/ThreadLocal:            true                           true
            // AlwaysUnique:                           false                          false

            NestedContainerHelper(createContainer(LifeCycles.Transient), false, true);
            NestedContainerHelper(createContainer(LifeCycles.Singleton), true, true);
            NestedContainerHelper(createContainer(LifeCycles.ContainerScoped), true, true);
            NestedContainerHelper(createContainer(LifeCycles.AlwaysUnique), false, false);
        }

        [Fact]
        public void NestedContainerCallsDispose()
        {
            var container = new Container(_ => _.For<ITester>().Use<FoodTester>());

            isDisposed = false;
            using (var nested = container.GetNestedContainer())
            {
                var tester = nested.GetInstance<ITester>();
                tester.Test();
                isDisposed.ShouldBeFalse();
            } // dispose will be called 
            isDisposed.ShouldBeTrue();
        }

        [Fact]
        public void NestedContainerLifeCycleTransient()
        {
            var container = new Container(_ => _.For<ITester>().Use<FoodTester>());

            // Transient will give a new object each time
            container.GetInstance<ITester>().ShouldNotBeSameAs(container.GetInstance<ITester>());
            using (var nested = container.GetNestedContainer())
            {
                // within nested container, transient keeps the same instance
                nested.GetInstance<ITester>().ShouldBeSameAs(nested.GetInstance<ITester>());
                nested.GetInstance<ITester>().ShouldBeSameAs(nested.GetInstance<ITester>());
                nested.GetInstance<ITester>().ShouldBeSameAs(nested.GetInstance<ITester>());
            }
            container.GetInstance<ITester>().ShouldNotBeSameAs(container.GetInstance<ITester>());
        }

        [Fact]
        public void NestedContainerLifeCycleSingleton()
        {
            var container = new Container(_ => _.ForSingletonOf<ITester>().Use<FoodTester>());

            // No change, singleton always
            container.GetInstance<ITester>().ShouldBeSameAs(container.GetInstance<ITester>());
            using (var nested = container.GetNestedContainer())
            {
                // within nested container, singleton setting is resolved from parent
                nested.GetInstance<ITester>().ShouldBeSameAs(nested.GetInstance<ITester>());
            }
        }

        [Fact]
        public void NestedContainerLifeCycleAlwaysUnique()
        {
            var container = new Container(_ => _.For<ITester>().Use<FoodTester>().AlwaysUnique());

            // AlwaysUnique doesn't matter if it is nested or not. Always unique is always unique
            container.GetInstance<ITester>().ShouldNotBeSameAs(container.GetInstance<ITester>());
            using (var nested = container.GetNestedContainer())
            {
                nested.GetInstance<ITester>().ShouldNotBeSameAs(nested.GetInstance<ITester>());
            }
        }

        [Fact]
        public void NestedContainerLifeCycleContainerScoped()
        {
            var container = new Container(_ => _.For<ITester>().Use<FoodTester>().ContainerScoped());

            // ContainerScoped doesn't matter if it is nested or not. It'll give back the same instance
            container.GetInstance<ITester>().ShouldBeSameAs(container.GetInstance<ITester>());
            using (var nested = container.GetNestedContainer())
            {
                nested.GetInstance<ITester>().ShouldBeSameAs(nested.GetInstance<ITester>());
            }
        }

        public interface ICareer
        {
            string Name { get; set; }
        }
        public class Bum : ICareer {
            public string Name { get; set; }
        }
        public class SoftwareDeveloper : ICareer {
            public string Name { get; set; }
        }
        public class Doctor : ICareer {
            public string Name { get; set; }
        }

        public interface IWidget { }
        public class WidgetA : IWidget { }

        [Fact]
        public void ChildContainerExample()
        {
            var container = new Container(_ =>
            {
                _.For<ICareer>().Use<Bum>();
                _.For<IWidget>().Use<WidgetA>();
            });
            
            var child = container.CreateChildContainer();
            child.Configure(_ => _.For<ICareer>().Use<SoftwareDeveloper>());
            child.GetInstance<ICareer>().ShouldBeOfType<SoftwareDeveloper>();
            // child doesn't have an implementation for IWidget, it defaults to it's parents configuration
            child.GetInstance<IWidget>().ShouldBeOfType<WidgetA>();

            container.GetInstance<ICareer>().ShouldBeOfType<Bum>();
            container.GetInstance<IWidget>().ShouldBeOfType<WidgetA>();
        }

        [Fact]
        public void ProfileExample()
        {
            // profiles are named child containers
            var container = new Container(_ =>
            {
                _.For<ICareer>().Use<SoftwareDeveloper>();
                _.Profile("MyProfile", p =>
                {
                    _.For<ICareer>().Use<Bum>();
                    _.For<IWidget>().Use<WidgetA>();
                });
            });

            var profile = container.GetProfile("MyProfile");
            profile.GetInstance<ICareer>().ShouldBeOfType<Bum>();
            profile.GetInstance<IWidget>().ShouldBeOfType<WidgetA>();
        }

        [Fact]
        public void EnumerationExample()
        {
            // if you specify a enumeration and you haven't overridden 
            // an enumeration within structure map, you can have structure map
            // give you an enumerable list of items in the exact order they were provided
            var container = new Container(_ =>
            {
                _.For<ICareer>().Add<Bum>();
                _.For<ICareer>().Add<SoftwareDeveloper>();
                _.For<ICareer>().Add<Doctor>();
            });
            var careersIList = container.GetInstance<IList<ICareer>>();
            var careersIEnumerable = container.GetInstance<IEnumerable<ICareer>>();
            var careersList = container.GetInstance<List<ICareer>>();
            var careersICollection = container.GetInstance<ICollection<ICareer>>();
            var careersArray = container.GetInstance<ICareer[]>();
            var counts = new List<int>
            {
                careersIList.Count,
                careersList.Count,
                careersIEnumerable.Count(),
                careersICollection.Count,
                careersArray.Length,
            };
            counts.Sum().ShouldBe(15);
            careersIList[0].ShouldBeOfType<Bum>();
            careersArray[1].ShouldBeOfType<SoftwareDeveloper>();
            careersList[2].ShouldBeOfType<Doctor>();
        }

        public interface IAnimal
        {
            string Name { get; set; }
        }
        public class Animal : IAnimal
        {
            private string _name;
            public string Name
            {
                get
                {
                    isCalled = true;
                    return _name;
                }
                set { _name = value; }
            }
        }

        public class LazyAnimal
        {
            private readonly Lazy<IAnimal> _lazyAnimal;

            public LazyAnimal(Lazy<IAnimal> animal)
            {
                _lazyAnimal = animal;
            }

            public IAnimal GetAnimal()
            {
                isCalled = true;
                return _lazyAnimal.Value;
            }
        }

        [Fact]
        public void LazyExample()
        {
            isCalled = false;
            var container = new Container(_ =>
            {
                _.For<IAnimal>().Use<Animal>();
            });
            isCalled.ShouldBeFalse();
            
            container
                .GetInstance<LazyAnimal>()
                .GetAnimal()
                .ShouldBeOfType<Animal>();

            isCalled.ShouldBeTrue();
        }

        [Fact]
        public void FuncGenericExample()
        {
            isCalled = false;
            var container = new Container(_ =>
            {
                _.ForSingletonOf<IAnimal>()
                    .Use<Animal>()
                    .Setter<string>("Name")
                    .Is("Ragnar");
            });
            isCalled.ShouldBeFalse();

            var func = container.GetInstance<Func<IAnimal>>();
            isCalled.ShouldBeFalse();
            var animal_1 = func();
            var animal_2 = func();
            var animal_3 = func();
            isCalled.ShouldBeFalse();

            animal_1.ShouldBeOfType<Animal>().Name.ShouldBe("Ragnar");
            isCalled.ShouldBeTrue();

            animal_1.ShouldBeSameAs(animal_2);
            animal_1.ShouldBeSameAs(animal_3);
            animal_2.ShouldBeSameAs(animal_3);
        }

        [Fact]
        public void NameFuncRetrievalExample()
        {
            var container = new Container(_ =>
            {
                _.For<ICareer>().Add<Bum>()
                    .Setter<string>("Name").Is("BOB").Named("Bob");
                _.For<ICareer>().Add<SoftwareDeveloper>()
                    .Setter<string>("Name").Is("SAM").Named("Sam");
                _.For<ICareer>().Add<Doctor>()
                    .Setter<string>("Name").Is("DAN").Named("Dan");
            });

            var func = container.GetInstance<Func<string, ICareer>>();
            func("Bob").ShouldBeOfType<Bum>()
                .Name.ShouldBe("BOB");
            func("Sam").ShouldBeOfType<SoftwareDeveloper>()
                .Name.ShouldBe("SAM");
            func("Dan").ShouldBeOfType<Doctor>()
                .Name.ShouldBe("DAN");
        }
    }
}
