namespace P2
{
    public interface ISpeedRadar
    {
        List<float> SpeedHistory
        {
            get => SpeedHistory;
            set => SpeedHistory = value;
        }
        void TriggerRadar(Vehicle vehicle);
        string GetLastReading();
        string WriteMessage(string radarReading);
    }
}
