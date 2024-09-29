namespace P2
{
    public class PoliceDepartment: IMessageWritter
    {
        private List<PoliceCar> policeCars;
        private IAlert alert;

        public PoliceDepartment(IAlert DepartmentAlert)
        {
            policeCars = new List<PoliceCar>();
            alert = DepartmentAlert;
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
