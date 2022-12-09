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
    public partial class CreateAccount : Form
    {
        private readonly CustomerModel _customer;
        private readonly IAccount _account;
        private readonly IAccountData _accountData;
        private readonly Login _login;
        public CreateAccount(CustomerModel customer,IAccount account, IAccountData accountData, Login login)
        {
            InitializeComponent();
            _customer = customer;
            _account = account;
            _accountData = accountData;
            _login = login;
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var amount = textBox2.Text;
            var savings = radioButton1.Text;
            var current = radioButton2.Text;
            var accType = savings;
            var isChecked = radioButton1.Checked;
            if(isChecked) accType = savings;
            else accType = current;

            if(amount == "")
            {
                MessageBox.Show("Please provide initial deposit");
                return;
            }

            var validAmount = double.TryParse(amount, out double amt);

            if(validAmount)
            {
                if(amt < 0)
                {
                    MessageBox.Show("Initial deposit cannot be negative");
                    return ;
                }
                if(accType == savings && amt < 1000)
                {
                    MessageBox.Show("Initial deposit cannot be less than N1000 for a savings account");
                    return ;
                }
            }else
            {
                MessageBox.Show("Invalid Input, please use a number");
                return;
            }
            var createdAcct = _account.CreateAccount(_customer.UserId, accType, amt);
            if (createdAcct)
            {
                MessageBox.Show("Account successfully created");
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                textBox2.Text = "";
            }
            else MessageBox.Show("Unable to open account,Please try again.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var home = new Home(_customer, _account, _accountData, _login);
            home.Show();
            Hide();
        }
    }
}
