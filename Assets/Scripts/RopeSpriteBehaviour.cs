using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class RopeSpriteBehaviour : MonoBehaviour
{
    //NOTE: THE NUMBER OF VERTICES IN THE SPRITESHAPE 
    //MUST BE EQUAL TO THE NUMBER OF ROPE BLOCKS - 1, OR ELSE
    //AN INDEX ERROR WILL OCCUR

    //The SpriteShape created for the rope
    public SpriteShapeController spriteShape;
    //An array of points storing the positions of each block in the rope
    public Transform[] points;

    // Update is called once per frame
    void Update()
    {
        UpdateVertices();
    }

    private void UpdateVertices()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            //Find and call reference to the position of a block in the list
            Vector2 vertex = points[i].localPosition;
            //Quaternion rotation = points[i].localRotation;

            //Set one of the SpriteShape's vertices to the position of the block
            spriteShape.spline.SetPosition(i, vertex);

            //Sets the SpriteShape's tanget mode
            spriteShape.spline.SetTangentMode(i, ShapeTangentMode.Linear);

            //Draws reference to the SpriteShape's tangents and sets them to 0
            spriteShape.spline.SetRightTangent(i, Vector2.zero);
            spriteShape.spline.SetLeftTangent(i, Vector2.zero);

            //Repeat until list is exhausted
        }
    }
}
