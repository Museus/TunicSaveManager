# TunicSaveManager
Unofficial Save Manager for the video game TUNIC

# Description

The TunicSaveManager tool is used to import and export saves for TUNIC. You can
use it to create snapshots of your run at various stages, and reload those
snapshots at any time.

# Installation

The TunicSaveManager is a portable executable, which means it does not require
direct installation on your PC. However, it does require the .NET Framework.
When you first try to run the SaveManager, your PC wil prompt you to install
.NET, if necessary.

# Usage

The Save Manger is a single window, with inputs for:
 - Save Folder: The location of your save folder on your PC. By default,
this is `C:\Users\<username>\AppData\LocalLow\Andrew Shouldice\Secret Legend\SAVES`

 - Snapshot Folder: The location you want to save your snapshots

Once you fill in the above information, you can type a snapshot name, and click
Create. This will create a file with the .sav extension in the `Snapshot Folder` you
provided.

To load a snapshot, use the dropdown to select the snapshot and then click
Load. This will create a new save file in TUNIC, with your snapshot data in it.

# License

Distributed under the MIT License. See LICENSE for more information.

# Contact

Museus [Twitch](https://twitch.tv/Museus7) [Email](museus@protonmail.com)