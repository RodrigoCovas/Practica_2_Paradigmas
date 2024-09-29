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

    public void RegisterTaxi(Taxi newTaxi)
    {
        taxis.Add(newTaxi);
        Console.WriteLine($"Taxi with plate {newTaxi.LicensePlate} registered.");
    }

    public void RemoveTaxi(string licensePlate)
    {
        Taxi? taxiToRemove = taxis.Find(t => t.LicensePlate == licensePlate);
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

    public List<Taxi> GetTaxis()
    {
        return taxis;
    }
    public PoliceDepartment GetPoliceDepartment()
    {
        return policeDepartment;
    }
}
