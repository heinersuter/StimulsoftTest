using System.ComponentModel;
using System.Runtime.CompilerServices;
using Stimulsoft.Report;

namespace StimulsoftTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _value;
        private StiReport _report;

        public MainWindowViewModel()
        {
            Report = new StiReport();
            Report.Load("Report.mrt");

            Value = "Test";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
                UpdateReport();
            }
        }

        public StiReport Report
        {
            get => _report;
            set
            {
                _report = value;
                OnPropertyChanged();
            }
        }

        private void UpdateReport()
        {
            Report.RegData("Data", new { Value });
            Report.Dictionary.Synchronize();
            Report.Render(false);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
