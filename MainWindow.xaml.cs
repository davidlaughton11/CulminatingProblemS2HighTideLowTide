/*David Laughotn
 *June 12th 2019
 * sorting tides high and low
 */

using System;
using System.Collections.Generic;
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

namespace CulminatingProblemS2HighTideLowTide
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //how many number
            int Number;
            int.TryParse(NInput.Text, out Number);

            //spliting the tides
            string Tides = TidesInput.Text;
            string[] SplitTides = Tides.Split(null);
            int[] tides = Array.ConvertAll(SplitTides, int.Parse);

            //ordering them from least to greatest
            IEnumerable<int> query = tides.OrderBy(x => x);

            //tides for high and low 
            int[] HighTides = new int[0];
            int[] LowTides = new int[0];

            //to check input
            if (Number != tides.Length)
            {
                lblOutput.Content = "Error with input";
            }
            else
            {
                //For loop to get the high and low tides
                for (int i = 0; i < query.ToArray().Length; i++)
                {
                    //for the low half of the array
                    if (i < query.ToArray().Length / 2)
                    {
                        Array.Resize(ref LowTides, LowTides.Length + 1);
                        LowTides[i] = query.ToArray()[i];
                    }
                    //for the high tides of the array
                    else
                    {
                        Array.Resize(ref HighTides, HighTides.Length + 1);
                        HighTides[i - (query.ToArray().Length / 2)] = query.ToArray()[i];
                    }
                }

                //Reversing the low tides
                IEnumerable<int> ReverseLowTides = LowTides.Reverse();
                LowTides = ReverseLowTides.ToArray();

                //Outputing the correct tides
                for (int i = 0; i < LowTides.Length; i++)
                {
                    lblOutput.Content += LowTides[i].ToString() + " " + HighTides[i].ToString() + " ";
                }
            }
        }
    }
}