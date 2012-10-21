using GalaSoft.MvvmLight;

namespace MvvmLight1.ViewModel
{
    public class TempViewModel : ViewModelBase
    {

        public string ApplicationTitle
        {
            get
            {
                return "RC HOME";
            }
        }

        public string PageTitle
        {
            get
            {
                return "Temperature";
            }
        }

        public string LowerTempButtonContent
        {
            get
            {
                return "Lower Temps";
            }
        }

        public string RaiseTempButtonContent
        {
            get
            {
                return "Raise Temps";
            }
        }

        public string TempControlsBlock
        {
            get
            {
                return "Temperature controls (placeholder)";
            }
        }

        public string LogBlock1
        {
            get
            {
                return "Temperature log";
            }
        }

        public TempViewModel()
        {
        }
    }
}