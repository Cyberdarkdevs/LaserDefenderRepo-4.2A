using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

    /* In Unity there are two types of methods; Built-in and User Defined
     * Built-in: These methods have their names already set up by Unity the Unity compiler will know
     * when the call the method during game execution. Thus, we just need to provide the method definition.
     * It is important to use the exact name for the built-in method during method definition (proper spelling
     * + proper casing)
     * 
     * User Defined: These methods are invented by the developer for proper organisation of code. Since
     * the Unity compiler doesn't know about these methods, we need to make sure that the method is called at the proper time.
     */
{

    [SerializeField] float movementSpeed = 10f;

    // boundary coordinates
    float xMin;
    float xMax;

    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start() // built-in method and this is a method definition (explaining what the method will do)
    {
        // print("The start method has been called!"); // Method call

        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        // print("The update method has been called!");

        Move();
    }

    // Move is a User-Defined method and it will be used to control the player ship's movements

    void Move()
    {

        //GetAxis returns a -ve or +ve value depending on which button on the keyboard

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        /*
         * Since the Move() method is being called in the Update which executes once per frame,
         * the player's movement is in general frame dependant since the higher

        /* To access properties for THIS objecect the format is:
         * componentName.propertyName
         * 
         * To acces properties for another object the format is:
         * object.componentName.propertyName
         */

        // The current x popsition (for the player) is changed with the slight change of deltaX EVERY frane

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        // changing the players ships' position
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
    }

    void SetUpMoveBoundaries()
    {
        float padding = 0.5f;

        /*
         * We're going to set the boundaries using ViewportToWorldPoint so that the
         * coordinates of the boundaries are not dependant on the camera size but
         * they are always 
         */

        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
