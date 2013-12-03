using ReactiveUI;
using System.Windows;
using System.Windows.Controls;

namespace MyReactiveUI.StreamingData
{
    /// <summary>
    /// Interaction logic for StreamingDataView.xaml
    /// </summary>
    public partial class StreamingDataView : UserControl, IViewFor<StreamingDataViewModel>
    {
        public StreamingDataView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.TheValue, v => v.TheValue.Text);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(StreamingDataViewModel), typeof(StreamingDataView), new PropertyMetadata(null));

        public StreamingDataViewModel ViewModel
        {
            get { return (StreamingDataViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (StreamingDataViewModel)value; }
        }
    }
}
