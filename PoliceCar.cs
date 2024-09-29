namespace P2
{
    public class PoliceCar : Vehicle, IRegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        private bool isPursuing;
        private string? pursuingVehiclePlate;
        private PoliceDepartment department;
        public string LicensePlate { get; private set; }

        public bool IsPursuing
        {
            get { return isPursuing; }
            private set { isPursuing = value; }
        }

        public PoliceCar(string licensePlate, PoliceDepartment department, SpeedRadar? radar = null) : base(typeOfVehicle)
        {
            isPatrolling = false;
            isPursuing = false;
            pursuingVehiclePlate = null;
            speedRadar = radar;
            this.department = department;
            LicensePlate = licensePlate;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    if (vehicle is IRegisteredVehicle registeredVehicle)
                    {
                        speedRadar.TriggerRadar(vehicle);
                        string measurement = speedRadar.GetLastReading();
                        Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));

                        if (measurement.Contains("Catched above legal speed"))
                        {
                            department.NotifyPoliceCars(registeredVehicle.LicensePlate);
                        }
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage("Cannot measure speed: Vehicle has no plate."));
                    }
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
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
            if (speedRadar != null && speedRadar.SpeedHistory.Any())
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no radar speed history."));
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