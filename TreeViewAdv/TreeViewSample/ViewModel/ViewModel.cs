using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TreeViewSample
{
    public class ViewModel
    {
        public ViewModel()
        {
            TreeItems = new ObservableCollection<Model>();
            PopulateData();
        }
        public ObservableCollection<Model> TreeItems { get; set; }
        private void PopulateData()
        {
            Model Root1 = new Model() { Header = "Root1" };
            PopulateSubItems(Root1);
            TreeItems.Add(Root1);

            Model Root2 = new Model() { Header = "Root2" };
            PopulateSubItems(Root2);
            TreeItems.Add(Root2);

            Model Root3 = new Model() { Header = "Root3" };
            PopulateSubItems(Root3);
            TreeItems.Add(Root3);


        }
        private void PopulateSubItems(Model Root)
        {
            Model SubItem1 = new Model() { Header ="Item1" };
            Model SubItem2 = new Model() { Header ="Item2" };
            Model SubItem3 = new Model() { Header ="Item3" };
            Model SubItem4 = new Model() { Header ="Item4" };

            Root.SubItems.Add(SubItem1);
            Root.SubItems.Add(SubItem2);
            Root.SubItems.Add(SubItem3);
            Root.SubItems.Add(SubItem4);
        }
    }
}
