using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class ClientController : NetworkBehaviour
{
    public override void OnStartLocalPlayer() //override the orginal function, but still can change it.
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    Count count = new Count();

    void Update ()
    {
        if (!isLocalPlayer)
            return;

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        transform.Rotate(0, x, 0); // allows the user to rotate
        transform.Translate(0, 0, z); // allows move forward/backwards.

        if(Input.GetKeyDown(KeyCode.Space))
        {
            count.countDown -= 1;
            print(count.countDown);

            count.countDownText.text = count.countDown.ToString();
            
            if (count.countDown == 0)
            {
                count.countDown += 1;
                count.countDownText.text = "You Win!";
            }
        }
    }
}
