//This must be attatched to the rope sprite object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class RopeGenerator : MonoBehaviour
{
    [SerializeField] int halfLength;
    [SerializeField] GameObject ropeJoint;
    [SerializeField] PlayerController plug, port;
    RopeSpriteBehaviour rsbRed, rsbBlue;
    SpriteShapeController spriteRed, spriteBlue;   
    List<Rigidbody2D> allJoints = new List<Rigidbody2D>();
    void Awake()
    {
        rsbRed = transform.GetChild(0).GetComponent<RopeSpriteBehaviour>();
        rsbBlue = transform.GetChild(1).GetComponent<RopeSpriteBehaviour>();
        spriteRed = rsbRed.GetComponent<SpriteShapeController>();
        spriteBlue = rsbBlue.GetComponent<SpriteShapeController>();
        //Temp while testing
        plug.allCordJoints.Clear();
        port.allCordJoints.Clear();
        rsbRed.points.Clear();
        rsbBlue.points.Clear();

        //Make a number of joints for the length we want
        for (int i = 1; i <= halfLength; ++i)
        {
            //Move each joint over slightly so it forms a rope
            GameObject newJoint = Instantiate(ropeJoint, plug.transform.position + new Vector3(.5f * i, 0), Quaternion.identity);

            //Set the joints
            if (allJoints.Count > 0)
            {
                newJoint.GetComponent<HingeJoint2D>().connectedBody = allJoints[i - 2];
            }
            else
            {
                newJoint.GetComponent<HingeJoint2D>().connectedBody = plug.GetComponent<Rigidbody2D>();
            }

            //Give plug access to their half of the rope
            plug.allCordJoints.Add(newJoint);

            allJoints.Add(newJoint.GetComponent<Rigidbody2D>());
        }

        //Make a number of joints for the length we want
        for (int i = 1; i <= halfLength; ++i)
        {
            //Move each joint over slightly so it forms a rope, start farther away to account for the rope that exists
            GameObject newJoint = Instantiate(ropeJoint, plug.transform.position + new Vector3(.5f * (i + halfLength), 0), Quaternion.identity);

            //Set the joints
            if (allJoints.Count > 0)
            {
                newJoint.GetComponent<HingeJoint2D>().connectedBody = allJoints[allJoints.Count - 1];
            }
            else
            {
                newJoint.GetComponent<HingeJoint2D>().connectedBody = plug.GetComponent<Rigidbody2D>();

            }

            //Give port access to their half of the rope
            port.allCordJoints.Add(newJoint);

            allJoints.Add(newJoint.GetComponent<Rigidbody2D>());

        }

        //Put port in the right spot and set his joint
        port.transform.position = allJoints[allJoints.Count - 1].transform.position + new Vector3(.5f, 0);
        port.GetComponent<HingeJoint2D>().connectedBody = allJoints[allJoints.Count - 1];


        //Add all the joints (and port) to the rope sprite script
        foreach (Rigidbody2D joint in allJoints)
        {
            joint.GetComponent<HingeJoint2D>().autoConfigureConnectedAnchor = false;
            joint.transform.SetParent(transform);
        }

        for(int i = 0; i <= allJoints.Count/2; ++i)
        {
            rsbRed.points.Add(allJoints[i].transform);
        }
        for(int i = allJoints.Count/2; i < allJoints.Count; ++i)
        {
            rsbBlue.points.Add(allJoints[i].transform);
        }

        int numPointsRed = spriteRed.spline.GetPointCount();
        for(int i = 0; i < allJoints.Count/2 - numPointsRed; ++i)
        {
            spriteRed.spline.InsertPointAt(3, Vector2.up * i);
        }
        numPointsRed = spriteRed.spline.GetPointCount();

        int numPointsBlue = spriteBlue.spline.GetPointCount();
        for (int i = 0; i < allJoints.Count / 2 - numPointsBlue; ++i)
        {
            spriteBlue.spline.InsertPointAt(3, Vector2.up * i);
        }
        numPointsBlue = spriteBlue.spline.GetPointCount();
        rsbBlue.points.Add(port.transform);
    }
}
