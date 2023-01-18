using Microsoft.Maui.Devices.Sensors;
using Proiect.Models;
namespace Proiect;

public partial class ServicePage : ContentPage
{
	public ServicePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.SaveServiceAsync(service);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {   
        var service = (Service)BindingContext;
        var address = service.Address;
        if (service.Address == null)
        {
            address = "Centru, Piatra Neamt";
        }
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Service-ul auto selectat" };
        var location = locations?.FirstOrDefault();
        var myLocation = await Geolocation.GetLocationAsync();
        await Map.OpenAsync(location, options);
    }


    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.DeleteServiceAsync(service);
        await Navigation.PopAsync();
    }
}