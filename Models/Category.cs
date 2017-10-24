namespace ITWEB_Mandatory5.Component
{
    public class Category
    {
        public Category()
        {
            ComponentTypes = newList<ComponentType>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentType> ComponentTypes { get; protected set; }
    }
}