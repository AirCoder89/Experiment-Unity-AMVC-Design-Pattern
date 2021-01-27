# AMVC for UI Unity projects

The best architecture to create Unity project based on Canvas and is flexible enough to be implemented even on top of ECS or OOP. 

The Application Model View Controller (**AMVC**) solve any dependencies issues by splits the software into :

- Single entry point "**Application**" : contains and manage all critical instances and application-related data.
- Three major components: 

1.  Models : Data CRUD.
2. Views : UI Panels (Canvas Component).
3. Controllers : Application systems.

![Amvc](https://user-images.githubusercontent.com/62396712/105978387-c44ffc00-6092-11eb-8b35-88cac0d0dcf1.png)

### Single Entry Point

![entryPt](https://user-images.githubusercontent.com/62396712/105978435-d5007200-6092-11eb-80a5-85a82338aa8c.png)

### Dependencies
we can get access to any panel/system from anywhere! with **GetPanel<T<T>>** and **GetSystem<T<T>>** we can get a reference easily.

![Get](https://user-images.githubusercontent.com/62396712/105911178-33ddd100-602a-11eb-8a13-20480f633b11.png)
