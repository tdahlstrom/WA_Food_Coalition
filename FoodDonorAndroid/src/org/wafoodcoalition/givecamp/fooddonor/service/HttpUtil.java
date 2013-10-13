package org.wafoodcoalition.givecamp.fooddonor.service;

import java.io.IOException;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpParams;
import org.json.JSONObject;

import android.util.Log;

public class HttpUtil {
	private static HttpClient getHttpClient() {
		HttpParams httpParams = new BasicHttpParams();
//		HttpConnectionParams.setConnectionTimeout(httpParams, 30000);
//		HttpConnectionParams.setSoTimeout(httpParams, 15000);
		HttpClient httpClient = new DefaultHttpClient(httpParams);
		return httpClient;
	}
/*	public static String[] getUrls(String getUrl, String baseUrl, String locparams) throws IOException, JSONException {
		HttpClient client = getHttpClient();
		HttpGet httpGet = new HttpGet(getUrl+"?"+locparams);
		HttpResponse response;

		response = client.execute(httpGet);
		HttpEntity entity = response.getEntity();
		InputStream inputStream = entity.getContent();

		JSONObject jsonObject = JsonUtil.process(inputStream);
		JSONArray urls = ((JSONArray) jsonObject.get("urls"));

		List<String> list = new ArrayList<String>();
		for (int i = 0; i < urls.length(); i++) {					
			String url = new StringBuilder()
				.append(baseUrl)
				.append(urls.getString(i))				
				.toString();
			list.add(url);
		}

		return (String[]) list.toArray(new String[list.size()]);
	}*/
	
	public static int post(JSONObject obj, String url) throws IOException {
		HttpClient httpClient = getHttpClient();
		HttpPost post = new HttpPost(url);
		
		Log.v("POST", obj.toString());
		StringEntity requestEntity = new StringEntity(obj.toString());
		//StringEntity requestEntity = new StringEntity("{\"Name\":\"NameTestX\",\"Email\":\"some@hotmail.com\",\"Phone\":\"5555555555\",\"Address\":\"some random place\",\"Latitude\":16.0,\"Longitude\":65.0,\"Description\":\"5 pounds of potatoes\",\"Status\":\"New\",\"ExpirationDate\":\"2013-10-12T12:55:45\",\"FoodBankID\":0}");
		requestEntity.setContentType("application/json");
		post.setEntity(requestEntity); 

		HttpResponse response = httpClient.execute(post);
		//Log.v("POST", response.getFirstHeader("location").toString());
		return response.getStatusLine().getStatusCode();
	}
}
