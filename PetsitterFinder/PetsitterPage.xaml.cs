using Core;
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

namespace PetsitterFinder
{
    /// <summary>
    /// Логика взаимодействия для PetsitterPage.xaml
    /// </summary>
    public partial class PetsitterPage : Page
    {
        private static Petsitter selectedPetsitter;
        public PetsitterPage(Petsitter petsitter)
        {
            InitializeComponent();
            selectedPetsitter = petsitter;
            tbName.Text = petsitter.Name;
            
        }
    }
}
