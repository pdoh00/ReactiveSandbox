using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace MyReactiveUI.StreamingData
{
    public class StreamingDataViewModel:ReactiveObject
    {
        public StreamingDataViewModel(DataFeed dataFeed)
        {
            ReactiveData = new ReactiveList<int>();
            IntegerViewModels = ReactiveData.CreateDerivedCollection(x => x);

            StartRecievingData = new ReactiveCommand();

            dataFeed.GetInfiniteSequence(1000)
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(d =>
                {
                    TheValue = d;
                });
        }

        public ReactiveCommand StartRecievingData { get; protected set; }

        public ReactiveList<int> ReactiveData { get; protected set; }
        public IReactiveDerivedList<int> IntegerViewModels { get; protected set; }

        private int _TheValue;
        public int TheValue
        {
            get { return _TheValue; }
            set { this.RaiseAndSetIfChanged(ref _TheValue, value); }
        }
    }
}
