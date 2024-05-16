USE PizzaStoreDB;

-- inserting pizza
insert into dbo.pizzas ([PizzaName], [PizzaDescription], [AvailabilityStatus], [StockCount])
values
    ('Margherita', 'Classic Italian pizza', 'true', 20),
    ('Pepperoni', 'Traditional pepperoni pizza', 'false', 0),
    ('Vegetarian', 'Pizza with assorted vegetables', 'true', 18),
    ('Hawaiian', 'Pizza with ham and pineapple', 'true', 12),
    ('BBQ Chicken', 'Pizza with barbecue chicken', 'false', 0);
