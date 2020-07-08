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
            Balance = 0.00m;
        }

        [Fact]
        public void BalanceAfterWithdrawal()
        {
            decimal amount = 500.00m;
            Balance = amount;
            decimal withdrawlAmount = 250.00m;
            Assert.Equal(amount - withdrawlAmount, Withdrawal(withdrawlAmount));
            Balance = 0.00m;
        }

        [Fact]
        public void BalanceAfterDespositAndWithdrawl()
        {
            decimal amount = 1500.00m;
            decimal withdrawalAmount = 750.00m;
            Deposit(amount);
            Withdrawal(withdrawalAmount);
            Assert.Equal(amount - withdrawalAmount, ViewBalance());
            Balance = 0.00m;
        }

        [Fact]
        public void BalanceUnchangedAfterNegativeWithdrawal()
        {
            Balance = 500.00m;
            decimal balance = ViewBalance();
            Assert.Throws<InvalidOperationException>(() => Withdrawal(-250.00m));
            Assert.Equal(balance, ViewBalance());
            Balance = 0.00m;
        }

        [Fact]
        public void BalanceUnchangedAFterNegativeDeposit()
        {
            Balance = 500.00m;
            decimal balance = ViewBalance();
            Assert.Throws<InvalidOperationException>(() => Deposit(-250.00m));
            Assert.Equal(balance, ViewBalance());
            Balance = 0.00m;
        }

        [Fact]
        public void BalanceCannotGoNegative()
        {
            Balance = 500.00m;
            decimal balance = ViewBalance();
            Assert.Throws<InvalidOperationException>(() => Withdrawal(750.00m));
            Assert.Equal(balance, ViewBalance());
            Balance = 0.00m;
        }
    }
}
