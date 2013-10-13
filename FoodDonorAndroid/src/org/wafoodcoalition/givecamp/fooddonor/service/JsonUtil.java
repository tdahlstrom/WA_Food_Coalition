package org.wafoodcoalition.givecamp.fooddonor.service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import org.json.JSONException;
import org.json.JSONObject;

public class JsonUtil {
	
	public static JSONObject process(InputStream inputStream) throws IOException, JSONException
	{
		String out = read(inputStream);
		return convert(out);
	}
	
	public static String read(InputStream inputStream) throws IOException, JSONException
	{
		BufferedReader r = new BufferedReader(
				new InputStreamReader(inputStream));
		StringBuilder total = new StringBuilder();
		String line;
		while ((line = r.readLine()) != null) {
			total.append(line);
		}
		return total.toString();
	}
	
	public static JSONObject convert(String string) throws JSONException {
		JSONObject jsonObject = new JSONObject(string);
		return jsonObject;
	}
}
