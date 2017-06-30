using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorizontalListView.CustomControls
{
    public delegate void RepeaterViewItemAddedEventHandler(object sender, RepeaterViewItemAddedEventArgs args);

    public class RepeaterView : Grid
    {
        #region Properties

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
          propertyName: "ItemsSource",
          returnType: typeof(IEnumerable),
          declaringType: typeof(RepeaterView),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: ItemsChanged);

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
          propertyName: "ItemTemplate",
          returnType: typeof(DataTemplate),
          declaringType: typeof(RepeaterView),
          defaultValue: default(DataTemplate));

        public static readonly BindableProperty NoOfColumnsProperty = BindableProperty.Create(
           propertyName: "NoOfColumns",
           returnType: typeof(string),
           declaringType: typeof(RepeaterView),
           defaultValue: "2",
           defaultBindingMode: BindingMode.OneWayToSource);

        public event RepeaterViewItemAddedEventHandler ItemCreated;

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public string NoOfColumns
        {
            get { return (string)GetValue(NoOfColumnsProperty); }
            set { SetValue(NoOfColumnsProperty, value); }
        }
        #endregion

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IEnumerable oldValueAsEnumerable;
            IEnumerable newValueAsEnumerable;
            try
            {
                oldValueAsEnumerable = oldValue as IEnumerable;
                newValueAsEnumerable = newValue as IEnumerable;
            }
            catch (Exception e)
            {
                throw e;
            }

            var control = (RepeaterView)bindable;
            var oldObservableCollection = oldValue as INotifyCollectionChanged;

            if (oldObservableCollection != null)
            {
                oldObservableCollection.CollectionChanged -= control.OnItemsSourceCollectionChanged;
            }

            var newObservableCollection = newValue as INotifyCollectionChanged;

            if (newObservableCollection != null)
            {
                newObservableCollection.CollectionChanged += control.OnItemsSourceCollectionChanged;
            }

            control.Children.Clear();
            int rowCounter = -1;
            int columnCounter = 0;

            int requiredColumns = control.CheckIfItIsInt();

            for (int i = 0; i < requiredColumns; i++)
            {
                control.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            if (newValueAsEnumerable != null)
            {
                foreach (var item in newValueAsEnumerable)
                {
                    var view = control.CreateChildViewFor(item);

                    if (columnCounter % requiredColumns == 0)
                    {
                        control.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                        rowCounter++;
                        columnCounter = 0;
                    }
                    control.Children.Add(view, columnCounter, rowCounter);
                    columnCounter++;
                    control.OnItemCreated(view);
                }
            }

            control.UpdateChildrenLayout();
            control.InvalidateLayout();
        }


        private int CheckIfItIsInt()
        {
            int requiredColumns;
            var isInt = int.TryParse(this.NoOfColumns, out requiredColumns);
            if (!isInt) return 1;
            return requiredColumns;
        }

        protected virtual void OnItemCreated(View view) =>
            this.ItemCreated?.Invoke(this, new RepeaterViewItemAddedEventArgs(view, view.BindingContext));

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var invalidate = false;

            if (e.OldItems != null)
            {
                this.Children.RemoveAt(e.OldStartingIndex);
                invalidate = true;
            }

            if (e.NewItems != null)
            {
                for (var i = 0; i < e.NewItems.Count; ++i)
                {
                    var item = e.NewItems[i];
                    var view = this.CreateChildViewFor(item);

                    this.Children.Insert(i + e.NewStartingIndex, view);
                    OnItemCreated(view);
                }

                invalidate = true;
            }

            if (invalidate)
            {
                this.UpdateChildrenLayout();
                this.InvalidateLayout();
            }
        }

        private View CreateChildViewFor(object item)
        {
            this.ItemTemplate.SetValue(BindableObject.BindingContextProperty, item);
            return (View)this.ItemTemplate.CreateContent();
        }
    }

    public class RepeaterViewItemAddedEventArgs : EventArgs
    {
        private readonly View view;
        private readonly object model;

        public RepeaterViewItemAddedEventArgs(View view, object model)
        {
            this.view = view;
            this.model = model;
        }

        public View View => this.view;

        public object Model => this.model;
    }
}
