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
            AllValues = new ReactiveList<int>();
            AllValuesViewModels = AllValues.CreateDerivedCollection(x => x);
            
            StartRecievingData = new ReactiveCommand();

            var s = StartRecievingData.RegisterAsync(x => dataFeed.GetInfiniteSequence(1000))
                .Subscribe(d =>
                {
                    TheValue = d; //this works how I expect
                    //AllValues.Add(d); //this crashes. Why?
                });

        }

        public ReactiveCommand StartRecievingData { get; protected set; }
        public ReactiveList<int> AllValues { get; protected set; }
        public IReactiveDerivedList<int> AllValuesViewModels { get; protected set; }

        private int _TheValue;
        public int TheValue
        {
            get { return _TheValue; }
            set { this.RaiseAndSetIfChanged(ref _TheValue, value); }
        }
    }
}
