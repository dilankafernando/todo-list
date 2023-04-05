using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using Todo_List.Core;

namespace Todo_List.Droid
{
    [Activity(Label = "Todo_List", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView _listView;
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            
            _listView = FindViewById<ListView>(Resource.Id.listView);

            await LoadData();
        }
        
        private async Task LoadData()
        {
            var service = new ToDoService();
            var todos = await service.GetToDosAsync();

            _listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, todos.ConvertAll(x => x.Title));
        }
    }
}