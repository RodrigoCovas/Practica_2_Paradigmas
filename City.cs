using P2;

public class City
{
    private PoliceDepartment policeDepartment;
    private List<Taxi> taxis;

    public City()
    {
        policeDepartment = new PoliceDepartment();
        taxis = new List<Taxi>();
    }

    public void RegisterTaxi(string licensePlate)
    {
        Taxi newTaxi = new Taxi(licensePlate);
        taxis.Add(newTaxi);
        Console.WriteLine($"Taxi with plate {licensePlate} registered.");
    }

    public void RemoveTaxi(string licensePlate)
    {
        Taxi? taxiToRemove = taxis.Find(t => t.GetPlate() == licensePlate);
        if (taxiToRemove != null)
        {
            taxis.Remove(taxiToRemove);
            Console.WriteLine($"Taxi with plate {licensePlate} removed.");
        }
        else
        {
            Console.WriteLine($"Taxi with plate {licensePlate} not found.");
        }
    }

    public void RegisterPoliceCar(string licensePlate)
    {
        policeDepartment.RegisterPoliceCar(licensePlate);
    }

    public PoliceDepartment GetPoliceDepartment()
    {
        return policeDepartment;
    }
}
