using StoryTeller;

namespace Fubu3TodoApp.StoryTeller.Fixtures
{
    public class ParagraphFixture : Fixture
    {
        [Hidden, FormatAs("Enter the user name: {name} and pass {pass}")]
        public void EnterUserCredentials(string name, string pass)
        {
            
        }

        [Hidden, FormatAs("Click the login button")]
        public void ClickLoginButton()
        {
        }

        public IGrammar LoginLogic()
        {
            return Paragraph("Log user in", _ =>
            {
                _ += this["EnterUserCredentials"];
                _ += this["ClickLoginButton"];
            });
        }
    }
}
