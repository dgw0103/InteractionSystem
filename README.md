[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# Interaction system
It helps player be able to interact other object. Also, some samples using interaction system is included.<br><br>

## The things you can do with this module is following...<br>
><b>1. It can create Interaction object.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/dba2dbc0-3790-4242-8c86-b34d4c0b0232" width="485" height="300"/><br><br>
><b>2. It can pick up interaction object. And then, can rotate and zoom in/out that.</b>
><img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/a36b3258-d57c-465d-ac7a-5b4c742909dc" width="485" height="300"/><br><br>
><img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/1b4cc7d5-f753-4175-a2b6-6f50ad7bce9d" width="485" height="300"/><br><br>
><b>3. Can use the UI's 'Navigation' function to non-UI GameObject.</b><br>
<img src="https://github.com/dgw0103/InteractionSystem/assets/68366554/b0e33ac7-a8ab-4dbc-abf2-66e2fa0e5907" width="485" height="300"/><br>

## Apply this package to your unity project
1. Copy this url. (https://github.com/dgw0103/InteractionSystem.git)
2. In Unity, open the Package Manager window.
3. Click plus icon in left up.
4. Paste coiped.
5. Download and import.

## Tutorial
This tutorial can help you use this system.

### Generate global data for interaction system
To use this system, it must generate global data object. It is a gameObject with singleton component.<br>
1. In hierarchy window -> right click -> click the 'Interaction system global data prefab'.
2. A prefab is generated inside current scene and under the Assets folder.
3. Set values in the prefab's fields.

### Make interactor
1. Add an 'Interctor' component to gameObject that will use as player's eyes. (In case of FPS, the gameObject is maybe main camera.)
2. And then, set the 'Ray shooter' field to the player's eyes gameObject. (Actually, the 'Interactor' component doesn't necessarily have to add to player's eyes object. But, the 'Ray shooter' must be player's eyes.)

### Make interaction object
1. Create a script and inherited from 'InteractionObject'.
2. Implement abstract functions.
3. Add the component to gameObject to use.
4. Add any collider component.
5. Set layer of the gameObject as same with Interaction system data/Interaction layer mask of Interaction system global data.
6. If you want to use the 'Light emission' function(like example above), add 'LightEmissoin' component.
7. 'Light emission data' field is for scriptable object asset and can generate at Project window -> right click -> Interaction system -> Targeting -> Light emission data.

### Make selector
Selector is a component for interacting object that is inherited from 'Selection' class.<br>
1. Add component to gameObject that added 'Interactor' component.

### Make examination object
1. Add a 'Examination' component at the 'Interaction object'.
2. 'Selector.Select' function needs a 'Selection' type parameter. And the 'Examination' type is 'Selection' type.
I intend that you call the 'Selector.Select' from abstract functions of 'InteractionObject'.

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
