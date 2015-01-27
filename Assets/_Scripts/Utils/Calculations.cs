using UnityEngine;
using System.Collections;


public class Calculations  {

	static double _eQuatorialEarthRadius = 6378.1370D;
	static double _d2r = (Mathf.PI / 180D);
	
	public static int HaversineInM(double lat1, double long1, double lat2, double long2)
	{
		return (int)(1000D * HaversineInKM(lat1, long1, lat2, long2));
	}
	
	private static double HaversineInKM(double lat1, double long1, double lat2, double long2)
	{
		/*http://forums.asp.net/t/1789515.aspx?calculates+the+distance+in+kilometers+between+two+GPS+coordinates*/

		float e=(float)(lat1*_d2r);
		
		float f= (float)(long1*_d2r);
		
		float g=(float)(lat2*_d2r);
		
		float h=(float)(long2*_d2r);

		float i=(Mathf.Cos(e)*Mathf.Cos(g)*Mathf.Cos(f)*Mathf.Cos(h)+Mathf.Cos(e)*Mathf.Sin(f)*Mathf.Cos(g)*Mathf.Sin(h)+
		          Mathf.Sin(e)*Mathf.Sin(g));
		
		float j=(Mathf.Acos(i));
		
		float k=(float)(_eQuatorialEarthRadius*j);
		return k;
	}
}
