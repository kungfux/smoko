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
                    Image = "pack://application:,,,/assets/coffee.png",
                    Date = "1 min ago"
                },
                new Invite()
                {
                    Title = "Lunch Invite",
                    Details = "Would you like to have a lunch, sir?",
                    Organizer = "Brooke Navarro",
                    Image = "pack://application:,,,/assets/pizza.png",
                    Date = "2 hours ago"
                },
                new Invite()
                {
                    Title = "IntercomApp Invite",
                    Details = "",
                    Organizer = "Tessa Chavez",
                    Image = "pack://application:,,,/assets/cigarette.png",
                    Date = "1 day ago"
                },
                new Invite()
                {
                    Title = "Party Invite",
                    Details = "Pizza will wait for you at 3pm today due to my birthday.",
                    Organizer = "Bill Joseph",
                    Image = "pack://application:,,,/assets/birthday-cake.png",
                    Date = "2 days ago"
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
                    Image = "pack://application:,,,/assets/tea.png",
                    Date = "1 day ago"
                });
            }
        }
    }
}
