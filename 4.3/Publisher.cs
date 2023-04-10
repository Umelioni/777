using System;
using System.Threading;

namespace _4._3
{
    public class Publisher
    {
        private EventBus eventBus;

        public Publisher(EventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public void SendEvent()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    eventBus.Send("EvenEvent", this, EventArgs.Empty);
                }
                else
                {
                    eventBus.Send("OddEvent", this, EventArgs.Empty);
                }
                Thread.Sleep(2000);
            }
        }
    }
}
