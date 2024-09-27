﻿namespace P2
{
    public class PoliceDepartment
    {
        private List<PoliceCar> policeCars;
        private Alert alert;

        public PoliceDepartment()
        {
            policeCars = new List<PoliceCar>();
            alert = new Alert();
        }

        public void RegisterPoliceCar(string licensePlate)
        {
            PoliceCar newCar = new PoliceCar(licensePlate,this);
            policeCars.Add(newCar);
            Console.WriteLine($"Police Car with plate {licensePlate} registered to the department.");
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
    }

}
