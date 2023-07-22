namespace BOL
{
    public enum Category
    {
        BISCUITS,Chips,COLDDRINKS
    }
    public class Product
    {
        private int id;
        private string name;
        private int quantity;
        private Category category;
        private double price;


        public Product()
        {

        }

        public Product(int id,string name, int quantity, Category category, double price)
        {
            this.id = id;
            this.name = name;
            this.quantity=quantity;
            this.category = category;
            this.price = price;
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }

        }

        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        public Category CATEGORY
        {
            get { return this.category; }
            set { this.CATEGORY = value; }

        }
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public override string ToString()
        {
            return "Id is: "+id+ "Name is: " + name + "Quantity: " + quantity + " Category: " + category + " Price: " + price;
        }

    }
}