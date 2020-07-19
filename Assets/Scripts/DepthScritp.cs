using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DepthScritp : MonoBehaviour
{
    public GameObject post_processing_Script;
    public int speed;
    public int speedF;
    public DepthOfField dptf;
    public GameObject Staranim;
    public GameObject PlayerStart;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("start"))
        {
            // Avoid any reload.
            Debug.Log("yes");
        }
        Volume volume = post_processing_Script.GetComponent<Volume>();
        DepthOfField tmp;
        if(volume.profile.TryGet<DepthOfField>(out tmp))
        {
            dptf = tmp;
            speedF++;
            if(speedF % 22 == 0)
            {
                speed++;
            }
        }
        dptf.aperture.value = speed;
        if(dptf.aperture.value == dptf.aperture.max)
        {
            Destroy(gameObject.GetComponent<DepthScritp>());
            Staranim.SetActive(false);
            PlayerStart.SetActive(true);
        }    
    }
}
