using DesignPattern.Observer.DAL;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateMagazineAnnouncement : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Context _context;

        public CreateMagazineAnnouncement(IServiceProvider serviceProvider, Context context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }
        public void CreateNewUser(AppUser appUser)
        {
            _context.UserProcesses.Add(new UserProcess
            {
                NameSurname = appUser.NameSurname,
                Magazine = "Bilim dergisi",
                Content = "Bilim dergimizin mart sayısı 1 martta evinize ulaştırılacaktır, konular jupiter gezegeni ve mars olucaktır."
            });
            _context.SaveChanges();
        }
    }
}
