using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NestedListViewSample.Model;
using Xamarin.Forms;

namespace NestedListViewSample
{
    public partial class NestedListViewSamplePage : ContentPage
    {
        ObservableCollection<Grouping<ItemModel, SecondItem>> Itemist { get; set; } =
            new ObservableCollection<Grouping<ItemModel, SecondItem>>();

        public NestedListViewSamplePage()
        {
            InitializeComponent();

            for (var i = 0; i < 30; i++)
            {
                // 1階層目セット
                var itemData = new ItemModel()
                {
                    FirstItemName = "アイテム名 1 - " + i.ToString()
                };

                // 2階層目セット
                var secondItemList = new List<SecondItem>();
                for (var j = 0; j < 3; j++)
                {
                    secondItemList.Add(new SecondItem
                    {
                        SecondItemName = "アイテム名 2 - " + j.ToString()
                    });
                }
                itemData.SecondItems = secondItemList;

                var group = new Grouping<ItemModel, SecondItem>(itemData, itemData.SecondItems);

                Itemist.Add(group);
            }
            ItemDataList.ItemsSource = Itemist;
        }
    }

    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
