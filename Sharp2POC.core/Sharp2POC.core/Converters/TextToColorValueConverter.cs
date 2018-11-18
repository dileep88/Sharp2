using MvvmCross.Plugin.Color;
using MvvmCross.UI;
using System.Globalization;

namespace Sharp2POC.Core.Converters
{
	public class TextToColorValueConverter : MvxColorValueConverter<int>
	{
		//Converters allow you to change UI dynamically based on the logic provided
		protected override MvxColor Convert(int value, object parameter, CultureInfo culture)
		{
			if (value == 0)
			{
				//red
				return new MvxColor(0xA8, 0x03, 0x00);
			}
			else if (value >= 1 && value <= 3)
			{
				//yellow
				return new MvxColor(0xF2, 0xB5, 0x00);
			}
			else if (value > 3)
			{
				//black
				return new MvxColor(0x00, 0x00, 0x00);
			}

			//black
			return new MvxColor(0x00, 0x00, 0x00);
		}
	}
}
