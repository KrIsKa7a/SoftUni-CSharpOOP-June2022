namespace PrototypePattern
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        //This is Indexer
        public SandwichPrototype this[string name]
        {
            get
            {
                return this.sandwiches[name];
            }
            set
            {
                this.sandwiches[name] = value;
            }
        }
    }
}
