namespace POC_RealTime.Services;

public class TimerService
{
    public System.Timers.Timer Timer { get; private set; }

    public int SecondsBetweenSignal { get; set; } = 5;

    public TimerService()
    {
        Timer = new System.Timers.Timer(SecondsBetweenSignal * 1000);
        Timer.Start();
    }
}