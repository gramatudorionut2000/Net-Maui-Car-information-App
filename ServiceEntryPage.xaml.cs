using Proiect.Models;
namespace Proiect;

public partial class ServiceEntryPage : ContentPage
{
	public ServiceEntryPage()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
    async void OnServiceAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServicePage
        {
            BindingContext = new Service()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ServicePage
            {
                BindingContext = e.SelectedItem as Service
            });
        }
    }
}