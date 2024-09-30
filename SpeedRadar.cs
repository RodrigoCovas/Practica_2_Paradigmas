namespace P2
{
    class SpeedRadar : IMessageWriter, IMeasuringDevice
    {
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> history { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            history = new List<float>();
        }

        public void TriggerDevice(Vehicle vehicle)
        {
            
            if (vehicle is IRegisteredVehicle registeredVehicle)
            {
                plate = registeredVehicle.LicensePlate;
            }
            speed = vehicle.GetSpeed();
            history.Add(speed);
        }

        public string GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return WriteMessage("Caught above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }
        public override string ToString()
        {
            return "Speed Radar";
        }

        public virtual string WriteMessage(string reading)
        {
            if (plate == "No plate")
            {
                return $"Vehicle with no plate at {speed.ToString()} km/h. {reading}";
            }
            else
            {
                return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {reading}";
            }
        }
    }
}