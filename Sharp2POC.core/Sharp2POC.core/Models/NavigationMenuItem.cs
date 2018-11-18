using System;
using System.Threading.Tasks;
namespace Sharp2POC.core.Models
{
    public class NavigationMenuItem 
    {
        public string Name { get; set; } 
        public string Udid { get; set; }
        public string LoadID { get; set; }
        public Func<Task> NavigationTask { get; }

        internal NavigationMenuItem(string name, Func<Task> navigationTask)
        {
            Name = name;
            NavigationTask = navigationTask;
        }
    }
}