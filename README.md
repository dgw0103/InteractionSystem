[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

<b>TODO</b>
<br>글로벌 데이터들 에디터 창에서 수정할 수 있는 기능 만들기.
<br>DetailedExamining 입력 부분 캡슐화

# Interaction system
Help that user can directly make objects to interact with player. Also, some samples using interaction system is included.<br><br>
![image](https://github.com/dgw0103/InteractionSystem/assets/68366554/8abe997a-3efd-46a5-ad00-ce9ad5bc6000)<br><br>

## The things you can do with this module is following...<br>
><b>1. Create Interaction object.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/dba2dbc0-3790-4242-8c86-b34d4c0b0232" width="485" height="300"/><br><br>
><b>2. Can use the UI's 'Navigation' function to non-UI GameObject.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/b0e33ac7-a8ab-4dbc-abf2-66e2fa0e5907" width="485" height="300"/><br>

## <br>Samples using interaction system is following...<br>
><b>1. Look at closer a object by interaction.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/a36b3258-d57c-465d-ac7a-5b4c742909dc" width="485" height="300"/><br><br>
><b>2. Rotate or zoom in/out the object after you interact by the function at '2.'.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/1b4cc7d5-f753-4175-a2b6-6f50ad7bce9d" width="485" height="300"/><br><br>
><b>3. Move camera to the position you want.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/f04bbfca-d136-4a6e-8cf4-770435b78476" width="485" height="300"/><br><br>

# Apply this package to your unity project
1. Copy this url.
2. Open the Package Manager window in Unity.
3. Click plus icon in left up.
4. Paste git url
5. Download and import.

# Make custom interaction object
## Simple interactable object
1. Create a script as component for interaction object that you want to make.
2. The script inherits from the 'InteractionObject'.
3. Implement abstract functions.
4. Add the component to GameObject to use.
5. If you want to get the GameObject light emission when the interactor is close with interaction object enough to interact, add the 'LightEmission' component too.

## Create the '~Data'
This is ScriptableObject type object. You can create this by right-click in the Project window. (It is at upside.)

# About the 'Selector'.
You can want to focus a GameObject by interaction such as [Samples using interaction system is following...](#TODO).The case you want to interact again to another after interact a GameObject can be occurred.

# License
MIT License

Copyright (c) 2023 dgw0103

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
