using MauiIcons.Core;
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

        // Temporary Workaround for url styled namespace in xaml
        _ = new MauiIcon();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        clockDrawable.UpdateTime();
        clockView.Invalidate();
    }

    private void OnStartButtonClicked(object sender, EventArgs e)
    {
        if (!isClockRunning)
        {
            timer.Start();
            clockDrawable.StartStopwatch();
            startButton.Text = "Stoppa klockan";
        }
        else
        {
            timer.Stop();
            clockDrawable.StopStopwatch();
            startButton.Text = "Starta klockan";

        }
        isClockRunning = !isClockRunning;
    }

    private void resetButton_Clicked(object sender, EventArgs e)
    {
        timer.Stop();
        clockDrawable.ResetStopwatch();
        clockView.Invalidate();
    }
}
