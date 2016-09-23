using System;

using Xamarin.Forms;

namespace FirstAid
{
	public class LogTypes : ContentPage
	{
		public LogTypes()
		{

			var listView = new ListView
			{
				RowHeight = 40
			};

			listView.ItemsSource = new string[]{
				"Test Data 1", "Test Data 2", "Test Data 3"
			};

			Content = new StackLayout
			{
				Children = {
					listView
				},
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
		}
	}
}
