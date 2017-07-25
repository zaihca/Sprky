using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SparkDotNet;
using Xamarin.Forms;

namespace Sparky
{
	public partial class Page3AnimationStart : ContentPage
	{
int x = 0;
double scSize = 1;
Spark spk;
Message isdone;
List<Message> msgs;

		System.Timers.Timer timer;
		int _countSeconds;
		public Page3AnimationStart()
		{
			InitializeComponent();
				timer = new System.Timers.Timer();
				//Trigger event every second
				timer.Interval = 1000;
				timer.Elapsed += OnTimedEvent;
				//count down 5 seconds
				_countSeconds = 60;

				timer.Enabled = true;
		}
			
			
		private async void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
		{
				 _countSeconds--;
				msgs = await spk.GetMessagesAsync(SharedInfo.sharedRoom.id);

			try
			{
				//isdone = msgs.Find((Message obj) => obj.text.Equals("Done"));
				isdone = msgs.Find((Message obj) =>  obj.text=="Done");
				if (isdone!=null)
				{
					Device.BeginInvokeOnMainThread (() => {
				//		lbl.Text = "there" + _countSeconds;
				if (isdone.text=="Done")
					{
						btn.IsVisible = false;
			//			image2.IsVisible = true;
						imageT.IsVisible = true;

						Animate();
							timer.Stop();
					}
						});
				}

			}
			catch (Exception ex)
			{
				await DisplayAlert("Error ", ex.Message, "OK");
			}


						
						
					 

			/*
			_countSeconds--;

	
			Device.BeginInvokeOnMainThread (() => {
			lbl.Text = "there" + _countSeconds; });
			
			if (_countSeconds == 0)
			{
				timer.Stop();
			} 
			*/
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			try
			{
			    spk = new Spark("MDliN2FjMGEtOGUyYS00NDRmLWFiODEtMDNkYjY1ZDEzZDE1ZGI0NTk2ZTgtNzgw");
				msgs = await spk.GetMessagesAsync(SharedInfo.sharedRoom.id);
			//	isdone = msgs.Find((Message obj) => obj.text=="Done");

			}
			catch (SparkException ex)
			{
				await DisplayAlert("Error "+ex.StatusCode, ex.Message, "OK");
			}
		}

		async void Animate()
		{
			if (SharedInfo.sharedWaitingTime > 1)
			{
				//Thread.Sleep(SharedInfo.sharedWaitingTime * 1000);
				//	await imageT.TranslateTo(scSize,0, 1000);
				for (int i = 0; i < SharedInfo.sharedWaitingTime; i++)
				{
					await imageT.RotateTo(360, 1000);
					imageT.Rotation = 0;
				}

			}
		await imageT.ScaleTo(2, 1000);
		await Task.Delay(1000);
		await imageT.ScaleTo(1, 1000);
			//await imageT.FadeTo(0, 1000);
			//await Audio.Manager.PlayBackgroundMusic("bgMusic.mp3");
		//	await image.TranslateTo(scSize - 50, 0, 1000);
		//	await image2.TranslateTo(scSize, 0, 1000);

		}

		void Handle_SizeChanged(object sender, System.EventArgs e)
		{
			scSize = grid1.Width;
		}
		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await spk.CreateMessageAsync(SharedInfo.sharedRoom.id, null, null, "Done");
		}

	}
}
