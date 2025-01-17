using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturesList : MonoBehaviour
{
    public Texture[] textures;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeTexture();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTexture()
    {
        //GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
        GetComponent<Renderer>().material.SetTexture("_Texture2D", textures[Random.Range(0, textures.Length)]);
    }
}
