using Proiect.Models;

namespace Proiect;

public partial class CarEntryPage : ContentPage
{
	public CarEntryPage()
	{
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCarDetailsAsync();
    }
    async void OnCarDetailAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarPage
        {
            BindingContext = new CarDetail()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CarPage
            {
                BindingContext = e.SelectedItem as CarDetail
            });
        }
    }

}