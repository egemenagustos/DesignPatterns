using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveProductCommand remove)
        {
            var values = _context.Products.Find(remove.Id);
            _context.Remove(values);
            _context.SaveChanges();
        }
    }
}
