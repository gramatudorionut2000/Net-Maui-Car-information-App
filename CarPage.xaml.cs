using Plugin.LocalNotification;
using Proiect.Models;

namespace Proiect;

public partial class CarPage : ContentPage
{
    public CarPage()
    {
        InitializeComponent();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var cars = await App.Database.GetCarsAsync();
        var detail = (CarDetail)BindingContext;
        var license_plate = detail.License_Plate;
        var services = await App.Database.GetServicesAsync();
        var service = await App.Database.GetServiceAsync(0);
        if (detail.ServiceID != 0)
        {
            service = await App.Database.GetServiceAsync(detail.ServiceID);
        }

        listView.ItemsSource = await App.Database.GetDriversAsync(detail.ID);
        InsurancelistView.ItemsSource = await App.Database.GetInsurancesAsync(detail.ID);
        CarPicker.ItemsSource = cars;
        CarPicker.ItemDisplayBinding = new Binding("Model");
        ServicePicker.ItemsSource = services;
        ServicePicker.ItemDisplayBinding = new Binding("ServiceDetails");
        if(service != null)
        {
            ServiceView.Text= service.ServiceDetails;
        }


        var insurances = await App.Database.GetInsurancesAsync(detail.ID);
        foreach (Insurance insurance in insurances)
        {
            if (DateTime.Compare(insurance.ExpirationDate, DateTime.Now.AddMonths(1)) < 0)
            {
                var request = new NotificationRequest
                {
                    Title = "Insurance Expiring Soon",
                    Description = license_plate,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddSeconds(1)
                    }
                };
                LocalNotificationCenter.Current.Show(request);
            }
        }

    }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (CarPicker.SelectedItem == null)
        {
            CarPicker.SelectedIndex = 0;
        }
            var cdet = (CarDetail)BindingContext;
            var selectedCar = (CarPicker.SelectedItem as Car);
            cdet.CarModel = selectedCar.Model;
        if  (ServicePicker.SelectedItem == null)
        {
            ServicePicker.SelectedIndex = 0;
        }
            var selectedService = (ServicePicker.SelectedItem as Service);
            cdet.ServiceID = selectedService.ID;
        await App.Database.SaveCarDetailAsync(cdet);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var cdet = (CarDetail)BindingContext;
            await App.Database.DeleteCarDetailAsync(cdet);
            await Navigation.PopAsync();
        }


    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonPage((CarDetail)
       this.BindingContext)
        {
            BindingContext = new Person()
        });

    }


    async void OnDeleteDriverButtonClicked(object sender, EventArgs e)
    {
        var detail = (CarDetail)BindingContext;
        var driver = listView.SelectedItem as Person;
        await App.Database.DeleteDriverAsync(detail, driver);
        await Navigation.PopAsync();


    }

    async void OnChooseInsuranceButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InsurancePage((CarDetail)
       this.BindingContext)
        {
            BindingContext = new Insurance()
        });

    }

    async void OnDeleteInsuranceButtonClicked(object sender, EventArgs e)
    {
        var detail = (CarDetail)BindingContext;
        var insurance = InsurancelistView.SelectedItem as Insurance;
        await App.Database.DeleteInsuranceAsync(detail, insurance);
        await Navigation.PopAsync();

    }

    }