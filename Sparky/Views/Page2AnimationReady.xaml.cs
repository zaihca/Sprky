using System;
using System.Collections.Generic;
using SparkDotNet;
using Xamarin.Forms;

namespace Sparky
{
	public partial class Page2AnimationReady : ContentPage
	{
		public Page2AnimationReady()
		{
			InitializeComponent();
		}
		async void NextPage(object sender, System.EventArgs e)
		{
				try
			{
				var spk = new Spark("MDliN2FjMGEtOGUyYS00NDRmLWFiODEtMDNkYjY1ZDEzZDE1ZGI0NTk2ZTgtNzgw");
				await spk.CreateMessageAsync(SharedInfo.sharedRoom.id, null, null, "hello");
				var msgs = await spk.GetMessagesAsync(SharedInfo.sharedRoom.id);
				SharedInfo.sharedWaitingTime = msgs.Count;
				await DisplayAlert("Success ", "Success ! You are Number "+msgs.Count, "Ok");

			}
			catch (SparkException ex)
			{
				await DisplayAlert("Error "+ex.StatusCode, ex.Message, "OK");
			}

			//await Navigation.PushModalAsync(new Page3Animate());
			await Navigation.PushModalAsync(new Page3AnimationStart());
		}
	}
}
