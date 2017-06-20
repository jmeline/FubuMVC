using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryTeller;
using StoryTeller.Grammars.Tables;
using StoryTeller.Model;

namespace Fubu3TodoApp.StoryTeller.Fixtures
{
    public class Calculator
    {
        public int value1;
        public int value2;

        public int AddNumbers()
        {
            return value1 + value2;
        }
    }

    public class SampleSentenceFixture : Fixture
    {
        private Calculator _calculator;
        public override void SetUp()
        {
            _calculator = new Calculator();
            Context.State.Store(_calculator);
        }

        [FormatAs("Setup state: {value1}, {value2}")]
        public void SetupState(int value1, int value2)
        {
            _calculator.value1 = value1;
            _calculator.value2 = value2;
        }

        [FormatAs("Verify that {returnValue} is returned")]
        public int VerifyValue()
        {
            return _calculator.AddNumbers();
        }

        [ExposeAsTable("Adding numbers", "result")]
        [return: AliasAs("result")]
        public int DetermineAdditionResult(int a, int b)
        {
            return a + b;
        }

        [ExposeAsTable("multiplying numbers", "result")]
        [return: AliasAs("result")]
        public int DetermineMultiplicationResult(int a, int b)
        {
            return a * b;
        }
    }

}
