namespace ExChanger;
public partial class MainPage : ContentPage
{
    // Kursy walut (PLN na inną walutę)
    private decimal kursUSD = 0.25m;
    private decimal kursEUR = 0.22m;
    private decimal kursGBP = 0.19m;
    private decimal kursCHF = 0.23m;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Przelicz_Clicked(object sender, EventArgs e)
    {
        bool czyPoprawnaKwota = decimal.TryParse(plnEntry.Text, out decimal kwotaPLN);

        if (!czyPoprawnaKwota)
        {
            wynikLabel.Text = "Proszę wpisać poprawną liczbę.";
            return;
        }

        decimal wynik = 0;
        string wybranaWaluta = "";

        if (radioUSD.IsChecked)
        {
            wynik = kwotaPLN * kursUSD;
            wybranaWaluta = "USD";
        }
        else if (radioEUR.IsChecked)
        {
            wynik = kwotaPLN * kursEUR;
            wybranaWaluta = "EUR";
        }
        else if (radioGBP.IsChecked)
        {
            wynik = kwotaPLN * kursGBP;
            wybranaWaluta = "GBP";
        }
        else
        {
            wynikLabel.Text = "Proszę wybrać walutę.";
            return;
        }
        wynikLabel.Text = $"{kwotaPLN} PLN = {wynik:F2} {wybranaWaluta}";
    }
}
