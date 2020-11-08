using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Telecom;
using Firebase.Database;
using Firebase.Database.Query;
using MoveMe.Models;


namespace MoveMe.Helper
{
    class FirebaseHelper
    {
        private readonly string uChild = "Users";
        private readonly string cChild = "Cities";
        private readonly string sChild = "Spots";

        readonly FirebaseClient firebase = new FirebaseClient("https://moveme-db.firebaseio.com/");

        // Users database operations
        public async Task<List<User>> GetAllUsers()
        {
            return (await firebase
                .Child(uChild)
                .OnceAsync<User>()).Select(item => new User
                {
                    uID = item.Object.uID,
                    password = item.Object.password,
                    fName = item.Object.fName,
                    lName = item.Object.lName,
                    email = item.Object.email,
                    uCity = item.Object.uCity,
                    uScore = item.Object.uScore
                }).ToList();
        }

        public async Task AddUser(string uID, string password, string fName, 
            string lName, string email, string uCity)
        {
            await firebase
                .Child(uChild)
                .PostAsync(new User() 
                {
                    uID = uID,
                    password = password,
                    fName = fName,
                    lName = lName,
                    email = email,
                    uCity = uCity,
                    uScore = 0
                });
        }

        public async Task<User> GetUser(string uID)
        {
            var allUsers = await GetAllUsers();
            await firebase
                .Child(uChild)
                .OnceAsync<User>();
            return allUsers.FirstOrDefault(a => a.uID == uID);
        }

        public async Task DeleteUser(string uID)
        {
            var toDeleteUser = (await firebase
                .Child(uChild)
                .OnceAsync<User>()).FirstOrDefault(a => a.Object.uID == uID);
            await firebase.Child(uChild).Child(toDeleteUser.Key).DeleteAsync();
        }

        // Cities database operations
        public async Task<List<City>> GetAllCities()
        {
            return (await firebase
                .Child(cChild)
                .OnceAsync<City>()).Select(item => new City
                {
                    cID = item.Object.cID,
                    cName = item.Object.cName,
                    cCoords = item.Object.cCoords
                }).ToList();
        }

        public async Task AddCity(string cName, string cCoords)
        {
            await firebase
                .Child(cChild)
                .PostAsync(new City()
                {
                    cID = Guid.NewGuid(),
                    cName = cName,
                    cCoords = cCoords
                });
        }

        public async Task<City> GetCity(string cName)
        {
            var allCities = await GetAllCities();
            await firebase
                .Child(cChild)
                .OnceAsync<City>();
            return allCities.FirstOrDefault(a => a.cName == cName);
        }

        public async Task DeleteCity(string cName)
        {
            var toDeleteCity = (await firebase
                .Child(cChild)
                .OnceAsync<City>()).FirstOrDefault(a => a.Object.cName == cName);
            await firebase.Child(cChild).Child(toDeleteCity.Key).DeleteAsync();
        }

        // Spots database operations
        public async Task<List<Spot>> GetAllSpots()
        {
            return (await firebase
                .Child(sChild)
                .OnceAsync<Spot>()).Select(item => new Spot
                {
                    sID = item.Object.sID,
                    sName = item.Object.sName,
                    sCity = item.Object.sCity,
                    sCoords = item.Object.sCoords,
                    data = item.Object.data,
                    sScore = item.Object.sScore
                }).ToList();
        }

        public async Task AddSpot(string sName, string sCity, string sCoords, string data)
        {
            await firebase
                .Child(sChild)
                .PostAsync(new Spot
                {
                    sID = Guid.NewGuid(),
                    sName = sName,
                    sCity = sCity,
                    sCoords = sCoords,
                    data = data,
                    sScore = 0
                });
        }

        public async Task<Spot> GetSpot(string sName)
        {
            var allSpots = await GetAllSpots();
            await firebase
                .Child(sChild)
                .OnceAsync<Spot>();
            return allSpots.FirstOrDefault(a => a.sName == sName);
        }

        public async Task DeleteSpot(string sName)
        {
            var toDeleteSpot = (await firebase
                .Child(sChild)
                .OnceAsync<Spot>()).FirstOrDefault(a => a.Object.sName == sName);
            await firebase.Child(sChild).Child(toDeleteSpot.Key).DeleteAsync();
        }
    }
}