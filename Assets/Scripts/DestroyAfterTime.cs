using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public int delayTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
