select p."NameProduct", c."NameCategories"
from Products p
left join ProductCategories pc on p.ID = pc.ProductId
left join Categories c on pc.CategoryId = c.ID