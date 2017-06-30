using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalListView.Models
{
    public class Community
    {
        public string CommunityName { get; set; }
        public string CreatedDate { get; set; }
        public IEnumerable<Person> Persons { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
