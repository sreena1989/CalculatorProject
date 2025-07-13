# CalculatorProject
Unity project with  Mobile and VR Calculator 

# Unity Calculator Project

This project contains two Unity Scenes:
- **XRCalculatorScene** (for Meta Quest)
- **AndroidCalculatorScene** (for Android phones)

## APK Builds
You can find the final APKs in the FinalBuilds/ folder.

- CalculatorVR.apk — Tested with Unity XR Device Simulator in editor
- CalculatorMobile.apk — Touch input supported

## Unity Version
- Unity 2022.3.62f1.

## Input System
- Unity New Input System  

## Build Process
For Android, Under XR PlugIn Management Tool (Project Setting)
- Disable the  initialise  XR on startup option for both desktop and android 
- Disable OpenXR under plugin provider
- Select AndroidCalculatorScene in build setting and deactivate the other one

For Meta Quest Under XR PlugIn Management Tool (Project Setting)
- Enable the  initialise  XR on startup option for both desktop and android
- Enable the OpenXR plugin provider
- Select XRCalculatorScene in build setting and deactivate the other one


Please contact me if you encounter any installation issues.
