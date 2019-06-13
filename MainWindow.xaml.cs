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
            int Number;
            int.TryParse(NInput.Text, out Number);

            string Tides = TidesInput.Text;
            string[] SplitTides = Tides.Split(null);
            int[] tides = Array.ConvertAll(SplitTides, int.Parse);           
            
            IEnumerable<int> query = tides.OrderBy(x => x);

            int[] tides2 = new int[0];
            tides = new int[0];

            for (int i = 0; i < query.ToArray().Length; i++)
            {
                if (i < query.ToArray().Length / 2)
                {
                    Array.Resize(ref tides, tides.Length + 1);
                    tides[i] = query.ToArray()[i];
                }
                else
                {
                    Array.Resize(ref tides2, tides2.Length + 1);
                    tides2[i - (query.ToArray().Length / 2)] = query.ToArray()[i];
                }
            }

            IEnumerable<int>ting = tides.Reverse();
            tides = ting.ToArray();

            for (int i = 0; i < tides.Length; i++)
            {
                lblOutput.Content += tides[i].ToString() + " " + tides2[i].ToString() + " ";
            }
        }
    }
}
