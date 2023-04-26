## Maui Custom Date Picker
Maui Custom Date Picker is a MAUI library that implements and extends the default Date Picker.

### Current Features
- [x] Nullable Date Picker (Android Only)

### ToDo
- [ ] Nullable Date Picker (iOS)
- [ ] Nullable Time Picker (Android and iOS )
- [ ] Editable DateTime Picker (Android and iOS)
- [ ] Improve Documentation
- [ ] Tests

### How To Use
Install the NugetPackage into your shared projects (if available)
```
Install-Package FedericoNembrini.Maui.CustomDatePicker
```
Then in the MauiProgram.cs, and the CustomDatePicker configuration method - 
```csharp
using FedericoNembrini.Maui.CustomDatePicker;;
```
```csharp
builder
	.UseMauiApp<App>()
    .UseCustomDatePicker();
```
Then in your .xaml use it like as a control
```xml
xmlns:cdp="clr-namespace:FedericoNembrini.Maui.CustomDatePicker;assembly=MauiCustomDatePicker"

<cdp:NullableDatePicker NullableDate="{Binding TestDate}" />
```