using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
	public bool Placed { get; private set; }
	public BoundsInt area;

	#region Build Methods

	public void Place(bool selector)
	{
		Placed = selector;

		BoundsInt areaTemp = AreaTemp();

		if (selector)
		{
			GridBuildingSystem.Current.PaintAreaWhite(areaTemp);
			return;
		}

		if (GridBuildingSystem.Current.CanTakeArea(areaTemp))
			GridBuildingSystem.Current.PaintArea(areaTemp);

	}

	private BoundsInt AreaTemp()
	{
		Vector3Int positionInt = GridBuildingSystem.Current.GridLayout.LocalToCell(transform.position);
		BoundsInt areaTemp = area;
		areaTemp.position = positionInt;
		return areaTemp;
	}
	
	#endregion
}
