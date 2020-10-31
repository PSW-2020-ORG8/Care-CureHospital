using Controller;
using Controller.RoomsControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
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
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        private readonly EquipmentController equipmentController;

        public AddEquipment()
        {
            InitializeComponent();
            InputCodeOfEquipment.Focus();
            InputCodeOfEquipment.SelectAll();

            var app = Application.Current as App;
            equipmentController = app.EquipmentController;
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            try
            {
                int.Parse(InputAmountOfEquipment.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Morate uneti broj za količinu", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ViewEquipment existingEquipment = EquipmentConverter.ConvertEquipmentToEquipmentView(
               equipmentController.AddExistingEquipmnet(InputCodeOfEquipment.Text, int.Parse(InputAmountOfEquipment.Text)));
            if (existingEquipment == null)
            {
                MessageBox.Show("Uneli ste nepostojeću šifru opreme", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                foreach (ViewEquipment equipment in Equipment.EquipmentView)
                {
                    if (equipment.Code.Equals(InputCodeOfEquipment.Text))
                    {
                        equipment.Amount += int.Parse(InputAmountOfEquipment.Text);
                        break;
                    }
                }
                this.Close();
                MessageBox.Show("Uspešno ste dodali novu količinu opreme", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
