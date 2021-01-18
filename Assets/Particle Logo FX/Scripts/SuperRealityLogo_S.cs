using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SuperRealityLogo_S : MonoBehaviour
{
    Animator logoAnimator;
    bool rotateAvailable, resetRotation;
    float speed, acceleration = 500;

    public AudioSource audioSource;
    public GameObject logoObject, blurredObject;

    private void Start()
    {
        if(logoObject)
            logoAnimator = logoObject.GetComponent<Animator>();

        logoObject.SetActive(false);

        StartCoroutine(LogoBehaviour());
    }

    /// <summary>
    /// FixedUpdate will handle all the rotation behaviour
    /// </summary>
    private void FixedUpdate()
    {
        if (rotateAvailable) // Rotation behaviour
        {
            logoObject.transform.Rotate(0f, 0f, -speed * Time.fixedDeltaTime);
            speed += acceleration * Time.fixedDeltaTime;

            if (speed < 0f)
            {
                rotateAvailable = false;
                resetRotation = true;
            }
        }

        if (resetRotation) // Reset logo to original rotation
        {
            logoObject.transform.Rotate(0f, 0f, 75f * Time.fixedDeltaTime);

            if (logoObject.transform.rotation.z >= 0f)
            {
                resetRotation = false;
            }
        }
    }

    //Logo Behaviour Function
    public IEnumerator LogoBehaviour()
    {
        logoAnimator.enabled = true;

        yield return new WaitForSeconds(1f); // Turn on logo

        if (!logoObject.activeSelf)
            logoObject.SetActive(true);

        audioSource.Play();       

        yield return new WaitForSeconds(1.5f); // Start the rotation sequence
        logoAnimator.enabled = false;
        rotateAvailable = true;

        yield return new WaitForSeconds(1f); // Turn on blur effect
        blurredObject.SetActive(true);
        blurredObject.GetComponent<Animator>().SetBool("Reverse", false);

        yield return new WaitForSeconds(6f); // Start slowing rotation
        if (rotateAvailable)
            acceleration *= -1f;

        yield return new WaitForSeconds(5f); // Turn blur off
        blurredObject.GetComponent<Animator>().SetBool("Reverse", true);

        yield return new WaitForSeconds(8f); //Reset variables
        acceleration = 500f;
        speed = 0f;

        StartCoroutine(LogoBehaviour()); // Call routine again
    }
}
