using FreshMvvm;
using HorizontalListView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalListView.PageModels
{
    public class DetailPageModel : FreshBasePageModel
    {
        #region Properties

        public Community SelectedCommunity { get; set; }

        #endregion

        #region ctor
        public DetailPageModel(Community selectedItem)
        {
        }
        #endregion

        public override void Init(object initData)
        {
            base.Init(initData);
            SelectedCommunity = initData as Community;
        }
    }
}
