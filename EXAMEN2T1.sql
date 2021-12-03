use WideWorldImporters
go

Select * from Sales.OrderLines ol order by OrderID
go

-- Primer ejercicio
create procedure ProductosVendidos
@anio int
as
Select distinct si.StockItemID, si.StockItemName, sum(ol.Quantity) as [Cantidad Vendida] from Sales.OrderLines ol
inner join Warehouse.StockItems si on si.StockItemID = ol.StockItemID
inner join Sales.Orders o on o.OrderID = ol.OrderID
where YEAR(o.OrderDate) = @anio
group by si.StockItemID, si.StockItemName
order by si.StockItemID
GO

-- Segundo ejercicio
ALTER PROC sp_top3Productos @Anio int, @mes int
as
Select top 3 b.StockItemID, b.StockItemName, b.[Cantidad Vendida] from(
Select distinct si.StockItemID, si.StockItemName, sum(ol.Quantity) as [Cantidad Vendida] from Sales.OrderLines ol
inner join Warehouse.StockItems si on si.StockItemID = ol.StockItemID
inner join Sales.Orders o on o.OrderID = ol.OrderID
where YEAR(o.OrderDate) = @Anio and MONTH(o.OrderDate) = @mes
group by si.StockItemID, si.StockItemName
) b
order by b.[Cantidad Vendida] desc

exec sp_top3Productos 2013, 12

-- Ejercicio 3
Select top 3 * from (
Select p.PackageTypeID, p.PackageTypeName, count(ol.PackageTypeID) as Cantidad from Sales.OrderLines ol
inner join Warehouse.PackageTypes p on p.PackageTypeID = ol.PackageTypeID
group by p.PackageTypeID, p.PackageTypeName
) a
order by a.Cantidad desc
go
-- Para la interfaz
create procedure MostrarItems
as
Select * from Warehouse.StockItems
go
create procedure BuscarItems @dato varchar(100)
as
Select * from Warehouse.StockItems s
where s.StockItemName like @dato + '%'