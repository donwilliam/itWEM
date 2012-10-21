using GalaSoft.MvvmLight;

namespace MvvmLight1.ViewModel
{
    public class LightViewModel : ViewModelBase
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
                return "Light control";
            }
        }

        public string LowerLightButtonContent
        {
            get
            {
                return "Lower Lights";
            }
        }

        public string RaiseLightButtonContent
        {
            get
            {
                return "Raise Lights";
            }
        }

        public string LightControlsBlock
        {
            get
            {
                return "Light controls (placeholder)";
            }
        }

        public string LogBlock1
        {
            get
            {
                return "Light log (placeholder)";
            }
        }

        public LightViewModel()
        {
        }
    }
}