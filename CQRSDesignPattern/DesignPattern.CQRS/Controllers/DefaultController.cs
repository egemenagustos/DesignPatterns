using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _handler;

        private readonly CreateProductCommandHandler _commandHandler;

        private readonly GetProductByIdQueryHandler _byIdQueryHandler;

        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        private readonly GetProductUpdateByIdQueryHandler _updateByIdQueryHandler;

        private readonly UpdateProductCommandHandler _update;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler commandHandler, GetProductByIdQueryHandler byIdQueryHandler, RemoveProductCommandHandler remove, GetProductUpdateByIdQueryHandler updateByIdQueryHandler, UpdateProductCommandHandler updateProduct)
        {
            _handler = getProductQueryHandler;
            _commandHandler = commandHandler;
            _byIdQueryHandler = byIdQueryHandler;
            _removeProductCommandHandler = remove;
            _updateByIdQueryHandler = updateByIdQueryHandler;
            _update = updateProduct;

        }

        public IActionResult Index()
        {
            var values = _handler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateProductCommand command)
        {
            _commandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var values = _byIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _updateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductCommand command)
        {
            _update.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
