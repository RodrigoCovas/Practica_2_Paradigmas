namespace P2
{
    internal class Program
    {

        static void Main()
        {
            // Crear una ciudad
            City city = new City();

            Taxi taxi = new Taxi("TAXI123");
            Taxi taxi2 = new Taxi("TAXI456");

            // Registrar taxis
            city.RegisterTaxi(taxi);
            city.RegisterTaxi(taxi2);

            // Obtener el departamento de policía para más operaciones
            PoliceDepartment department = city.GetPoliceDepartment();

            PoliceCar policeCar1 = new PoliceCar("POLICE123", department, new SpeedRadar());
            PoliceCar policeCar2 = new PoliceCar("POLICE456", department, new SpeedRadar());
            PoliceCar policeCar3 = new PoliceCar("POLICE789", department);

            department.RegisterPoliceCar(policeCar1);
            department.RegisterPoliceCar(policeCar2);
            department.RegisterPoliceCar(policeCar3);

            // Comenzar a patrullar con un coche de policía
            policeCar1.StartPatrolling();

            // El coche de policía mide la velocidad del taxi
            policeCar1.UseRadar(taxi); // no hay infracción

            // Notificación de la comisaría y persecución
            policeCar2.StartPatrolling();

            // El taxi 2 comete una infracción
            taxi2.StartRide();  // Ahora la velocidad del taxi 2 es 100
            policeCar2.UseRadar(taxi2); // hay infracción

            // Intentar usar el radar en el coche de policía 3
            policeCar3.UseRadar(taxi); // no hay radar
            policeCar3.PrintRadarHistory(); // no hay radar

            // Iniciar un scooter
            Scooter scooter = new Scooter();
            scooter.KickStart();

            // Intentar usar el radar en el scooter
            policeCar1.UseRadar(scooter); // no hay matricula



        }
    }
}


