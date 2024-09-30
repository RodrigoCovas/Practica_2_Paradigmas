namespace P2
{
    class Scooter : Vehicle
    {
        private const string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle)  // No need for plate
        {
            SetSpeed(0f);  // Velocidad inicial del patinete
        }

        public void KickStart()
        {
            Console.WriteLine(WriteMessage("Kickstarted the scooter and started moving."));
            SetSpeed(15f);  // Cambia la velocidad a 15 km/h
        }

        public void StopScooter()
        {
            Console.WriteLine(WriteMessage("Scooter stopped."));
            SetSpeed(0f);
        }
    }
}
