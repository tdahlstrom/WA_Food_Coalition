package org.wafoodcoalition.givecamp.fooddonor;

import android.app.Activity;
import android.content.Context;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.Menu;

public class FoodDonor extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_food_donor);
	    LocationManager lm = (LocationManager)getSystemService(Context.LOCATION_SERVICE); 
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_food_donor, menu);
		return true;
	}

}
