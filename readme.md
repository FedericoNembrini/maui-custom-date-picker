## Maui Custom Date Picker
Maui Custom Date Picker is a MAUI library that implements and extends the default Date Picker.

<table>
    
</table>

|   | Android | iOS | Mac | Windows |
|---|:-:|:-:|:-:|:-:|
| NullableDatePicker | ✅ | ✅ | - | - |
| NullableTimePicker | 🛠️ | 🛠️ | - | - |
| EditableDateTimePicker | - | - | - | - |

### ToDo
- [ ] Improve Documentation
- [ ] Tests

### How To Use
Install the NugetPackage into your shared projects (available soon)
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

### Screenshot
<img src="https://user-images.githubusercontent.com/25205086/236876170-603b6f6e-8304-450a-819e-b0319d721904.png" height="700px" /> <img src="https://user-images.githubusercontent.com/25205086/236876402-cba37c1d-7fdd-4667-89c6-8a6ab8b0f0c9.png" height="700px" />

<img src="https://user-images.githubusercontent.com/25205086/236877244-b2446eb0-e484-4761-8a17-d89946df5820.png" height="700px" /> <img src="https://user-images.githubusercontent.com/25205086/236877138-73a526c0-2db3-489d-acc8-5d9e62d435b5.png" height="700px" />

<img src="https://user-images.githubusercontent.com/25205086/236877818-92700a05-074e-4a24-82dd-abfd645a6ea7.png" height="700px" /> <img src="https://user-images.githubusercontent.com/25205086/236877693-00a6872a-aac4-47ba-92d8-c5e92dbe9e33.png" height="700px" />
