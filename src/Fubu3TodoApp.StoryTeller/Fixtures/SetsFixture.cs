using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryTeller;

namespace Fubu3TodoApp.StoryTeller.Fixtures
{
    public class Colors
    {
        public List<string> ColorsList { get; set; }

        public Colors()
        {
            ColorsList = new List<string>();
        }
    }

    public class SetsFixture : Fixture
    {
        private Colors _colors;

        public override void SetUp()
        {
            _colors = new Colors();
        }

        public SetsFixture()
        {
            Title = "Comparing values in an array";
        }

        [FormatAs("The array should contain the following colors {colors}")]
        public void SetupColors(string[] colors)
        {
            foreach (var color in colors)
            {
                _colors.ColorsList.Add(color);
            }
        }

        [FormatAs("Verify colors are: {colors}")]
        public string[] VerifyColors()
        {
           return _colors.ColorsList.ToArray(); 
        }
    }
}
