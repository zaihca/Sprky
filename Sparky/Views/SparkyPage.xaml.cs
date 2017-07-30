using Xamarin.Forms;

namespace Sparky
{
	public partial class SparkyPage : ContentPage
	{
		public SparkyPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new Page1Menu());
		}
	}
}
