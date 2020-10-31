using Controller;
using Controller.RoomsControlers;
using HealthClinic.View.Converter;
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
    /// Interaction logic for AddNewEquipment.xaml
    /// </summary>
    public partial class AddNewEquipment : Window
    {
        private readonly EquipmentController equipmentController;

        public AddNewEquipment()
        {
            InitializeComponent();
            InputCodeOfEquipment.Focus();
            InputCodeOfEquipment.SelectAll();

            var app = Application.Current as App;
            equipmentController = app.EquipmentController;
        }

        private void Button_Click_Potvrdi(object sender, RoutedEventArgs e)
        {
            if(InputCodeOfEquipment.Text.Equals("") || InputNameOfEquipment.Text.Equals("") || InputTypeOfEquipment.Text.Equals(""))
            {
                MessageBox.Show("Morate popuniti sva polja", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                int.Parse(InputAmountOfEquipment.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Morate uneti broj za količinu", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (equipmentController.ExistEquipmentWithCode(InputCodeOfEquipment.Text)) 
            {
                MessageBox.Show("Oprema sa šifrom koju ste uneli već postoji", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Equipment.EquipmentView.Add(EquipmentConverter.ConvertEquipmentToEquipmentView(
                    equipmentController.AddEntity(new Model.Manager.Equipment(InputCodeOfEquipment.Text, InputNameOfEquipment.Text,InputTypeOfEquipment.Text, int.Parse(InputAmountOfEquipment.Text)))));
                this.Close();
                MessageBox.Show("Usepešno ste dodali novu opremu", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);               
            }           
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
