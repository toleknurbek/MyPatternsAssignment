using System;
using System.Collections.Generic;

namespace MyFinalPatterns {
    // Strategy
    public interface IPaymentStrategy { void Pay(double a); }
    public class CryptoPayment : IPaymentStrategy { public void Pay(double a) => Console.WriteLine($"[Strategy] Криптомен {a} тг төленді."); }
    public class PaymentContext { 
        private IPaymentStrategy _s; 
        public void SetStrategy(IPaymentStrategy s) => _s = s; 
        public void Execute(double a) => _s?.Pay(a); 
    }
    // Observer
    public interface IObserver { void Update(double r); }
    public class CurrencyExchange {
        private List<IObserver> _obs = new List<IObserver>();
        public void Add(IObserver o) => _obs.Add(o);
        public void Notify(double r) => _obs.ForEach(o => o.Update(r));
    }
    public class MobileApp : IObserver { public void Update(double r) => Console.WriteLine($"[Observer] Курс: {r} тг"); }

    class Program {
        static void Main() {
            var p = new PaymentContext(); p.SetStrategy(new CryptoPayment()); p.Execute(12000);
            var e = new CurrencyExchange(); e.Add(new MobileApp()); e.Notify(455.5);
        }
    }
}