package org.wafoodcoalition.givecamp.fooddonor.service;

import org.json.JSONObject;

import android.os.AsyncTask;
import android.util.Log;


public class DonateTask extends AsyncTask<Void, Void, Integer> {
		private String url;
		private JSONObject obj;
		public DonateTask(JSONObject obj, String url) {
			this.url = url;
			this.obj = obj;
		}
		@Override
		protected Integer doInBackground(Void... unsued) {
			try {				
				return HttpUtil.post(obj, url);
			} catch (Exception e) {
				Log.e(e.getClass().getName(), e.getMessage(), e);
				return null;
			}
		}

		@Override
		protected void onProgressUpdate(Void... unsued) {

		}

		@Override
		protected void onPostExecute(Integer sResponse) {
			Log.v("POST", String.valueOf(sResponse));
/*			if (dialog.isShowing())
				dialog.dismiss();
			if (sResponse != null && sResponse.length()>0) {
			    String url = sResponse;
				Intent i = new Intent(getApplicationContext(), ViewActivity.class);
				i.putExtra("url",url);
				startActivity(i);
			} else {
				AlertUtil.createNetworkAlert(PostActivity.this).show();
			}*/
		}
}
