using Proiect.Models;

namespace Proiect;

public partial class PersonPage : ContentPage
{
    CarDetail cd;
    public PersonPage(CarDetail detail)
	{
		InitializeComponent();
        cd = detail;
	}


    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Person p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Person;
            var d = new Driver()
            {
                CarDetailID = cd.ID,
                PersonID = p.ID
            };
            await App.Database.SaveDriverAsync(d);
            p.Drivers = new List<Driver> {d};
            await Navigation.PopAsync();
        }
    }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var person = (Person)BindingContext;
            await App.Database.SavePersonAsync(person);
            listView.ItemsSource = await App.Database.GetPersonsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
        var person = listView.SelectedItem as Person;
        await App.Database.DeletePersonAsync(person);
            listView.ItemsSource = await App.Database.GetPersonsAsync();
        }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetPersonsAsync();
    }


}