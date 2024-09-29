namespace P2
{
    internal class Program
    {
        static void Main()
        {
            City city = new City();
            Console.WriteLine(city.WriteMessage("Created"));

            PoliceDepartment department = city.GetPoliceDepartment();
            Console.WriteLine(department.WriteMessage("Created"));

            Taxi taxi1 = new Taxi("TAXI123");
            Taxi taxi2 = new Taxi("TAXI456");
            city.RegisterTaxi(taxi1);
            city.RegisterTaxi(taxi2);

            PoliceCar policeCar1 = new PoliceCar("POLICE123", department);
            PoliceCar policeCar2 = new PoliceCar("POLICE456", department, new SpeedRadar());
            department.RegisterPoliceCar(policeCar1);
            department.RegisterPoliceCar(policeCar2);

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            policeCar2.StartPatrolling();
            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            
            city.RemoveTaxi("TAXI123");
        }
    }
}


