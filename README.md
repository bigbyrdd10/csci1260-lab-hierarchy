# csci1260-lab-hierarchy


Name: Jackson Byrd
Section: CSCI 1260-002
Track: A - The Shop

How to Run

Open the project folder and run:

dotnet run

 Design Question 1
PhysicalGood should be an abstract class since it is not a complete item type. It has common properties like the weight and delivery price, but it is unaware of the category it belongs to and its handling cost. This is defined by its subclasses such as PerishableGood and DurableGood. In case PhysicalGood is made into a concrete class, then one can create an instance of an object that does not belong to any category of inventory. This will result in an unorganized design and may generate improperly functioning objects.

Design Question 2
Shop and StockItem have aggregation relationship indicated by the hollow diamond. StockItem objects are created by Program and then handed over to Shop through Add method. Since these objects can survive even without Shop, their lifecycles are independent. StockItem and StockMovement have composition relationship which is indicated by the filled diamond. StockItem creates StockMovement objects within itself in Receive and Release methods and these movement records only exist for that particular StockItem object. When StockItem object is deleted, these movement records get deleted along with it. If Shop was responsible for creating item objects themselves, then the aggregation relationship would have been much stronger as Shop would have control over creation of these records. It would be wrong as it will decrease flexibility and increase responsibility of Shop.

Design Question 3
For adding a rental item, I would create a new class RentalItem.cs and inherit it from PhysicalGood and implement IDiscountable. I don’t think there will be any changes in Shop.cs since Shop is already using the concept of inheritance and polymorphism and is working with the StockItem object. The newly created class can be used without making any other changes to the design. Perhaps, I might modify Program.cs to create and test new items. However, all other parts of design remain unchanged. Had the property IsOnSale been a part of the StockItem instead of being in the interface IDiscountable, each type of item will have to implement the sale operation despite the fact that it may not be necessary.
