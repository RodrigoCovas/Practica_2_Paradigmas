namespace P2
{
    public class PoliceCar : Vehicle, IRegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private IMeasuringDevice? device;
        private bool isPursuing;
        private string? pursuingVehiclePlate;
        private PoliceDepartment department;
        public string LicensePlate { get; private set; }

        public bool IsPursuing
        {
            get { return isPursuing; }
            private set { isPursuing = value; }
        }

        public PoliceCar(string licensePlate, PoliceDepartment department, IMeasuringDevice? Device = null) : base(typeOfVehicle)
        {
            isPatrolling = false;
            isPursuing = false;
            pursuingVehiclePlate = null;
            device = Device;
            this.department = department;
            LicensePlate = licensePlate;
        }

        public void UseDevice(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (device != null)
                {
                    if (vehicle is IRegisteredVehicle registeredVehicle)
                    {
                        device.TriggerDevice(vehicle);
                        string measurement = device.GetLastReading();
                        Console.WriteLine(WriteMessage($"Triggered {device.ToString()}. Result: {measurement}"));

                        if (measurement.Contains("Caught above legal"))
                        {
                            department.NotifyPoliceCars(registeredVehicle.LicensePlate);
                        }
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage("Cannot measure: Vehicle has no plate."));
                    }
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active device."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (device != null && device.history.Any())
            {
                Console.WriteLine(WriteMessage("Report device history:"));
                foreach (float speed in device.history)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no device history."));
            }
        }

        public void Pursue(string vehicleLicensePlate)
        {
            isPursuing = true;
            pursuingVehiclePlate = vehicleLicensePlate;
            Console.WriteLine(WriteMessage($"is pursuing vehicle with plate {vehicleLicensePlate}."));
        }

        public void StopPursuit()
        {
            isPursuing = false;
            Console.WriteLine(WriteMessage($"stopped pursuing vehicle with plate {pursuingVehiclePlate}."));
        }

        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {LicensePlate}";
        }
    }
}