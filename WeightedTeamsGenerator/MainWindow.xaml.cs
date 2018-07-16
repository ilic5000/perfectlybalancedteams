using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeightedTeamsGenerator.Models;

namespace WeightedTeamsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Player> loadedPlayers;
        public static Team team1;
        public static Team team2;
        public static List<TwoTeam> possibleGamesWithSameDifference = new List<TwoTeam>();
        public static Dictionary<int, List<TwoTeam>> allCombinationsSaved = new Dictionary<int, List<TwoTeam>>();
        public static List<int> differences = new List<int>();
        public static int numberOfSuggestions = possibleGamesWithSameDifference.Count();
        public static int numberOfSuggestion = 0;
        public static int iteratorDifference = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadPlayersDataButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var path = System.IO.Path.GetFullPath("PlayersData/playersData.txt");
            String line = string.Empty;
            loadedPlayers = new List<Player>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        string name = line.Split(',')[0].Trim();
                        if (name.StartsWith("#"))
                        {
                            continue;
                        }

                        string value = line.Split(',')[1].Trim();
                        loadedPlayers.Add(new Player()
                        {
                            name = name,
                            value = Int32.Parse(value)
                        });
                    }

                    button.Content = "Loading was OK (" + loadedPlayers.Count.ToString() + ")";
                    button.IsEnabled = false;
                }
            }
            catch (Exception)
            {
                button.Content = "Error loading file...";
                button.IsEnabled = true;
            }
        }

        private void Magic(object sender, RoutedEventArgs e)
        {
            progressBarMagic.Visibility = Visibility.Visible;

            var buttonMagic = (Button)sender;

            if (loadedPlayers == null || loadedPlayers.Count < 10)
            {
                buttonMagic.Content = "Something went wrong...";
                progressBarMagic.Visibility = Visibility.Hidden;
                return;
            }

            progressBarMagic.Visibility = Visibility.Visible;
            buttonMagic.IsEnabled = false;

            // Data needed for everything to work:
            // all differences possible to be in differences list
            // allPermutationsSaved is dictionary with <difference, list<twoteam>>

            GenerateOppositeTeamAndFillRestOfTheData(
                loadedPlayers.Combinations(loadedPlayers.Count / 2).ToList());

            differences.Sort();

            IncreaseDifferenceButton_Click(null, null);

            if (team1.players.Count < 5 || team2.players.Count < 5)
            {
                magicButton.Content = "Something went wrong...";
                progressBarMagic.Visibility = Visibility.Hidden;
                return;
            }

            revealTeam1Button.Visibility = Visibility.Visible;
            revealTeam2Button.Visibility = Visibility.Visible;
            increaseDifferenceButton.Visibility = Visibility.Visible;
            differenceCurrentLabel.Visibility = Visibility.Visible;
            numberOfSuggestionsLabel.Visibility = Visibility.Visible;

            magicButton.Content = "Everything's good";
            magicButton.IsEnabled = false;
            progressBarMagic.Visibility = Visibility.Hidden;
        }

        private void GenerateOppositeTeamAndFillRestOfTheData(List<IEnumerable<Player>> allCombinations)
        {
            foreach (var combination in allCombinations)
            {
                var firstTeam = combination.ToList();
                var otherTeam = loadedPlayers.Except(firstTeam).ToList();

                var team1 = new Team(firstTeam, "1");
                var team2 = new Team(otherTeam, "2");

                var twoTeam = new TwoTeam()
                {
                    team1 = team1,
                    team2 = team2,
                    team1Value = team1.value,
                    team2Value = team2.value,
                    difference = Math.Abs(team2.value - team1.value)
                };

                if (!differences.Contains(twoTeam.difference))
                {
                    differences.Add(twoTeam.difference);
                }

                if (!allCombinationsSaved.ContainsKey(twoTeam.difference))
                {
                    allCombinationsSaved.Add(twoTeam.difference, new List<TwoTeam>());
                }

                allCombinationsSaved[twoTeam.difference].Add(twoTeam);
            }
        }

        private void LoadNextTeamsForShowing()
        {
            var twoTeam = possibleGamesWithSameDifference.ElementAt(numberOfSuggestion);

            team1 = new Team(twoTeam.team1.players, "1");
            team2 = new Team(twoTeam.team2.players, "2");

            numberOfSuggestionsLabel.Content = "Number of sugestion: " + (numberOfSuggestion + 1) + " (" + numberOfSuggestions + ")";

            if (numberOfSuggestions > 1)
            {
                nextSuggestionButton.Visibility = Visibility.Visible;
            }

            if (numberOfSuggestion + 1 < numberOfSuggestions)
            {
                numberOfSuggestion++;
            }
        }

        private void IncreaseDifferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (iteratorDifference > 0)
            {
                decreaseDifferenceButton.IsEnabled = true;
                decreaseDifferenceButton.Visibility = Visibility.Visible;
            }

            var nextDifference = differences.ElementAt(iteratorDifference);

            differenceCurrentLabel.Content = "Difference: " + nextDifference;

            possibleGamesWithSameDifference = allCombinationsSaved[nextDifference];
            numberOfSuggestions = possibleGamesWithSameDifference.Count;
            numberOfSuggestion = 0;

            LoadNextTeamsForShowing();
            ResetImagesToDefault();

            if (iteratorDifference + 1 < differences.Count)
            {
                iteratorDifference++;
            }
            else
            {
                increaseDifferenceButton.IsEnabled = false;
            }
        }

        private void DecreaseDifferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (iteratorDifference - 1 < 0)
            {
                return;
            }
            else
            {
                iteratorDifference--;
            }

            var previousDifference = differences.ElementAt(iteratorDifference);

            differenceCurrentLabel.Content = "Difference: " + previousDifference;

            possibleGamesWithSameDifference = allCombinationsSaved[previousDifference];
            numberOfSuggestions = possibleGamesWithSameDifference.Count;
            numberOfSuggestion = 0;

            LoadNextTeamsForShowing();
            ResetImagesToDefault();

            if (iteratorDifference - 1 < 0)
            {
                decreaseDifferenceButton.IsEnabled = false;
            }

            if (iteratorDifference + 1 < differences.Count)
            {
                increaseDifferenceButton.IsEnabled = true;
            }
        }

        private void NextSuggestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfSuggestion >= 1)
            {
                firstSuggestionButton.Visibility = Visibility.Visible;
            }

            LoadNextTeamsForShowing();
            ResetImagesToDefault();
        }

        private void FirstsSuggestionButton_Click(object sender, RoutedEventArgs e)
        {
            numberOfSuggestion = 0;

            LoadNextTeamsForShowing();
            ResetImagesToDefault();
        }

        private void RevealTeam1Button_Click(object sender, RoutedEventArgs e)
        {
            team1LabelValue.Content = team1.value;
            team1LabelValue.Visibility = Visibility.Visible;
            ShowTeam(team1);
        }

        private void RevealTeam2Button_Click(object sender, RoutedEventArgs e)
        {
            team2LabelValue.Content = team2.value;
            team2LabelValue.Visibility = Visibility.Visible;
            ShowTeam(team2);
        }

        private void ResetImagesToDefault()
        {
            var defaultUriBrush = new ImageBrush(new BitmapImage(
              new Uri(
                    "Images/Players/unknown.jpg", UriKind.Relative)));

            Team1Player1.Fill = defaultUriBrush;
            Team1Player2.Fill = defaultUriBrush;
            Team1Player3.Fill = defaultUriBrush;
            Team1Player4.Fill = defaultUriBrush;
            Team1Player5.Fill = defaultUriBrush;
            Team1Player6.Fill = defaultUriBrush;
            Team1Player7.Fill = defaultUriBrush;
            Team2Player1.Fill = defaultUriBrush;
            Team2Player2.Fill = defaultUriBrush;
            Team2Player3.Fill = defaultUriBrush;
            Team2Player4.Fill = defaultUriBrush;
            Team2Player5.Fill = defaultUriBrush;
            Team2Player6.Fill = defaultUriBrush;
            Team2Player7.Fill = defaultUriBrush;
            team1LabelValue.Visibility = Visibility.Hidden;
            team2LabelValue.Visibility = Visibility.Hidden;
            Team1Player1Label.Visibility = Visibility.Hidden;
            Team1Player2Label.Visibility = Visibility.Hidden;
            Team1Player3Label.Visibility = Visibility.Hidden;
            Team1Player4Label.Visibility = Visibility.Hidden;
            Team1Player5Label.Visibility = Visibility.Hidden;
            Team1Player6Label.Visibility = Visibility.Hidden;
            Team1Player7Label.Visibility = Visibility.Hidden;
            Team2Player1Label.Visibility = Visibility.Hidden;
            Team2Player2Label.Visibility = Visibility.Hidden;
            Team2Player3Label.Visibility = Visibility.Hidden;
            Team2Player4Label.Visibility = Visibility.Hidden;
            Team2Player5Label.Visibility = Visibility.Hidden;
            Team2Player6Label.Visibility = Visibility.Hidden;
            Team2Player7Label.Visibility = Visibility.Hidden;
            Team1Player6.Visibility = Visibility.Hidden;
            Team1Player7.Visibility = Visibility.Hidden;
            Team2Player6.Visibility = Visibility.Hidden;
            Team2Player7.Visibility = Visibility.Hidden;
        }

        private void ShowTeam(Team team)
        {
            int index = 1; // Gods of internet, please don't kill me for this blasphemy
            foreach (var player in team.players.OrderByDescending(p => p.value))
            {
                ShowPlayer(player, team.id, index.ToString());
                index++;
            }
        }

        private void ShowPlayer(Player player, string teamId, string id)
        {
            string componentName = string.Format("Team{0}Player{1}", teamId, id);
            var component = (Ellipse)FindName(componentName);

            component.Fill = new ImageBrush(new BitmapImage(
                new Uri(
                    string.Format("Images/Players/{0}.jpg", player.name), UriKind.Relative)));
            component.Visibility = Visibility.Visible;
            try
            {
                component.Refresh();
            }
            catch (Exception)
            {
                component.Fill = new ImageBrush(new BitmapImage(
              new Uri(
                  string.Format("Images/Players/unknown.jpg", player.name), UriKind.Relative)));
                component.Visibility = Visibility.Visible;
                component.Refresh();

                string componentNameLabel = string.Format("Team{0}Player{1}Label", teamId, id);
                var componentLabel = (Label)FindName(componentNameLabel);
                componentLabel.Visibility = Visibility.Visible;
                componentLabel.Content = player.name;
                componentLabel.Refresh();
            }
        }
    }
}
