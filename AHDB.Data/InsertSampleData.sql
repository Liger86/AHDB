--Insert random data
Declare @Id int
Set @Id = 1

While(@Id <= 10)
Begin
	insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime)
	values ('Description - ' + cast(@Id as nvarchar(20)), 'Company - ' + CAST(@Id as nvarchar(20)), GETUTCDATE())

	Print @Id
	Set @Id = @Id + 1
End
GO

--Select Statements
select * from Customer

--Paging
Declare 
@PageNumber int = 1,
@RowsPerPage int = 5

Select ID, [Description], PurchaseOrder, QuoteNumber, Completed, DateCreatedAsUtcTime, DateCompleted
from Repair
order by ID
offset (@pagenumber-1)*@RowsPerPage Rows
Fetch next @RowsPerPage Rows Only
Go

--Delete stuff

delete from Customer