using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField] float minX = 5f;
    [SerializeField] float maxX = 19f;
    [SerializeField] float ScreenWidthInUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = PaddlePos;
    }
}
