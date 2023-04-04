using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_ATMSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account();
            acc.DisplayBalance();
            acc.Deposit();
            acc.Withdraw();

            SavingsAccount savingsAcc = new SavingsAccount();
            savingsAcc.DisplayBalance();
            savingsAcc.CalculateInterest();

            CheckingAccount checkingAcc = new CheckingAccount();
            checkingAcc.DisplayBalance();
            checkingAcc.Withdraw();
        }
    }

    class Account
    {
    
        public virtual void Deposit()
        {
 
        }

        public virtual void Withdraw()
        {
          
        }

        public virtual void DisplayBalance()
        {
       
        }
    }

    class SavingsAccount : Account
    {
        public override void DisplayBalance()
        {
         
        }

        public void CalculateInterest()
        {
            
        }
    }
    class CheckingAccount : SavingsAccount
    {
        public override void Withdraw()
        {
           
        }
    }

}
