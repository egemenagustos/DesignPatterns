namespace DesignPattern.Composite.DAL
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UpperCategoryId { get; set; }

        public List<Product> Products { get; set; }
    }
}
