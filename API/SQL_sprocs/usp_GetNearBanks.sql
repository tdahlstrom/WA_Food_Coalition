CREATE PROCEDURE [dbo].[usp_GetNearBanks]
    @latitude FLOAT,
    @longitude FLOAT,
	@amtToReturn INT
AS
BEGIN

    SET NOCOUNT ON;

	CREATE TABLE #distance_to_loc(
		ID int,
		distance float
	)

	INSERT INTO #distance_to_loc (ID, distance)
	SELECT ID, dbo.fn_calculate_distance (@latitude, @longitude, latitude, longitude) as dist
	FROM FoodBanks (NOLOCK)
	
	SELECT TOP (@amtToReturn) fb.Name, fb.Email, dtl.distance
	FROM #distance_to_loc dtl (NOLOCK)
		INNER JOIN FoodBanks fb(NOLOCK)
			ON dtl.ID = fb.ID
	ORDER BY dtl.distance

END