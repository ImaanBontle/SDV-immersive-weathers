<div align="center">

# Immersive Weathers <a id="return-to-top"></a>

Control the weather systems in Stardew Valley!

<!--Badges-->
[![License][license-shield]][license-link]
[![Release][release-shield]][release-link]
[![Pre-release][pre-release-shield]][release-link]
[![Release date][release-date-shield]][release-link]
<br>
[![Contributors][contributors-shield]][contributors-link]
[![Open issues][issues-shield]][issues-link]
[![Pull requests][pulls-shield]][pulls-link]
[![Commits since latest release][commits-shield]][commits-link]
[![Last commit][last-commit-shield]][commits-link]

<!--Links-->
[Nexus][nexus-link]
 &#183; 
[ModDrop][moddrop-link]
 &#183; 
[Report Bug][bugs-link]
 &#183; 
[Request a Feature][request-features-link]

</div>

<br>

<!--Table of Contents-->
# Table of Contents
- [About](#about)
	- [Framework](#about-framework)
	- [Climate Control](#about-climate-control)
- [Getting Started](#getting-started)
	- [Prerequisites](#requirements)
	- [Installation](#installation)
- [Usage](#usage)
	- [Documentation](#docs)
	- [Config Options](#config)
	- [Known Issues](#issues)
- [Compatibility](#compatibility)
	- [Supported](#supported)
	- [Recommended](#recommended)
	- [Incompatible](#incompatible)
- [Future](#future)
- [Contribute](#contribute)
	- [Bug Reports](#bugs)
	- [Feature Suggestions](#suggestions)
	- [Translations](#translations)
- [Support](#support)
- [License](#license)
- [Acknowledgements](#acknowledgements)

# Readme TODO List:

- [ ] Flesh out mod overviews
- [ ] Proofread Getting Started
- [ ] Draft Future Plans checklist
- [ ] Draft Contributions policy
- [ ] Draft Bug Report process
- [ ] Draft Feature Suggestion process
- [ ] Draft Translations placeholder
- [ ] Add Placeholder Translation Table
- [ ] Add Support My Work links
- [ ] Add License description
- [ ] Add Acknowledgements
- [ ] Check all links
- [ ] Prepare README for Climate Control
- [ ] Prepare Supp Docs for Climate Control

<!--About the Mods-->
## About Immersive Weathers <a id="about"></a>

Family of mods used to influence the weather systems in Stardew Valley. Work in progress. Only first mod released.

<!--Framework-->
### Framework <a id="about-framework"></a>

Central framework containing useful functions for sister mods. Required for the other mods to work correctly. If others not installed, will only print weather predictions.

<!--Climate Control-->
### Climate Control ([GitHub page][climate-control-github]) <a id="about-climate-control"></a>

Allows you to set custom weather probabilities for each day of the year.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Getting Started-->
## Getting Started <a id="getting-started"></a>

Follow these steps to get Immersive Weathers running on your local copy of Stardew Valley.

<!--Requirements-->
### Requirements: <a id="requirements"></a>

You will need the following:

- [Stardew Valley v1.5.6][stardew-link] on Windows/MacOS/Linux.
- The [latest version of SMAPI][smapi-link].

*Optionally, you may install any of the [supported](#supported)/[recommended](#recommended) mods.*

<!--Installation-->
### Installation <a id="installation"></a>

[Review the requirements](#requirements), then:

1. Install SMAPI ([read the instructions][smapi-instructions]).
2. Download the [latest version of the Framework][framework-link].
3. Extract the .zip file to your `Stardew Valley/Mods` folder ([wiki][smapi-mod-wiki]).
4. Repeat steps 3-4 for each sister mod you're installing ([see mod overview](#about)) (***NB: currently only Climate Control has been released!***)
5. Run SMAPI once to generate the `config.json`.

If you enjoy the mod, consider leaving a :thumbsup: on the mod page.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--How to Use-->
## How to Use <a id="usage"></a>

This section contains the necessary information for using each of the mods in-game.

### Documentation <a id="docs"></a>

Below, you can find links to each of the sister mods' README file, as well as any supplementary documentation that exists.

- Climate Control ([README][climate-control-readme])

<!--Config Options-->
### Configuration Options <a id="config"></a>

You can change each config option in-game by using the [Generic Mod Config Menu][gmcm-link] or by manually editing the `config.json` found inside your `Stardew Valley/Mods/ImmersiveWeathers` folder (only generated after launching SMAPI at least).

*These config options apply ONLY to the main Framework mod.*

| Name | Allowed Values | Summary |
|:---:|:---:|---|
| Terminal Logging | true, false | *Prints weather predictions to the SMAPI terminal during gameplay.* |
| HUD Logging | true, false | *Prints weather predictions to the in-game HUD each morning.* |

<!--Known Issues-->
### Known Issues <a id="issues"></a>

<!--Storms to rain flags not resetting in ClimateControl-->
There are currently no known issues with this mod.

*Make sure to [skim each mod's documentation](#docs) for any mod-specific issues.*

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Compatibility-->
## Compatibility <a id="compatibility"></a>

The following is a list of all supported, recommended and incompatible mods.

<!--Supported-->
### Supported Mods <a id="supported"></a>

The following mods are officially supported by Immersive Weathers and enable special functionality.

- [Generic Mod Config Menu][gmcm-link] - allows you to edit the configuration in-game.
- [Even Better RNG][even-better-rng-link] - enables more accurate weather probabilities.

<!--Recommended-->
### Recommended Mods <a id="recommended"></a>

The following mods are optional and may enhance your experience. Install only those which sound interesting to you. 

- [Thunder and Frog Sounds][thunder-frog-link] (requires [Custom Music][custom-music-link]) - for a more relaxing, cozy thunderstorm ambience.
- [Stardew Survival Project][survival-link] - if you enjoy survival gameplay and like the idea of micro-managing your farmer's body temperature.

<!--Incompatible-->
### Incompatible Mods <a id="incompatible"></a>

In general, any mod which alters the weather is likely to be incompatible. Currently, the list of known weather mods includes:

- [More Rain][more-rain-link] - *incompatible*. Alters the weather probabilities.
- [Rain Plus][rain-plus-link] - *likely incompatible*. Forces rain on certain days of the week.
- [Winter Rain][winter-rain-link] - *incompatible*. Alters winter weather probabilities.
- [Weather Machine][weather-machine-link] / [Real Weather][real-weather-link] - *incompatible*. Adds new weather types and changes the way weather is calculated (use if you prefer using live weather data).
- [Extreme Weather][extreme-weather-link] - *incompatible*. Lol, why would you use these together?
- [Climates of Ferngill][climates-ferngill-link] - *use with caution*. Planned features will likely render this incompatible but no obvious problems have been observed (yet). 

[Content Patcher][content-patcher-link] packs that ***only*** change the appearance of weather should be compatible.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Future Plans-->
## Future Plans <a id="future"></a>

The following checklist outlines a loose roadmap of plans for this mod series. These are not binding in any way and details may be changed or features dropped over time.

**CHECKLIST COMING SOON.**

*For info on upcoming releases, see the [latest changelog][framework-changelog].*

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Contributing-->
## Contribute to this Project <a id="contribute"></a>

<!--Outline a general policy regarding pull requests, prior contact, etc.-->
**COMING SOON**

<!--Bug Reports-->
### Bug Reports <a id="bugs"></a>

<!--Process for submitting bug reports (and link).-->
**COMING SOON**

<!--Feature Suggestions-->
### Feature Suggestions <a id="suggestions"></a>

<!--Process for submitting feature requests (and link)-->
**COMING SOON**

<!--Translations-->
### Translations <a id="translations"></a>

<!--Process for adding a translation-->
<!--Table of translations-->
**COMING SOON**

**COMPLETED TRANSLATIONS COMING SOON**

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Support-->
## Support My Work <a id="support"></a>

<!--Donation, Ko-Fi, buymeacoffee links-->
**COMING SOON**

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--License-->
## License <a id="license"></a>

<!--MIT License and link-->
**COMING SOON**

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Acknowledgements-->
## Acknowledgements <a id="acknowledgements"></a>

<!--Relevant acknowledgements (APIs, ConcernedApe, Pathoschild)-->
**COMING SOON**

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Markdown Links, Images and Abbreviations-->
<!--
REFERENCES FOR INSPIRATION LAYOUTS
[best-readme]: https://github.com/othneildrew/Best-README-Template
[awesome-readme]: https://github.com/Louis3797/awesome-readme-template
[readme-article]: https://www.freecodecamp.org/news/how-to-write-a-good-readme-file/
[translation-table]: https://github.com/Pathoschild/StardewMods/#translating-the-mods
[translation-script]: https://gist.github.com/Pathoschild/040ff6c8dc863ed2a7a828aa04447033
-->

<!--Shields-->
[license-shield]: <https://img.shields.io/github/license/ImaanBontle/SDV-immersive-weathers>
[license-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/blob/main/LICENSE> "License"
[release-shield]: <https://img.shields.io/github/v/release/ImaanBontle/SDV-immersive-weathers>
[release-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/releases> "Latest releases"
[pre-release-shield]: <https://img.shields.io/github/v/release/ImaanBontle/SDV-immersive-weathers?include_prereleases&label=pre-release>
[release-date-shield]: <https://img.shields.io/github/release-date/ImaanBontle/SDV-immersive-weathers>
[contributors-shield]: <https://img.shields.io/github/contributors/ImaanBontle/SDV-immersive-weathers>
[contributors-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/graphs/contributors> "Contributors"
[commits-shield]: <https://img.shields.io/github/commits-since/ImaanBontle/SDV-immersive-weathers/latest?include_prereleases>
[commits-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/commits> "Commit history"
[issues-shield]: <https://img.shields.io/github/issues-raw/ImaanBontle/SDV-immersive-weathers>
[issues-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/issues> "Open issues"
[pulls-shield]: <https://img.shields.io/github/issues-pr/ImaanBontle/SDV-immersive-weathers>
[pulls-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/pulls> "Open pull requests"
[last-commit-shield]: <https://img.shields.io/github/last-commit/ImaanBontle/SDV-immersive-weathers>

<!--Repo Links-->
[nexus-link]: <https://www.nexusmods.com/stardewvalley/mods/14658> "NexusMods"
[moddrop-link]: <> "ModDrop"
[bugs-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/issues/new?assignees=ImaanBontle&labels=bug&template=bug_report.md&title=%5BBUG%5D%3A+> "Report a Bug/Problem"
[request-features-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/issues/new?assignees=ImaanBontle&labels=enhancement&template=feature_request.md&title=%5BFEATURE%5D%3A+> "Request a New Feature"

<!--Dependency Links-->
[stardew-link]: <https://store.steampowered.com/app/413150/Stardew_Valley/> "Get Stardew Valley on Steam"
[smapi-link]: <https://smapi.io/> "Download SMAPI"
[smapi-mod-wiki]: <https://stardewvalleywiki.com/Modding:Player_Guide/Getting_Started#Install_mods> "SMAPI Modding Guide"
[smapi-instructions]: <https://stardewvalleywiki.com/Modding:Player_Guide/Getting_Started#Getting_started> "SMAPI Installation Guide"

<!--ImmersiveWeathers-->
[framework-link]: <https://www.nexusmods.com/stardewvalley/mods/14658> "Download from NexusMods"
[climate-control-github]: <https://github.com/ImaanBontle/SDV-IW-climate-control/tree/main> "Climate Control's on GitHub"

<!--Documentation-->
[framework-changelog]: <https://github.com/ImaanBontle/SDV-immersive-weathers/blob/develop/CHANGELOG.md> "Latest CHANGELOG"
[climate-control-readme]: <https://github.com/ImaanBontle/SDV-IW-climate-control/blob/main/README.md> "Climate Control README"

<!--Compatibility Links-->
[custom-music-link]: <https://www.nexusmods.com/stardewvalley/mods/3043?tab=files&BH=2> "Custom Music on NexusMods"
[content-patcher-link]: <https://www.nexusmods.com/stardewvalley/mods/1915> "Content Patcher on NexusMods"

<!--Supported Mods-->
[gmcm-link]: <https://www.nexusmods.com/stardewvalley/mods/5098> "Generic Mod Config Menu on NexusMods"
[even-better-rng-link]: <https://www.nexusmods.com/stardewvalley/mods/8680> "Even Better RNG on NexusMods"

<!--Recommended Mods-->
[thunder-frog-link]: <https://www.nexusmods.com/stardewvalley/mods/7450> "Thunder and Frog Sounds on NexusMods"
[survival-link]: <https://www.nexusmods.com/stardewvalley/mods/14183> "Stardew Survival Project on NexusMods"

<!--Incompatible Mods-->
[more-rain-link]: <https://www.nexusmods.com/stardewvalley/mods/441> "More Rain on NexusMods"
[rain-plus-link]: <https://www.nexusmods.com/stardewvalley/mods/441> "Rain Plus on NexusMods"
[winter-rain-link]: <https://www.nexusmods.com/stardewvalley/mods/13767> "Winter Rain on NexusMods"
[weather-machine-link]: <https://www.nexusmods.com/stardewvalley/mods/3203> "Weather Machine on NexusMods"
[real-weather-link]: <https://www.nexusmods.com/stardewvalley/mods/5773> "Real Weather on NexusMods"
[extreme-weather-link]: <https://www.nexusmods.com/stardewvalley/mods/12334> "Extreme Weather on NexusMods"
[climates-ferngill-link]: <https://www.moddrop.com/stardew-valley/mods/664033-climates-of-ferngill> "Climates of Ferngill on ModDrop"