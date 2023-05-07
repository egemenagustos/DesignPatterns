using DesignPattern.Observer.DAL;
using System.Collections.Generic;

namespace DesignPattern.Observer.ObserverPattern
{
    public class ObserverObject
    {
        private readonly List<IObserver> _obServer;

        public ObserverObject()
        {
            _obServer = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            _obServer.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _obServer.Remove(observer);
        }

        public void NotifyObserver(AppUser appUser)
        {
            _obServer.ForEach(x =>
            {
                x.CreateNewUser(appUser);
            });
        }
    }
}
