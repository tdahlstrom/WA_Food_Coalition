
/*
	Calculate the distance (in miles) between two coordinates.
*/
CREATE FUNCTION [dbo].[fn_calculate_distance] (
	@user_lat FLOAT,
	@user_long FLOAT,
	@destination_lat FLOAT,
	@destination_long FLOAT )
	RETURNS FLOAT
AS
BEGIN

    DECLARE @p1 geography = geography::Point(@user_lat,@user_long, 4326);
	DECLARE @distance FLOAT
	SET @distance = (SELECT @p1.STDistance(geography::Point(@destination_lat, @destination_long, 4326)))
	return @distance * 0.000621371
END