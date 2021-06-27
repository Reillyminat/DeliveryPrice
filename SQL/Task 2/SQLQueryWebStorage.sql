use DeliveryService
--1a
INSERT INTO Users VALUES 
('�. ������������, ��. ��������������, �. 5�', '������� ������ ��������',+380975315200),
('�. �����, ��. ��������, �. 7, ��. 9', '�������� �������� ���������',+380671827384),
('�. ����, ��. ����������, �. 56, ��. 12', '������� ���� ����������',+380669019234),
('�. ������������, ��. ��������, �. 28, ��. 16', '����� ��������� �������������',+380974536172),
('�. �����, ��. ���������, �. 6, ��. 17', '����� ������� ������������',+380509090101),
('�. �������, ��. ��������, �. 29, �� 19', '����� ������ ����������',+380783423231);
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