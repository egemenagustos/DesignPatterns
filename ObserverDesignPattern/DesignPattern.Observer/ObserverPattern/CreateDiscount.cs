using DesignPattern.Observer.DAL;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateDiscount : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Context _context;

        public CreateDiscount(IServiceProvider serviceProvider, Context context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }
        public void CreateNewUser(AppUser appUser)
        {
            _context.Add(new Discount
            {
                Code = "DERGIMART",
                Amount = 35,
                CodeStatus = true
            });
            _context.SaveChanges();
        }
    }
}
