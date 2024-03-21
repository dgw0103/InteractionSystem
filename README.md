[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# Interaction system
Help that user can directly make objects to interact with player. Some basic things and examples are included.

- [How to use](#how-to-use)
  - [Make any interaction object](#make-any-interaction-object)
- [Install](#install)
  - [via Git URL](#via-git-url)
- [License](#license)

## How to use
![Whole structure](https://private-user-images.githubusercontent.com/68366554/315544757-9122ca42-4959-4d57-91be-0a3f69dd6665.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTEwMzk4MzEsIm5iZiI6MTcxMTAzOTUzMSwicGF0aCI6Ii82ODM2NjU1NC8zMTU1NDQ3NTctOTEyMmNhNDItNDk1OS00ZDU3LTkxYmUtMGEzZjY5ZGQ2NjY1LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAzMjElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMzIxVDE2NDUzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTgwOTk4ODI3OTIxYjVkOTE5OTBjN2JkMWIyZTMwNmI1OWY4Yzk3ZGFhZTJiNGViY2Y5OWQxNDAzMGZjMjg4OGImWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.6i1UEpJF35lYKmoydeVyGI19IFgmb05BzjRhn4Hy4qM)
This is whole structure.<br>
Contents inside of Main are objects that are made from the Unity project. It means that this package don't include those.

### Get starting

### Make any interaction object
1. Create a script for interaction object that you want to make.
2. The script inherits from the 'InteractionObject'.
3. Implement abstract functions.

## Install
### via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
    "com.dgw0103.interactionsystem": "https://github.com/dgw0103/interactionsystem.git"
  }
}
```

## License

MIT License

Copyright © 2023 dgw0103
