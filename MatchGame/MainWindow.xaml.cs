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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;

        TextBlock lastTextBlockClicked;
        bool findingMath = false;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick; ;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Jeszcze raz?";
            }
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
            Random random = new Random();                                           //Tworzy nowy generator liczb losowych.

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())  //Znajduje wszystkie kontrolki TextBlock z głównej siatki i wykonuje dla każdej z nich podane instrukcje.
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);                     //Wybiera liczbę Losową z przedziału od 0 do liczbyemoji pozostałych na liście i nazywa tę wartość "index".
                    string nextEmoji = animalEmoji[index];                          //Używa liczby losowej "index" do pobrania losowego emoji z listy.
                    textBlock.Text = nextEmoji;                                     //Przypisuje do kontrolki TextBlock losowe emoji z listy.
                    animalEmoji.RemoveAt(index);                                    //Usywa Losowe emoji z listy.
                }
            }
            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMath == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMath = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMath = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMath = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}