use Northwind
go

alter function RecaudacionMasAltaPorMes(@Anio int)
RETURNS Table
As
Return
Select distinct MONTH(a.fecha) as Fecha, MAX(a.Recaudado) as Recaudado from(
Select o.OrderID as id, o.OrderDate fecha, 
ROUND(sum(od.Quantity*od.UnitPrice*(1-od.Discount)), 2)
as Recaudado from [Order Details] od
inner join Orders o
on o.OrderID = od.OrderID
where YEAR(o.OrderDate) = @Anio
group by o.OrderID, o.OrderDate
) a group by MONTH(a.fecha)
GO

Select * from RecaudacionesEmpleado(1997)

alter function RecaudacionesEmpleado(@Anio int)
RETURNS TABLE
AS
RETURN
Select c.Fecha, c.Recaudado from (
Select o.OrderID as id, o.OrderDate fecha, 
ROUND(sum(od.Quantity*od.UnitPrice*(1-od.Discount)), 2)
as Recaudado from [Order Details] od
inner join Orders o
on o.OrderID = od.OrderID
where YEAR(o.OrderDate) = @Anio
group by o.OrderID, o.OrderDate
) a
inner join dbo.RecaudacionMasAltaPorMes(@Anio) as c
on c.Fecha = a.fecha and c.Recaudado = a.Recaudado