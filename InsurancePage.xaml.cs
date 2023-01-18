using Proiect.Models;

namespace Proiect;

public partial class InsurancePage : ContentPage
{
	CarDetail cd;
	public InsurancePage(CarDetail cdetail)
	{
		InitializeComponent();
		cd = cdetail;
	}

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        var insurance = (Insurance)BindingContext;

        insurance.CarDetailID = cd.ID;
        await App.Database.SaveInsuranceAsync(insurance);
        await Navigation.PopAsync();
        }

    }