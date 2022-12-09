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
    public partial class Transfer : Form
    {
        private readonly CustomerModel _customer;
        private readonly IAccount _account;
        private readonly IAccountData _accountData;
        private readonly Login _login;
        public Transfer(CustomerModel customer, IAccount account, IAccountData accountData, Login login)
        {
            InitializeComponent();
            _customer = customer;
            _account = account;
            _accountData = accountData;
            _login = login;
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            var sender = textBox1.Text;
            var receiver = textBox2.Text;
            var amount = textBox3.Text;

            if (sender == "" || receiver == "" || amount == "")
            {
                MessageBox.Show("No field should not be empty");
                return false;
            }
           var senderAcct = _accountData.GetAccountByUserIdAndAccountNo(_customer.UserId, sender);
            if(senderAcct == null)
            {
                MessageBox.Show("Not authorized to transfer from this account");
                return false;
            }
            var receiverAcct = _accountData.GetAccountByAccountNo(receiver);
            if(receiverAcct == null)
            {
                MessageBox.Show("This account does not exist");
                return false;
            }
            if(!double.TryParse(amount, out double amt))
            {
                MessageBox.Show("Please put a valid number");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                var amount = double.Parse(textBox3.Text);
                if(amount < 0)
                {
                    MessageBox.Show("Cannot transfer amount less than 0");
                    return;
                }
                var transferApproval = _account.Transfer(_customer.UserId, amount, textBox1.Text, textBox2.Text);
                if (transferApproval)
                {
                    MessageBox.Show("Transfer successful!");
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                }
                else MessageBox.Show("Insufficient Balance.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var home = new Home(_customer, _account, _accountData, _login);
            home.Show();
            Hide();
        }
    }
}
