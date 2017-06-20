#tool nuget:?package=Storyteller&version=3.0.1
#addin "Cake.Storyteller"

Task("StOpen")
    .Does(() => 
    {
        StorytellerOpen("src/Fubu3TodoApp.StoryTeller/", 
            new StorytellerSettings 
            {
                Build = "Debug",
            });
    });