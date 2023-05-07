using System.Text;

namespace DesignPattern.Composite.CompositePattern
{
    public class ProductComposite : IComponent
    {
        public int Id { get ; set ; }
        public string Name { get ; set ; }

        private List<IComponent> _components;

        public ProductComposite(int id, string name)
        {
            Id = id;
            Name = name;
            _components = new List<IComponent>();
        }

        public ICollection<IComponent> Components => _components;

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public string Display()
        {
            var stringBuiler = new StringBuilder();
            stringBuiler.Append($"<div class'text-success'>{Name} ({TotalCount()})</div>");
            stringBuiler.Append("<ul class='list-group list-group-flush ms-2'>");

            foreach (var component in _components)
            {
                stringBuiler.Append(component.Display());
            }
            stringBuiler.Append("</ul>");
            return stringBuiler.ToString();
        }

        public int TotalCount()
        {
            return _components.Sum(x => x.TotalCount());
        }
    }
}
