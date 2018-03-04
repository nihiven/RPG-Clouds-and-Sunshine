using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    private Transform target;

    private float xMax;
    private float xMin;
    private float yMax;
    private float yMin;

    [SerializeField]
    private Tilemap tilemap;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetLimits(minTile, maxTile);
    }
	


	// Update is called once per frame
	private void LateUpdate ()
    {
        // -10 because of the z value
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax) - 10);
	}

    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera camera = Camera.main;

        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
