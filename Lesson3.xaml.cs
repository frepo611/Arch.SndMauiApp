using Microsoft.Maui.Graphics;
namespace SndMauiApp;

public partial class Lesson3 : ContentPage
{
    private bool isClockRunning = false;
    private IDispatcherTimer timer;
    private ClockDrawable clockDrawable;

    public Lesson3()
    {
        InitializeComponent();
        clockDrawable = (ClockDrawable)Resources["clockDrawable"];

        timer = Application.Current!.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        clockDrawable.UpdateTime(DateTime.Now);
        clockView.Invalidate();
    }

    private void OnStartButtonClicked(object sender, EventArgs e)
    {
        if (!isClockRunning)
        {
            timer.Start();
            startButton.Text = "Stoppa klockan";
        }
        else
        {
            timer.Stop();
            startButton.Text = "Starta klockan";
        }
        isClockRunning = !isClockRunning;
    }
}
