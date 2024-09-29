namespace P2
{
    public abstract class Vehicle : IMessageWritter
    {
        private string typeOfVehicle;
        protected string? plate;
        private float speed;

        public Vehicle(string typeOfVehicle, string? plate = null)
        {
            this.typeOfVehicle = typeOfVehicle;
            this.plate = plate;
            speed = 0f;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return plate != null ? $"{GetTypeOfVehicle()} with plate {GetPlate()}" : $"{GetTypeOfVehicle()}";
        }

        public string GetTypeOfVehicle()
        {
            return typeOfVehicle;
        }

        public string? GetPlate()
        {
            return plate;
        }


        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        //Implment interface with Vechicle message structure
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
