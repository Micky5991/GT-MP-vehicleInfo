# vehicleInfo.json - Vehicle Information Library V1.4.1
This ScriptHookV.NET3 script is intended to generate information about all vehicles available in GTA V. 

## Usecases
* Validate information about vehiclemods or -liveries serverside
* Provide only available mods to the player while modding the vehicle
* Use original Mod/Livery-Names from GTA V
* Determine electric vehicles from this library
* Calculate sizes of vehicles
* Get a list of all bones of a vehicle

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
​- Vehicle wheel type (integer) [New in 1.4.0]
​- Vehicle wheel type name (string) [New in 1.4.0]
​- Localized vehicle wheel type (string) [New in 1.4.0] [only full version]
​
- Is convertible? (bool)
- Is electric? (bool)
​- Is trailer? (bool)​
​- Has neon? (bool) [New in 1.1.0]​

- Vehicle dimensions: [New in 1.2.0]
    - Minimum (Vector3) 
    - Maximum (Vector3)
    
- Vehicle bones -> boneName:boneIndex (Dictionary<string, int>) [New in 1.3.0]

- Maximum vehicle speed (float) [New in 1.3.0]
- Maximum vehicle braking (float) [New in 1.3.0]
- Maximum vehicle traction (float) [New in 1.3.0]
- Vehicle Acceleration (float) [New in 1.3.0]
- _0xBFBA3BA79CFF7EBF (float) [New in 1.3.0]
- _0x53409B5163D5B846 (float) [New in 1.3.0]
- _0xC6AD107DDC9054CC (float) [New in 1.3.0]
- _0x5AA3F878A178C4FC (float) [New in 1.3.0]
- Maximum number of passengers (integer) [New in 1.3.0]
- Maximum number of occupants (integer) [New in 1.3.0]
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
### V 1.4.1
* Increase mod-range to suppot more mod-slots

### V 1.4.0
* Added wheel types and names

### V 1.3.1
* Added lights and turbo

### V 1.3.0
* Added vehiclebones and boneindex.
* Added missing values from vehicleData.json

### V 1.2.1
* Fixed .ZIP-creation
* Fixed neon-property - *It should give the right value now*

### V 1.2.0
* Added .ZIP option with all vehicles in seperate files. *(<intHash>.json)*
* Added dimensions to general information *(min-, max-Vector3)*

## Precreated files
### Smaller files

Description | Last updated | Download
--- | --- | ---
Without localization* | 30th December 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo.noloc.json)
Without listing** | 30th December 2017 | [Click here](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo.nolist.json)

*This version can be used if you want to create your own gametexts with `API.getGameText(string name);` [GT-MP Wiki entry](https://wiki.gt-mp.net/index.php?title=GetGameText)

**This version only contains the amount of possibilities. Smallest size possible

### Full information (Including localized names)

Language | Last updated | Single file | Multiple files
--- | --- | --- | ---:
English | 30th December 2017 | [JSON](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo-en.full.json) | [ZIP](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo-en.zip)
German | 30th December 2017 | [JSON](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo-de.full.json) | [ZIP](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo-de.zip)
French | 21st August 2017 | [JSON](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.0-sr/vehicleInfo-fr.full.json) | [ZIP](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.0-sr/vehicleInfo-fr.zip)

If you want to look into the structure of this file, we also have an indented version:

**DO NOT USE THIS IN AN PRODUCTIVE ENVIRONMENT!**
[Download](https://github.com/Micky5991/GT-MP-vehicleInfo/releases/download/V1.4.1-dh/vehicleInfo.ind.json)

## Installation
### Requirements
- [ScriptHookV](http://www.dev-c.com/gtav/scripthookv/)
- [ScriptHookV.NET 3](https://github.com/crosire/scripthookvdotnet)

_todo_

## Known issues
* In the non-/localized versions are some horn-information missing. This will be fixed, when i find the right display name.
* Not-moddable vehicles have sometimes missing display/localization names. This is not fixable
* Some mod slots contain some mods, but they don't have a title. This is not fixable

## Thanks to
[SyBozz](https://gt-mp.net/user/2198-sybozz/) for assisting me and collecting some further information

