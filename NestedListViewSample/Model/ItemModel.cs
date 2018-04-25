using System;
using System.Collections.Generic;

namespace NestedListViewSample.Model
{
    public class ItemModel
    {
        public string FirstItemName { get; set; }
        public List<SecondItem> SecondItems { get; set; }
    }

    public class SecondItem
    {
        public string SecondItemName { get; set; }
    }
}
