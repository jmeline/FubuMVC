
using StoryTeller;

namespace Fubu3TodoApp.StoryTeller.Fixtures
{
    public class PreferencesFixture : Fixture
    {
        [FormatAs("Use special sauce {enabled}")]
        public void EnableSpecialSauce(bool enabled)
        {
        }
        
    }
    public class EmbeddedSections : Fixture
    {
        public IGrammar Preferences()
        {
            return Embed<PreferencesFixture>("Use the set fixture")
                .Before(context =>
                {

                })
                .After(context =>
                {

                });
        }
    }
}
