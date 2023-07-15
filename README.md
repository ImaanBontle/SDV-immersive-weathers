<div align="center">

# ImmersiveWeathers <a id="return-to-top"></a>

Control the weather in Stardew Valley!

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

- [About ImmersiveWeathers](#about)
- [Mod Summaries](#mod-summaries)
	- [Framework](#about-framework)
	- [Climate Control](#about-climate-control)
- [Getting Started](#getting-started)
	- [Prerequisites](#requirements)
	- [Installation](#installation)
- [Documentation](#docs)
- [Configuration](#config)
    - [Framework](#framework-config)
	- [Climate Control](#climate-control-config)
- [Compatibility](#compatibility)
	- [Supported](#supported)
	- [Recommended](#recommended)
	- [Incompatible](#incompatible)
- [Known Issues](#issues)
- [Future Plans](#future)
- [Contributing](#contribute)
	- [Bug Reports](#bugs)
	- [Feature Suggestions](#suggestions)
	- [Translations](#translations)
- [Support](#support)
- [License](#license)
- [Thanks](#thanks)

<details><summary><strong>Readme TODO List:</strong></summary>

- [x] Flesh out mod overviews
- [x] Proofread Getting Started
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

</details>

<!--About the Mods-->
## About ImmersiveWeathers <a id="about"></a>

*[Skip to installation](#getting-started) or [share your feedback][discussions-tab].*

Do you yearn to add more nuance, variety and realism to Stardew Valley's rather dry and predictable weather? Does the lack of weather mods currently available on the Nexus summon dark stormclouds overhead? Does your dream of embarking on an atmospheric adventure seem doomed to evaporate before your very eyes? Well, fear no longer! The dry spell is finally ending!

**Introducing: ImmersiveWeathers, an ambitious mod project currently in development which aims to enhance and elevate your in-game weather experience, adding further depth, immersion, and variety to your farming adventure!**

ImmersiveWeathers is a brand new mod project where each mod in the series focuses on enhancing or expanding a different aspect of the weather, gradually adding increased complexity and realism to the in-game systems. Some of these planned features include custom climates, dynamic weather changes, realistic yet partially-unreliable weather forecasts, an expanded range of weather types, optional gameplay challenges and more complex weather modelling.

Additionally, Immersive Weathers features an inherently modular design, allowing players to mix-and-match mods to suit their preferences and customize the weather system to their liking. Each mod's features are designed to operate largely independently (although, some cool interactions may occur when used in conjuction), meaning that players are free to make the experience as complex or as simple as they would like. *(Basically, don't like something, don't download it!)*

To begin your meteorological journey, you must first install [the Framework mod](#about-framework). This essential mod serves as the backbone for the rest of the project, providing the essential functionality, enabling seamless integration between the sister mods, and handling all external mod integrations. Simply put, the other mods won't work without it!

Once this mod is installed, you are then free to choose from any of the remaining mods in the project. For an overview of each mod's features, please read the [individual mod summaries](#mod-summaries) below. And if you find yourself enjoying the mods in this project, please leave an endorsement on each mod's respective Nexus page &mdash; it helps spread the word to fellow players!

**UPDATE: The first mod in the series, [ClimateControl](#about-climate-control), has just been released *(did someone say 'Snow in Fall'?)*, with more on the way soon! Stay tuned for future updates!**

ImmersiveWeathers is an ongoing project, with plans to expand and refine the mod collection to deliver the most immersive and atmospheric weather experience possible. [Your feedback is invaluable][discussions-tab], so don't hesitate to share your thoughts and experiences as we grow and develop this project together!

<!--Mod Summaries-->
## Mod Summaries <a id="mod-summaries"></a>

*This section contains mod overviews and download links. For mod READMEs, see [documentation](#docs).*

<!--Framework-->
### Framework (REQUIRED) ([Nexus][nexus-link]|[ModDrop][moddrop-link]|[GitHub][github-link]) <a id="about-framework"></a>

*See [list of supported mods](#supported).*

***For players:*** *This mod **MUST** be installed.*

***For modders:*** *All integrations should go through this mod. An API for this will be released soon.*

This mod is the central framework containing the common functionality shared between the mods in this series. It is required for the other mods to work and, if no other mods are installed, will print only daily weather updates. Additionally, the Framework handles internal cross-compatibility features (interactions between mods) and external mod integrations (interactions with other mods). 

<!--Climate Control-->
### ClimateControl ([Nexus][climate-control-nexus]|[ModDrop][climate-control-moddrop]|[GitHub][climate-control-github]) <a id="about-climate-control"></a>

*See [README][climate-control-github].*

***For players:** This mod will not work properly with other mods that change the weather ([see incompatible mods](#incompatible)).*

The first of the sister mods, Climate Control generates unique weather odds for each day, gradually shifting from one season to the next. Snow becomes more likely as Winter approaches, rain transforms into thunderstorms by the start of Summer, and weather patterns smoothly evolve throughout the year. Say goodbye to abrupt changes and embrace a more realistic and finely tuned weather system in Stardew Valley.

**Key features:**

- **Unique daily weather odds:**
	- Experience snow in Fall or rain in Winter, thanks to cubic spline interpolation.
	- Alternatively, for a more predictable weather experience, use fixed rules for the early-, mid- and late-season.
- **Pre-defined templates:**
	- Choose from one of several pre-defined climate templates. Alternatively, craft your own!
	- Each template's weather can be adjusted to your liking. Go crazy with the sliders and model your hometown!
	- Submit climate ideas for potential inclusion in future updates.
- **Available climates:**
	- *Standard:* Inspired by the vanilla game, the standard climate retains each season's original identity but features more gradual weather changes for an overall more immersive experience.
	- *Custom:* The custom climate allows you to design your own personalised weather experience without risking changes to any of the pre-existing templates.
- ***Coming soon...***
    - More templates!
	- Bug fixes.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Getting Started-->
## Getting Started <a id="getting-started"></a>

*This section covers the installation process for Immersive Weathers.*

<!--Requirements-->
### Requirements: <a id="requirements"></a>

To use this mod series, you must:

- Own [Stardew Valley v1.5.6][stardew-link] for Windows/MacOS/Linux.
- [Install SMAPI][smapi-link] (see [instructions][smapi-instructions]).
- Decide [which mods to use](#about).
   - *So far, only Climate Control is released.*

<!--Installation-->
### Installation <a id="installation"></a>

Ensure that you have carefully read the requirements, then:

1. Download the [latest version of the Framework][nexus-link] and [each of your chosen mods](#about).
2. For each mod, extract the ZIP file to your `Mods` folder (see [wiki guide][smapi-mod-wiki]).
3. Install [any of the supported mods](#supported).
4. Launch SMAPI once, to generate each mod's `config.json`.
5. Enjoy!

Consider leaving a :thumbsup: on each mod's [Nexus page][nexus-link]! This makes it easier for other players to find!

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Documentation-->
## Documentation <a id="docs"></a>

*This section contains the README links and other documentation.*

- Climate Control ([README][climate-control-readme])

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Config Options-->
## Configuration <a id="config"></a>

*This section covers the available config options. **Default values are shown in bold**.*

*For other mods in the series, see the [mod documentation](#docs).*

You can change these options in-game using [Generic Mod Config Menu][gmcm-link] or by manually editing the `config.json` in each mod's folder (generated after running SMAPI at least once).

### Weather Reports:

Each morning, you can choose to receive a forecast for the weather today and tomorrow. The following options determine whether you will receive these messages and how.

| Name | Value | Description |
|:---|:---|:---|
| **SMAPI Terminal** | ***true**, false* | *If *true*, weather predictions are printed to the SMAPI terminal.* |
| **In-Game HUD** | *true, **false*** | *If *true*, weather predictions are printed using the in-game HUD.* |

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Compatibility-->
## Mod Compatibility <a id="compatibility"></a>

*The following is a list of all supported, recommended and incompatible mods.*

<!--Supported-->
### Supported Mods <a id="supported"></a>

The following mods are officially supported by Immersive Weathers. When used in-game, you will see special functionality.

- **[Generic Mod Config Menu][gmcm-link]** - allows editing of the configuration in-game.
- **[Even Better RNG][even-better-rng-link]** - enables more accurate dice rolls for tomorrow's weather.

<!--Recommended-->
### Recommended Mods <a id="recommended"></a>

The following mods are entirely optional. You don't need these to enjoy Immersive Weathers but they may enhance your experience. I don't use them all myself, so please only install those which sound interesting to you.

- **[Thunder and Frog Sounds][thunder-frog-link]** (requires [Custom Music][custom-music-link]) - for a more relaxing, cozy thunderstorm ambience.
- **[Stardew Survival Project][survival-link]** - for those who enjoy survival gameplay and like the idea of micro-managing the farmer's body temperature.

<!--Incompatible-->
### Incompatible Mods <a id="incompatible"></a>

The following is a list of all mods which are not supported or are incompatible with *one or more* mods in the series. In general, any mod which alters the weather is going to cause unpredictable behaviour. You should be cautious when using these. However, [Content Patcher packs][content-patcher-link] should still be fine.

- **[More Rain][more-rain-link]** - *incompatible*. Alters the weather probabilities.
- **[Rain Plus][rain-plus-link]** - *incompatible*. Forces rain on certain days of the week.
- **[Winter Rain][winter-rain-link]** - *incompatible*. Changes the winter weather probabilities.
- **[Climates of Ferngill][climates-ferngill-link]** - *use with caution*. No problems yet, but this will break in the future.
- **[Weather Machine][weather-machine-link] / [Real Weather][real-weather-link]** - *incompatible*. Changes the way weather is calculated and adds new weather types. Use this if you prefer using live weather data rather than generated weather.
- **[Extreme Weather][extreme-weather-link]** - *incompatible*. Hilarious mod. But lol, why would you use these together?

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Known Issues-->
## Known Issues <a id="issues"></a>

*This section contains known issues with the Framework. For mod-specific issues, see the [mod documentation](#docs).*

No known issues.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Future Plans-->
## Planned Features <a id="future"></a>

*To suggest/contribute a feature, [see contributions](#contribute). For upcoming releases, [see the latest changelog][framework-changelog].*

This list contains some future ideas for this mod project. Please note that this is not a guaranteed plan. It's more of an inspiration source than a roadmap.

<details><summary>List of ideas</summary>

- [x] Daily weather odds
	- [ ] Add more climate templates
- [ ] Dynamic weather transitions
    - [ ] Varying weather intensities
	- [ ] Early/late (non-day-start) weather changes (is this even possible?)
- [ ] Custom weather effects
    - [ ] Dynamic wind directions/intensities
	- [ ] Custom sprites (doable)
    - [ ] Dynamic daylight (e.g. overcast, partly cloudy)
	- [ ] Audio/ambience? Maybe
- [ ] Custom weather types
	- [ ] Sandstorm (desert)
	- [ ] Sleet
	- [ ] Fog
	- [ ] Hail
	- [ ] Cloudy/overcast
	- [ ] Drizzle
	- [ ] Monkey's wedding (if you know, you know)
	- [ ] More fantastical weather? Cats & dogs lol
- [ ] Daylight savings time
    - [ ] Likely conflicts with dynamic nighttime
	- [ ] Would require custom implementation
- [ ] Temperature and humidity simulations
    - [ ] Effects on weather forecasts
	- [ ] Optional gameplay challenges (crops, stamina etc)
	- [ ] Support for survival mods
- [ ] Realistic weather forecasts
    - [ ] Stochastic variation
	- [ ] Worse predictions farther in future
	- [ ] In-game mail
	- [ ] Almanac integration
- [ ] Random weather events
    - [ ] Heat waves, droughts, frosts, gales, blizzards
	- [ ] Difficulty modes
	- [ ] Villager reactions (Schedules? Major headache)

</details>

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Contributing-->
## Contribute to this Project <a id="contribute"></a>

This project is open-source and contributions are welcome, particularly in the form of [bug fixes](#bugs), [feature suggestions](#suggestions) and [translation support](#translations).

For more substantial contributions, please fork the develop repo and submit a pull request using the https://github.com/ImaanBontle/SDV-immersive-weathers/labels/contribution label. You can also attempt to contact me via [NexusMods][nexus-profile] or by [opening an issue][issues-link].

Please be patient if I haven't responded immediately. I am likely busy with my studies.

<!--Bugs-->
### Bug Fixes/Reports <a id="bugs"></a>

If you encounter any bugs, please first remove any [incompatible mods](#incompatible) and re-run SMAPI to check if the issue resolves itself. If the bug persists or you do not see your mod included in the list, you can [submit a bug report][bugs-link]. Please answer the prompts to the best of your ability and mention any suspected mod conflicts. You should provide a link to your [SMAPI log][smapi-log] in the report.

If you would like submit a bugfix, you can do so by submitting a pull request using the https://github.com/ImaanBontle/SDV-immersive-weathers/labels/fix and https://github.com/ImaanBontle/SDV-immersive-weathers/labels/contribution labels.

<!--Feature Suggestions-->
### Suggestions <a id="suggestions"></a>

If you would like to suggest a feature for this project, please [submit a feature request][request-features-link]. While I can't guarantee these will be included in future releases, I would still love to hear from you. You will be credited for any suggestions that get implemented.

<!--Translations-->
### Translations <a id="translations"></a>

*Translation support will be added in the next minor release. In anticipation, I am adding the following table of translations.*

***Please note that the associated `default.json` files are currently empty and should be ignored.***

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
## Support <a id="support"></a>

If you would like to support my work, you can [buy me a coffee][ko-fi-link]. However, this is entirely optional. My mods are available for free and without expectation.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--License-->
## License <a id="license"></a>

The source code for this mod is available under the [MIT license][license-link]. Please do not host my official releases without my written consent.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Acknowledgements-->
## Special Thanks <a id="acknowledgements"></a>

I'd like to extend a **huge thanks** to [ConcernedApe][concernedape] for creating this masterpiece. Without your imagination, generosity and dedication, we wouldn't be here. You deserve all of your success and more. Thank you from the bottom of my heart.

I'd additionally like to thank [Pathoschild][pathoschild] for creating SMAPI and, through it, enabling the modding commmunity to thrive. I am very grateful to the modders who contributed to its success, who built this community, and who collectively curated the [amazing resources][stardew-modding-wiki] that taught me how to mod in C#.

I would like to thank the following individuals by name:

- [spacechase0][spacechase0] for creating the [Generic Mod Config Menu][gmcm-link] and its API.
- [Pepoluan][Pepoluan] for providing the API for [Even Better RNG][even-better-rng-link].

I would also like to thank my loving family and friends, for believing in my project and for your encouragement since its inception. Your love means the world to me.

To all the players who have downloaded and enjoyed my mods: Thank you. I am eternally grateful for your support. May you have many happy years in the Valley.

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
[discussion-template-link]: <https://github.com/ImaanBontle/SDV-immersive-weathers/discussions/new?category=weather-templates> "Discussions: Weather Templates"

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
