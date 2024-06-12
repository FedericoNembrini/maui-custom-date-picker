using Android.App;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace FedericoNembrini.Maui.CustomDatePicker.Handlers
{
    public partial class NullableDatePickerHandler
    {
        DatePickerDialog? _datePickerDialog;

        protected override MauiDatePicker CreatePlatformView()
        {
            MauiDatePicker mauiDatePicker = base.CreatePlatformView();

            mauiDatePicker.ShowPicker = ShowPickerDialog;

            return mauiDatePicker;
        }

        protected override void ConnectHandler(MauiDatePicker platformView)
        {
            base.ConnectHandler(platformView);

            UpdateDisplayDate();
        }

        protected override DatePickerDialog CreateDatePickerDialog(int year, int month, int day)
        {
            _datePickerDialog = base.CreateDatePickerDialog(year, month, day);

            _datePickerDialog.SetButton("Ok", (sender, e) =>
            {
                this.PlatformView.Text = _datePickerDialog.DatePicker.DateTime.ToString(this.VirtualView.Format);

                this.VirtualView.Date = _datePickerDialog.DatePicker.DateTime;
                (this.VirtualView as INullableDatePicker)!.NullableDate = _datePickerDialog.DatePicker.DateTime;

                this.PlatformView.ClearFocus();
            });

            if (!(this.VirtualView as INullableDatePicker)!.IsClearButtonVisible)
            {
                _datePickerDialog.SetButton2("Cancel", (sender, e) =>
                {
                    this.PlatformView.ClearFocus();
                });
            }

            if ((this.VirtualView as INullableDatePicker)!.IsClearButtonVisible)
            {
                _datePickerDialog.SetButton2("Clear", (sender, e) =>
                {
                    (this.VirtualView as INullableDatePicker)!.NullableDate = null;
                    this.PlatformView.ClearFocus();
                });

                _datePickerDialog.SetButton3("Cancel", (sender, e) =>
                {
                    this.PlatformView.ClearFocus();
                });
            }

            return _datePickerDialog;
        }

        protected override void DisconnectHandler(MauiDatePicker platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }

        public void UpdateDisplayDate()
        {
            this.PlatformView.Text = (this.VirtualView as INullableDatePicker)?.NullableDate?.ToString(this.VirtualView.Format);
        }

        void ShowPickerDialog()
        {
            if (VirtualView == null)
                return;

            if (_datePickerDialog != null && _datePickerDialog.IsShowing)
                return;

            if (this.VirtualView is not INullableDatePicker)
                return;

            int year, month, day;

            if ((this.VirtualView as INullableDatePicker)!.NullableDate.HasValue)
            {
                year = (this.VirtualView as INullableDatePicker)!.NullableDate!.Value.Year;
                month = (this.VirtualView as INullableDatePicker)!.NullableDate!.Value.Month;
                day = (this.VirtualView as INullableDatePicker)!.NullableDate!.Value.Day;
            }
            else
            {
                if (this.VirtualView.MinimumDate != new DateTime(1900, 1, 1).Date && this.VirtualView.MinimumDate != DateTime.MinValue)
                {
                    year = this.VirtualView.MinimumDate.Year;
                    month = this.VirtualView.MinimumDate.Month;
                    day = this.VirtualView.MinimumDate.Day;
                }
                else
                {
                    year = DateTime.Today.Year;
                    month = DateTime.Today.Month;
                    day = DateTime.Today.Day;
                }
            }

            ShowPickerDialog(year, month - 1, day);
        }

        void ShowPickerDialog(int year, int month, int day)
        {
            if (_datePickerDialog == null)
            {
                _datePickerDialog = CreateDatePickerDialog(year, month, day);
            }
            else
            {
                EventHandler? setDateLater = null;
                setDateLater = (sender, e) => { _datePickerDialog!.UpdateDate(year, month, day); _datePickerDialog.ShowEvent -= setDateLater; };
                _datePickerDialog.ShowEvent += setDateLater;
            }

            _datePickerDialog.Show();
        }

        public static void MapNullableDate(IDatePickerHandler handler, IDatePicker datePicker)
        {
            (handler as INullableDatePickerHandler)?.UpdateDisplayDate();
        }

        public static new void MapDate(IDatePickerHandler handler, IDatePicker datePicker)
        {
            // Not needed, MapNullableDate is called
            //handler.PlatformView?.UpdateDate(datePicker);
        }

        public static new void MapFormat(IDatePickerHandler handler, IDatePicker datePicker)
        {
            handler.PlatformView?.UpdateFormat(datePicker);

            (handler as INullableDatePickerHandler)?.UpdateDisplayDate();
        }
    }
}
