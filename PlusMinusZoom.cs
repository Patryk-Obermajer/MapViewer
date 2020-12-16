using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp3;

namespace WpfApp3
{
    public class PlusMinusZoom : Border
    {
        public UIElement image = null;
        private Point origin;
        private Point start;

        public void Initialize()
        {
            this.smell();
        }
        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is TranslateTransform);
        }

        public ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }
        public void smell()
        {
            return;
        }

    }
}

