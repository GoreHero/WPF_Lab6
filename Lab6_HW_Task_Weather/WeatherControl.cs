using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6_HW_Task_Weather
{
    enum Pre { sunny, cloudy, rain, snow }

    class WeatherControl : DependencyObject
    {
        private Pre pre;
        private string windDerection;
        private int windSpeed;
        public string WindDirection { get; private set; }
        public int WindSpeed { get; private set; }

        public WeatherControl(Pre pre, string windDerection, int windSpeed)
        {
            this.pre = pre;
            this.windDerection = windDerection;
            this.WindSpeed = windSpeed;
        }
        public static readonly DependencyProperty DataProperty;
        public int Data { get => (int)GetValue(DataProperty); set => SetValue(DataProperty, value); }

        static WeatherControl()
        {
            DataProperty = DependencyProperty.Register(
                nameof(Data),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.Inherits,
                    null,
                    new CoerceValueCallback(CoerceData)),
                new ValidateValueCallback(ValideDate));
        }

        private static bool ValideDate(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50) { return true; }
            else { return false; }
        }

        private static object CoerceData(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50) { return v; }
            else { return null; }
        }
    }
}
