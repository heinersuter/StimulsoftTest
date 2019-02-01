using Stimulsoft.Report;

namespace StimulsoftTest
{
    public class MainWindowViewModel : ViewModel
    {
        private string _textValue;
        private StiReport _report;

        public MainWindowViewModel()
        {
            Report = new StiReport();
            Report.Load("Report.mrt");

            TextValue = "Test";
        }

        public string TextValue
        {
            get => _textValue;
            set => SetValue(ref _textValue, value, UpdateReport);
        }

        public StiReport Report
        {
            get => _report;
            set => SetValue(ref _report, value);
        }

        private void UpdateReport()
        {
            Report.RegData("Data", new { Value = TextValue });
            Report.Dictionary.Synchronize();
            Report.Render(false);
        }
    }
}
