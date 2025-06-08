
--view data from Resources
SELECT * FROM Resources;
SELECT * FROM Resources
WHERE Title LIKE '%EF Core%';
SELECT * FROM Resources
ORDER BY PublicationYear DESC;
UPDATE Resources
SET Title = 'EF Core Final Edition'
WHERE Id = 1;
DELETE FROM Resources
WHERE Id = 3;
EXEC sp_help 'Resources';

-- View data in BorrowingRecords
SELECT * FROM BorrowingRecords;

-- View table structure
EXEC sp_help 'BorrowingRecords';
