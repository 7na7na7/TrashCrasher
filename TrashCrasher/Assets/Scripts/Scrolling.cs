using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;

    private void Awake()
    {
        viewHeight = 18.07869f;
    }

    void Update()
    {
        transform.position = new Vector2(Camera.main.transform.position.x / speed, Camera.main.transform.position.y);

        if(sprites[endIndex].position.x < viewHeight*(-1) + Camera.main.transform.position.x)
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.right * viewHeight;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = startIndexSave - 1 == -1 ? sprites.Length - 1 : startIndexSave - 1;
        }

        if (sprites[startIndex].position.x > viewHeight * 2 + Camera.main.transform.position.x)
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[startIndex].transform.localPosition = frontSpritePos + Vector3.left * viewHeight;

            endIndex = startIndex;
            startIndex = startIndex - 1 == -1 ? sprites.Length - 1 : startIndex - 1;
        }
    }
}
