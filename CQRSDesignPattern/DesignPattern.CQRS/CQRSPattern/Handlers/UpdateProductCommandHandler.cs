using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
            var values = _context.Products.Find(command.Id);
            values.Name = command.Name;
            values.Description = command.Description;
            values.Price = command.Price;
            values.Status = true;
            values.Stock = command.Stock;
            _context.Products.Update(values);
            _context.SaveChanges();
        }
    }
}
