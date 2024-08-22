## 1. About

EssenceIsoCodes is a C# .NET 8 library that provides developers easy access to essential ISO and other standard codes, 
including country, currency, language, and phone codes, in .NET applications. This library is designed to be 
lightweight and efficient, making it easy to integrate into your projects.

## 2. Features and How to Use

### Airport Codes 
- Retrieve airport name, IATA code, ICAO code, and country code.
```csharp
var _airports = await Airport.GetAirportsAsync();
```

### Country Codes
- Get country name, two-letter code, three-letter code, and numeric code following the ISO 3166-1 standard.
```csharp
var _countries = await Country.GetCountriesAsync();
```

### Currency Codes
- Get currency name, three-letter code, and numeric code, adhering to the ISO 4217 standard.
```csharp
var _currencies = await Currency.GetCurrenciesAsync();
```

### Language Codes
- Get language name, ISO 639-1, ISO 639-2, and ISO 639-3 codes. 
- Focuses on macrolanguages, which are groups of mutually intelligible speech varieties or dialect continuums without a common traditional name.
```csharp
var _languages = await Language.GetLanguagesAsync();
```

### Phone Codes
- Retrieve country code and phone code for countries, following the ITU-T E.164 standard.
```csharp
var _phoneCodes = await Phone.GetPhonesAsync();
```

### Timezones
- Get timezone information, including the tz identifier, and standard (SDT) and daylight saving (DST) UTC offsets.
```csharp
var _timezones = await Timezone.GetTimezonesAsync();
```

## 3. Release Notes

**19th August 2024**

- Initial release.

## 4. Feedback

Bug reports and contributions are welcome at [Project Issues](https://github.com/gcl-team/gcl-essenceisocodes/issues).