using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace CSharp_Language
{
    /*
    Properties vs Fields
      Fields: variables of a class
        Staic fields and instance fields
          Can be private, public, or protected
          Read-only fields
            can only assign values in the declaration or in a constructor
        Properties: like fields, but do not denote a storage location
          Every property defines a get and/or a set accessor
          often used to expose and control fields
          access level for get and set are independent
    */
    public class Sample
    {
        // field
        private string _color;

        // property
        public string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (_colorList.Any(x => x == value.ToLower()))
                {
                    _color = value;
                }
            }
        }

        private readonly List<string> _colorList = new List<string>
        {
            "blue", "black", "red", "white", "grey", "yellow", "purple", "pink"
        };

    }

    public class PropertiesAndFields
    {
        [Fact]
        public void SetColorUsingProperty()
        {
            var sample = new Sample
            {
                Color = ""
            };
            
            sample.Color.ShouldBeNull();
        }

        [Fact]
        public void SetColorToBeSomethingWeird()
        {
            var sample = new Sample
            {
                Color = "blackblueweirdness"
            };
            
            sample.Color.ShouldBeNull();
        }

        [Fact]
        public void SetColorToBeSomethingValid()
        {
            var sample = new Sample()
            {
                Color = "Blue"
            };
            sample.Color.ShouldBe("Blue");
        }
    }
}
