using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace TreeViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        TreeViewItemAdv drag = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DragStart(object sender, DragTreeViewItemAdvEventArgs e)
        {
            drag = (sender as TreeViewAdv).SelectedContainer;
        }
        public void DragEnd(object sender, DragTreeViewItemAdvEventArgs e)
        {
            e.Cancel = false;
            TreeViewItemAdv drop = e.TargetDropItem as TreeViewItemAdv;
            if (drag != null && drop != null && drag.ParentItemsControl == drop.ParentItemsControl)
            {
                e.Cancel = true;
            }           
        }
    }
}
