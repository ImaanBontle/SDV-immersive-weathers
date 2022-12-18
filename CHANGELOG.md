# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased](https://github.com/ImaanBontle/SDV-immersive-weathers/commits/compare/v0.8.0...HEAD)

### Planned

- More colourful flavour text

## [v0.8.0](https://github.com/ImaanBontle/SDV-immersive-weathers/commits/compare/v0.7.0...v0.8.0) - 2022-12-18

### What Changed 🚀

Minor release for compatibility with ClimateControl

### ⚠️ Changes

- Reduced unnecessary SMAPI trace messages (#35)

### 📄 Documentation

- Updated code to reflect C# naming conventions (#36)
- Added XML comments to C# code (#37)

**Full Changelog**: https://github.com/ImaanBontle/SDV-immersive-weathers/compare/v0.7.0...v0.8.0

## [v0.7.0](https://github.com/ImaanBontle/SDV-immersive-weathers/commits/compare/v0.6.0...v0.7.0) - 2022-12-14

### What Changed 🚀

Generic Mod Config Menu added!

### 👽️ Integrations

- Generic Mod Config Menu now supported (#27)

### 📄 Documentation

- Switched to improved changelog system (#26)

**Full Changelog**: https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.6.0...v0.7.0

## [v0.6.0](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.6.0...v0.6.1)

- Added trace messages to SMAPI log for easier debugging.
- Fixed bug where weather would be reported as Sunny on Summer 13 & 26, despite weather being hardcoded to storm.
- Added config option to enable/disable weather updates to terminal / player HUD.

## [v0.5.1](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.4.2...0.5.1)

- Integrated TODO into code, rather than separate file.
- Revised API.
- Integrated method for transferring messages by passing objects in and out of framework.
- Framework now waits for all sister mods to complete tasks before predicting weather for tomorrow.

## [v0.4.2](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.4.1...0.4.2)

- Minor code cleanup.

## [v0.4.1](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.4.0...0.4.1)

- Moved WeatherState class to WeatherUtils, until I figure out how to usefully broadcast custom classes across APIs. WeatherTypes remain in IW API since they are a useful reference.

## [v0.4.0](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.3.2...0.4.0)

- Added integration with the EvenBetterRNG mod. Can call RollTheDice() or RollTheDiceInt() from the IW API to access the cached RNG for ImmersiveWeathers. Will return numbers from System.Random() otherwise.

## [v0.3.2](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.3.1...0.3.2)

- General clean up of code.
- Created two new class files, WeatherMan and WeatherUtils, which respectively handle terminal output about the current weather and grab/translate weather states. This makes IWFramework cleaner and easier to read.
- Made calls to separate classes explicit for readability purposes.
- Left WeatherState and WeatherType inside the API even though they can't be easily called, so that the information can be easily found by other users.

## [v0.3.1](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.3.0...0.3.1)

- Moved API to separate C# file.
- Added translation of weather states between integers and strings to API.
- Added Festival and Wedding to API weather states, just in case someone needs these converted when talking to the game (use GetWeatherInfo() if you just need the weather and not the integer states).

## [v0.3.0](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.2.0...0.3.0)

- Added API for integration with sister mods.

## [v0.2.0](https://github.com/ImaanBontle/SDV-immersive-weathers/compare/0.1.1...0.2.0)

- Added predictions for tomorrow's weather.

## [v0.1.1](https://github.com/ImaanBontle/SDV-immersive-weathers/commits/0.1.1)

- Restructured code into classes and methods.
- Weather types are now stored in a WeatherState class. Has functionality for predicting tomorrow's weather (not yet implemented).

## [v0.1.0]


---

- Initial release for purpose of generating update key for GitHub.
