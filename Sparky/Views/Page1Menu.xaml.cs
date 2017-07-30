using System;
using System.Collections.Generic;
using SparkDotNet;
using Xamarin.Forms;

namespace Sparky
{
	public partial class Page1Menu : ContentPage
	{
		public Page1Menu()
		{
			InitializeComponent();
		}

		async void NextPage(object sender, System.EventArgs e)
		{
			try
			{
				SharedInfo.sharedRoomName = tbRoomName.Text;
				var spk = SparkInstance.Instance.Sparkey;
				SharedInfo.sharedRoom = await spk.CreateRoomAsync(SharedInfo.sharedRoomName);
				await DisplayAlert("Success ", "Room created successfully", "Ok");


			}
			catch (SparkException ex)
			{
				await DisplayAlert("Error "+ex.StatusCode, ex.Message, "OK");
			}

			await Navigation.PushModalAsync(new Page2AnimationReady());

		}
		
		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new Page2Rooms());
		}
	}
}
