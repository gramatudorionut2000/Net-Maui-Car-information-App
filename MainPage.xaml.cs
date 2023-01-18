using Proiect.Models;
namespace Proiect;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	 public async void OnCounterClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new CarPage
        {
            BindingContext = new CarDetail()
        });

    }
}

