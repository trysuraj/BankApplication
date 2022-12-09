using BankApp.Data;
using BankApp.Implementations;
using BankApp.Interfaces;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAppWinForm
{
    public partial class Home : Form
    {
        private readonly CustomerModel _customer;
        private readonly IAccount _account;
        private readonly IAccountData _accountData;
        private readonly Login _login;
        public Home(CustomerModel customer, IAccount account, IAccountData accountData, Login login)
        {
            InitializeComponent();
            _customer = customer;
            _account = account;
            _accountData = accountData;
            _login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Deposit = new Deposit(_customer,_account, _accountData, _login);
            Deposit.Show();
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            label3.Text = _customer.Name;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Deposit = new Withdraw(_customer, _account, _accountData, _login);
            Deposit.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var SOA = new SOAInput(_customer,_account,_accountData, _login);
            SOA.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var AcctDetails = new AccountDetails(_customer, _account, _accountData, _login);
            var allAcount = _accountData.GetAccountsByUserId(_customer.UserId);
            if(allAcount.Count > 0)
            {
                AcctDetails.Show();
                Hide();
                
            }else
            {
                MessageBox.Show("No account for this user");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var createAcct = new CreateAccount(_customer, _account, _accountData, _login);
            createAcct.Show();
            Hide();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _login.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var createAcct = new Transfer(_customer, _account, _accountData, _login);
            createAcct.Show();
            Hide();
        }
    }
}
