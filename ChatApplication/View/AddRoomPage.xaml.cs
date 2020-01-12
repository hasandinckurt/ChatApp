using ChatApp.Database;
using ChatApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.View
{
    public partial class AddRoomPage : ContentPage
    {
        public AddRoomPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var db = new DBFire();
            await db.saveRoom(new Room() { Name = _rootName.Text });
            await Navigation.PopAsync();

        }
    }
}