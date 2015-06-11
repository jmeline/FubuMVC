namespace MyFubuApp.EndPoints
{
    /// <summary>
    /// Home page
    /// </summary>
    public class HomeEndpoint
    {
        public HomeViewModel Index(HomeImportModel model)
        {
           return new HomeViewModel(); 
        }

        public HomeViewModel HelloWithName(HomeImportWithNameModel model)
        {
            return new HomeViewModel
            {
                Name = model.Name
            };
        }

   }


    public class HomeImportWithNameModel
    {
        public string Name { get; set; }
    }

    public class HomeImportModel
    {
    }

    public class HomeViewModel
    {
        public string Name { get; set; }
    }

    
}