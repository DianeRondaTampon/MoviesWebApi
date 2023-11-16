namespace MoviesWebApi.Dto
{
    public class Car
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Speed { get; set; }
        public string Color { get; set; }
        public List<int> List { get; set; }

        //constructor 
        public Car(string color)
        {
            Id = 1;
            Name = "Car of Juan Carlos";
            Brand = "SEAT";
            Speed = 0;
            Color = color;
            List = new List<int>(); //initialize the properties of the class in the constructor
        }

        //methods
        public void accelerate()
        {
            //increment the speed by 10
            Speed = Speed + 10 ;
            
        }


    }
}
