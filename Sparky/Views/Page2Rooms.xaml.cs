using System;
using System.Collections.Generic;
using SparkDotNet;
using Xamarin.Forms;

namespace Sparky
{
	public partial class Page2Rooms : ContentPage
	{
		public Page2Rooms()
		{
			InitializeComponent();
		}
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			try
			{
				var spk = SparkInstance.Instance.Sparkey;
				var rooms = await spk.GetRoomsAsync();
				lstRooms.ItemsSource = rooms;
			}
			catch (SparkException ex)
			{
				await DisplayAlert("Error "+ex.StatusCode, ex.Message, "OK");
			}

		}
		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			SharedInfo.sharedRoom = (lstRooms.SelectedItem as Room);
			await Navigation.PushModalAsync(new Page2AnimationReady());
		}
	}
}
