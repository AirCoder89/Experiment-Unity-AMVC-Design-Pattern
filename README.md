# AMVC for UI Unity projects

The best architecture to create Unity project based on Canvas and is flexible enough to be implemented even on top of ECS or OOP. 


This is a sample project I have made to demonstrate the AMVC architecture. It consists of two scene: 

1.  **Loading Scene** : when we send few requests to fill our models with the necessary data. The loading system based on **Command Design Pattern** to make it flexible when we need to reload or skip some thing or even to handle errors more efficiently. and the DataBaseManager is a helper class I made it on top of [Rest Client for Unity](https://assetstore.unity.com/packages/tools/network/rest-client-for-unity-102501) plugin.
2. **Main Scene** : I consume the Api result with two different ways to explain how the Controller (Systems) and Views (Panels) are communicate.

Also you will notice that all my UI Panels are canvases. and the reason to use multiple canvases is to avoid regenerates the meshes when UI elements change. [Read More about it](https://unity3d.com/how-to/unity-ui-optimization-tips?_ga=2.201878425.948249629.1611743546-219693309.1579194164)

The Application Model View Controller (**AMVC**) solve any dependencies issues by splits the software into :

- Single entry point "**Application**" : contains and manage all critical instances and application-related data.
- Three major components: 

1.  Models : Data CRUD.
2. Views : UI Panels (Canvas Component).
3. Controllers : Application systems.

![Amvc](https://user-images.githubusercontent.com/62396712/105978631-0da04b80-6093-11eb-8285-fa04ec5674d1.png)

### Single Entry Point

![entryPt](https://user-images.githubusercontent.com/62396712/105978435-d5007200-6092-11eb-80a5-85a82338aa8c.png)

### Dependencies
we can get access to any panel/system from anywhere! with **GetPanel<T<T>>** and **GetSystem<T<T>>** we can get a reference easily.

![Get](https://user-images.githubusercontent.com/62396712/105911178-33ddd100-602a-11eb-8a13-20480f633b11.png)
