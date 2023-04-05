using System;
using System.Collections.Generic;
using UIKit;
using System.Threading.Tasks;
using Foundation;
using Todo_List.Core;

namespace Todo_List.iOS
{
    public partial class ViewController : UIViewController
    {
        private UITableView _tableView;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            _tableView = new UITableView(View.Bounds);
            View.AddSubview(_tableView);
            
            await  LoadData();
        }
        
        private async Task LoadData()
        {
            var service = new ToDoService();
            var todos = await service.GetToDosAsync();
            _tableView.Source = new TableSource(todos);
            _tableView.ReloadData();
        }
        
        private class TableSource : UITableViewSource
        {
            private readonly List<ToDo> _todos;

            public TableSource(List<ToDo> todos)
            {
                _todos = todos;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell(UITableViewCellStyle.Default, "cell");

                var todo = _todos[indexPath.Row];
                cell.TextLabel.Text = todo.Title;

                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _todos.Count;
            }
        }
        
    }
}