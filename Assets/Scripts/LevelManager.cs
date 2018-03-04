using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Transform map;

    [SerializeField]
    private Texture2D[] _mapData; // set in ui

    [SerializeField]
    private MapElement[] _mapElements;  // set in ui

    [SerializeField]
    private Sprite _defaultTile;
    
    private Vector3 WorldStartPosition
    {
        get { return Camera.main.ScreenToWorldPoint(new Vector3(0, 0));  }
    }

	// Use this for initialization
	void Start ()
    {
       GenerateMap();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void GenerateMap()
    {
        for (int i = 0; i < _mapData.Length; i++)
        {
            for (int x = 0; x < _mapData[i].width; x++)
            {
                for (int y = 0; y < _mapData[i].height; y++)
                {
                    // read color from current pixe;
                    Color color = _mapData[i].GetPixel(x, y);
                    MapElement newElement = Array.Find(_mapElements, e => e.Color == color);

                    if (newElement != null)
                    {
                        float xPos = WorldStartPosition.x + (_defaultTile.bounds.size.x * x);
                        float yPos = WorldStartPosition.y + (_defaultTile.bounds.size.y * y);

                        GameObject go = Instantiate(newElement.ElementPrefab);
                        go.transform.position = new Vector2(xPos, yPos);
                        go.transform.parent = map;

                    }
                }
            }
        }
    }
}

[Serializable]
public class MapElement
{
    [SerializeField]
    private string _tileTag;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private GameObject _elementPrefab;

    public GameObject ElementPrefab
    {
        get { return _elementPrefab;  }
    }

    public Color Color
    {
        get { return _color; }
    }

    public string TileTag
    {
        get { return _tileTag; }
    }
}