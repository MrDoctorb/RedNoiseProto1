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

            spriteShape.spline.SetTangentMode(i, ShapeTangentMode.Linear);

            //Draws reference to the SpriteShape's left tangent
/*            Vector2 leftTangent = spriteShape.spline.GetLeftTangent(i);
            Vector2 rightTangent = spriteShape.spline.GetRightTangent(i);

            leftTangent = Vector2.zero;*/

            spriteShape.spline.SetRightTangent(i, Vector2.zero);
            spriteShape.spline.SetLeftTangent(i, Vector2.zero);

/*            //Sets the tangents perpendicular to the rope blocks
            Vector2 newRT = Vector2.Perpendicular(vertex.normalized) * leftTangent.magnitude;
            Vector2 newLT = -newRT;

            //Set the SpriteShape vertice to the rotation of the block
            spriteShape.spline.SetRightTangent(i, newRT);
            spriteShape.spline.SetLeftTangent(i, newLT);*/

            //Repeat until list is exhausted
        }
    }
}
