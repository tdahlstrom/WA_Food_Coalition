package org.wafoodcoalition.givecamp.fooddonor;

import java.util.Calendar;

import org.wafoodcoalition.givecamp.fooddonor.location.FoodLocation;
import org.wafoodcoalition.givecamp.fooddonor.location.LocationDetection;
import org.wafoodcoalition.givecamp.fooddonor.location.LocationUpdated;

import android.app.Activity;
import android.content.Context;
import android.location.LocationManager;
import android.os.Bundle;
import android.telephony.TelephonyManager;
import android.view.Menu;
import android.widget.DatePicker;
import android.widget.EditText;

public class Donate extends Activity implements LocationUpdated {
	
	private EditText phone;
	private DatePicker dpResult;

	EditText locationEdit = null;
	FoodLocation location;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_donate);
		setDefaultPhoneOnView();
		setCurrentDateOnView();
		locationEdit = (EditText) findViewById(R.id.location);
	    LocationManager lm = (LocationManager)getSystemService(Context.LOCATION_SERVICE); 
	    LocationDetection.init(this.getApplicationContext(), lm, this);
	}
	@Override
	protected void onResume() {
		super.onResume();
	}
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_donate, menu);
		return true;
	}
	
	// display current date
	public void setCurrentDateOnView() {
	 
		dpResult = (DatePicker) findViewById(R.id.dpResult);
	 
		final Calendar c = Calendar.getInstance();
		int year = c.get(Calendar.YEAR);
		int month = c.get(Calendar.MONTH);
		int day = c.get(Calendar.DAY_OF_MONTH);
	 
		// set current date into date picker
		dpResult.init(year, month, day, null);
	}
	
	public void setDefaultPhoneOnView() {
		
		phone = (EditText) findViewById(R.id.phone);
		
		TelephonyManager tMgr =(TelephonyManager)getSystemService(Context.TELEPHONY_SERVICE);
		String phoneNumber = tMgr.getLine1Number();
		
		if (phoneNumber != null) {
			phone.setText(phoneNumber);
		}
	}
	public void updated(FoodLocation l) {
		this.location = l;
		locationEdit.setText(l.getAddress());
		locationEdit.postInvalidate();
	}

}
