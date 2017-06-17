using System;
using Shouldly;
using StructureMap;
using Xunit;

namespace IoC.Tests
{
    public class NestedChildContainerTests
    {
        public interface ITester
        {
            void Test();

        }

        public static bool isDisposed;
        public class FoodTester : ITester, IDisposable
        {
            public void Test()
            {
            }

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

        public enum LifeCycles 
        {
            Transient, 
            Singleton,
            ContainerScoped,
            AlwaysUnique,
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

        public interface ICareer { }
        public class Bum : ICareer { }
        public class SoftwareDeveloper : ICareer { }

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
    }

}
