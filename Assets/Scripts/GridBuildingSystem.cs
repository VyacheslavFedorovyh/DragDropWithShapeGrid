using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
	public static GridBuildingSystem Current;

	public GridLayout GridLayout;
	public Tilemap MainTilemap;
	public Tilemap TempTilemap;
	public int SpaceshipArea;

	private Module _temp;
	private Module[] _tempMainTilemaps;
	private int _counterTempMainTilemap = 0;


	private static Dictionary<TileType, TileBase> _tileBases = new Dictionary<TileType, TileBase>();

	#region Unity Methods

	private void Awake()
	{
		Current = this;
		_tempMainTilemaps = new Module[SpaceshipArea];
	}

	private void Start()
	{
		string tilePath = @"Tiles\";

		_tileBases.Add(TileType.Empty, null);
		_tileBases.Add(TileType.White, Resources.Load<TileBase>(tilePath + "white"));
		_tileBases.Add(TileType.Green, Resources.Load<TileBase>(tilePath + "green"));
		_tileBases.Add(TileType.Red, Resources.Load<TileBase>(tilePath + "red"));
	}

	#endregion

	#region Tilemap management

	private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
	{
		int counter = 0;

		TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];

		foreach (var v in area.allPositionsWithin)
		{
			Vector3Int pos = new Vector3Int(v.x, v.y, 0);
			array[counter] = tilemap.GetTile(pos);
			counter++;
		}

		return array;
	}

	private void GetTilesBlockMainTilemap(BoundsInt area, int counterTemp)
	{
		int counter = 0;

		var gameObjectsModules = GameObject.FindGameObjectsWithTag("Module").Where(d => d != _temp.gameObject);

		Vector3Int posTemp = new Vector3Int();

		foreach (var v in area.allPositionsWithin)
		{
			if (counter == counterTemp)
			{
				posTemp = new Vector3Int(v.x, v.y, 0);
				break;
			}

			counter++;
		}

		foreach (var gameObjectsModule in gameObjectsModules)
		{
			var componentBuilding = gameObjectsModule.GetComponent<Module>();

			foreach (var v in componentBuilding.area.allPositionsWithin)
			{
				Vector3Int posDestroy = new Vector3Int(v.x, v.y, 0);

				if (posTemp == posDestroy)
				{
					_tempMainTilemaps[_counterTempMainTilemap] = componentBuilding;
					_counterTempMainTilemap++;
				}
			}
		}
	}

	private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
	{
		int size = area.size.x * area.size.y * area.size.z;
		TileBase[] tileArray = new TileBase[size];
		FillTiles(tileArray, type);
		tilemap.SetTilesBlock(area, tileArray);
	}

	private static void FillTiles(TileBase[] arr, TileType type)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			arr[i] = _tileBases[type];
		}
	}

	#endregion

	#region Building Placement

	public void InitializeWithBuilding(GameObject module)
	{
		_temp = Instantiate(module, Vector3.zero, Quaternion.identity).GetComponent<Module>();
		FollowBuilding(_temp);
	}

	private void ClearArea(BoundsInt prevArea)
	{
		TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
		FillTiles(toClear, TileType.Empty);
		TempTilemap.SetTilesBlock(prevArea, toClear);
	}

	public void FollowBuilding(Module module)
	{
		_temp = module;
		ClearArea(module.area);
		PaintTempMainTilemap(TileType.Green);
		_tempMainTilemaps = new Module[SpaceshipArea];
		_temp.area.position = GridLayout.WorldToCell(_temp.gameObject.transform.position);

		BoundsInt buildingArea = _temp.area;

		TileBase[] baseArray = GetTilesBlock(buildingArea, MainTilemap);

		int size = baseArray.Length;
		TileBase[] tileArray = new TileBase[size];

		for (int i = 0; i < baseArray.Length; i++)
		{
			if (baseArray[i] == _tileBases[TileType.White])
			{
				tileArray[i] = _tileBases[TileType.Green];
			}
			else if (baseArray[i] == _tileBases[TileType.Empty])
			{
				FillTiles(tileArray, TileType.Red);
				break;
			}
			else if (baseArray[i] == _tileBases[TileType.Green])
			{
				GetTilesBlockMainTilemap(buildingArea, i);
			}
		}

		_counterTempMainTilemap = 0;
		TempTilemap.SetTilesBlock(buildingArea, tileArray);
		PaintTempMainTilemap(TileType.Red);
	}

	public bool CanTakeArea(BoundsInt area)
	{
		TileBase[] baseArray = GetTilesBlock(area, MainTilemap);

		if (baseArray.Any(d => d == _tileBases[TileType.Empty]))
		{
			ClearArea(_temp.area);
			Destroy(_temp.gameObject);
			PaintTempMainTilemap(TileType.Green);
			return false;
		}
		else if (baseArray.Any(d => d == _tileBases[TileType.Red]))
		{
			foreach (var tempMainTilemap in _tempMainTilemaps.Where(d => d != null))
			{
				PaintTempMainTilemap(TileType.White);
				Destroy(tempMainTilemap.gameObject);
			}
		}

		return true;
	}

	public void PaintArea(BoundsInt area)
	{
		SetTilesBlock(area, TileType.Empty, TempTilemap);
		SetTilesBlock(area, TileType.Green, MainTilemap);
	}

	public void PaintAreaWhite(BoundsInt area)
	{
		SetTilesBlock(area, TileType.White, MainTilemap);
	}

	private void PaintTempMainTilemap(TileType tileType)
	{
		foreach (var tempMainTilemap in _tempMainTilemaps.Where(d => d != null))
		{
			ClearArea(tempMainTilemap.area);
			SetTilesBlock(tempMainTilemap.area, tileType, MainTilemap);
		}
	}

	#endregion

}

public enum TileType
{
	Empty,
	White,
	Green,
	Red
}