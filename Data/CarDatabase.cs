using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Models;
using SQLite;
namespace Proiect.Data
{
    public class CarDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CarDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CarDetail>().Wait();
            _database.CreateTableAsync<Car>().Wait();
            _database.CreateTableAsync<Person>().Wait();
            _database.CreateTableAsync<Driver>().Wait();
            _database.CreateTableAsync<Insurance>().Wait();
            _database.CreateTableAsync<Service>().Wait();

        }

        public Task<int> SaveCarAsync(Car car)
        {
            if (car.ID != 0)
            {
                return _database.UpdateAsync(car);
            }
            else
            {
                return _database.InsertAsync(car);
            }
        }
        public Task<int> DeleteCarAsync(Car car)
        {
            return _database.DeleteAsync(car);
        }
        public Task<List<Car>> GetCarsAsync()
        {
            return _database.Table<Car>().ToListAsync();
        }

        public Task<Car> GetCarAsync(int id)
        {
            return _database.Table<Car>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<List<CarDetail>> GetCarDetailsAsync()
        {
            return _database.Table<CarDetail>().ToListAsync();
        }
        public Task<CarDetail> GetCarDetailAsync(int id)
        {
            return _database.Table<CarDetail>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveCarDetailAsync(CarDetail cdet)
        {
            if (cdet.ID != 0)
            {
                return _database.UpdateAsync(cdet);
            }
            else
            {
                return _database.InsertAsync(cdet);
            }
        }
        public Task<int> DeleteCarDetailAsync(CarDetail cdet)
        {
            return _database.DeleteAsync(cdet);
        }

        public Task<int> SavePersonAsync(Person person)
        {
            if (person.ID != 0)
            {
                return _database.UpdateAsync(person);
            }
            else
            {
                return _database.InsertAsync(person);
            }
        }
        public Task<int> DeletePersonAsync(Person person)
        {
            return _database.DeleteAsync(person);
        }
        public Task<List<Person>> GetPersonsAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<int> SaveDriverAsync(Driver driver)
        {
            if (driver.ID != 0)
            {
                return _database.UpdateAsync(driver);
            }
            else
            {
                return _database.InsertAsync(driver);
            }
        }
        public Task<List<Person>> GetDriversAsync(int cardetailid)
        {
            return _database.QueryAsync<Person>(
            "select P.ID, P.Name from Person P"
            + " inner join Driver D"
            + " on P.ID = D.PersonID where D.CarDetailID = ?",
            cardetailid);
        }

        public Task<int> DeleteDriverAsync(CarDetail detail, Person person)
        {
            return _database.DeleteAsync(_database.Table<Driver>()
            .Where(i => i.PersonID == person.ID && i.CarDetailID == detail.ID)
           .FirstOrDefaultAsync().Result);
        }


        public Task<int> SaveInsuranceAsync(Insurance insurance)
        {
            if (insurance.ID != 0)
            {
                return _database.UpdateAsync(insurance);
            }
            else
            {
                return _database.InsertAsync(insurance);
            }
        }
        public Task<List<Insurance>> GetInsurancesAsync(int cardetailid)
        {
            return _database.QueryAsync<Insurance>(
            "select I.ID, I.Type, I.ExpirationDate from Insurance I where I.CarDetailID = ?",
    cardetailid);
        }

        public Task<int> DeleteInsuranceAsync(CarDetail detail, Insurance insurance)
        {
            return _database.DeleteAsync(_database.Table<Insurance>()
            .Where(i => i.ID == insurance.ID && i.CarDetailID == detail.ID)
           .FirstOrDefaultAsync().Result);
        }

        public Task<List<Service>> GetServicesAsync()
        {
            return _database.Table<Service>().ToListAsync();
        }

        public Task<int> SaveServiceAsync(Service service)
        {
            if (service.ID != 0)
            {
                return _database.UpdateAsync(service);
            }
            else
            {
                return _database.InsertAsync(service);
            }
        }
        public Task<int> DeleteServiceAsync(Service service)
        {
            return _database.DeleteAsync(service);
        }

        public Task<Service> GetServiceAsync(int id)
        {
            return _database.Table<Service>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
    }
}
