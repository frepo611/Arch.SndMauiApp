namespace SndMauiApp;

public partial class Lesson2 : ContentPage
{
    public Lesson2()
    {
        InitializeComponent();
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        double result = (double)firstNumber.Value + (double)secondNumber.Value;
        resultLabel.Text = $"{result}";

    }

    private void OnSubtractButtonClicked(object sender, EventArgs e)
    {
        double result = (double)firstNumber.Value + (double)secondNumber.Value;
        resultLabel.Text = $"{result}";
    }

    private void OnMultiplyButtonClicked(object sender, EventArgs e)
    {
        double result = (double)firstNumber.Value * (double)secondNumber.Value;
        resultLabel.Text = $"{result}";
    }

    private void OnDivideButtonClicked(object sender, EventArgs e)
    {
        {
            if (secondNumber.Value != 0)
            {
                double result = (double)firstNumber.Value / (double)secondNumber.Value;
                resultLabel.Text = $"{result:f4}";
            }
            else
            {
                resultLabel.Text = "Cannot divide by zero";
            }
        }
    }
}
