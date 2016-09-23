using System;
using Xamarin.Forms;

namespace FirstAid
{
	public class EmergencyContact : ContentPage
	{
		public EmergencyContact()
		{
			Button emergencyCall = new Button
			{
				Text = "Call",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Button Call = new Button
			{
				Text = "Call",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				
				Children = {
					new Label { Text = "Emergency Services: 000" },
					emergencyCall,
					new Label { Text = "Emergency Contact: *insert here*" },
					Call
				}
			};
		}
	}
}