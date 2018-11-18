using System;
using System.Threading.Tasks;
namespace Sharp2POC.core.Models
{
    public class ManageLoadItem
    { 
        public string Udid { get; set; }
        public string LoadID { get; set; }

        public Func<Task> NavigationTask { get; }

        internal ManageLoadItem(string udid,string loadid, Func<Task> navigationTask)
        {
            Udid = udid;
            LoadID = loadid;
            NavigationTask = navigationTask;
        }
    }
}