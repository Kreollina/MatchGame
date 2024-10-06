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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()   //Tworzy listę ośmiy par emoji.
            {
                "🐬", "🐬",
                "🐰", "🐰",
                "🦁", "🦁",
                "🦄", "🦄",
                "🦔", "🦔",
                "🦉", "🦉",
                "🍀", "🍀",
                "🔥", "🔥",
            };
            Random random = new Random();   //Tworzy nowy generator liczb losowych.

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())  //Znajduje wszystkie kontrolki TextBlock z głównej siatki i wykonuje dla każdej z nich podane instrukcje.
            {
                int index = random.Next(animalEmoji.Count); //Wybiera liczbę Losową z przedziału od 0 do liczbyemoji pozostałych na liście i nazywa tę wartość "index".
                string nextEmoji = animalEmoji[index];  //Używa liczby losowej "index" do pobrania losowego emoji z listy.
                textBlock.Text = nextEmoji; //Przypisuje do kontrolki TextBlock losowe emoji z listy.
                animalEmoji.RemoveAt(index);    //Usywa Losowe emoji z listy.
            }
        }
    }
}