﻿using HorizontalListView.Models;
using HorizontalListView.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorizontalListView.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(object selectedCommunity)
        {
            InitializeComponent();
        }

        public DetailPage()
        {
            InitializeComponent();
        }
    }
}