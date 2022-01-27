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
    RopeSpriteBehaviour rsb;
    SpriteShapeController sprite;   
    

    List<Rigidbody2D> allJoints = new List<Rigidbody2D>();
    void Start()
    {
        rsb = transform.parent.GetComponent<RopeSpriteBehaviour>();
        sprite = GetComponent<SpriteShapeController>();
        //Temp while testing
        plug.allCordJoints.Clear();
        port.allCordJoints.Clear();
        rsb.points.Clear();

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
            rsb.points.Add(joint.transform);
        }

        int numPoints = sprite.spline.GetPointCount();
        print(numPoints);
        for(int i = 0; i < allJoints.Count - numPoints; ++i)
        {
            sprite.spline.InsertPointAt(3, Vector2.up * i);
        }
        numPoints = sprite.spline.GetPointCount();
        print(numPoints);

        rsb.points.Add(port.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
