using System;
using Xunit;
using static Lab02_UnitTest_Docs.BobsBodaciousBank;

namespace Lab02Test
{
    public class BobsBodaciousBankTest
    {
        [Fact]
        public void BalanceReturnsADecmialValueGreaterThanZero()
        {
            Assert.InRange(ViewBalance(), 0.0m, Decimal.MaxValue);
        }

        [Fact]
        public void WithdrawalInvalidInput()
        {
            Assert.Throws<InvalidOperationException>(() => Withdrawal(-5.00m));
        }

        [Fact]
        public void DepositInvalidInput()
        {
            Assert.Throws<InvalidOperationException>(() => Deposit(-5.00m));
        }

        [Fact]
        public void BalanceAfterDeposit()
        {
            decimal amount = 500.00m;
            Deposit(amount);
            Assert.Equal(amount, ViewBalance());
        }

        [Fact]
        public void BalanceAfterDespositAndWithdrawl()
        {
            decimal amount = 1500.00m;
            decimal withdrawalAmount = 750.00m;
            Deposit(amount);
            Withdrawal(withdrawalAmount);
            Assert.Equal(amount - withdrawalAmount, ViewBalance());
        }

        [Fact]
        public void BalanceUnchangedAfterNegativeWithdrawal()
        {
            Balance = 500.00m;
            decimal balance = ViewBalance();
            Assert.Equal(balance, Withdrawal(-250.00m));
        }

        [Fact]
        public void BalanceUnchangedAFterNegativeDeposit()
        {
            Balance = 500.00m;
            decimal balance = ViewBalance();
            Assert.Equal(balance, Deposit(-250.00m));
        }

        [Fact]
        public void BalanceCannotGoNegative()
        {
            Balance = 500.00m;
            decimal balance = ViewBalance();
            Assert.Equal(balance, Withdrawal(750.00m));
        }
    }
}
