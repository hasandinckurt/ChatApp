using ChatApp.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Database
{
    public class DBFire
    {

        FirebaseClient fbClient;

        public DBFire()
        {
            fbClient = new FirebaseClient("https://chatapp-4c926.firebaseio.com/");
        }

        public async Task<List<Room>> getRoomList()
        {
            return (await fbClient
                .Child("Chat")
                .OnceAsync<Room>())
                .Select((item) =>
                new Room
                {
                    Key = item.Key,
                    Name = item.Object.Name
                }

                       ).ToList();

        }

        public async Task saveRoom(Room rm)
        {
            await fbClient.Child("Chat")
                    .PostAsync(rm);

        }


        public async Task saveMessage(Chat _ch, string _room)
        {
            await fbClient.Child("Chat/" + _room + "/Message")
                    .PostAsync(_ch);
        }

        public ObservableCollection<Chat> subChat(string _roomKEY)
        {

            return fbClient.Child("Chat/" + _roomKEY + "/Message")
                           .AsObservable<Chat>()
                           .AsObservableCollection<Chat>();
        }

    }
}
