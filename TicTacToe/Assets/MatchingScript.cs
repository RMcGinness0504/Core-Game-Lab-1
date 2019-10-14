using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingScript : MonoBehaviour
{
	int xCount;
	int oCount;

    public void checkMatch(bool xOrO)
	{
		xCount = 0;
		oCount = 0;

		if (xOrO)
		{
			xCount++;
		} else
		{
			oCount++;
		}

        if (xCount == 3)
		{
			Debug.Log("x win");
		} else if (oCount == 3)
		{
			Debug.Log("o win");
		}
	}
}
