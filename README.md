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
## About Immersive Weathers <a id="about"></a>

*Read on for a summary of each mod's features. Alternatively, [skip to installation](#getting-started) or [share your feedback][discussions-tab].*

**Introducing Immersive Weathers, a brand-new family of weather-related mods!** Have you ever felt saddened by the lack of weather mods for Stardew Valley? Well, I definitely have. And I set out to fix that.

Each mod in Immersive Weathers adds some element of nuance or realism to Stardew's weather systems, resulting in a much more immersive and dynamic weather experience than the vanilla game. These planned changes range from crafting your own custom weather probabilities and climates to modelling dynamic weather systems, simulating realistic (i.e. inaccurate) weather forecasts or adding optional gameplay challenges.

**So far, the first mod in the series, [Climate Control](#about-climate-control), has been released! (Did someone say 'Snow in Fall'?)** More features will be added in future updates.

This project follows a modular design, meaning you can pick-and-choose which mods to include in your playthrough. In many cases, each mod also allows you to use one of many weather templates, so they'll usually work straight out-of-the-box. However, if you'd prefer more direct control, you can also tweak the numbers manually, crafting your own customised weather.

<!--Framework-->
### Framework (REQUIRED) ([Nexus][nexus-link]|[ModDrop][moddrop-link]|[GitHub][github-link]) <a id="about-framework"></a>

***For players:*** *This mod must be installed.*

***For modders:*** *All integrations should go through this mod. An API will be released soon.*

This mod is the central framework containing some common functionality needed for the other mods in the series. If none are installed, the Framework will simply print weather updates to the terminal/HUD. The Framework also handles internal cross-compatibility features and external mod integrations ([list of supported mods](#supported)).

<!--Climate Control-->
### Climate Control ([Nexus][climate-control-nexus]|[ModDrop][climate-control-moddrop]|[GitHub][climate-control-github]) <a id="about-climate-control"></a>

***For players:** This mod will not work properly with mods that change the weather ([see incompatible mods](#incompatible)).*

The first of the sister mods to be released, Climate Control allows you to define custom weather probabilities for every day of the year, rather than using the fixed seasonal rules from the vanilla game. Yup, gone are the days of weather being unrealistically confined to the separate seasons! Now, you might witness more frequent thunderstorms as Summer arrives, or shiver from the increasing chances of snow as Winter rolls over the horizon. Finally, an excuse to dress up as Ned Stark on Spirit's Eve!

- Unique daily weather odds:
    - Experience snow in Fall or rain in Winter, thanks to cubic spline interpolation.
	- For a more predictable experience, use fixed rules instead in the early-, mid- and late-season.
- Use the 'standard' climate, or make your own:
    - Inspired by the vanilla game, the standard climate has more gradual seasonal changes
    - More climates will be coming soon!

**Daily Weather:**

The mod achieves this behaviour by taking a set of player-defined weather probabilities for the start, middle and end of each season. It then performs cubic spline interpolation for all the days in-between those time periods, essentially producing a "guess" for how easily the weather can change based on the numbers given.

There are two major advantage to this approach: 1) No two days have the same odds for all weather types, so that each day 'feels' slightly different 2) Weather can also seem to 'bleed over' from one period to the next, resulting in cool effects like witnessing snow at the end of Fall, similar to real-life!

If you would prefer a simpler weather approach, interpolation can also be disabled and the mod will treat the config values as fixed probabilities for each 1/3rd of its season. This is less realistic than using the interpolation but will still produce more varied weather than in the base game.

**Climate Templates:**

By default, the mod uses a pre-defined 'standard climate'. This is the climate most similar to vanilla, featuring gentle rain showers in Spring, brief thunderstorms in early Summer, dry, windy weather in Fall, and continous snowfall in Winter. However, when combined with cubic spline interpolation, this produces a smoother weather profile and more gradual season changes.

In the settings menu, you can define your own custom template or tweak the existing one. In future updates, you can expect more templates themed around various real-world biomes, each allowing for similar customisation.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Getting Started-->
## Getting Started <a id="getting-started"></a>

*This section covers everything you need to get Immersive Weathers running in Stardew Valley.*

<!--Requirements-->
### Requirements: <a id="requirements"></a>

To use this mod series, you must first:

- Own [Stardew Valley v1.5.6][stardew-link] for Windows/MacOS/Linux.
- [Install SMAPI][smapi-link] ([see instructions][smapi-instructions]).

<!--Installation-->
### Installation <a id="installation"></a>

Ensure that you have met the requirements, then:

1. Download the latest version of [the Framework][nexus-link].
2. Extract the zip file to your `Mods` folder ([wiki guide][smapi-mod-wiki]).
3. Repeat for each mod you want to use ([mod overviews](#about)).
    - So far, this only includes Climate Control.
4. Install any of [the supported mods](#supported).
5. Launch SMAPI once, to generate each mod's `config.json`.
6. Enjoy the mods!

If you like this mod project, consider leaving a :thumbsup: on the [Nexus][nexus-link]. This makes it easier to find for players like you!

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Config Options-->
## Configuration <a id="config"></a>

*Default values are **shown in bold**.*

This section contains the available configuration options for each mod.
You can change these options in-game using [Generic Mod Config Menu][gmcm-link] or through manually editing the `config.json` contained in each mod's folder (generated after running SMAPI at least once).

### Framework <a id="framework-config"></a>

#### Weather Reports:

Each morning, you can choose to receive a forecast of the weather for today and tomorrow. These options determine whether you receive these messages, and if so, how.

| Name | Value | Description |
|:---|:---|:---|
| **SMAPI Terminal** | ***true**, false* | *If *true*, weather predictions are printed to the SMAPI terminal.* |
| **In-Game HUD** | *true, **false*** | *If *true*, weather predictions are printed using the in-game HUD.* |

### Climate Control <a id="climate-control-config"></a>

#### Weather Models:

The weather model determines the likelihood of weather changes for each day of the year (e.g. the chance of rain, snow, thunderstorms etc.). You can make your own custom model or use one of the provided templates.

| Name | Value | Description |
|:---|:---|:---|
| **Model Choice** | ***standard**, custom* | *Determines the choice of weather model.* |
| **Daily Odds** | ***true**, false* | *If *true*, interpolation will be used to estimate the daily weather odds.* |

<details><summary>Resetting custom models</summary>
<p>

Custom models are preserved when resetting with [Generic Mod Config Menu][gmcm-link]. If you want to reset any changes, you can delete `models/custom.json`. Alternatively, you can copy the *standard* values into the *custom* model by

1. Switching from *standard* to *custom*
2. Opening the values page
3. Clicking "Save" followed by "Save & Close"

</p>
</details>

In addition to selecting one of the model templates above, you can also manually edit the probabilities. If using [Generic Mod Config Menu][gmcm-link], then this can be done via the in-game menu, sorted by weather or by season. Otherwise, this can be done by manually editing the JSON files in the `models` folder.

You may assign any decimal value between 0 and 100 to days 1-9, 10-19 and 20-28 within each season for each type of weather (rain, storm, snow, wind). If interpolation is enabled, these numbers will be held fixed for days 5, 15 and 24 respectively. Otherwise, they will be treated as fixed for the entirety of each time period.

***For the curious:** You can see the effects of changing the settings by looking at the daily weather probabilities in the `data` folder. These will update in real-time when using [Generic Mod Config Menu][gmcm-link].*

#### Debug Logging:

When debug logging is enabled, SMAPI will output the dice rolls and other useful information to the terminal.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Documentation-->
## Documentation <a id="docs"></a>

*This section contains links to the READMEs and other mod documentation.*

- Climate Control ([README][climate-control-readme])

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Known Issues-->
## Known Issues <a id="issues"></a>

*This section contains updates on any known mod issues.*

### Framework

None known.

### Climate Control:

- Due to the way the game currently handles thunderstorms, an existing storm might continue whenever it is supposed to rain tomorrow.
    - The issue will resolve itself at the start of the next sunny/windy day.
	- This issue will be patched in a coming update. 

<!--Storms-to-rain flags not resetting in ClimateControl-->

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Compatibility-->
## Mod Compatibility <a id="compatibility"></a>

*The following is a list of all supported, recommended and incompatible mods.*

<!--Supported-->
### Supported Mods <a id="supported"></a>

The following mods are officially supported by Immersive Weathers. When using these in-game, you will get special functionality.

- **[Generic Mod Config Menu][gmcm-link]** - allows editing of the configuration in-game.
- **[Even Better RNG][even-better-rng-link]** - enables more accurate dice rolls for tomorrow's weather.

<!--Recommended-->
### Recommended Mods <a id="recommended"></a>

The following mods are entirely optional but may enhance your experience. However, you don't need these mods to enjoy Immersive Weathers (I don't use them all myself). Please only install those which sound interesting to you.

- **[Thunder and Frog Sounds][thunder-frog-link]** (requires [Custom Music][custom-music-link]) - for a more relaxing, cozy thunderstorm ambience.
- **[Stardew Survival Project][survival-link]** - if you enjoy survival gameplay and like the idea of micro-managing your farmer's body temperature.

<!--Incompatible-->
### Incompatible Mods <a id="incompatible"></a>

In general, any mod which alters the weather is likely incompatible. Note that [Content Patcher][content-patcher-link] packs which change the appearance of weather *should* still be compatible. Currently, the list of known weather mods and their status includes:

- **[More Rain][more-rain-link]** - *incompatible*. Alters the weather probabilities.
- **[Rain Plus][rain-plus-link]** - *likely incompatible*. Forces rain on certain days of the week.
- **[Winter Rain][winter-rain-link]** - *incompatible*. Changes the winter weather probabilities.
- **[Weather Machine][weather-machine-link] / [Real Weather][real-weather-link]** - *incompatible*. Changes the way weather is calculated and adds new weather types. Use this if you prefer using live weather data rather than generated weather.
- **[Extreme Weather][extreme-weather-link]** - *incompatible*. Hilarious mod. Lol, why would you use these together?
- **[Climates of Ferngill][climates-ferngill-link]** - *use with caution*. No problem yet, but future features will break this. 

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Future Plans-->
## Planned Features <a id="future"></a>

*To suggest/contribute a feature, [see contributions](#contribute). For upcoming releases, [see the latest changelog][framework-changelog].*

This list contains some future ideas for this mod project. Please do not treat this as a guaranteed plan. It's more like a 'personal scratchpad' than a 'roadmap', and is intended primarily as a central source of inspiration.

<details><summary>List of feature ideas</summary>

- [x] Daily weather odds
	- [ ] Add more climate templates
- [ ] Custom weather types
- [ ] Dynamic weather transitions
    - [ ] Varying weather intensities
	- [ ] Early/late (non-sunrise) weather changes (is this even possible?)
- [ ] Custom effects
    - [ ] Dynamic wind directions/intensities
	- [ ] Custom sprites (doable?)
    - [ ] Dynamic daylight (e.g. overcast, partly cloudy)
	- [ ] Audio/ambience?
- [ ] Daylight savings time
    - [ ] Likely conflicts with dynamic nighttime, would need custom implementation
- [ ] Temperature and humidity simulation
    - [ ] Effects on weather odds
	- [ ] Optional gameplay challenges (crops, stamina etc)
- [ ] Realistic/inaccurate weather forecasts
    - [ ] Stochastic variation
	- [ ] Almanac integration
- [ ] Random weather events
    - [ ] Heat waves, frosts, gales, blizzards
	- [ ] Toggleable difficulty modes
	- [ ] In-game mail?

</details>

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Contributing-->
## Contribute to this Project <a id="contribute"></a>

*Please be patient if I haven't responded immediately. I am likely busy with my studies.*

This project is open-source and contributions are welcome, particularly in the form of [bug fixes](#bugs), [feature suggestions](#suggestions) and [translation support](#translations). For more substantial contributions, please fork the develop repo and submit a pull request using the https://github.com/ImaanBontle/SDV-immersive-weathers/labels/contribution label. You can also attempt to contact me via [NexusMods][nexus-profile] or by [opening an issue][issues-link].

<!--Bugs-->
### Bug Fixes/Reports <a id="bugs"></a>

If you encounter any bugs, please first remove any [incompatible mods](#incompatible) and re-run SMAPI to check if the issue resolves itself. If the bug persists or you do not see your mod included in the list, you can [submit a bug report][bugs-link]. You should answer the prompts to the best of your ability and mention any suspected mod conflicts. You will need to provide a link to your [SMAPI log][smapi-log] in the report. If you would like submit a bugfix, you can do so by submitting a pull request using the https://github.com/ImaanBontle/SDV-immersive-weathers/labels/fix and https://github.com/ImaanBontle/SDV-immersive-weathers/labels/contribution labels.

<!--Feature Suggestions-->
### Suggestions <a id="suggestions"></a>

If you would like to suggest a feature for this mod family, please feel free to [submit a feature request][request-features-link]. While I can't guarantee these will be included in future releases, I am open to new ideas and would love to hear from you. You will be credited for suggestions that get implemented in later releases. 

<!--Translations-->
### Translations <a id="translations"></a>

*Translation support will be added in the next minor release. In anticipation, I am adding the following table of translations. Please note that the associated `default.json` files **are currently empty and should be ignored**.*

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

The source code for this mod is available under the [MIT license][license-link].

Please do not host my official releases without my written consent.

<div align="right">

[[Back to top](#return-to-top)]

</div>

<!--Acknowledgements-->
## Special Thanks <a id="acknowledgements"></a>

I'd like to extend a huge thank you to [ConcernedApe][concernedape] for creating this masterpiece. Without your imagination, generosity and dedication, we wouldn't be here. Thank you from the bottom of my heart. You deserve all of your success and more.

I'd additionally like to thank [Pathoschild][pathoschild] for creating SMAPI and for enabling the modding commmunity to thrive. I'd like to thank the modders who collectively contributed to its success, built this community, and created the [amazing resources][stardew-modding-wiki] that showed me how to mod in C#.

I would also like to specifically thank the following individuals:

- [spacechase0][spacechase0] for creating the [Generic Mod Config Menu][gmcm-link] and its API.
- [Pepoluan][Pepoluan] for providing the API for [Even Better RNG][even-better-rng-link].

In closing, I'd like to personally thank all the players who have downloaded and enjoyed my mods. I am eternally grateful for your support. May you have many happy years ahead in the Valley.

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