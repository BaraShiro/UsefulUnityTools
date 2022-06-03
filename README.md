# UsefulUnityTools

A collection of useful utilities, tools, and extensions. Intended to be added to new projects.

Example scenes showing the loading scene, enforce aspect ratio, and FPS counter are included.

## Usage

### LoadingScene

Calling `LoadingSceneController.LoadScene(scene)` loads the scene `scene` via the loading screen.
The script does not need to be attached to a GameObject, and no special GameObject needs to be present in the current scene, or the scene to be loaded.  
However the scene `Loading` needs to be added to the build settings.

### EnforceAspectRatio

If attached to a camera it enforces an aspect ratio of `widthUnits:heightUnits` on that camera. Can be turned off  by setting `enforce` to `false`.

Four common presets are included:
- 16:9
- 9:16
- 4:3
- 3:4

### FPSDisplay
Can be added to a canvas to show an FPS counter in the top left corner.

### SelectionHelpers

Adds the following keyboard shortcuts:
- `ctrl + q` select nothing

### Tools

`MainCamera`
Handy shortcut to Camera.Main.

`GetWaitForSeconds(time)`
Uses a dictionary to cache and retrieve `WaitForSeconds` yield instructions.

`GetWorldPositionOfCanvasElement(element)`
Translates a position on a canvas to a position in world space.

`ClampAngle(angle, min, max)`
Normalizes an angle to a range from -180 to 180 and clamps it between min and max.

`NormalizeAngle(angle)`
Normalizes an angle to a range from 0 to 360.

### Extensions

`List<T>.Shuffle()`
Performs a Fisher–Yates shuffle on the list.

`GameObject.DeleteChildren()`
Calls `Destroy()` on all the child objects of the GameObject.

`Quaternion.ZeroOutXZ()`
Sets the rotation on the X and Z axis to zero. If called every frame it effectively freezes rotation on those axes.

`LayerMask.Contains(layer)`
Returns `true` if the layer mask contains the provided layer, else returns `false`.

