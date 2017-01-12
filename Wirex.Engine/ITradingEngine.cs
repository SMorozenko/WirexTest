using System;

namespace Wirex.Engine
{
    public interface ITradingEngine
    {
        void Place(Order order);
        void FullFill(Order order);
        event EventHandler<OrderArgs> OrderPlaced;
        event EventHandler<OrderArgs> OrderClosed;
    }
}