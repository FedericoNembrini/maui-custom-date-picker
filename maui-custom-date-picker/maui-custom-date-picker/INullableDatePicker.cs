namespace FedericoNembrini.Maui.CustomDatePicker
{
	public interface INullableDatePicker : IDatePicker
	{
		bool IsClearButtonVisible { get; set; }

		new DateTime Date { get; set; }

		DateTime? NullableDate { get; set; }
	}
}
