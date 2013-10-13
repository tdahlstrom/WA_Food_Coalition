package org.wafoodcoalition.givecamp.fooddonor.service;

import java.io.IOException;

import org.json.JSONObject;


public class DonationServiceWrapper {
	public static int post(JSONObject obj) throws IOException {
		return HttpUtil.post(obj, "http://sgcwfcorg00.web803.discountasp.net/api/Donation");
	}


}
