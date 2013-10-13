package org.wafoodcoalition.givecamp.fooddonor;

import java.util.Calendar;
import java.util.regex.Pattern;

import org.json.JSONObject;
import org.wafoodcoalition.givecamp.fooddonor.location.FoodLocation;
import org.wafoodcoalition.givecamp.fooddonor.location.LocationDetection;
import org.wafoodcoalition.givecamp.fooddonor.location.LocationUpdated;
import org.wafoodcoalition.givecamp.fooddonor.service.DonateTask;

import android.accounts.Account;
import android.accounts.AccountManager;
import android.app.Activity;
import android.content.Context;
import android.location.LocationManager;
import android.os.Bundle;
import android.telephony.TelephonyManager;
import android.util.Patterns;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;

public class Donate extends Activity implements LocationUpdated, OnClickListener {
	
	private EditText phone;
	private DatePicker dpResult;
	private EditText email;
	private EditText nameEdit;
	private EditText descriptionEdit;
	
	EditText locationEdit = null;
	FoodLocation location;
	Button submitButton;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_donate);
		setDefaultPhoneOnView();
		setCurrentDateOnView();
		setDefaultEmailOnView();
		
		locationEdit = (EditText) findViewById(R.id.location);
		nameEdit = (EditText) findViewById(R.id.name);
		descriptionEdit = (EditText) findViewById(R.id.description);
		
	    LocationManager lm = (LocationManager)getSystemService(Context.LOCATION_SERVICE); 
	    LocationDetection.init(this.getApplicationContext());
	    LocationDetection.instance().detectLocation(lm, this);
	    
	    submitButton = (Button) findViewById(R.id.submit);
	    submitButton.setOnClickListener(this);
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
	
	public void setDefaultEmailOnView() {
		
		email = (EditText) findViewById(R.id.email);
		
		Pattern emailPattern = Patterns.EMAIL_ADDRESS; // API level 8+
		Account[] accounts = AccountManager.get(this.getApplicationContext()).getAccounts();
		
		for (Account account : accounts) {
			if (emailPattern.matcher(account.name).matches()) {
				email.setText(account.name);
				return;
			}
		}
	}
	
	public void updated(FoodLocation l) {
		if(l!=null) {
			this.location = l;
			locationEdit.setText(l.getAddress());
			locationEdit.postInvalidate();
		}
	}
	public void onClick(View arg0) {
		if(arg0==submitButton) {
			submit();
		}		
	}

	private void submit() {
		updateAddress();
		postToService();
	}
	
	private void updateAddress() {
		String newAddress = locationEdit.getText().toString();
		if(location==null || !location.getAddress().equals(newAddress)) {
			location = LocationDetection.instance().geoCode(newAddress);
		} 
		//TODO: handle the case if no location.
	}
	
	private void postToService() {
		//{"Name":"NameTestX","Email":"some@hotmail.com","Phone":"5555555555","Address":"some random place","Latitude":16.0,"Longitude":65.0,"Description":"5 pounds of potatoes","Status":"New","ExpirationDate":"2013-10-12T12:55:45","FoodBankID":0}]
		try {
			JSONObject obj = new JSONObject();
			obj.put("Name", nameEdit.getText().toString());
			obj.put("Email", email.getText().toString());
			obj.put("Phone", phone.getText().toString());
			obj.put("Address", location.getAddress());
			obj.put("Latitude", location.getLat());
			obj.put("Longitude", location.getLng());
			obj.put("Description", descriptionEdit.getText());
			obj.put("Status", "New");
			obj.put("ExpirationDate", "2013-10-14T12:55:45");
			obj.toString();
			
			new DonateTask(obj, "http://sgcwfcorg00.web803.discountasp.net/api/Donation").execute();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
	}
}
