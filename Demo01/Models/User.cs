using System;
using Demo01.Interfaces;

namespace Demo01.Models {
    public class User : IUser {
        public User() {
        }

        public string Username //{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            { get; set; }

        public void SayHello() {
            //throw new NotImplementedException();
            Console.WriteLine($"This is {Username} SayHello Method.");
        }

        //public void 

    }

    //private void btnInterfaceClick(object sender, EventArgs e) {

    //}
}

