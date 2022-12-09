using BankApp.Data;
using BankApp.Implementations;
using BankApp.Interfaces;
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
    public partial class Login : Form
    {
        private Register _register;
        private readonly IBank _bank;
        private readonly ICustomerData _customerData;
        private readonly IAccountData _accountData;
        private readonly IValidation _validation;
        private readonly ICustomer _customer;
        private readonly IAccount _account;
        public Login(IBank bank, IValidation validation, ICustomerData customerData,
                            ICustomer customer, IAccount account, IAccountData accountData)
        {
            InitializeComponent();
            _bank = bank;
            _customerData = customerData;
            _validation = validation;
            _customer = customer;
            _register = new Register(_bank, _validation, _customerData, _customer, this);
            _account = account;
            _accountData = accountData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide a valid Email and Password");
                return;
            }
            var customer = _bank.Login(textBox1.Text, textBox2.Text);
           
            if (customer == null) MessageBox.Show("User does not exist");
            else
            {
                var home = new Home(customer, _account, _accountData,this);
                home.Show();
                Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            _register.Show();
            Hide();
        }

        
    }
}
