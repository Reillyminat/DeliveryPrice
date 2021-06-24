use DeliveryService
--1a
INSERT INTO Users VALUES 
('г. Новомосковск, ул. Техникумовская, д. 5б', 'Мищенко Сергей Иванович',+380975315200),
('г. Днепр, ул. Тарасова, д. 7, кв. 9', 'Треньков Вячеслав Данилович',+380671827384),
('г. Киев, ул. Славянская, д. 56, кв. 12', 'Таращев Юрий Васильевич',+380669019234),
('г. Новомосковск, ул. Северная, д. 28, кв. 16', 'Нуров Александр Александрович',+380974536172),
('г. Днепр, ул. Советская, д. 6, кв. 17', 'Роева Надежда Владимировна',+380509090101),
('г. Харьков, ул. Громовая, д. 29, кв 19', 'Сивич Андрей Николаевич',+380783423231);
--1b
INSERT INTO ProductsTypes (Type) VALUES 
('Washer'),
('Refrigerator'),
('Kirchen stove'),
('Air conditioner'),
('Vacuum cleaner');
--1c
SELECT * INTO UsersCache FROM Users;
--1c alt
INSERT INTO ProductsTypesNew (Type,ScopeOfApplication)
SELECT Type, ScopeOfApplication FROM ProductsTypes;
--2a
UPDATE ProductsTypes SET Type='Washer machine' WHERE Type='Washer';
--2b
UPDATE Orders SET BuyingDate=DATEADD(hour,1,BuyingDate) WHERE BuyingDate='2020-12-23 13:41:25.2756145';
--2c
UPDATE PT
SET 
PT.ScopeOfApplication=PTN.ScopeOfApplication
FROM ProductsTypes PT JOIN
ProductsTypesNew PTN
ON PT.ProductTypeId=PTN.ProductTypeId
WHERE PTN.ScopeOfApplication='home';