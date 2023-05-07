using DesignPattern.Observer.DAL;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateWelcomeMessage : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Context _context;

        public CreateWelcomeMessage(IServiceProvider serviceProvider, Context context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        public void CreateNewUser(AppUser appUser)
        {
            _context.WelcomeMessages.Add(new WelcomeMessage
            {
                NameSurname = appUser.NameSurname,
                Content = "Dergi bültenimize kayıt olduğunuz için çok teşekkür ederiz. Dergilerimize web sitemizden ulaşabilirsiniz"
            });
            _context.SaveChanges();
        }
    }
}
