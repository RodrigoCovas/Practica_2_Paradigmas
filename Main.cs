namespace P2
{
    internal class Program
    {

        static void Main()
        {
            /*
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP");
            PoliceCar policeCar2 = new PoliceCar("0002 CNP");

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();
            */

            // Crear una ciudad
            City city = new City();

            // Registrar taxis
            city.RegisterTaxi("TAXI123");
            city.RegisterTaxi("TAXI456");

            // Registrar coches de policía
            city.RegisterPoliceCar("POLICE123");
            city.RegisterPoliceCar("POLICE456");

            // Obtener el departamento de policía para más operaciones
            PoliceDepartment department = city.GetPoliceDepartment();

            // Comenzar a patrullar con un coche de policía
            PoliceCar policeCar1 = new PoliceCar("POLICE123", department);
            policeCar1.StartPatrolling();

            // Crear un taxi para medir su velocidad
            Taxi taxi = new Taxi("TAXI123");

            // El coche de policía mide la velocidad del taxi
            policeCar1.UseRadar(taxi); // no hay infracción

            // Notificación de la comisaría y persecución
            PoliceCar policeCar2 = new PoliceCar("POLICE456", department);
            policeCar2.StartPatrolling();

            // El taxi 2 comete una infracción
            Taxi taxi2 = new Taxi("TAXI456");
            taxi2.StartRide();  // Ahora la velocidad del taxi 2 es 100
            policeCar2.UseRadar(taxi2); // hay infracción

            // Empezar la persecución
            policeCar2.Pursue("TAXI456");

            policeCar2.NotifyDepartment();






            // Reportar la situación actual de los coches de policía
            Console.WriteLine(policeCar1);
            Console.WriteLine(policeCar2);

        }
    }
}


