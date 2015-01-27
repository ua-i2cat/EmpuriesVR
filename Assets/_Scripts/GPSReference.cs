using UnityEngine;
using System.Collections;
using System;

public class GPSReference : MonoBehaviour
{
		public float latitude;
		public float longitude;
		public float radius;
		bool gpsInit = false;
		LocationInfo currentGPSPosition;
		Vector2 initialLocation;

		void Awake ()
		{
				initialLocation = new Vector2 (latitude, longitude);
		}
		// Use this for initialization
		IEnumerator Start ()
		{
			
				if (!Input.location.isEnabledByUser)
						yield break;
		
				Input.location.Start (5f, 0f);
				int maxWait = 20;
				// Checks if the GPS is enabled by the user (-> Allow location )
 
				while (Input.location.status == LocationServiceStatus.Initializing && maxWait>0) {
						yield return new WaitForSeconds (1);
						maxWait--;
				}
			
				if (maxWait < 1) {
						print ("Timed out");
						yield break;
				}
				if (Input.location.status == LocationServiceStatus.Failed) {
						print ("GPS failed");
						yield break;
				} else {
						gpsInit = true;
						// We start the timer to check each tick (every 3 sec) the current gps position
						InvokeRepeating ("RetrieveGPSData", 0, 3);
				}
		}
		 
		void RetrieveGPSData ()
		{
				currentGPSPosition = Input.location.lastData;
				Vector2 currentLocation = new Vector2 (currentGPSPosition.latitude, currentGPSPosition.longitude);
		print ("Calculations , lat1,long1=" + currentGPSPosition.latitude + "," + currentGPSPosition.longitude + " lat2,long2=" + latitude + "," + longitude);

				float distance = Calculations.HaversineInM(currentGPSPosition.latitude, currentGPSPosition.longitude,latitude,longitude);
				
				if (distance < radius) {
						Vector2 newPosition = (currentLocation - initialLocation);
						transform.position = new Vector3 (newPosition.x, transform.position.y, newPosition.y);
				}
				TimeSpan timeSpan = TimeSpan.FromSeconds (Time.time);
				string timeText = string.Format ("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
				string gpsString = "::" + currentGPSPosition.latitude + "//" + currentGPSPosition.longitude+
				"// acc:"+currentGPSPosition.horizontalAccuracy+" distance:"+distance;
				GameObject.Find ("gps_debug_text").guiText.text = timeText + gpsString;
				print ("GPS distance:" + distance);
		} 
	

 
}
