namespace P2
{
    public interface IMeasuringDevice
    {
        List<float> history
        {
            get => history;
            set => history = value;
        }
        void TriggerDevice(Vehicle vehicle);
        string GetLastReading();
        string WriteMessage(string reading);
    }
}
