package org.wafoodcoalition.givecamp.fooddonor.location;

import java.io.IOException;
import java.util.List;
import java.util.Locale;

import android.content.Context;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.util.Log;

public class LocationDetection implements LocationListener {
	private static LocationDetection detector = null;
		
	private LocationManager locationManager;
	private LocationUpdated updateListener;
	private Geocoder geocoder; 
	
	private LocationDetection() {		
		
	}
	
	public static LocationDetection instance() {
		return detector;
	}
	
	public static void init(Context c) {
		if(detector==null) {
			 detector = new LocationDetection();		
			 detector.geocoder = new Geocoder(c, Locale.ENGLISH);
		}
	}
	
	public void detectLocation(LocationManager lm, LocationUpdated listener) {
		if(lm!=null) {
			//getLatLng(lm);
			this.locationManager = lm;
			if(lm.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
				lm.requestLocationUpdates(
						LocationManager.GPS_PROVIDER, 1000, 1, this);
			} 
			lm.requestLocationUpdates(
					LocationManager.NETWORK_PROVIDER, 1000, 1, this);
				this.updateListener = listener;
		}
	}
	
		public void onLocationChanged(Location l) {
			this.updateLocation(l);
		}

		public void onProviderDisabled(String provider) {
			
		}

		public void onProviderEnabled(String provider) {
			
		}

		public void onStatusChanged(String provider, int status, Bundle extras) {
			
		}

/*	private static void getLatLng(LocationManager locationManager) {
		List<String> providers = locationManager.getProviders(true);

		Location l = null;
		// loop backwards - better accuracy is last.
		for (int i = providers.size() - 1; i >= 0; i--) {
			l = locationManager.getLastKnownLocation(providers.get(i));
			if (l != null)
				break;
		}
		detector.updateLocation(l);		
	}*/
	
	private synchronized void updateLocation(Location l) {
		if (l != null && l.getAccuracy()<1500) {	//1500 meters accuracy	~ 1 miles
			try {
				List<Address> address = geocoder.getFromLocation(l.getLatitude(), l.getLongitude(), 1);
				if(address!=null && address.size()>0) {
					StringBuilder sb = new StringBuilder();
					int maxIndex = address.get(0).getMaxAddressLineIndex();
					for(int i=0;i<=maxIndex;i++) {
						String line = address.get(0).getAddressLine(i);
						if(line.trim().length()>0) {
							sb.append(line);
							if(i!=maxIndex)
								sb.append(", ");
						}
					}
					FoodLocation location = new FoodLocation(sb.toString(), l.getLatitude(), l.getLongitude());
					if(updateListener!=null) {
						updateListener.updated(location);
						locationManager.removeUpdates(this);
					}
				}
			} catch (IOException ioe) {
				Log.e("location", "reverse geocode failed");		
				if(updateListener!=null) {
					updateListener.failed();
				}
			}
		}
	}
	
	public FoodLocation geoCode(String address) throws IOException {
		if (address != null && address.trim().length()>5) {			
			try {
				List<Address> locations = geocoder.getFromLocationName(address, 1);
				
			    Address location = locations.get(0);
			    location.getLatitude();
			    location.getLongitude();
		
				FoodLocation foodLocation = new FoodLocation(address, location.getLatitude(), location.getLongitude());
				return foodLocation;
			} catch (IOException ioe) {
				Log.e("location", "geocode failed"); 
				throw ioe;
			}
		}
		return null;
	}
}
