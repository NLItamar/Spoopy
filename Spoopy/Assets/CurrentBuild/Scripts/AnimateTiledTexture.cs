using UnityEngine;
using System.Collections;

class AnimateTiledTexture : MonoBehaviour
{
    /*
    Animates the texture of the material assigned to an object
    Sprite tiling, framecount/speed etc can be adjusted
    */
    public int columns = 2;
    public int rows = 2;
    public float framesPerSecond = 10f;

    //the current frame to display
    private int index = 0;
    private Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        //set the tile size of the texture (in UV units), based on the rows and columns
        Vector2 size = new Vector2(1f / columns, 1f / rows);
        myRenderer.sharedMaterial.SetTextureScale("_MainTex", size);
    }



    void Update()
    {
        //move to the next index
        index++;
        if (index >= rows * columns)
            index = 0;

        //split into x and y indexes
        Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
                                      (index / columns) / (float)rows);          //y index

        myRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);



    }

}