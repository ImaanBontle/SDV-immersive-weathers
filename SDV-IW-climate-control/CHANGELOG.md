# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v1.1.0...HEAD)

### Planned

- Add more weather templates
- Improve documentation

## [v1.1.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v1.0.1...v1.1.0) - 2023-08-18

### What Changed 🚀

OFFICIAL RELEASE! Added support for custom festivals and some minor bugfixes.

### ✨ New Features

- Added support for custom festivals (#66)

### 🐛 Bug Fixes

- Fixed issues with debug logging (#67)
- Weather dicerolls should now use the correct day (#68)

### 📄 Documentation

- Added README file (#65)

**Full Changelog**: https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v1.0.1...v1.1.0

## [v1.0.1](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v1.0.0...v1.0.1) - 2022-12-18

### What Changed 🚀

Previous release was incompatible with older versions of the framework. The manifest.json is now updated to reflect this.

### 🐛 Bug Fixes

- Updated manifest.json to require the latest version of the framework (#60)

**Full Changelog**: https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v1.0.0...v1.0.1

## [v1.0.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v0.7.0...v1.0.0) - 2022-12-18

### What Changed 🚀

Daily weather probabilities and consistent predictions upon reload!

### ✨ New Features

- Tomorrow's weather is now consistent after loading a saved game (#45)
- Weather odds are now calculated uniquely for every day of the year! (#48)

### 🐛 Bug Fixes

- Fixed incorrect weather check for Spring 1-4 (#42)

### 🔧 Configs

- Added option to enable/disable daily probabilities (#52)
- Added option to enable debug logging (#54)

**Full Changelog**: https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v0.7.0...v1.0.0

## [v0.7.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v0.6.0...v0.7.0) - 2022-12-14

### What Changed 🚀

Generic Mod Config Menu added!

### ⚠️ Changes

- Tweaked rain probabilities in the standard model for a smoother Summer and Fall (#36)

### 👽️ Integrations

- Generic Mod Config Menu now supported (#29)

**Full Changelog**: https://github.com/ImaanBontle/SDV-IW-climate-control/compare/v0.6.0...v0.7.0

## [v0.6.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.5.1...v0.6.0) - 2022-12-13

### What Changed 🚀

Granular seasons and bugfixes!

*(NB: Make sure to delete the old config.json and model files when updating.)*

### ✨ New Features

- Seasons are now granular (players can adjust early, mid and late probabilities per season) (#23)

### 🐛 Bug Fixes

- Winter 14, 15 and 16 are always sunny and will be ignored when changing the weather (#24)

### 📄 Documentation

- Switched to an improved changelog system (#21)

**Full Changelog**: https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.5.1...v0.6.0

## [v0.5.1](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.5.0...0.5.1)

- Added XML comments to methods and classes.
- Cleaned up code and simplified config set-up.
- Changed the choice of weather tomorrow from operating on a successful first-come, first-serve basis to a lowest successful dice-roll basis. This means that no weather type is prioritised more than another; only the weather probabilities affect the outcome.
- Added dice-rolls for each successful weather type to the SMAPI trace log.

## [v0.5.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.4.0...0.5.0)

- Added trace messages to SMAPI log for easier debugging.

## [v0.4.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.3.1...0.4.0)

- Implemented improved messaging system from framework.
- Now broadcasts all relevant information to framework when changing weather and not just a simple string.
- Waits for permission from framework before recaching the model on save load.

## [v0.3.1](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.3.0...0.3.1)

- Stopped mod from caching model every day. Now checks model choice on save loaded.

## [v0.3.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.2.1...0.3.0)

- Added integration with Framework. Now broadcasts weather changes to SMAPI console through the Framework.
- Created a class framework for storing multiple different template models and printing these to json files at first launch. Major code re-write to accomodate this.
- If player edits a template's json files, mod will use the edited values.
- Player can also create a custom template by editing config.json and also specifying a "custom" model.
- Subcategorised seasonal weather into "Mid" grouping, in anticipation of "Early", "Mid" and "Late" chances of each weather type.
- Fleshed out code comments.
- Added list of models to API.
- Made sure mod only caches Framework's API once rather than daily.
- Mod only checks for model choice the first time.
- Integrated TODO into code, rather than separate file

## [v0.2.1](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.2.0...0.2.1)

- Minor code clean-up.

## [v0.2.0](https://github.com/ImaanBontle/SDV-IW-climate-control/compare/0.1.0...0.2.0)

- Added config file for each weather type's chance per season.
- Implemented a dice roll for changing the weather tomorrow (first weather feature implemented!).

## v0.1.0

- Initial release for purposes of generating GitHub keys. Demonstrates rudimentary fixing of weather to a certain day of the week.
