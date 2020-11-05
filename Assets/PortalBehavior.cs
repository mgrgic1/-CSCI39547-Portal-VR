using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    static bool firstPortalSpawned;
    static bool secondPortalSpawned;

    static GameObject portal1;
    static GameObject portal2;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "portal1")
        {
            firstPortalSpawned = true;
            portal1 = gameObject;
        }
        if (gameObject.name == "portal2")
        {
            secondPortalSpawned = true;
            portal2 = gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //both portals must be spawned for player to be able to travel through them
            //in addition, player must be moving when going through (because they're walking through, standing and going through wouldnt make sense)
            if (firstPortalSpawned && secondPortalSpawned)
            {
                //if you're walking through portal 1, you'll spawn/teleport to portal 2
                if(gameObject.name == "portal1")
                {
                    collision.gameObject.transform.position = portal2.transform.Find("teleportPos").position;
                    collision.gameObject.transform.forward = portal2.transform.Find("teleportPos").up;

                    //adjusting for coming out of the ceiling or floor
                    if (portal2.transform.rotation == Quaternion.Euler(new Vector3(-180, 90, 0)) || portal2.transform.rotation == Quaternion.Euler(new Vector3(0, 90, 0)))
                    {
                        collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //stops velocity
                        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                else
                {
                    collision.gameObject.transform.position = portal1.transform.Find("teleportPos").position;
                    collision.gameObject.transform.forward = portal1.transform.Find("teleportPos").up;

                    //adjusting for coming out of the ceiling or floor
                    if (portal1.transform.rotation == Quaternion.Euler(new Vector3(-180, 90, 0)) || portal1.transform.rotation == Quaternion.Euler(new Vector3(0, 90, 0)))
                    {
                        collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //stops velocity
                        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }

            }
        }
    }


    void OnCollisionExit(Collision collision)
    {

    }






}
