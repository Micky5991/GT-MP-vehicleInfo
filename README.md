# vehicleInfo.json - Vehicle Information Library V1.1.0
This ScriptHookV.NET3 script is intended to generate information about all vehicles available in GTA V. 

## Usecases
* Validate information about vehiclemods or -liveries serverside
* Provide only available mods to the player while modding the vehicle
* Use original Mod/Livery-Names from GTA V
* Determine electric vehicles from this library

**And many more!**

## Provided information
```
==> PER VEHICLE
- Hash (uint)
- ID (string)
- Display name (string)
- Localized name (string) [only full version]
- Manufacturer display name (string) 
- Localizedmanufacturer name (string) [only full version]
​- Vehicle class (integer)
​- Vehicle class display name (string)
​- Localized vehicle class name (string) [only full version]
​
- Is convertible? (bool)
- Is electric? (bool)
​- Is trailer? (bool)​
​- Has neon? (bool) [New in 1.1.0]​
​
​- Rewards on enter: (string[]) [New in 1.1.0]
​- Available mods: (object[integer]​​)
​    ==> PER MODDABLE SLOT:
​    - Amount of mods in this slot (integer)
​    - list of available mods (object[integer])
​        ==> PER MOD
​        - Display name (string)
​        - Localized name (string) [only full version]
​        - Flags (string[]) [eg: for wheels: "chrome", "stock"]
​
​- Available liveries (object)
​    - Amount of available liveries (integer)
​    - list of available liveries (object[integer])
​        ==> PER LIVERY
​        - ID of the livery (integer)
​        - Display name (string)
​        - Localized name (string) [only full version]
```

## Precreated files
### Smaller files

Description | Last updated | Download | Filesize
--- | --- | --- | ---:
Without localization* | 7th July 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.1.0/vehicleInfo.noloc.json) | 2.3 MB
Without listing** | 7th July 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.1.0/vehicleInfo.nolist.json) | 204 KB

*This version can be used if you want to create your own gametexts with `API.getGameText(string name);` [GT-MP Wiki entry](https://wiki.gt-mp.net/index.php?title=GetGameText)

**This version only contains the amount of possibilities. Smallest size possible

### Full information (Including localized names)

Language | Last updated | Download | Filesize
--- | --- | --- | ---:
English | 7th July 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.1.0/vehicleInfo-en.full.json) | 3.9 MB
German | 7th July 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.1.0/vehicleInfo-de.full.json) | 4.0 MB

If you want to look into the structure of this file, we also have an indented version:

**DO NOT USE THIS IN AN PRODUCTIVE ENVIRONMENT!**
[Download (8.4MB)](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.1.0/vehicleInfo.ind.json)

## Installation
### Requirements
- [ScriptHookV](http://www.dev-c.com/gtav/scripthookv/)
- [ScriptHookV.NET 3](https://github.com/crosire/scripthookvdotnet)

_todo_

## Known issues
* In the non-/localized versions are some horn-information missing. This will be fixed, when i find the right display name.
* Not-moddable vehicles have sometimes missing display/localization names. This is not fixable

## Thanks to
[SyBozz](https://gt-mp.net/user/2198-sybozz/) for assisting me and collecting some further information

