**Project Outline**
 
The project is an application available for Windows and Android that focuses on the realistic visualisation of the chemical processes, Single Stage Distillation. The visualisation is enhanced by graphical representations and supported by textual descriptions. The main motive of the project is to help the user visualise this process and at the same time give the user in-depth information about the execution of the process including the activities that happen at the back end give the user a good learning experience.

**Installation and Configuration**

- **Window** 
Download the zip file from the link. The .exe file will be available in the extract which can be double clicked to start the application. 
- **Android** 
Download the apk file from the link and installed on the mobile device. 

**Tool Suite**

- **Unity and C#:** The application was developed using Unity3D version 2019.3.12. Unity 3D is a cross platform game engine, such that we have support for both Windows and Android. For scripting we used C#. We maintained code under version C# 5.0 and .NET Framework 4.5.
- **Blender:** We used Blender 2.8 to model the entire apparatus. We could export the model to .fbx format which is the native format used in Unity3D.

**Pattern**

Unity is based on the Entity Component System(ECS) pattern. Entity refers to an object, component refers to the data and system refers to the part performing global actions on the object. We followed this pattern partially in combination with the Decorator pattern and Singleton pattern. 

**Add another process**

- Place the new model in the _LAB_ scene
- Place a button _START_ at the bottom of the model
- Add the function 
- The new scene would be started on pressing press and has no other dependencies. The scene could be designed anyway. 