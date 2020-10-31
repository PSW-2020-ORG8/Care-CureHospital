using Controller;
using Controller.MedicamentControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using Model.DoctorMenager;
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
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for AddMedicament.xaml
    /// </summary>
    public partial class AddMedicament : Window
    {
        private readonly MedicamentController medicamentController;

        public AddMedicament()
        {
            InitializeComponent();
            InputCodeOfMedicament.Focus();
            InputCodeOfMedicament.SelectAll();

            var app = Application.Current as App;
            medicamentController = app.MedicamentController;
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            try
            {
                int.Parse(InputAmountOfMedicament.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Morate uneti broj za količinu", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ViewMedicament existingMedicament = MedicamentConverter.ConvertMedicamentToMedicamentView(
                medicamentController.AddExistingMedicament(InputCodeOfMedicament.Text, int.Parse(InputAmountOfMedicament.Text)));
            if (existingMedicament == null)
            {
                MessageBox.Show("Uneli ste nepostojeću šifru leka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                foreach (ViewMedicament medicament in Medicaments.MedicamentsView)
                {
                    if (medicament.Code.Equals(InputCodeOfMedicament.Text))
                    {
                        medicament.Quantity += int.Parse(InputAmountOfMedicament.Text);
                        break;
                    }
                }
                this.Close();
                MessageBox.Show("Uspešno ste dodali novu količinu leka", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
