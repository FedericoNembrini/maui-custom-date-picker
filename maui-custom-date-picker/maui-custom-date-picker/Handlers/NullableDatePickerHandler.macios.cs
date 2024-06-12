using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace FedericoNembrini.Maui.CustomDatePicker.Handlers
{
    public partial class NullableDatePickerHandler
    {
        MauiDatePicker mauiDatePicker;

        UIDatePicker uiDatePicker { get => mauiDatePicker.InputView as UIDatePicker; }

        protected override MauiDatePicker CreatePlatformView()
        {
            mauiDatePicker = base.CreatePlatformView();

            uiDatePicker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
            uiDatePicker.ValueChanged += HandleValueChanged;

            UIToolbar originalToolbar = mauiDatePicker.InputAccessoryView as UIToolbar;

            UIBarButtonItem newDoneButton = new("Ok", UIBarButtonItemStyle.Done, HandleDoneButton);
            UIBarButtonItem clearButton = new("Clear", UIBarButtonItemStyle.Plain, HandleClearButton);

            List<UIBarButtonItem> newToolbarItems = new();
            foreach (UIBarButtonItem toolbarItem in originalToolbar.Items)
            {
                if (toolbarItem.Style == UIBarButtonItemStyle.Done)
                    newToolbarItems.Add(newDoneButton);
                else
                    newToolbarItems.Add(toolbarItem);
            }

            if ((this.VirtualView as INullableDatePicker).IsClearButtonVisible)
                newToolbarItems.Insert(0, clearButton);

            originalToolbar.Items = newToolbarItems.ToArray();
            originalToolbar.SetNeedsDisplay();

            return mauiDatePicker;
        }

        protected override void ConnectHandler(MauiDatePicker platformView)
        {
            base.ConnectHandler(platformView);

            UpdateDisplayDate();
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

        void HandleValueChanged(object? sender, EventArgs e)
        {

        }

        void HandleDoneButton(object? sender, EventArgs e)
        {
            (this.VirtualView as INullableDatePicker).NullableDate = uiDatePicker.Date.ToDateTime();
            this.PlatformView.ResignFirstResponder();
        }

        void HandleClearButton(object? sender, EventArgs e)
        {
            (this.VirtualView as INullableDatePicker).NullableDate = null;
            this.PlatformView.ResignFirstResponder();
        }

        public static void MapNullableDate(IDatePickerHandler handler, IDatePicker datePicker)
        {
            (handler as INullableDatePickerHandler)?.UpdateDisplayDate();
        }

        public static new void MapDate(IDatePickerHandler handler, IDatePicker datePicker)
        {
            // Not needed, MapNullableDate is going to be called
        }

        public static new void MapFormat(IDatePickerHandler handler, IDatePicker datePicker)
        {
            handler.PlatformView.UpdateFormat(datePicker);

            (handler as INullableDatePickerHandler)?.UpdateDisplayDate();
        }

        public static new void MapFlowDirection(DatePickerHandler handler, IDatePicker datePicker)
        {
            handler.PlatformView?.UpdateFlowDirection(datePicker);
            handler.PlatformView?.UpdateTextAlignment(datePicker);

            (handler as INullableDatePickerHandler)?.UpdateDisplayDate();
        }

        public static new void MapTextColor(IDatePickerHandler handler, IDatePicker datePicker)
        {
            handler.PlatformView?.UpdateTextColor(datePicker);

            (handler as INullableDatePickerHandler)?.UpdateDisplayDate();
        }
    }
}
