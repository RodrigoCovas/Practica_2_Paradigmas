namespace P2
{
    class Breathalyzer : IMessageWriter, IMeasuringDevice
    {
        private string plate;
        private float percentage;
        private float alcoholLimit = 0.05f;
        public List<float> history { get; private set; }

        public Breathalyzer()
        {
            plate = "";
            percentage = 0f;
            history = new List<float>();
        }

        public void TriggerDevice(Vehicle vehicle)
        {

            if (vehicle is IRegisteredVehicle registeredVehicle)
            {
                plate = registeredVehicle.LicensePlate;
            }
            percentage = vehicle.GetSpeed();
            history.Add(percentage);
        }

        public string GetLastReading()
        {
            if (percentage > alcoholLimit)
            {
                return WriteMessage("Caught above legal alcohol percentage.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public override string ToString()
        {
            return "Breathalyzer";
        }
        public virtual string WriteMessage(string reading)
        {
            if (plate == "No plate")
            {
                return $"Vehicle with no plate at {percentage.ToString()} %. {reading}";
            }
            else
            {
                return $"Vehicle with plate {plate} at {percentage.ToString()} %. {reading}";
            }
        }
    }
}