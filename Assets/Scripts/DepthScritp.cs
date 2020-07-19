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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        Volume volume = post_processing_Script.GetComponent<Volume>();
        DepthOfField tmp;
        if(volume.profile.TryGet<DepthOfField>(out tmp))
        {
            dptf = tmp;
            speedF++;
            if(speedF % 12 == 0)
            {
                speed++;
            }
        }
        dptf.aperture.value = speed;
        if(dptf.aperture.value == dptf.aperture.max)
        {
            Destroy(gameObject.GetComponent<DepthScritp>());
        }    
    }
}
