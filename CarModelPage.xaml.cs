using Proiect.Models;
namespace Proiect;

public partial class CarModelPage : ContentPage
{
	public CarModelPage()
	{
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var car = (Car)BindingContext;
        await App.Database.SaveCarAsync(car);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var car = (Car)BindingContext;
        await App.Database.DeleteCarAsync(car);
        await Navigation.PopAsync();
    }
}