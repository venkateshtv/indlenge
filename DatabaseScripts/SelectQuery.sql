
SELECT DISTINCT a.Store AS Store,a.`Top Level Category`,ROUND(AVG(a.Price),2) as CompetitorsPrice, ROUND(b.MyStorePrice,2) as MyStorePrice FROM pricing  a 
JOIN (SELECT DISTINCT `Top Level Category` AS category,AVG(Price) AS MyStorePrice FROM pricing WHERE Store = 'My Store' GROUP BY Store,`Top Level Category`)  b 
ON a.`Top Level Category` = b.category
GROUP BY a.Store,a.`Top Level Category`




