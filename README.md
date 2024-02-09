# AMVC for Unity UI Projects

This sample project demonstrates the AMVC architecture for Unity UI projects. The project is composed of two scenes:

1. **Loading Scene**: Incorporates a flexible loading system based on the Command Design Pattern. The DataBaseManager integrates the [Rest Client for Unity](https://assetstore.unity.com/packages/tools/network/rest-client-for-unity-102501) plugin with the AMVC architecture.
2. **Main Scene**: Demonstrates communication between Controllers (Systems) and Views (Panels) using the API result.

All UI Panels are canvases to prevent mesh regeneration during UI changes. [Learn More](https://unity3d.com/how-to/unity-ui-optimization-tips?_ga=2.201878425.948249629.1611743546-219693309.1579194164)

The Application Model View Controller (AMVC) manages dependencies by splitting the software into four parts:

- Single entry point "**Application**": Manages critical instances and application-related data.
- **Models**: Handle data CRUD operations.
- **Views**: Represent UI Panels.
- **Controllers**: Operate as application systems.

AMVC Structure:
![Amvc](https://user-images.githubusercontent.com/62396712/105978631-0da04b80-6093-11eb-8285-fa04ec5674d1.png)

Access panels and systems from anywhere with **GetPanel<T<T>>** and **GetSystem<T<T>>** respectively.
![Get](https://user-images.githubusercontent.com/62396712/105911178-33ddd100-602a-11eb-8a13-20480f633b11.png)
