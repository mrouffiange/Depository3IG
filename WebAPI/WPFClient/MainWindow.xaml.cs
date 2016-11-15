using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using Labo3;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyContext _context = new CompanyContext();
        private Customer _customer;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _customer = _context.Customers.ToList().First();
            Formulaire.DataContext = _customer;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _customer.AccountBalance += MontantAAjouterAuCompte.Value.Value;
            try
            {
                await UpdateCustomer(_customer.Id, _customer.RowVersion);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                
            }
        }

        private async Task<Boolean> UpdateCustomer (long? id, byte[] rowVersion)
        {
            //string[] fieldsToBind = new string[] { "AccountBalance", "RowVersion" };

            if (id == null)
            {
                return false;
            }

            var customerToUpdate = await _context.Customers.FindAsync(id);
            if (customerToUpdate == null)
            {
                return false;
            }


            try
            {
                _context.Entry(customerToUpdate).OriginalValues["RowVersion"] = rowVersion;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = (CompanyContext)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    System.Console.WriteLine("Unable to save changes. The department was deleted by another user.");
                }
                else
                {
                    System.Console.WriteLine("The record you attempted to edit "
                        + "was modified by another user after you got the original value.");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                System.Console.WriteLine("Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return true;
        }

    }
}
