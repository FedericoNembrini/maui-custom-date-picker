using Microsoft.Maui.Handlers;

#if IOS && !MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiDatePicker;
#elif MACCATALYST
using PlatformView = UIKit.UIDatePicker;
#elif ANDROID
using PlatformView = Microsoft.Maui.Platform.MauiDatePicker;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.CalendarDatePicker;
#elif TIZEN
using PlatformView = Tizen.UIExtensions.NUI.Entry;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace FedericoNembrini.Maui.CustomDatePicker.Handlers
{
	public partial class NullableDatePickerHandler : DatePickerHandler, INullableDatePickerHandler
	{
		public NullableDatePickerHandler() : base(Mapper)
		{
#if ANDROID
			Mapper.Add(nameof(INullableDatePicker.NullableDate), MapNullableDate);
			Mapper.Add(nameof(INullableDatePicker.Date), MapDate);
			Mapper.Add(nameof(INullableDatePicker.Format), MapFormat);
#endif
		}

		public NullableDatePickerHandler(IPropertyMapper? mapper)
			: base(mapper ?? Mapper, CommandMapper)
		{
#if ANDROID
			Mapper.Add(nameof(INullableDatePicker.NullableDate), MapNullableDate);
			Mapper.Add(nameof(INullableDatePicker.Date), MapDate);
#endif
		}

		public NullableDatePickerHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
			: base(mapper ?? Mapper, commandMapper ?? CommandMapper)
		{
#if ANDROID
			Mapper.Add(nameof(INullableDatePicker.NullableDate), MapNullableDate);
			Mapper.Add(nameof(INullableDatePicker.Date), MapDate);
			Mapper.Add(nameof(INullableDatePicker.Format), MapFormat);
#endif
		}

#if DEBUG
		public override void UpdateValue(string property)
		{
			System.Diagnostics.Debug.WriteLine(property);
			base.UpdateValue(property);
		}
#endif
	}
}
