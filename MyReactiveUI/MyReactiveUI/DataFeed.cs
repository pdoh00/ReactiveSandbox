using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReactiveUI
{
    public class DataFeed
    {
        /// <summary>
        /// Returns a random int at interval intervals
        /// </summary>
        /// <param name="interval">How fast, in millsec, to return a new int.</param>
        /// <returns></returns>
        public IObservable<int> GetInfiniteSequence(int interval)
        {
            return Observable.Create<int>(o =>
                {
                    Random r = new Random((int)DateTime.UtcNow.Ticks);
                    
                    System.Timers.Timer t = new System.Timers.Timer(interval);
                    t.Elapsed += (s, e) => { o.OnNext(r.Next(0, Int32.MaxValue)); };
                    t.Start();
                    return t;
                });
        }
    }
}
