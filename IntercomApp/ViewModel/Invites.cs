using IntercomApp.Domain;
using System.Collections.Generic;

namespace IntercomApp.ViewModel
{
    public class Invites
    {
        public List<Invite> InviteItems { get; }
            = new List<Invite>()
            {
                new Invite()
                {
                    Title = "Coffee Break Invite",
                    Details = "Let's meet and discuss further IntercomApp architecture and protocol enhancements in 5 mins. Cheers!",
                    Organizer = "Phoenix Rangel",
                    Image = "pack://application:,,,/assets/coffee.jpg",
                    Date = "1 min"
                },
                new Invite()
                {
                    Title = "Lunch Invite",
                    Details = "Would you like to have a lunch, sir?",
                    Organizer = "Brooke Navarro",
                    Image = "pack://application:,,,/assets/lunch.jpg",
                    Date = "2 hours"
                },
                new Invite()
                {
                    Title = "IntercomApp Invite",
                    Details = "",
                    Organizer = "Tessa Chavez",
                    Image = "pack://application:,,,/assets/smoke.jpg",
                    Date = "1 day"
                },
                new Invite()
                {
                    Title = "Party Invite",
                    Details = "Pizza will wait for you at 3pm today due to my birthday.",
                    Organizer = "Bill Joseph",
                    Image = "pack://application:,,,/assets/party.jpg",
                    Date = "2 days"
                },
            };

        public Invites()
        {
            for (var i = 0; i < 10; i++)
            {
                InviteItems.Add(new Invite()
                {
                    Title = "IntercomApp Invite",
                    Details = "",
                    Organizer = "Tessa Chavez",
                    Image = "pack://application:,,,/assets/smoke.jpg",
                    Date = "1 day"
                });
            }
        }
    }
}
