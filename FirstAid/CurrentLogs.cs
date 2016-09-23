using System;
using Xamarin.Forms;
using FirstAid.Database;

namespace FirstAid
{
	class CurrentLogs : ContentPage
	{
		public CurrentLogs(int LogTypeId)
		{
			System.Diagnostics.Debug.WriteLine("Category ID is " + LogTypeId.ToString());

			// Create an object that can access the database table Injury.
			var iDatabase = new LogDataBase();

			// Create the listview that will hold the injuries.
			var listView = new ListView
			{
				RowHeight = 40,
				// Define where to pull the data from, in this case it is the rows from the Injury table.
				ItemsSource = iDatabase.GetLogsByLogType(LogTypeId),
				// Define the ItemTemplate, this will contain a single TextCell.
				ItemTemplate = new DataTemplate(typeof(TextCell))
			};

			// Bind the InjuryName attribute to the TextCell in the ItemTemplate.
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "InjuryName");

			Content = new StackLayout
			{

				Children = {
					listView
				}
			};
		}
	}
}

