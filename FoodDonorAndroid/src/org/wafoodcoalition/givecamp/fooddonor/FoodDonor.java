package org.wafoodcoalition.givecamp.fooddonor;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;

public class FoodDonor extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_food_donor);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_food_donor, menu);
		return true;
	}

}
