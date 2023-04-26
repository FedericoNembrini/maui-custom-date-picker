using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DemoMauiCustomDatePicker.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		[ObservableProperty]
		private DateTime? testDate;

		[ObservableProperty]
		private DateTime testMinDate = DateTime.MinValue;

		[ObservableProperty]
		private DateTime testMaxDate = DateTime.MaxValue;

		[RelayCommand]
		private void SetCurrentDate()
		{
			TestDate = DateTime.Now;
		}

		[RelayCommand]
		private void ClearTestDate()
		{
			TestDate = null;
		}

		[RelayCommand]
		private void SetMinDate()
		{
			TestMinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		}

		[RelayCommand]
		private void SetMaxDate()
		{
			TestMaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
		}

		[RelayCommand]
		private void ClearMinMaxDate()
		{
			TestMinDate = DateTime.MinValue;
			TestMaxDate = DateTime.MaxValue;
		}
	}
}
