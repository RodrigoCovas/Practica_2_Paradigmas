namespace P2
{
    public class PoliceDepartment: IMessageWritter
    {
        private List<PoliceCar> policeCars;
        private Alert alert;

        public PoliceDepartment()
        {
            policeCars = new List<PoliceCar>();
            alert = new Alert();
        }

        public void RegisterPoliceCar(PoliceCar newCar)
        {
            policeCars.Add(newCar);
            Console.WriteLine(WriteMessage($"Police Car with plate {newCar.LicensePlate} registered to the department."));
        }

        public void NotifyPoliceCars(string vehicleLicensePlate)
        {
            alert.ActivateAlert(vehicleLicensePlate);
            foreach (var policeCar in policeCars)
            {   
                if (policeCar.IsPatrolling())
                {
                    policeCar.Pursue(vehicleLicensePlate);
                }
            }
        }
        public override string ToString()
        {
            return $"Police Department";
        }
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }

}
