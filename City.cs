using P2;

public class City: IMessageWritter
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
        Console.WriteLine(WriteMessage($"Taxi with plate {newTaxi.LicensePlate} registered."));
    }

    public void RemoveTaxi(string licensePlate)
    {
        Taxi? taxiToRemove = taxis.Find(t => t.LicensePlate == licensePlate);
        if (taxiToRemove != null)
        {
            taxis.Remove(taxiToRemove);
            Console.WriteLine(WriteMessage($"Taxi with plate {licensePlate} removed."));
        }
        else
        {
            Console.WriteLine(WriteMessage($"Taxi with plate {licensePlate} not found."));
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
    public override string ToString()
    {
        return $"City";
    }
    public string WriteMessage(string message)
    {
        return $"{this}: {message}";
    }
}
