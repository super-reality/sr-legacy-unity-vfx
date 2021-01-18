using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ParticleLogoManager_S : MonoBehaviour
{
    Texture newTexture;
    Animator logoAnimator;
    Vector3 initialScale;

    public AudioSource audioSource;

    public GameObject particleParent, secondParent;
    public GameObject logoObject;
    public List<ParticleSystem> particlesList = new List<ParticleSystem>();

    private void Start()
    {
        if(logoObject)
            logoAnimator = logoObject.GetComponent<Animator>();

        logoObject.SetActive(true);
        particleParent.SetActive(true);

        if (secondParent)
            secondParent.SetActive(true);

        initialScale = logoObject.transform.localScale;

        //SetLogo();
    }

    /// <summary>
    /// Starts the Setting logo process
    /// </summary>
    /// <param name="url"></param>
    public void SetLogo(string url)
    {
        logoObject.SetActive(false);
        particleParent.SetActive(false);

        logoObject.transform.localScale = initialScale;

        StartCoroutine(ChangeLogoRoutine(url));
        //StartCoroutine(ChangeLogoRoutine("https://static.wikia.nocookie.net/logopedia/images/9/90/YouTube_logo_2005.svg/revision/latest/scale-to-width-down/340?cb=20160807125041"));
        //StartCoroutine(ChangeLogoRoutine("https://99designs-blog.imgix.net/blog/wp-content/uploads/2018/10/attachment_91976356-e1539290932445.png?auto=format&q=60&fit=max&w=930"));
        //StartCoroutine(ChangeLogoRoutine("https://cdn.vox-cdn.com/thumbor/p01ezbiuDHgRFQ-htBCd7QxaYxo=/0x105:2012x1237/1600x900/cdn.vox-cdn.com/uploads/chorus_image/image/47070706/google2.0.0.jpg"));
    }

    /// <summary>
    /// Downloads the logo from the Url if the url is valid and permitted.
    /// </summary>
    /// <param name="link"></param>
    /// <returns></returns>
    IEnumerator ChangeLogoRoutine(string link)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(link);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            print(www.error);
            yield break;
        }

        else
        {
            newTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }

        ChangeLogo(newTexture);
    }

    /// <summary>
    /// Change the logo dynamically from the url / link passed on
    /// The logo resizes to fit accordingly with the screen sizes or canvas size
    /// 
    /// Sizes may vary from the logos passed, some fit mroe accordingly than others
    /// </summary>
    /// <param name="passedTexture"></param>
    void ChangeLogo(Texture passedTexture)
    {
        logoObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", passedTexture);

        logoObject.transform.localScale = new Vector3(passedTexture.width / 100f, passedTexture.height / 100f, logoObject.transform.localScale.z);

        if (Screen.width < passedTexture.width)
            logoObject.transform.localScale = new Vector3(Mathf.Abs(logoObject.transform.localScale.x / (Screen.width / 100f)), logoObject.transform.localScale.y, logoObject.transform.localScale.z);

        if (Screen.height < passedTexture.height)
            logoObject.transform.localScale = new Vector3(logoObject.transform.localScale.x, Mathf.Abs(logoObject.transform.localScale.y / (Screen.height / 100f)), logoObject.transform.localScale.z);

        foreach (ParticleSystem particles in particlesList)
        {
            ParticleSystem.ShapeModule shapeModule = particles.shape;

            shapeModule.texture = (Texture2D)passedTexture;
        }

        logoObject.SetActive(true);
        particleParent.SetActive(true);

        if (secondParent)
            secondParent.SetActive(true);
    }

}
