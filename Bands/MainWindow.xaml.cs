using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Band> allBands;
        ObservableCollection<Band> filteredBands;
        public string[] Genres = { "All", "Rock", "Pop", "Indie" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allBands = new ObservableCollection<Band>();
            filteredBands = new ObservableCollection<Band>();

            #region adding bands
            allBands.Add(new RockBand("Band AKB", new DateTime(2000, 08, 11),"Member1","Member2", "Member3","Member4"));
            allBands.Add(new RockBand("Band G", new DateTime(2010, 02, 01), "Member1", "Member2", "Member3", "Member4", "Memeber5"));
            allBands.Add(new PopBand("Band C", new DateTime(1967, 05, 04), "Member1", "Member2", "Member3"));
            allBands.Add(new PopBand("Band D", new DateTime(2002, 06, 28), "Member1", "Member2", "Member3", "Member4", "Member5", "Member6"));
            allBands.Add(new IndieBand("Band KFC", new DateTime(1939, 04, 30), "Member1", "Member2", "dead", "dead", "Not Dead Yet"));
            allBands.Add(new IndieBand("Band F", new DateTime(1990, 10, 20), "Member1", "Member2", "Member3", "Member4"));
            #endregion

            #region add albums for bands
            allBands[0].addAlbums("Boogiepop", "NiceName", "No name yet", "Mosquitoes", "Facilitate");
            allBands[1].addAlbums("Cats", "Ice cream and summers", "Planes", "All right folks", "No more");
            allBands[2].addAlbums("Wild west", "Words", "Yes name yet");
            allBands[3].addAlbums("Earphones", "String", "Names", "Alone");
            allBands[4].addAlbums("Cucumber", "Flippity", "Look here", "Moo", "Facist", "Give something to someone");
            allBands[5].addAlbums("Glasses", "Pin", "None", "Bees", "If else");
            #endregion

            genreCbx.ItemsSource = Genres;

            allBands.OrderBy(item => item.BandName);
            bandsLBx.ItemsSource = allBands;            
        }

        private void BandsLBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band b = bandsLBx.SelectedItem as Band;

            if (b != null)
            {
                informationTxBl.Text = b.getInfo();

                //clear list box
                albumsLBx.ItemsSource = null;

                //albums to listbox
                albumsLBx.ItemsSource = b.Albums;
            }           
            
        }

        private void GenreCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genreCbx.SelectedValue.ToString() == Genres[0])
            {
                filteredBands = allBands;
            }
            else if (genreCbx.SelectedValue.ToString() == Genres[1])
            {
                filteredBands = FilterBands(Genres[1]);
            }
            else if (genreCbx.SelectedValue.ToString() == Genres[2])
            {
                filteredBands = FilterBands(Genres[2]);
            }
            else if (genreCbx.SelectedValue.ToString() == Genres[3])
            {
                filteredBands = FilterBands(Genres[3]);
            }
            bandsLBx.ItemsSource = filteredBands;
        }

        ObservableCollection<Band> FilterBands(string variation)// make a temp list of the objects that have "variation" 
        {
            ObservableCollection<Band> temp = new ObservableCollection<Band>();

            foreach (Band b in allBands)
            {
                if (b.Genre == variation)//if the given integer is the same as the enum turned to integer then add a to temp list
                {
                    temp.Add(b);
                }
            }

            return temp;
        }
    }
}
