using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;
using SparkDotNet;
using System.Threading.Tasks;

namespace Sparky
{
	public partial class Page3Animate : ContentPage
	{
		int x = 0;
		double scSize = 1;
		Spark spk;
		Message isdone;
		List<Message> msgs;

 



		public Page3Animate()
		{
			InitializeComponent();

		}

		async void Animate()
		{
			if (SharedInfo.sharedWaitingTime >1)
			{
				Thread.Sleep(SharedInfo.sharedWaitingTime *1000);
			}

			await image.TranslateTo(scSize-50, 0, 1000);
			await image2.TranslateTo(scSize, 0, 1000);
		}




		protected async override void OnAppearing()
		{
			base.OnAppearing();






			try
			{
			    spk = new Spark("MDliN2FjMGEtOGUyYS00NDRmLWFiODEtMDNkYjY1ZDEzZDE1ZGI0NTk2ZTgtNzgw");
			    msgs = await spk.GetMessagesAsync(SharedInfo.sharedRoom.id);
			    isdone = msgs.Find((Message obj) => obj.Equals("Done"));

			}
			catch (SparkException ex)
			{
				await DisplayAlert("Error "+ex.StatusCode, ex.Message, "OK");
			}


			try
			{

			}
			catch (Exception ex)
			{

			}



			var minutes = TimeSpan.FromSeconds(1);


		

			Device.StartTimer (minutes, () => {

				// call your method to check for notifications here
				 isdone = msgs.Find((Message obj) => obj.Equals("Done"));
					if (isdone.Equals("Done"))
					{
						btn.IsVisible = false;
						image2.IsVisible = true;
						Animate();
						return false;

					} 
				x++;
			lbl.Text = x + " ";
				if (x>10)
				{
					return false;
				}
												// Returning true means you want to repeat this timer
					return true;
  										  });
		//
	
		
		
		}

		private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
		{
					isdone = msgs.Find((Message obj) => obj.Equals("Done"));
					if (isdone.Equals("Done"))
					{
						btn.IsVisible = false;
						image2.IsVisible = true;
						Animate();
						

					} 	
			x++;
				lbl.Text = x + " ";
   		}

		void Handle_SizeChanged(object sender, System.EventArgs e)
		{
			scSize = grid1.Width;
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await spk.CreateMessageAsync(SharedInfo.sharedRoom.id, null, null, "DONE");
		}
	}
}
