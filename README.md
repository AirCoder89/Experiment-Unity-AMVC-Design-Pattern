# AMVC for Unity UI Projects

<table>
  <tr>
    <td><img src="https://github.com/user-attachments/assets/628d98c6-0224-48a2-b3e3-321b5f48e681" alt="InspectMe Logo" width="100"></td>
    <td>
      🛠️ Boost your Unity workflows with <a href="https://divinitycodes.de/">InspectMe</a>! Our tool simplifies debugging with an intuitive tree view. Check it out! 👉 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-lite-advanced-debugging-code-clarity-283366">InspectMe Lite</a> - 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-pro-advanced-debugging-code-clarity-256329">InspectMe Pro</a>
    </td>
  </tr>
</table>

---

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

---

<table>
  <tr>
    <td><img src="https://github.com/user-attachments/assets/628d98c6-0224-48a2-b3e3-321b5f48e681" alt="InspectMe Logo" width="100"></td>
    <td>
      🛠️ Boost your Unity workflows with <a href="https://divinitycodes.de/">InspectMe</a>! Our tool simplifies debugging with an intuitive tree view. Check it out! 👉 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-lite-advanced-debugging-code-clarity-283366">InspectMe Lite</a> - 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-pro-advanced-debugging-code-clarity-256329">InspectMe Pro</a>
    </td>
  </tr>
</table>
