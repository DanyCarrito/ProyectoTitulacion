using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturesList : MonoBehaviour
{
    public Texture[] textures;
    public Color[] colors;

    Color c1 = new Color(0f, 1f, .80f, 1f);
    Color c2 = new Color(1f, 0f, .50f, 1f);

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
        GetComponent<Renderer>().material.SetColor("_Color", colors[Random.Range(0, colors.Length)]);
    }
}
