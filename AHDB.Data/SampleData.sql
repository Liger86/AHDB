insert into Customers (CompanyName) values ('Some Company 1')
insert into Customers (CompanyName) values ('Some Company 2')
insert into Customers (CompanyName) values ('Some Company 3')
insert into Customers (CompanyName) values ('Some Company 4')
insert into Customers (CompanyName) values ('Some Company 5')

insert into Repairs ([Description], CustomerId) values ('Some description 1', 1)
insert into Repairs ([Description], CustomerId) values ('Some description 2', 1)
insert into Repairs ([Description], CustomerId) values ('Some description 3', 1)
insert into Repairs ([Description], CustomerId) values ('Some description 4', 1)

insert into Repairs ([Description], CustomerId) values ('Some description 5', 2)
insert into Repairs ([Description], CustomerId) values ('Some description 6', 2)
insert into Repairs ([Description], CustomerId) values ('Some description 7', 2)
insert into Repairs ([Description], CustomerId) values ('Some description 8', 2)

select * from Customers
select * from Repairs

select * from Repairs
where CustomerId = 1