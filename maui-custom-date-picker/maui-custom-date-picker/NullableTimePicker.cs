namespace FedericoNembrini.Maui.CustomDatePicker
{
	public class NullableTimePicker : TimePicker
	{
		public bool IsClearButtonVisible { get; set; } = true;

		public static readonly BindableProperty NullableTimeProperty = BindableProperty.Create(
			propertyName: nameof(NullableTime),
			returnType: typeof(TimeSpan?),
			declaringType: typeof(NullableTimePicker),
			defaultValue: null,
			defaultBindingMode: BindingMode.TwoWay
		);

		public TimeSpan? NullableTime
		{
			get => (TimeSpan?)GetValue(NullableTimeProperty);
			set => SetValue(NullableTimeProperty, value);
		}

		public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
			propertyName: nameof(PlaceHolder),
			returnType: typeof(string),
			declaringType: typeof(NullableTimePicker),
			string.Empty
		);

		public string PlaceHolder
		{
			get => (string)GetValue(PlaceHolderProperty);
			set => SetValue(PlaceHolderProperty, value);
		}

		public NullableTimePicker() { }

		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			if (propertyName == TimeProperty.PropertyName || (propertyName == IsFocusedProperty.PropertyName && !IsFocused && (Time.ToString("t") == DateTime.Now.ToString("t"))))
			{
				AssignValue();
			}

			if (propertyName == NullableTimeProperty.PropertyName && NullableTime.HasValue)
			{
				Time = NullableTime.Value;
			}
		}

		public void AssignValue()
		{
			NullableTime = Time;
		}
	}
}
