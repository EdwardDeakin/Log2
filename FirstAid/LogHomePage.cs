using System;
using Xamarin.Forms;
using FirstAid.Database;
using SQLite.Net;
namespace FirstAid
{
	public class LogHomePage : ContentPage
	{
		//private SQLiteConnection _Database;
		//string entry;
		public LogHomePage()
		{
			//_Database = DependencyService.Get<IDatabaseConnection>().GetConnection(); 
			//Navigation.PushAsync();
			// Create an object that can access the database table Category.
			var dDatabase = new LogTypeDB();

			//var editor = new Editor { };
			//var text1 = editor.Text;
			var searchBar = new SearchBar
			{
				Placeholder = "Enter Search Term"
			};


			// Create the listview that will hold the categories of all the injuries.
			var listView = new ListView
			{
				RowHeight = 40,
				// Define where to pull the data from, in this case it is the rows from the Category table.
				ItemsSource = dDatabase.GetAllLogTypes(),
				// Define the ItemTemplate, this will contain a single TextCell.
				ItemTemplate = new DataTemplate(typeof(TextCell))
			};

			// Bind the CategoryName attribute to the TextCell in the ItemTemplate.
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "InjuryName");

			// Add a handler for when a ListItem is selected.
			listView.ItemSelected += onLogSelected;

			var Logo = new Image { Aspect = Aspect.AspectFit };
			Logo.Source = ImageSource.FromFile("FirstAid.png");

			Button Home = new Button
			{
				Text = "Home",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Button Emergency = new Button
			{
				Text = "Emergency",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			Button Add = new Button
			{
				Text = "Add Injury",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			// Assign delegates to the buttons that will change to different pages.
			Home.Clicked += onHomeButtonClicked;
			Emergency.Clicked += onEmergencyButtonClicked;
			//Add.Clicked += onAddButtonClicked;
			StackLayout list = new StackLayout
			{
				Children = {
					listView
				},
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Center
			};

			StackLayout buttons = new StackLayout
			{
				Children = {
					Home,
					Emergency,
					Add
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Children = {
					searchBar,
					//editor,
					Logo,
					list,
					buttons
					}
			};
		}

		private void onEmergencyButtonClicked(object sender, EventArgs e)
		{
			// Switch to the Emergency view.
			Navigation.PushAsync(new EmergencyContact());
		}

		/*void onAddButtonClicked(object sender, EventArgs e)
		{
			

			_Database.Insert(new LogType { LogInjuryName = "Text" }); 
		}*/
		private void onHomeButtonClicked(object sender, EventArgs e)
		{
			// Switch to the HomePage view.
			Navigation.PushAsync(new HomePage());
		}

		private void onLogSelected(object sender, SelectedItemChangedEventArgs e)
		{
			// Ensure SelectedItem is not null. This is to make sure no action is taken when it is deselected.
			if (e.SelectedItem == null)
			{
				return;
			}

			// Get the selected item and cast it to category so we can pull the id.
			LogType edward = (LogType)e.SelectedItem;

			// Switch to the Injuries view and pass the current category id.
			Navigation.PushAsync(new CurrentLogs(edward.LogTypeId));
		}
	}
}

