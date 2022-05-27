using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSize : MonoBehaviour
{
    public Vector2 bottomLeft;
    public Vector2 bottomRight;
    public Vector2 topRight;
    public Vector2 topLeft;
    public float brickSize;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
        bottomRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner
        topLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        brickSize = ((topRight.x - topLeft.x) / 11);

       // float cameraHeight = Camera.main.orthographicSize * 2;
       // float cameraWidth = cameraHeight * Screen.width / Screen.height; // cameraHeight * aspect ratio

        gameObject.transform.localScale = Vector3.one * brickSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
