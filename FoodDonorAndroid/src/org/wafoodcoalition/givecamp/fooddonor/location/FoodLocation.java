package org.wafoodcoalition.givecamp.fooddonor.location;

public class FoodLocation {
	private String address = null;
	private Double lat = null;
	private Double lng = null;
	public FoodLocation(String address, Double lat, Double lng) {
		super();
		this.address = address;
		this.lat = lat;
		this.lng = lng;
	}
	public String getAddress() {
		return address;
	}
	public Double getLat() {
		return lat;
	}
	public Double getLng() {
		return lng;
	}
	
}
