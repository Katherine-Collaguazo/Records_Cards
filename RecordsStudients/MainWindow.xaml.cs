using Newtonsoft.Json;
using RecordLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace RecordsStudients
{
    public partial class MainWindow : Window
    {
        Studient[] studients = new Studient[0];
        Score[] scores = new Score[0];
        public MainWindow()
        {
            InitializeComponent();
        }
        //Textbox validation
        private void txtList_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtPhonestudient_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtPhoneteacher_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtQualification_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtNamestudient_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }
        private void txtLastname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }
        private void txtRepresentative_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }
        private void txtNsubject_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }
        private void txtNameteacher_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            cmbConduct.ItemsSource = Enum.GetValues(typeof(Parameters.Conduct));
        }
        private void txtStudientcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtClasscode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtClasscodemodificar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtstudientcodemodificar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Avoid entering any type of data
            if (txtStudientcode.Text.Length < 1)
            {
                MessageBox.Show("Need studient code", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtList.Text.Length < 0)
            {
                MessageBox.Show("Need list", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtNamestudient.Text.Length < 0)
            {
                MessageBox.Show("Need name studient", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtLastnamestudient.Text.Length < 1)
            {
                MessageBox.Show("Need last name studient", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtPhonestudient.Text.Length < 1)
            {
                MessageBox.Show("Need phone studient", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtEmail.Text.Length < 1)
            {
                MessageBox.Show("Need Email", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtRepresentative.Text.Length < 1)
            {
                MessageBox.Show("Need Legal Representative", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtNsubject.Text.Length < 1)
            {
                MessageBox.Show("Need Subject", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtNameteacher.Text.Length < 1)
            {
                MessageBox.Show("Need Name teacher", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtPhoneteacher.Text.Length < 1)
            {
                MessageBox.Show("Need Phone teacher", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (txtQualification.Text.Length < 1)
            {
                MessageBox.Show("Need Quialification", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (cmbConduct.SelectedIndex < 0)
            {
                MessageBox.Show("Need Conduct", "Ingreso de Estudiante", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                //Object to create the json file and
                Studient studient = new Studient(txtNamestudient.Text,txtLastnamestudient.Text,txtEmail.Text,txtRepresentative.Text);
                studient.Namestudient = txtNamestudient.Text.ToUpper().Trim();
                studient.Lastnamestudient = txtLastnamestudient.Text.ToUpper().Trim();
                studient.Email = txtEmail.Text.ToUpper().Trim();
                studient.Representative = txtRepresentative.Text.ToUpper().Trim();

                Score score = new Score();
                score.Conduct = (Parameters.Conduct)cmbConduct.SelectedItem;

                //Transform to number in textbox
                int number = 0;
                Int32.TryParse(txtStudientcode.Text, out number);
                studient.Studientcode = number;
                Int32.TryParse(txtList.Text, out number);
                studient.Lista = number;
                Int32.TryParse(txtPhonestudient.Text, out number);
                studient.Phonestudient = number;
                
                Int32.TryParse(txtQualification.Text, out number);
                score.Qualification = number;
                
                //Creating the array for the datagrid
                Array.Resize(ref studients, studients.Length + 1);
                studients[studients.Length - 1] = studient;
                dgListing.ItemsSource = studients;
                dgListing.Items.Refresh();
                Array.Resize(ref scores, scores.Length + 1);
                scores[scores.Length - 1] = score;
                dgListing2.ItemsSource = scores;
                dgListing2.Items.Refresh();

                //Json file creation
                string json = JsonConvert.SerializeObject(studient);
                string codeStudient = studient.Studientcode.ToString();
                string path = ( @"C:\Users\use\source\repos\ReportCard-ECH\Records\"+ codeStudient + ".json");
                System.IO.File.WriteAllText(path, json);

                //Clean data
                txtStudientcode.Clear();
                txtList.Clear();
                txtNamestudient.Clear();
                txtLastnamestudient.Clear();
                txtPhonestudient.Clear();
                txtEmail.Clear();
                txtRepresentative.Clear();
                txtNsubject.Clear();
                txtNameteacher.Clear();
                txtPhoneteacher.Clear();
                txtQualification.Clear();
                cmbConduct.SelectedIndex = -1;
            }
        }
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtStudientcode.Clear();
            txtList.Clear();
            txtNamestudient.Clear();
            txtLastnamestudient.Clear();
            txtPhonestudient.Clear();
            txtEmail.Clear();
            txtRepresentative.Clear();
            txtNsubject.Clear();
            txtNameteacher.Clear();
            txtPhoneteacher.Clear();
            txtQualification.Clear();
            cmbConduct.SelectedIndex = -1;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Find if a record exists with this code
            int numero = 0;
            Int32.TryParse(txtStudientcode.Text, out numero);
            Studient studientAux = null;
            foreach (Studient p in studients)
            {
                if (p.Studientcode == numero)
                {
                    studientAux = p;
                }
                if (studientAux == null)
                {
                    btnAdd.IsEnabled = true;
                    btnClean.IsEnabled = false;
                    btnModify.IsEnabled = false;
                    btnRemove.IsEnabled = false;
                    txtList.Focus();
                }
                else
                {
                    btnAdd.IsEnabled = false;
                    btnClean.IsEnabled = true;
                    btnModify.IsEnabled = true;
                    btnRemove.IsEnabled = true;

                }
            }
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Studient studient = new Studient(txtNamestudient.Text, txtLastnamestudient.Text, txtEmail.Text, txtRepresentative.Text);
            studient.Namestudient = txtNamestudient.Text.ToUpper().Trim();
            studient.Lastnamestudient = txtLastnamestudient.Text.ToUpper().Trim();
            studient.Email = txtEmail.Text.ToUpper().Trim();
            studient.Representative = txtRepresentative.Text.ToUpper().Trim();

            //Transform to number in textbox
            int number = 0;
            Int32.TryParse(txtStudientcode.Text, out number);
            studient.Studientcode = number;
            Int32.TryParse(txtList.Text, out number);
            studient.Lista = number;
            Int32.TryParse(txtPhonestudient.Text, out number);
            studient.Phonestudient = number;

            string codeStudient = studient.Studientcode.ToString();
            string path = (@"C:\Users\use\source\repos\ReportCard-ECH\Records\" + codeStudient + ".json");
            System.IO.File.Delete(path);

            MessageBox.Show("Information has been removed with Success!");

            txtStudientcode.Clear();
            txtList.Clear();
            txtNamestudient.Clear();
            txtLastnamestudient.Clear();
            txtPhonestudient.Clear();
            txtEmail.Clear();
            txtRepresentative.Clear();
            txtNsubject.Clear();
            txtNameteacher.Clear();
            txtPhoneteacher.Clear();
            txtQualification.Clear();
            cmbConduct.SelectedIndex = -1;
        }
        public void modifyJson(int codeStudient)
        {
            string path = (@"C:\Users\use\source\repos\ReportCard-ECH\Records\"+codeStudient+".json");
            System.IO.File.Delete(path);

            Studient studient = new Studient(txtNamestudient.Text, txtLastnamestudient.Text, txtEmail.Text, txtRepresentative.Text);
            studient.Namestudient = txtNamestudient.Text.ToUpper().Trim();
            studient.Lastnamestudient = txtLastnamestudient.Text.ToUpper().Trim();
            studient.Email = txtEmail.Text.ToUpper().Trim();
            studient.Representative = txtRepresentative.Text.ToUpper().Trim();

            //Transform to number in textbox
            int number = 0;
            Int32.TryParse(txtStudientcode.Text, out number);
            studient.Studientcode = number;
            Int32.TryParse(txtList.Text, out number);
            studient.Lista = number;
            Int32.TryParse(txtPhonestudient.Text, out number);
            studient.Phonestudient = number;

            string json = JsonConvert.SerializeObject(studient);
            System.IO.File.WriteAllText(path, json);
        }
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            this.modifyJson(Convert.ToInt32(txtStudientcode.Text));
            MessageBox.Show("The information was saved successfully!");

            txtStudientcode.Clear();
            txtList.Clear();
            txtNamestudient.Clear();
            txtLastnamestudient.Clear();
            txtPhonestudient.Clear();
            txtEmail.Clear();
            txtRepresentative.Clear();
            txtNsubject.Clear();
            txtNameteacher.Clear();
            txtPhoneteacher.Clear();
            txtQualification.Clear();
            cmbConduct.SelectedIndex = -1;
        }
    }
}