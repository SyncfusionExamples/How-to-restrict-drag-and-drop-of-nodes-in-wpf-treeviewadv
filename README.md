# How to restrict drag and drop of nodes in WPF TreeView

This session explains how to restrict drag and drop of nodes in [WPF TreeView](https://help.syncfusion.com/wpf/classic/treeview/overview) (TreeGridAdv).

To restrict drag and drop of a parent node into another parent node, where it will allow only reordering the child nodes in `TreeViewAdv`. This can be achieved by using [DragStart](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Tools.Controls.TreeViewAdv.html#Syncfusion_Windows_Tools_Controls_TreeViewAdv_DragStart) and [DragEnd](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Tools.Controls.TreeViewAdv.html#Syncfusion_Windows_Tools_Controls_TreeViewAdv_DragEnd) event.

#### XAML

``` xml
<Grid>
    <syncfusion:TreeViewAdv Margin="10"
                            x:Name="tree"
                            AllowDragDrop="True"
                            ItemsSource="{Binding TreeItems}">
        <syncfusion:TreeViewAdv.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                <TextBlock Text="{Binding Header}" />
            </HierarchicalDataTemplate>
        </syncfusion:TreeViewAdv.ItemTemplate>
    </syncfusion:TreeViewAdv>
</Grid>
```

#### C#

``` csharp
public class Model
{
    public Model()
    {
        SubItems = new ObservableCollection<Model>();
    }

    public string Header { get; set; }
    public ObservableCollection<Model> SubItems { get; set; }
}
```

``` csharp
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
        Model root1 = new Model() { Header = "Root1" };
        PopulateSubItems(root1);
        TreeItems.Add(root1);

        Model root2 = new Model() { Header = "Root2" };
        PopulateSubItems(root2);
        TreeItems.Add(root2);

        Model root3 = new Model() { Header = "Root3" };
        PopulateSubItems(root3);
        TreeItems.Add(root3);
    }

    private void PopulateSubItems(Model root)
    {
        Model subItem1 = new Model() { Header = "Item1" };
        Model subItem2 = new Model() { Header = "Item2" };
        Model subItem3 = new Model() { Header = "Item3" };
        Model subItem4 = new Model() { Header = "Item4" };

        root.SubItems.Add(subItem1);
        root.SubItems.Add(subItem2);
        root.SubItems.Add(subItem3);
        root.SubItems.Add(subItem4);
    }
}
```

``` csharp
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
```