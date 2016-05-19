using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0); // allows the user to rotate
        transform.Translate(0, 0, z); // allows move forward/backwards.
    }
}
