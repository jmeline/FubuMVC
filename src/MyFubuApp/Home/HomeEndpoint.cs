using System;

namespace MyFubuApp.Home
{
    public class HomeEndpoint
    {
        public HomeViewModel Index(HomeImportModel him)
        {
           return new HomeViewModel(); 
        }

        public HomeViewModel HelloWithName(HomeImportWithNameModel hinm)
        {
            return new HomeViewModel
            {
                Name = hinm.Name
            };
        }

        public AddItemModel post_AddItem(AddItemInputModel itemInputModel)
        {
            return new AddItemModel();
        }
    }

    public class AddItemInputModel
    {
        public string Assignee { get; set; }
        public bool IsCompleted { get; set; }
        public string Task { get; set; }
    }

    public class AddItemModel
    {
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