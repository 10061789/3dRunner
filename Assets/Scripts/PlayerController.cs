using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    public float runningSpeed;
    float touchXDelta=0;
    float newX = 0;
    public float xSpeed;
    public float limitX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Swipe();


    }


    private void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);

            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;

        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");

        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;

        newX = Mathf.Clamp(newX, -limitX, limitX);



        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }



}
