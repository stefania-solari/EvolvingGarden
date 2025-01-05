using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using XRMultiplayer;

public class Dissolve : MonoBehaviour
{

    public float dissolveDuration = 2;
    public float dissolveStrength;

    public Material dissolveMaterial;



    public void StartDissolver()
    {
 
        StartCoroutine(dissolver());
        
    }
    public IEnumerator dissolver()
    {
        float elapsedTime = 0;
        dissolveMaterial = GetComponent<Renderer>().material;
        while(elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(0,1, elapsedTime/dissolveDuration);
            dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);
            yield return null;
        }
    }

    

/*
    public void MyDissolver()
    {
        Debug.Log("inside dissolver");
        
        dissolveMaterial = GetComponent<Renderer>().material;

        dissolveMaterial.SetFloat("_DissolveStrength",1);

    }
*/
    
}
