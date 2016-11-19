using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using static ChessInfrastructure.ChessEnums;

namespace ChessGame.Converters
{
    class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = new SolidColorBrush(Colors.Transparent);
            TileBackground background;
            if (Enum.TryParse(value.ToString(), out background))
            {
                switch (background)
                {
                    case TileBackground.Transparent:
                        break;
                    case TileBackground.Green:
                        color = new SolidColorBrush(Colors.Green);
                        break;
                    case TileBackground.Red:
                        color = new SolidColorBrush(Colors.Red);
                        break;
                    default:
                        color = new SolidColorBrush(Colors.Transparent);
                        break;
                }
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
