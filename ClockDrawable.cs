using System.Diagnostics;

namespace SndMauiApp;

public class ClockDrawable : IDrawable
{
    private const float CENTER_X = 200;
    private const float CENTER_Y = 150;
    private const float RADIUS = 100;
    
    private Stopwatch _stopwatch;
    private TimeSpan _elapsedTime;
    public ClockDrawable()
    {
        _stopwatch = new Stopwatch();
    }
    public void StartStopwatch()
    {
        _stopwatch.Start();
    }
    public void StopStopwatch()
    {
        _stopwatch.Stop();
    }
    public void ResetStopwatch()
    {
        _stopwatch.Reset();
        UpdateTime();
    }
    public void UpdateTime()
    {
        _elapsedTime = _stopwatch.Elapsed;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Draw clock face (circle)
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 4;
        canvas.StrokeDashPattern = [1,4];
        canvas.DrawCircle(CENTER_X, CENTER_Y, RADIUS);


        // Calculate hand angles
        float secondAngle = (float)(_elapsedTime.Seconds * 6 * Math.PI / 180); // 6 degrees per second
        float minuteAngle = (float)((_elapsedTime.Minutes + _elapsedTime.Seconds / 60.0) * 6 * Math.PI / 180); // 6 degrees per minute

        // Draw minute hand
        canvas.StrokeDashPattern = default;
        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 3;
        float minuteHandLength = RADIUS * 0.8f;
        float minuteEndX = CENTER_X + minuteHandLength * (float)Math.Sin(minuteAngle);
        float minuteEndY = CENTER_Y - minuteHandLength * (float)Math.Cos(minuteAngle);
        canvas.DrawLine(CENTER_X, CENTER_Y, minuteEndX, minuteEndY);

        // Draw second hand
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 1;
        float secondHandLength = RADIUS * 0.9f;
        float secondEndX = CENTER_X + secondHandLength * (float)Math.Sin(secondAngle);
        float secondEndY = CENTER_Y - secondHandLength * (float)Math.Cos(secondAngle);
        canvas.DrawLine(CENTER_X, CENTER_Y, secondEndX, secondEndY);

        // Draw center dot
        canvas.FillColor = Colors.Black;
        canvas.FillCircle(CENTER_X, CENTER_Y, 3);
    }
}
