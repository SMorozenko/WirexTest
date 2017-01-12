using System;
using System.Collections.Generic;
using System.Linq;

namespace Wirex.Engine
{
    public class TradingEngine : ITradingEngine
    {
        private readonly List<Order> placedOrders;

        public TradingEngine()
        {
            placedOrders = new List<Order>();
            OrderPlaced += Match;
        }

        public void Place(Order order)
        {
            placedOrders.Add(order);
            OrderPlaced?.Invoke(this, new OrderArgs(order));
        }

        public void FullFill(Order order)
        {
            //TODO: implement order fullfillment logic
            OrderClosed?.Invoke(this, new OrderArgs(order));
        }

        public event EventHandler<OrderArgs> OrderPlaced;

        public event EventHandler<OrderArgs> OrderClosed;

        private void Match(object sender, OrderArgs args)
        {
            Match(args.Order);
        }

        private void Match(Order order)
        {
            var matchedOrders = placedOrders.Where(
                x => x.CurrencyPair.Equals(order.CurrencyPair) &&
                     (x.Side != order.Side) &&
                     (((x.Side == Side.Buy) && (x.Price >= order.Price)) ||
                      ((x.Side == Side.Sell) && (x.Price <= order.Price))));
        }
    }
}