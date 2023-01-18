using Proiect.Data;

namespace Proiect;

public partial class App : Application
{
    static CarDatabase database;
    public static CarDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               CarDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CarDatabase.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
