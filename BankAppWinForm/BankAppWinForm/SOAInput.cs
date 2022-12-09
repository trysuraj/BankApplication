using BankApp.Data;
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
    public partial class SOAInput : Form
    {
        private readonly CustomerModel _customer;
            private readonly IAccount _account;
            private readonly IAccountData _accountData;
            private readonly Login _login;
        public SOAInput(CustomerModel customer, IAccount account, IAccountData accountData, Login login)
        {
            InitializeComponent();
            _customer = customer;
            _account = account;
            _accountData = accountData;
            _login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var acct = textBox1.Text;
            if(acct == "")
            {
                MessageBox.Show("Provide your account number");
                return;
            }
            var transactions = _account.GetAllTransactions(_customer.UserId, acct);
            if(transactions != null)
            {
                dataGridView1.DataSource = transactions;
                label2.Text = "ACCOUNT STATEMENT ON ACCOUNT NO "+acct;
                //var tableTrans = new SOATable(_customer, _account, _accountData, transactions);

            }
            else MessageBox.Show("No transactions found for this account");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var home = new Home(_customer, _account, _accountData, _login);
            home.Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
