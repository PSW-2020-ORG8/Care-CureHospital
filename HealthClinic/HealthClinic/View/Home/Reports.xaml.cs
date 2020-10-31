using Controller.ExaminationSurgeryControlers;
using Controller.MedicamentControlers;
using Controller.RoomsControlers;
using Controller.UsersControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using Model.AllActors;
using Model.DoctorMenager;
using Model.Term;
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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        private readonly UserController userController;
        private readonly RoomController roomController;
        private readonly RenovationController renovationController;
        private readonly SurgeryController surgeryController;
        private readonly MedicalExaminationController medicalExaminationController;
        private readonly MedicamentController medicamentController;
        private readonly WorkingTimeForDoctorController workingTimeForDoctorController;

        public static ObservableCollection<Doctor> DoctorsView { get; set; }
        public static ObservableCollection<Room> RoomsView { get; set; }

        public Reports()
        {
            InitializeComponent();
            this.DataContext = this;
            DataPickerFromDataTime.SelectedDate = DateTime.Now.Date;
            DataPickerToDataTime.SelectedDate = DateTime.Now.Date;

            var app = Application.Current as App;
            userController = app.UserController;
            roomController = app.RoomController;
            renovationController = app.RenovationController;
            surgeryController = app.SurgeryController;
            medicalExaminationController = app.MedicalExaminationController;
            medicamentController = app.MedicamentController;
            workingTimeForDoctorController = app.WorkingTimeForDoctorController;

            DoctorsView = new ObservableCollection<Doctor>(userController.GetAllDoctors());
            RoomsView = new ObservableCollection<Room>(roomController.GetAllEntities().ToList());
        }

        private void Button_Click_GenerisiIzvestaj(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Parse(DataPickerFromDataTime.SelectedDate.ToString());
            DateTime endDate = DateTime.Parse(DataPickerToDataTime.SelectedDate.ToString());
            Doctor selectedDoctor = (Doctor)ComboBoxDoctors.SelectedItem;
            Room selectedRoom = (Room)ComboBoxRooms.SelectedItem;

            if (Report1.IsChecked == true)
            {
                FlowDocument flowDocument = new FlowDocument();
                flowDocument.PagePadding = new Thickness(50);
                flowDocument.ColumnWidth = 1000;
                flowDocument.PageWidth = 700;
                flowDocument.PageHeight = 900;
                flowDocument.Background = System.Windows.Media.Brushes.WhiteSmoke;

                //NASLOV
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                TextBlock naslov = new TextBlock();
                naslov.Text = "Izveštaj o zauzetosti sale";
                naslov.FontWeight = FontWeights.Bold;
                naslov.FontSize = 32;
                naslov.Margin = new Thickness(60, 0, 0, 0);

                stackPanel.Children.Add(naslov);

                Paragraph top = new Paragraph();
                top.Inlines.Add(stackPanel);
                flowDocument.Blocks.Add(top);

                Paragraph prazanRedP = new Paragraph();
                prazanRedP.FontSize = 20;
                TextBlock prazanRedText = new TextBlock();
                prazanRedText.Text = " ";

                StackPanel zaPrazanRed = new StackPanel();
                zaPrazanRed.Orientation = Orientation.Horizontal;
                zaPrazanRed.Children.Add(prazanRedText);
                prazanRedP.Inlines.Add(zaPrazanRed);
                flowDocument.Blocks.Add(prazanRedP);

                Paragraph lekarP = new Paragraph();
                lekarP.FontSize = 20;
                TextBlock lekarLabel = new TextBlock();
                lekarLabel.Text = "Izveštaj o zauzetosti za salu:  ";
                TextBlock lekarData = new TextBlock();
                lekarData.Text = selectedRoom.RoomID;

                StackPanel zaLekara = new StackPanel();
                zaLekara.Orientation = Orientation.Horizontal;
                zaLekara.Children.Add(lekarLabel);
                zaLekara.Children.Add(lekarData);
                lekarP.Inlines.Add(zaLekara);
                flowDocument.Blocks.Add(lekarP);

                Paragraph periodP = new Paragraph();
                periodP.FontSize = 20;
                TextBlock periodLabel = new TextBlock();
                periodLabel.Text = "Vremenski period:  ";
                TextBlock periodData = new TextBlock();
                periodData.Text = startDate.ToString().Substring(0, 10) + " - " + endDate.ToString().Substring(0, 10);

                StackPanel zaPeriod = new StackPanel();
                zaPeriod.Orientation = Orientation.Horizontal;
                zaPeriod.Children.Add(periodLabel);
                zaPeriod.Children.Add(periodData);
                periodP.Inlines.Add(zaPeriod);
                flowDocument.Blocks.Add(periodP);

                Paragraph tabelaP = new Paragraph();
                tabelaP.FontSize = 20;
                TextBlock tabelaLabel = new TextBlock();
                tabelaLabel.Text = "Pregled zauzetosti sale";
                tabelaLabel.TextDecorations = TextDecorations.Underline;

                StackPanel zaTabelu = new StackPanel();
                zaTabelu.Orientation = Orientation.Horizontal;
                zaTabelu.Children.Add(tabelaLabel);
                tabelaP.Inlines.Add(zaTabelu);
                flowDocument.Blocks.Add(tabelaP);
                // TABELA
                Table table1 = new Table();
                table1.TextAlignment = TextAlignment.Center;
                table1.CellSpacing = 5;
                table1.Background = System.Windows.Media.Brushes.LightGray;
                table1.BorderThickness = new Thickness(50, 0, 50, 0);

                int numberOfColumns = 3;

                for (int i = 1; i < numberOfColumns; i++)
                {
                    table1.Columns.Add(new TableColumn());
                }

                table1.RowGroups.Add(new TableRowGroup());
                table1.RowGroups[0].Rows.Add(new TableRow());
                TableRow currentRow = table1.RowGroups[0].Rows[0];
                currentRow.FontSize = 23;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Početni datum"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Krajnji datum"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Zauzetost"))));
                table1.RowGroups[0].Rows.Add(new TableRow());

                int j = 1;

                List<MedicalExamination> medicalExaminations = medicalExaminationController.GetAllEntities().ToList();
                List<Surgery> surgeries = surgeryController.GetAllEntities().ToList();
                List<Model.Term.Renovation> renovations = renovationController.GetAllEntities().ToList();

                foreach (MedicalExamination medicalExamination in medicalExaminations)
                {
                    if(medicalExamination.Room.GetId() == selectedRoom.GetId())
                    {
                        if (medicalExamination.FromDateTime > startDate && medicalExamination.FromDateTime < endDate &&
                        medicalExamination.ToDateTime > startDate && medicalExamination.ToDateTime < endDate)
                        {
                            table1.RowGroups[0].Rows[j].FontSize = 20;
                            table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                            table1.RowGroups[0].Rows.Add(new TableRow());
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(medicalExamination.FromDateTime.ToString()))));
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(medicalExamination.ToDateTime.ToString()))));
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run("Običan pregled"))));
                            startDate = startDate.AddDays(1);
                            j++;
                        }
                    }                  
                }

                foreach (Surgery surgery in surgeries)
                {
                    if(surgery.Room.GetId() == selectedRoom.GetId())
                    {
                        if (surgery.FromDateTime > startDate && surgery.FromDateTime < endDate &&
                        surgery.ToDateTime > startDate && surgery.ToDateTime < endDate)
                        {
                            table1.RowGroups[0].Rows[j].FontSize = 20;
                            table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                            table1.RowGroups[0].Rows.Add(new TableRow());
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(surgery.FromDateTime.ToString()))));
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(surgery.ToDateTime.ToString()))));
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run("Operacija"))));
                            startDate = startDate.AddDays(1);
                            j++;
                        }
                    }                   
                }

                foreach (Model.Term.Renovation renovation in renovations)
                {
                    if (renovation.Room.GetId() == selectedRoom.GetId())
                    {
                        if (renovation.FromDateTime > startDate && renovation.FromDateTime < endDate &&
                        renovation.ToDateTime > startDate && renovation.ToDateTime < endDate)
                        {
                            table1.RowGroups[0].Rows[j].FontSize = 20;
                            table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                            table1.RowGroups[0].Rows.Add(new TableRow());
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(renovation.FromDateTime.ToString()))));
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(renovation.ToDateTime.ToString()))));
                            table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run("Renoviranje sale"))));
                            startDate = startDate.AddDays(1);
                            j++;
                        }
                    }
                }

                flowDocument.Blocks.Add(table1);

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, "");
                }
                MessageBox.Show("Izveštaj je uspešno izgenerisan", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Report2.IsChecked == true)
            {
                GenerateReportForDoctorOccupancy(selectedDoctor, startDate, endDate);
                
            }
            else if (Report3.IsChecked == true)
            {
                GenerateReportForDoctorWorkPlan(selectedDoctor, startDate, endDate);
            }
            else if (Report4.IsChecked == true)
            {
                GenerateReportForMedicaments();
            }
        }

        private void GenerateReportForDoctorOccupancy(Doctor selectedDoctor, DateTime startDate, DateTime endDate)
        {
            FlowDocument flowDocument = new FlowDocument();
            flowDocument.PagePadding = new Thickness(50);
            flowDocument.ColumnWidth = 1000;
            flowDocument.PageWidth = 700;
            flowDocument.PageHeight = 900;
            flowDocument.Background = System.Windows.Media.Brushes.WhiteSmoke;

            //NASLOV
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            TextBlock naslov = new TextBlock();
            naslov.Text = "Izveštaj o zauzetosti lekara";
            naslov.FontWeight = FontWeights.Bold;
            naslov.FontSize = 32;
            naslov.Margin = new Thickness(60, 0, 0, 0);

            stackPanel.Children.Add(naslov);

            Paragraph top = new Paragraph();
            top.Inlines.Add(stackPanel);
            flowDocument.Blocks.Add(top);

            Paragraph prazanRedP = new Paragraph();
            prazanRedP.FontSize = 20;
            TextBlock prazanRedText = new TextBlock();
            prazanRedText.Text = " ";

            StackPanel zaPrazanRed = new StackPanel();
            zaPrazanRed.Orientation = Orientation.Horizontal;
            zaPrazanRed.Children.Add(prazanRedText);
            prazanRedP.Inlines.Add(zaPrazanRed);
            flowDocument.Blocks.Add(prazanRedP);

            Paragraph lekarP = new Paragraph();
            lekarP.FontSize = 20;
            TextBlock lekarLabel = new TextBlock();
            lekarLabel.Text = "Izveštaj o zauzetosti za lekara:  ";
            TextBlock lekarData = new TextBlock();
            lekarData.Text = selectedDoctor.Name + " " + selectedDoctor.Surname;

            StackPanel zaLekara = new StackPanel();
            zaLekara.Orientation = Orientation.Horizontal;
            zaLekara.Children.Add(lekarLabel);
            zaLekara.Children.Add(lekarData);
            lekarP.Inlines.Add(zaLekara);
            flowDocument.Blocks.Add(lekarP);

            Paragraph periodP = new Paragraph();
            periodP.FontSize = 20;
            TextBlock periodLabel = new TextBlock();
            periodLabel.Text = "Vremenski period:  ";
            TextBlock periodData = new TextBlock();
            periodData.Text = startDate.ToString().Substring(0, 10) + " - " + endDate.ToString().Substring(0, 10);

            StackPanel zaPeriod = new StackPanel();
            zaPeriod.Orientation = Orientation.Horizontal;
            zaPeriod.Children.Add(periodLabel);
            zaPeriod.Children.Add(periodData);
            periodP.Inlines.Add(zaPeriod);
            flowDocument.Blocks.Add(periodP);

            Paragraph tabelaP = new Paragraph();
            tabelaP.FontSize = 20;
            TextBlock tabelaLabel = new TextBlock();
            tabelaLabel.Text = "Pregled zauzetosti lekara";
            tabelaLabel.TextDecorations = TextDecorations.Underline;

            StackPanel zaTabelu = new StackPanel();
            zaTabelu.Orientation = Orientation.Horizontal;
            zaTabelu.Children.Add(tabelaLabel);
            tabelaP.Inlines.Add(zaTabelu);
            flowDocument.Blocks.Add(tabelaP);
            // TABELA
            Table table1 = new Table();
            table1.TextAlignment = TextAlignment.Center;
            table1.CellSpacing = 5;
            table1.Background = System.Windows.Media.Brushes.LightGray;
            table1.BorderThickness = new Thickness(50, 0, 50, 0);

            int numberOfColumns = 3;

            for (int i = 1; i < numberOfColumns; i++)
            {
                table1.Columns.Add(new TableColumn());
            }

            table1.RowGroups.Add(new TableRowGroup());
            table1.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = table1.RowGroups[0].Rows[0];
            currentRow.FontSize = 23;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Početni datum"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Krajnji datum"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Zauzetost"))));
            table1.RowGroups[0].Rows.Add(new TableRow());

            int j = 1;

            List<MedicalExamination> medicalExaminationsForDoctor = medicalExaminationController.GetAllMedicalExaminationsByDoctor(selectedDoctor);
            List<Surgery> surgeriesForDoctor = surgeryController.GetAllSurgeryByDoctor(selectedDoctor);

            foreach (MedicalExamination medicalExamination in medicalExaminationsForDoctor)
            {
                if (medicalExamination.FromDateTime > startDate && medicalExamination.FromDateTime < endDate &&
                    medicalExamination.ToDateTime > startDate && medicalExamination.ToDateTime < endDate)
                {
                    table1.RowGroups[0].Rows[j].FontSize = 20;
                    table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                    table1.RowGroups[0].Rows.Add(new TableRow());
                    table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(medicalExamination.FromDateTime.ToString()))));
                    table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(medicalExamination.ToDateTime.ToString()))));
                    table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run("Običan pregled"))));
                    startDate = startDate.AddDays(1);
                    j++;
                }
            }

            foreach (Surgery surgery in surgeriesForDoctor)
            {
                if (surgery.FromDateTime > startDate && surgery.FromDateTime < endDate &&
                    surgery.ToDateTime > startDate && surgery.ToDateTime < endDate)
                {
                    table1.RowGroups[0].Rows[j].FontSize = 20;
                    table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                    table1.RowGroups[0].Rows.Add(new TableRow());
                    table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(surgery.FromDateTime.ToString()))));
                    table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(surgery.ToDateTime.ToString()))));
                    table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run("Operacija"))));
                    startDate = startDate.AddDays(1);
                    j++;
                }
            }

            flowDocument.Blocks.Add(table1);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, "");
            }
            MessageBox.Show("Izveštaj je uspešno izgenerisan", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void GenerateReportForDoctorWorkPlan(Doctor selectedDoctor, DateTime startDate, DateTime endDate)
        {
            FlowDocument flowDocument = new FlowDocument();
            flowDocument.PagePadding = new Thickness(50);
            flowDocument.ColumnWidth = 1000;
            flowDocument.PageWidth = 700;
            flowDocument.PageHeight = 900;
            flowDocument.Background = System.Windows.Media.Brushes.WhiteSmoke;

            //NASLOV
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            TextBlock naslov = new TextBlock();
            naslov.Text = "Izveštaj o planu rada lekara";
            naslov.FontWeight = FontWeights.Bold;
            naslov.FontSize = 32;
            naslov.Margin = new Thickness(80, 0, 0, 0);

            stackPanel.Children.Add(naslov);

            Paragraph top = new Paragraph();
            top.Inlines.Add(stackPanel);
            flowDocument.Blocks.Add(top);

            Paragraph prazanRedP = new Paragraph();
            prazanRedP.FontSize = 20;
            TextBlock prazanRedText = new TextBlock();
            prazanRedText.Text = " ";

            StackPanel zaPrazanRed = new StackPanel();
            zaPrazanRed.Orientation = Orientation.Horizontal;
            zaPrazanRed.Children.Add(prazanRedText);
            prazanRedP.Inlines.Add(zaPrazanRed);
            flowDocument.Blocks.Add(prazanRedP);

            Paragraph lekarP = new Paragraph();
            lekarP.FontSize = 20;
            TextBlock lekarLabel = new TextBlock();
            lekarLabel.Text = "Plan rada za lekara:  ";
            TextBlock lekarData = new TextBlock();
            lekarData.Text = selectedDoctor.Name + " " + selectedDoctor.Surname;

            StackPanel zaLekara = new StackPanel();
            zaLekara.Orientation = Orientation.Horizontal;
            zaLekara.Children.Add(lekarLabel);
            zaLekara.Children.Add(lekarData);
            lekarP.Inlines.Add(zaLekara);
            flowDocument.Blocks.Add(lekarP);

            Paragraph periodP = new Paragraph();
            periodP.FontSize = 20;
            TextBlock periodLabel = new TextBlock();
            periodLabel.Text = "Vremenski period:  ";
            TextBlock periodData = new TextBlock();
            periodData.Text = startDate.ToString().Substring(0, 10) + " - " + endDate.ToString().Substring(0, 10);

            StackPanel zaPeriod = new StackPanel();
            zaPeriod.Orientation = Orientation.Horizontal;
            zaPeriod.Children.Add(periodLabel);
            zaPeriod.Children.Add(periodData);
            periodP.Inlines.Add(zaPeriod);
            flowDocument.Blocks.Add(periodP);

            Paragraph tabelaP = new Paragraph();
            tabelaP.FontSize = 20;
            TextBlock tabelaLabel = new TextBlock();
            tabelaLabel.Text = "Pregled plana rada lekara";
            tabelaLabel.TextDecorations = TextDecorations.Underline;

            StackPanel zaTabelu = new StackPanel();
            zaTabelu.Orientation = Orientation.Horizontal;
            zaTabelu.Children.Add(tabelaLabel);
            tabelaP.Inlines.Add(zaTabelu);
            flowDocument.Blocks.Add(tabelaP);
            // TABELA
            Table table1 = new Table();
            table1.TextAlignment = TextAlignment.Center;
            table1.CellSpacing = 5;
            table1.Background = System.Windows.Media.Brushes.LightGray;
            table1.BorderThickness = new Thickness(50, 0, 50, 0);

            int numberOfColumns = 3;

            for (int i = 1; i < numberOfColumns; i++)
            {
                table1.Columns.Add(new TableColumn());
            }

            table1.RowGroups.Add(new TableRowGroup());
            table1.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = table1.RowGroups[0].Rows[0];
            currentRow.FontSize = 23;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Datum"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Dan"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Radno vreme"))));
            table1.RowGroups[0].Rows.Add(new TableRow());

            int j = 1;

            List<WorkingTimeForDoctor> workingTimesForDoctor = workingTimeForDoctorController.GetWorkTimeForDoctor(selectedDoctor);

            while (startDate < endDate)
            {
                String dayOfWeek = GetDayOfWeek(startDate);
                //radnoVreme.Add("08:00 - 15:00");
                table1.RowGroups[0].Rows[j].FontSize = 20;
                table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                table1.RowGroups[0].Rows.Add(new TableRow());
                table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(startDate.ToString().Substring(0, 10)))));
                table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(dayOfWeek))));
                WorkingTimeForDoctor workingTimeForOneDoctor = workingTimeForDoctorController.
                    GetWorkTimeForDoctorByDoctorAndDay(selectedDoctor, startDate.DayOfWeek);
                ViewWorkingTimeForDoctor viewWorkingTimeForOneDoctor = WorkingTimeForDoctorConverter.
                    ConvertWorkingTimeForDoctorToWorkingTimeForDoctorView(workingTimeForOneDoctor);
                String workingTime = viewWorkingTimeForOneDoctor.WorkingTime;
                table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(workingTime))));
                startDate = startDate.AddDays(1);
                j++;
            }

            flowDocument.Blocks.Add(table1);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, "");
            }
            MessageBox.Show("Izveštaj je uspešno izgenerisan", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void GenerateReportForMedicaments()
        {
            FlowDocument flowDocument = new FlowDocument();
            flowDocument.PagePadding = new System.Windows.Thickness(50);
            flowDocument.ColumnWidth = 1000;
            flowDocument.PageWidth = 700;
            flowDocument.PageHeight = 900;
            flowDocument.Background = System.Windows.Media.Brushes.WhiteSmoke;

            //NASLOV
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            TextBlock naslov = new TextBlock();
            naslov.Text = "Izveštaj o količini lekova u magacinu";
            naslov.FontWeight = FontWeights.Bold;
            naslov.FontSize = 28;
            naslov.Margin = new System.Windows.Thickness(38, 0, 0, 0);

            stackPanel.Children.Add(naslov);

            Paragraph top = new Paragraph();
            top.Inlines.Add(stackPanel);
            flowDocument.Blocks.Add(top);

            Paragraph tabelaP = new Paragraph();
            tabelaP.FontSize = 20;
            TextBlock tabelaLabel = new TextBlock();
            tabelaLabel.Text = "Pregled lekova u magacinu (trenutno stanje)";
            tabelaLabel.TextDecorations = TextDecorations.Underline;
            tabelaLabel.Margin = new System.Windows.Thickness(90, 0, 0, 0);

            StackPanel zaTabelu = new StackPanel();
            zaTabelu.Orientation = Orientation.Horizontal;
            zaTabelu.Children.Add(tabelaLabel);
            tabelaP.Inlines.Add(zaTabelu);
            flowDocument.Blocks.Add(tabelaP);
            // TABELA
            Table table1 = new Table();
            table1.TextAlignment = TextAlignment.Center;
            table1.CellSpacing = 5;
            table1.Background = System.Windows.Media.Brushes.LightGray;
            table1.BorderThickness = new Thickness(50, 0, 50, 0);

            int numberOfColumns = 3;

            for (int i = 1; i < numberOfColumns; i++)
            {
                table1.Columns.Add(new TableColumn());
            }

            table1.RowGroups.Add(new TableRowGroup());
            table1.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = table1.RowGroups[0].Rows[0];
            currentRow.FontSize = 23;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Šifra"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Naziv"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Količina"))));
            table1.RowGroups[0].Rows.Add(new TableRow());

            int j = 1;

            List<Medicament> medicaments = medicamentController.GetComfirmedMedicaments();
            IList<ViewMedicament> viewMedicaments = MedicamentConverter.ConvertMedicamentListToMedicamentViewList(medicaments);

            foreach (ViewMedicament viewMedicament in viewMedicaments)
            {
                table1.RowGroups[0].Rows[j].FontSize = 20;
                table1.RowGroups[0].Rows[j].FontWeight = FontWeights.Normal;
                table1.RowGroups[0].Rows.Add(new TableRow());
                table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(viewMedicament.Code))));
                table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(viewMedicament.Name))));
                table1.RowGroups[0].Rows[j].Cells.Add(new TableCell(new Paragraph(new Run(viewMedicament.Quantity.ToString()))));
                j++;
            }

            flowDocument.Blocks.Add(table1);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, "");
            }
            MessageBox.Show("Izveštaj je uspešno izgenerisan", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static string GetDayOfWeek(DateTime fromDate)
        {
            switch (fromDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "PONEDELJAK";
                case DayOfWeek.Tuesday:
                    return "UTORAK";
                case DayOfWeek.Wednesday:
                    return "SREDA";
                case DayOfWeek.Thursday:
                    return "ČETVRTAK";
                case DayOfWeek.Friday:
                    return "PETAK";
                case DayOfWeek.Saturday:
                    return "SUBOTA";
                case DayOfWeek.Sunday:
                    return "NEDELJA";
                default:
                    return fromDate.AddDays(1).DayOfWeek.ToString();
            }
        }
        static DateTime GetNextWeekday(DayOfWeek day)
        {
            DateTime result = DateTime.Now.AddDays(1);
            while (result.DayOfWeek != day)
                result = result.AddDays(1);
            return result;
        }

        private void Button_Click_PocetnaStrana(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FromDateTime_SelectedDataChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataPickerFromDataTime != null)
                DataPickerToDataTime.DisplayDateStart = DateTime.Parse(DataPickerFromDataTime.SelectedDate.ToString());
        }
    }
}
