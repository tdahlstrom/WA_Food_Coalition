CREATE PROCEDURE [dbo].[usp_GetNearDonations]
    @latitude FLOAT,
    @longitude FLOAT
AS
BEGIN

    SET NOCOUNT ON;

	CREATE TABLE #distance_to_loc(
		ID int,
		distance float
	)

	INSERT INTO #distance_to_loc (ID, distance)
	SELECT ID, dbo.fn_calculate_distance (@latitude, @longitude, latitude, longitude) as dist
	FROM Donations (NOLOCK)
	
	SELECT TOP 10 d.name, d.Email, d.Phone, d.Address, d.Description, d.Status, d.ExpirationDate, dtl.distance
	FROM #distance_to_loc dtl (NOLOCK)
		INNER JOIN Donations d(NOLOCK)
			ON dtl.ID = d.ID
	ORDER BY distance

END