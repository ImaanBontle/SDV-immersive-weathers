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
- [Configuration](#config)
    - [Framework](#framework-config)
	- [Climate Control](#climate-control-config)
- [Documentation](#docs)
- [Known Issues](#issues)
- [Compatibility](#compatibility)
	- [Supported](#supported)
	- [Recommended](#recommended)
	- [Incompatible](#incompatible)
- [Future Plans](#future)
- [Contributing](#contribute)
	- [Bug Reports](#bugs)
	- [Feature Suggestions](#suggestions)
	- [Translations](#translations)
- [Support](#support)
- [License](#license)
- [Thanks](#thanks)

# Readme TODO List:

- [ ] Flesh out mod overviews
- [ ] Proofread Getting Started
- [x] Draft Future Plans checklist
- [x] Draft Contributions policy
- [x] Draft Bug Report process
- [x] Draft Feature Suggestion process
- [x] Draft Translations placeholder
- [x] Add Placeholder Translation Table
- [x] Add Support My Work links
- [x] Add License description
- [x] Add Acknowledgements
- [ ] Check all links
- [ ] Prepare README for Climate Control
- [ ] Prepare Supp Docs for Climate Control

<!--About the Mods-->
## About Immersive Weathers <a id="about"></a>

*This mod series is currently a work-in-progress.*

Have you ever felt saddened by the general lack of weather mods for Stardew Valley? Well, I have. And I set out to fix that.

**Introducing: Immersive Weathers, a brand-new family of weather-related mods!**

Each mod in Immersive Weathers adds some element of nuance or realism to Stardew's weather systems, from crafting your own custom weather probabilities and climates to modelling dynamic weather systems, simulating realistic (i.e. inaccurate) weather forecasts and even introducing optional gameplay challenges.

**The first of these mods, [Climate Control](#about-climate-control), has just been released! (Did someone say 'Snow in Fall'? Winter Is Coming!)**

This project follows a modular design, meaning you can pick-and-choose which ones to include in your playthrough. In many cases, each mod will also allow you to default to one of several different templates, so mods will work straight out-of-the-box. Though if you'd prefer, you can also tweak each number to your liking and craft your own unique weather experience.

*Read on for a summary of each mod's features.*

*Alternatively, [skip to installation](#getting-started) or [share feedback][discussions-tab].*

<!--Framework-->
### Framework (REQUIRED) ([Nexus][nexus-link]|[ModDrop][moddrop-link]|[GitHub][github-link]) <a id="about-framework"></a>

*See [config options](#framework-config).*

This mod is the central framework containing common functionality for the other mods. It also handles cross-compatibility features stemming from the modular design and implements all external mod integrations. If no other mods in the series are installed, the Framework can only print weather updates.

***For players:*** *This mod **must** be installed. Without it, the others will not work.*

***For modders:*** *All integrations should go through this mod. An API will be officially released soon.*

<!--
Central framework containing useful functions for sister mods. Required for the other mods to work correctly. If others not installed, will only print weather predictions.
-->

<!--Climate Control-->
### Climate Control ([Nexus][climate-control-nexus]|[ModDrop][climate-control-moddrop]|[GitHub][climate-control-github]) <a id="about-climate-control"></a>

which allows you to define custom weather probabilities for every day of the year. Yep, gone are the days where each day of the season followed exactly the same rules! Instead, now you might find an increasing chance for snow as Winter comes, or increasingly frequent thunderstorms with Summer on the horizon.

You have complete control over each feature's customisation, with the ability to tweak the numbers/models to your personal liking (or opt for one of the pre-defined templates), crafting your own unique weather experience.

Allows you to set custom weather probabilities for each day of the year.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Getting Started-->
## Getting Started <a id="getting-started"></a>

*NB: To use this mod series, you will need the [Framework mod](#about-framework). Make sure to download it! It handles all cross-compatibility, integrations and shared functionality.*

Follow these steps to get Immersive Weathers running on your local copy of Stardew Valley.

<!--Requirements-->
### Requirements: <a id="requirements"></a>

You will need to install the following:

- [Stardew Valley v1.5.6][stardew-link] on Windows/MacOS/Linux.
- The [latest version of SMAPI][smapi-link] ([instructions][smapi-instructions]).

*Optionally, you may install any of the [supported](#supported)/[recommended](#recommended) mods.*

<!--Installation-->
### Installation <a id="installation"></a>

Review the requirements, then:

1. Download [the latest version of the Framework][nexus-link].
2. Extract the zip file to your `Stardew Valley/Mods` folder ([wiki guide][smapi-mod-wiki]).
3. Repeat steps 3-4 for each sister mod you're installing ([see overview of sister mods](#about)) (***NB: currently, only Climate Control has been released!***)
4. Run SMAPI at least once to generate the `config.json`.

That's it! If you enjoy the mod, please consider leaving a :thumbsup: on the [Nexus page][nexus-link]. It helps others find the mod too!

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Config Options-->
## Configuration Options <a id="config"></a>

Here, I have included a break-down of the config options for each mod.

You can change these in-game by using the [Generic Mod Config Menu][gmcm-link] or by manually editing the `config.json` found inside your unique mod folder, e.g. `Stardew Valley/Mods/ImmersiveWeathers` (this is only generated after launching SMAPI at least once).

### Framework Mod <a id="framework-config"></a>

The following general options exist:

| Name | Summary | Allowed Values|
|:---|:---|:---|
| **Terminal Logging** | Prints weather predictions to the SMAPI terminal during gameplay. | *true, false* |
| **HUD Logging** | Prints weather predictions to the in-game HUD each morning. | *true, false* |

### Climate Control <a id="climate-control-config"></a>

**COMING SOON**

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Documentation-->
## Documentation <a id="docs"></a>

Below, you will find links to each of the README files and any supplementary documentation.

- Climate Control ([README][climate-control-readme])

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Known Issues-->
## Known Issues <a id="issues"></a>

<!--Storms-to-rain flags not resetting in ClimateControl-->
There are currently no known issues with this mod.

*Make sure to [skim each mod's documentation](#docs) for any mod-specific issues.*

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Compatibility-->
## Compatibility <a id="compatibility"></a>

The following is a list of all [supported](#supported), [recommended](#recommended) and [incompatible](#incompatible) mods.

<!--Supported-->
### Supported Mods <a id="supported"></a>

The following mods are officially supported by Immersive Weathers. Using these in-game will enable special functionality.

- **[Generic Mod Config Menu][gmcm-link]** - allows you to edit the configuration in-game.
- **[Even Better RNG][even-better-rng-link]** - enables more accurate weather probabilities.

<!--Recommended-->
### Recommended Mods <a id="recommended"></a>

The following mods are entirely optional but may enhance your experience. They are not required to fully enjoy ImmersiveWeathers, so please install only those which sound interesting to you.

- **[Thunder and Frog Sounds][thunder-frog-link]** (requires [Custom Music][custom-music-link]) - for a more relaxing, cozy thunderstorm ambience.
- **[Stardew Survival Project][survival-link]** - if you enjoy survival gameplay and like the idea of micro-managing your farmer's body temperature.

<!--Incompatible-->
### Incompatible Mods <a id="incompatible"></a>

In general, any mod which alters the weather is likely to be incompatible. [Content Patcher][content-patcher-link] packs that only change the appearance of weather *should* be compatible. Currently, the list of known weather mods and their compatibility status includes:

- **[More Rain][more-rain-link]** - *incompatible*. Alters the weather probabilities.
- **[Rain Plus][rain-plus-link]** - *likely incompatible*. Forces rain on certain days of the week.
- **[Winter Rain][winter-rain-link]** - *incompatible*. Alters winter weather probabilities.
- **[Weather Machine][weather-machine-link] / [Real Weather][real-weather-link]** - *incompatible*. Adds new weather types and changes the way weather is calculated (use if you prefer using live weather data).
- **[Extreme Weather][extreme-weather-link]** - *incompatible*. Lol, why would you use these together?
- **[Climates of Ferngill][climates-ferngill-link]** - *use with caution*. No obvious problems have been observed, but planned features will likely render this incompatible. 

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Future Plans-->
## Feature Plans <a id="future"></a>

*If you would like to suggest a feature, [see contributions](#contribute). For upcoming releases, [view the latest changelog][framework-changelog].*

The following checklist outlines my general roadmap for this mod series. Please note that these ideas should not be taken as fixed commitments. Rather, they could change at any time and may even be dropped entirely. Nonetheless, I hope this provides a general sense of where this project is headed in the long-term.

- [x] Gradual seasonal weather
	- [ ] Add more templates
- [ ] Custom weather types
- [ ] Dynamic/gradual weather transitions
- [ ] Custom wind effects/sprites
- [ ] Daylight savings + seasonal day/night cycles
	- [ ] Dynamic daylight (e.g. overcast, partly cloudy)
- [ ] Temperature and humidity (+ effects on weather)
- [ ] Realistic/inaccurate weather forecasts
- [ ] Optional gameplay effects

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Contributing-->
## Contribute to this Project <a id="contribute"></a>

This project is open-source and contributions are welcome, particularly in the form of [bug fixes](#bugs), [feature suggestions](#suggestions) and [translation support](#translations). For more substantial contributions, please fork the develop repo and submit a pull request using the https://github.com/ImaanBontle/SDV-immersive-weathers/labels/contribution label. You can also attempt to contact me via [NexusMods][nexus-profile] or by [opening an issue][issues-link] on this repo.

*(Please be patient if I haven't responded, I am likely busy with studies.)*

<!--Bugs-->
### Bug Fixes/Reports <a id="bugs"></a>

If you encounter any bugs, please first remove any [incompatible mods](#incompatible) and re-run SMAPI to see if the issue resolves itself. If the bug persists or you do not see your mod included in this list, you can [submit a bug report][bugs-link]. You should answer the prompts to the best of your ability and mention any suspected mod conflicts. You will also need to provide a link to your [SMAPI log][smapi-log] in the report.

If you would like submit a bugfix, you can do so by submitting a pull request using the https://github.com/ImaanBontle/SDV-immersive-weathers/labels/fix and https://github.com/ImaanBontle/SDV-immersive-weathers/labels/contribution labels.

<!--Feature Suggestions-->
### Feature Suggestions <a id="suggestions"></a>

If you would like to suggest a feature for this mod family, please feel free to [submit a feature request][request-features-link]. While I can't guarantee they will be included in a future release, I am open to new ideas and would love to hear from you. You will of course be credited for any suggestions that ultimately get implemented. 

<!--Translations-->
### Translations <a id="translations"></a>

*Translation support will be added in the next minor release. In anticipation of this release, I am adding the following table. The required `default.json` files are **currently empty** and should be ignored.*

(❑ = untranslated, ↻ = partly translated, ✓ = fully translated)

&nbsp;     | [ClimateControl][climatecontrol-translation] | [Framework][framework-translation]
:--------- | :--------------------------------- | :----------------------------
Chinese    | ❑                                  | ❑
French     | ❑                                  | ❑
German     | ❑                                  | ❑
Hungarian  | ❑                                  | ❑
Italian    | ❑                                  | ❑
Japanese   | ❑                                  | ❑
Korean     | ❑                                  | ❑
Portuguese | ❑                                  | ❑
Russian    | ❑                                  | ❑
Spanish    | ❑                                  | ❑
Turkish    | ❑                                  | ❑

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Support-->
## Support My Work <a id="support"></a>

If you would like to support my work, you can do so by [buying me a coffee][ko-fi-link]. This is entirely optional and I will never charge for my mods.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--License-->
## License <a id="license"></a>

The source code for this mod is available under the [MIT license][license-link]. However, please do not host my own mod releases without written consent.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Acknowledgements-->
## Special Thanks <a id="acknowledgements"></a>

A **huge** thank you to [ConcernedApe][concernedape] for creating this masterpiece of a game. Without your imagination, generosity and dedication, none of us would be here to enjoy this gem. Thank you from the bottom of my heart. You deserve all of your success and more!

Additionally, a big thank you to [Pathoschild][pathoschild] for creating SMAPI and enabling the modding commmunity to thrive. I'd also like to thank all the modders who contributed to SMAPI's success over the years, who built this community, and who contributed collectively to the [amazing modding resources][stardew-modding-wiki] that helped me learn how to mod in C# in the first place.

The following individuals also deserve a mention:

- [spacechase0][spacechase0] for creating the [Generic Mod Config Menu][gmcm-link] and its API.
- [Pepoluan][Pepoluan] for providing an API for [Even Better RNG][even-better-rng-link].

Lastly, a personal thank you to all the players who have downloaded and enjoyed my mods. I am eternally grateful for your support. I hope you will have many more happy memories ahead in Stardew Valley.

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
[issues-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/issues> "Issues"
[pulls-shield]: <https://img.shields.io/github/issues-pr/ImaanBontle/SDV-immersive-weathers>
[pulls-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/pulls> "Open pull requests"
[last-commit-shield]: <https://img.shields.io/github/last-commit/ImaanBontle/SDV-immersive-weathers>

<!--Repo Links-->
[nexus-link]: <https://www.nexusmods.com/stardewvalley/mods/14658> "Framework on NexusMods"
[moddrop-link]: <> "Framework on ModDrop"
[github-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers> "Framework on GitHub"
[bugs-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/issues/new?assignees=ImaanBontle&labels=bug&template=bug_report.md&title=%5BBUG%5D%3A+> "Report a Bug/Problem"
[smapi-log]: <https://smapi.io/log> "SMAPI Log Parser"
[request-features-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/issues/new?assignees=ImaanBontle&labels=enhancement&template=feature_request.md&title=%5BFEATURE%5D%3A+> "Request a New Feature"
[discussions-tab]: <https://github.com/ImaanBontle/SDV-immersive-weathers/discussions> "Start a Discussion"

<!--Dependency Links-->
[stardew-link]: <https://store.steampowered.com/app/413150/Stardew_Valley/> "Get Stardew Valley on Steam"
[smapi-link]: <https://smapi.io/> "Download SMAPI"
[smapi-mod-wiki]: <https://stardewvalleywiki.com/Modding:Player_Guide/Getting_Started#Install_mods> "SMAPI Modding Guide"
[smapi-instructions]: <https://stardewvalleywiki.com/Modding:Player_Guide/Getting_Started#Getting_started> "SMAPI Installation Guide"

<!--ImmersiveWeathers-->
[climate-control-nexus]: <https://www.nexusmods.com/stardewvalley/mods/14659> "Climate Control on NexusMods"
[climate-control-moddrop]: <> "Climate Control on ModDrop"
[climate-control-github]: <https://github.com/ImaanBontle/SDV-IW-climate-control/tree/main> "Climate Control on GitHub"

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

<!--Translations-->
[framework-translation]: <https://github.com/ImaanBontle/SDV-immersive-weathers/tree/develop/i18n> "Framework i18n folder"
[climatecontrol-translation]: <https://github.com/ImaanBontle/SDV-IW-climate-control/tree/develop/i18n> "ClimateControl i18n folder"

<!--Contact Links-->
[nexus-profile]: <https://forums.nexusmods.com/index.php?showuser=54975162> "NexusMods Profile"
[ko-fi-link]: <https://ko-fi.com/msbontle> "Donate"

<!--Acknowledgements-->
[concernedape]: <https://twitter.com/ConcernedApe> "ConcernedApe on Twitter"
[pathoschild]: <https://www.nexusmods.com/stardewvalley/users/1552317> "Pathoschild on NexusMods"
[stardew-modding-wiki]: <https://stardewvalleywiki.com/Modding:Index> "Stardew Valley Wiki"
[spacechase0]: <https://www.nexusmods.com/stardewvalley/users/34250790> "spacechase0 on NexusMods"
[Pepoluan]: <https://www.nexusmods.com/stardewvalley/users/27024274> "Pepoluan on NexusMods"