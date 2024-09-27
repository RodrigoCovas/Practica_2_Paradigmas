namespace P2
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool isPursuing;
        private string? pursuingVehiclePlate;
        private PoliceDepartment department;

        public bool IsPursuing
        {
            get { return isPursuing; }
            private set { isPursuing = value; }
        }

        public PoliceCar(string licensePlate, PoliceDepartment department) : base(typeOfVehicle, licensePlate)
        {
            isPatrolling = false;
            isPursuing = false;
            pursuingVehiclePlate = null;
            speedRadar = new SpeedRadar();
            this.department = department;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string measurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));
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
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
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

        public void NotifyDepartment()
        {
            if (pursuingVehiclePlate != null)
            {
                department.NotifyPoliceCars(pursuingVehiclePlate);
            }
            else
            {
                Console.WriteLine(WriteMessage("No vehicle is being pursued."));
            }
        }

        // Receive alert from department
        public void ReceiveAlert(string vehicleLicensePlate)
        {
            Console.WriteLine(WriteMessage($"received alert for vehicle with plate {vehicleLicensePlate}."));
        }

    }
}