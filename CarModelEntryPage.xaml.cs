using Proiect.Models;
namespace Proiect;

public partial class CarModelEntryPage : ContentPage
{
    public CarModelEntryPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCarsAsync();
    }
    async void OnCarAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarModelPage
        {
            BindingContext = new Car()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CarModelPage
            {
                BindingContext = e.SelectedItem as Car
            });
        }
    }
}
