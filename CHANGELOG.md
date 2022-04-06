
# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/), and will follow [Semantic Versioning](https://semver.org/).

## [1.1.3] - Apr 5 2022

### Changed
 - Only check top level directory for logical saves

### Bug fixes
 - Snapshots could not be created from any save file not named "new\_snapshot" [#5](https://github.com/Museus/TunicSaveManager/issues/5)

#
## [1.1.2] - Apr 5 2022

### Bug fixes
 - Snapshot stopped working due to logical save implementation. Now deletes all logical saves for snapshot when loading. [#3](https://github.com/Museus/TunicSaveManager/issues/3)

## [1.1.1] - Mar 21 2022

### Bug fixes

 - Snapshot would be created from previous save when changing files due to timing issues on Player.log updates. [#1](https://github.com/Museus/TunicSaveManager/issues/1)


## [1.1.0] - Mar 20 2022

### New Features

- Can now create snapshots from most recently loaded save.

## [1.0.0] - Mar 19 2022

Initial release of the Save Manager. Was distributed offline, no Github for it.

### Missing Features

- Snapshots must be manually created
