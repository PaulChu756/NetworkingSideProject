using UnityEngine;
using UnityEngine.Networking; // for network aware scripts
using System.Collections;

public class PlayerController : NetworkBehaviour // gameobjects that need to use network feature
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    /*
     By setting the send rate to zero so the position is not synchronized over the network, 
     and allowing each Client to calculate to position of the bullet, 
     the overall network traffic is reduced to improve game performance.
    */

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0); // allows the user to rotate
        transform.Translate(0, 0, z); // allows move forward/backwards.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    [Command]
    void CmdFire()
    {
        // Create Bullet
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet); 

        // Delete bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer() //override the orginal function, but still can change it.
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
