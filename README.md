# vehicleInfo.json - Vehicle Information Library V1.2.0
This ScriptHookV.NET3 script is intended to generate information about all vehicles available in GTA V. 

## Usecases
* Validate information about vehiclemods or -liveries serverside
* Provide only available mods to the player while modding the vehicle
* Use original Mod/Livery-Names from GTA V
* Determine electric vehicles from this library
* Calculate sizes of vehicles

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

- Vehicle dimensions: [New in 1.2.0]
    - Minimum (Vector3) 
    - Maximum (Vector3)
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

## Changelogs
### V 1.2.0

* Added .ZIP option with all vehicles in seperate files. *(<intHash>.json)*
* Added dimensions to general information *(min-, max-Vector3)*

## Precreated files
### Smaller files

Description | Last updated | Download | Filesize
--- | --- | --- | ---:
Without localization* | 10th July 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo.noloc.json) | 2.3 MB
Without listing** | 10th July 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo.nolist.json) | 204 KB

*This version can be used if you want to create your own gametexts with `API.getGameText(string name);` [GT-MP Wiki entry](https://wiki.gt-mp.net/index.php?title=GetGameText)

**This version only contains the amount of possibilities. Smallest size possible

### Full information (Including localized names)

Language | Last updated | Single file | Multiple files
--- | --- | --- | ---:
English | 10th July 2017 | [JSON (3.9 MB)](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo-en.full.json) | [ZIP (690 KB)](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo-en.zip)
German | 10th July 2017 | [JSON (4.0 MB)](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo-de.full.json) | [ZIP (718 KB)](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo-de.zip)

If you want to look into the structure of this file, we also have an indented version:

**DO NOT USE THIS IN AN PRODUCTIVE ENVIRONMENT!**
[Download (8.2MB)](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.2.0/vehicleInfo.ind.json)

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

