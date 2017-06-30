using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizontalListView.Models;
using Xamarin.Forms;
using HorizontalListView.Pages;
using HorizontalListView.PageModels;
using FreshMvvm;

namespace HorizontalListView
{
    public class ListViewPageModel : FreshBasePageModel
    {
        #region Properties

        public List<Community> CommunitiesList { get; set; }

        private Community _selectedCommunity;
        public Community SelectedCommunity
        {
            get
            {
                return _selectedCommunity;
            }
            set
            {
                if (value != null)
                {
                    if (_selectedCommunity != value)
                    {
                        _selectedCommunity = value;
                        CoreMethods.PushPageModel<DetailPageModel>(value);
                    }
                }
            }
        }

        #endregion

        #region Ctor

        public ListViewPageModel()
        {
            CommunitiesList = GetItems().ToList();
        }

        #endregion

        #region Methods

        private IEnumerable<Community> GetItems()
        {
            var list = new List<Community>()
            {
                new Community()
                {
                    CommunityName = "Community 1",CreatedDate = "1/5/2017", 
                    Persons = new List<Person>()
                    {
                        new Person() { Name = "Person1" , City= "Hyderabad"},
                        new Person() { Name = "Person2" , City= "Banagalore"},
                        new Person() { Name = "Person3" , City= "Hyderabad"},
                        new Person() { Name = "Person4" , City= "Chennai"},
                        new Person() { Name = "Person5" , City= "Hyderabad"},
                        new Person() { Name = "Person6" , City= "Gangtok"},
                        new Person() { Name = "Person7" , City= "Hyderabad"}
                    }
                },
                new Community()
                {
                    CommunityName = "Community 2",CreatedDate = "2/5/2017",
                    Persons = new List<Person>()
                    {
                        new Person() { Name = "Person1" , City= "Hyderabad"},
                        new Person() { Name = "Person2" , City= "Banagalore"},
                        new Person() { Name = "Person3" , City= "Hyderabad"},
                        new Person() { Name = "Person4" , City= "Chennai"},
                        new Person() { Name = "Person5" , City= "Hyderabad"},
                    }
                },
                new Community()
                {
                    CommunityName = "Community 3",CreatedDate = "3/5/2017",
                    Persons = new List<Person>()
                    {
                        new Person() { Name = "Person1" , City= "Chennai"},
                        new Person() { Name = "Person2" , City= "Banagalore"},
                        new Person() { Name = "Person3" , City= "Hyderabad"},
                        new Person() { Name = "Person4" , City= "Chennai"},
                        new Person() { Name = "Person5" , City= "Hyderabad"},
                        new Person() { Name = "Person6" , City= "Gangtok"},
                        new Person() { Name = "Person7" , City= "Lucknow"},
                        new Person() { Name = "Person8" , City= "Gangtok"},
                        new Person() { Name = "Person9" , City= "Hyderabad"}
                    }
                },
                new Community()
                {
                    CommunityName = "Community 4",CreatedDate = "4/5/2017",
                    Persons = new List<Person>()
                    {
                        new Person() { Name = "Person1" , City= "Gangtok"},
                        new Person() { Name = "Person2" , City= "Banagalore"},
                        new Person() { Name = "Person3" , City= "Hyderabad"},
                        new Person() { Name = "Person4" , City= "Chennai"},
                        new Person() { Name = "Person5" , City= "Hyderabad"},
                        new Person() { Name = "Person6" , City= "Gangtok"},
                        new Person() { Name = "Person7" , City= "Lucknow"},
                        new Person() { Name = "Person8" , City= "Hyderabad"},
                    }
                },
                new Community()
                {
                    CommunityName = "Community 5",CreatedDate = "5/5/2017",
                    Persons = new List<Person>()
                    {
                        new Person() { Name = "Person1" , City= "Gangtok"},
                        new Person() { Name = "Person2" , City= "Banagalore"},
                        new Person() { Name = "Person3" , City= "Hyderabad"},
                        new Person() { Name = "Person4" , City= "Chennai"},
                    }
                }
            };
            return list;
        }

        #endregion

    }
}
