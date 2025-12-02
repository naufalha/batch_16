using System;
using CheckoutSystem.interfaces;// We need this to find INotifier
using Serilog;
using Serilog.Core;
namespace CheckoutSystem.Services // Updated Namespace
{
    public class DiscountService
    {
        private readonly INotifier _notifier;
        private readonly ILogger _logger;

        public DiscountService(INotifier notifier, ILogger logger)
        {
            _notifier = notifier;
            _logger = logger;
        }

        public double GetDiscount(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
                _logger.Error("attepted to calculate discount for negative amount");

            if (amount > 100)
            {
                _notifier.Send("hasta lavista baby");
                _logger.Information("hastalavistababy");
                return amount - (amount * 0.10);
            }
            _logger.Information("no discount applied");
            return amount;
        }
    }
}