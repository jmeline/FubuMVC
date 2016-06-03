using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_EventSourcing
{
    // CQRS = command query responsibility segregation
    // CQS = command query segregation

    // COMMAND = do/change
    public class Person
    {
        private int _age;
        private readonly EventBroker _broker;

        public Person(EventBroker broker)
        {
            _broker = broker;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            var ac = query as AgeQuery;
            if (ac != null && ac.Target == this)
            {
                ac.Result = _age;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if (cac == null || cac.Target != this) return;
            var newAge = cac.Age;
            if (cac.Register)
            {
                _broker.AllEvents.Add(new AgeChangedEvent(this, _age, newAge));
            }
            _age = newAge;
        }
    }

    public class EventBroker
    {
        // 1. All events that happened
        public IList<Event> AllEvents = new List<Event>();
        
        // 2. Commands 
        public event EventHandler<Command> Commands;

        // 3. Query
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T) q.Result;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangedEvent;
            if (ac == null) return;
            Command(new ChangeAgeCommand(ac.Target, ac.OldValue) {Register = false});
            AllEvents.Remove(e);
        }
    }

    public class Command : EventArgs
    {
        public bool Register = true;
    }

    public class Query
    {
        public object Result;
    }

    public class AgeQuery : Query
    {
        public Person Target { get; set; }
    }

    public class ChangeAgeCommand : Command
    {
        public Person Target;
        public int Age;

        public ChangeAgeCommand(Person target, int age)
        {
            Target = target;
            Age = age;
        }
    }

    public class Event
    {
        // backtrack
    }

    class AgeChangedEvent : Event
    {
        public Person Target;
        public int OldValue, NewValue;

        public AgeChangedEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age changed from {OldValue} to {NewValue}";
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            int age;
            var eventBroker = new EventBroker();
            var person = new Person(eventBroker);
            eventBroker.Command(new ChangeAgeCommand(person, 123));

            foreach (var evt in eventBroker.AllEvents)
            {
                Console.WriteLine(evt);
            }

            age = eventBroker.Query<int>(new AgeQuery() {Target = person});
            Console.WriteLine(age);
            eventBroker.UndoLast();

            foreach (var evt in eventBroker.AllEvents)
            {
                Console.WriteLine(evt);
            }

            age = eventBroker.Query<int>(new AgeQuery() {Target = person});
            Console.WriteLine(age);
            
            eventBroker.Command(new ChangeAgeCommand(person, 234));
            foreach (var evt in eventBroker.AllEvents)
            {
                Console.WriteLine(evt);
            }
            Console.ReadKey();
        }
    }

}