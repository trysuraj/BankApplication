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
    public partial class Withdraw : Form
    {
        private readonly CustomerModel _customer; 
        private readonly IAccount _account;
        private readonly IAccountData _accountData;
        private readonly Login _login;
        public Withdraw(CustomerModel customer, IAccount account, IAccountData accountData, Login login)
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
            var amount = textBox2.Text;
            if (acct == "" || amount == "")
            {
                MessageBox.Show("To Withdraw please provide Account number and amount");
                return;
            }
            if (!double.TryParse(amount, out double amt))
            {
                MessageBox.Show("Amount must be a valid number");
                return;
            }

            var confirmDeposit = _account.Withdrawal(_customer.UserId, acct, amt);
            if (confirmDeposit)
            {
                MessageBox.Show("Take your N"+amount+" cash.");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }
            MessageBox.Show("Unable to withdraw from this account");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var home = new Home(_customer, _account, _accountData, _login);
            home.Show();
            Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Withdraw_Load(object sender, EventArgs e)
        {

        }
    }
}
