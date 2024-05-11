# Match3-Unity-Game Project Evaluation

## Advantages:
+ The project is very code driven, making it easier to resolve merge conflicts.
+ Button events are handled in code, making it easier to debug, find reference and resolve merge conflict.
+ The original project stored most of the path in one script (Constants), making it easier to modify path and find references.
+ Menu items use interface for an additional layer of abstraction.

## Disadvantages & Recommendations:
+ The project uses a lot of casting which can be prone to error, making it harder for new developers to join in the project and be familiar with the code base.
=> The project can reduce type conversions and castings by implement more generic classes and methods.

+ For a project that uses a lot of Resources.Load() to swap texture, it is better to organize the assets following some rules or patterns, e.g. bonus_1, bonus_2, bonus_3
=> This helps with proper texture loading using IDs.

+ The project did not implement enough caching method.
=> Expensive methods like GetComponent can be cached to reduce the amount of garbage created, one time use function such as getting the prefab from Resources.Load() can also be used to reduce GC.

+ The project has inconsistant naming style.
=> Might cause confusion and making it harder for other developers to join in the project.

+ The project had inconsistant null check which can cause NullReferenceException.

+ The project did not follow DRY principle, e.g. setting sorting layer higher and lower, and clearing cell and exploding cell 
=> DRY principle can helps the developers to modify changes quickly.

+ The project does not make use of asset driven principle in Unity.
=> Should implement more asset driven methods, such as exposing data and configs to the inspector, making it easier for other department such as game designers and vfx artists to test and modify. This may also help with the debugging process.

+ UIs are scene objects and not prefabs. This can make resolving conflicts harder to retrive, espcially when multiple people are modifying scene objects.
=> UIs should be turned into prefab so that changing the UIs does not cause scene conflicts. Also, this enable easy loading UIs only when needed, improving the performance of the game.

+ There was no object pooling system.
=> Object pooling system should be implemented to reduce garbage collection.

+ The code though easy to read, can be a pain to expand and maintain because of extensive uses of switch case, such as when the project was getting the item prefab by checking the enum type and getting different path for each types.
=> Should implement more abstraction and generic method, such as an id loading method (implemented in code).
