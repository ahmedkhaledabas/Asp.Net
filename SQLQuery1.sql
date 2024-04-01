UPDATE Movies
SET MovieStatus = CASE
    WHEN StartDate > GETDATE() THEN 2
    WHEN EndDate < GETDATE() THEN 0
    ELSE 1
END;

UPDATE Movies
SET EndDate = DATEADD(year, 1, EndDate)