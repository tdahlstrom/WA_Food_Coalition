package org.wafoodcoalition.givecamp.fooddonor.service;

import java.io.IOException;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicHeader;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpParams;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;
import org.json.JSONObject;

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
		HttpContext localContext = new BasicHttpContext();
		HttpPost post = new HttpPost(url);
		
		StringEntity requestEntity = new StringEntity(obj.toString());
		requestEntity.setContentEncoding(new BasicHeader("Content-Type", "application/json"));
		post.setEntity(requestEntity); 

		HttpResponse response = httpClient.execute(post, localContext);
		return response.getStatusLine().getStatusCode();
	}
}
