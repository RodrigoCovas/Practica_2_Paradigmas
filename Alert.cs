﻿namespace P2
{
    public class Alert: IAlert
    {
        public void ActivateAlert(string vehicleLicensePlate)
        {
            Console.WriteLine($"Alert activated: Vehicle with plate {vehicleLicensePlate} is speeding. Notify all police cars.");
        }
    }

}
