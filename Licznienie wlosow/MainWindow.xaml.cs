using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Licznienie_wlosow.MainWindow;

namespace Licznienie_wlosow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class Glowa
        {
            private double gestosc;
            private double obwod;
            private double wysokosc;
           
            public void ustaw(double gestosc, double obwod, double wysokosc)
            {
                this.gestosc = gestosc;
                this.obwod = obwod;
                this.wysokosc = wysokosc;
            }

            public double liczbawlosow()
            {
                double powierzchnia = obwod * wysokosc;
                return gestosc * powierzchnia;
            }

            private const double srednialiczbawlosow = 100000;

            public double roznica()
            {
                double liczbaWlosow = liczbawlosow();
                return ((liczbaWlosow - srednialiczbawlosow) / srednialiczbawlosow) * 100;
            }

        }

        private void zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            Glowa glowa = new Glowa();

            glowa.ustaw(int.Parse(gestosc.Text), int.Parse(obwod.Text), int.Parse(wysokosc.Text));
            double liczbawlosow = glowa.liczbawlosow();

            double roznica = glowa.roznica();
            MessageBox.Show($"liczba włosów na głowie: {liczbawlosow} Różnica względem przeciętnej: {roznica} %");
        }

        private void resetuj_Click(object sender, RoutedEventArgs e)
        {
            gestosc.Text = "";
            obwod.Text = "";
            wysokosc.Text = "";
        }
    }
}