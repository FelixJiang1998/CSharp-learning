using System;
using Demo01.Interfaces;

namespace Demo01.Models {
    public class Car {
        public Car(IUser user) {
            User = user;
        }

        // Properties
        public IUser User { get; set; }

        public string Color { get; set; } = "Red";

        public double Length { get; set; }

        // Methods
        public void Run() {
            Console.WriteLine($"Length: {Length}, Color: {Color}, User: {User.Username}");
        }

        //private void RunCar(Car car) {

        //}
    }

    public class Truck : Car {
        public Truck(IUser user) : base(user) {

        }

        public string Goods { get; set; }

    }

    public class SUV : Car
    {
        public SUV(IUser user) : base(user)
        {
        }

        public string Seat { get; set; }
    }
}

