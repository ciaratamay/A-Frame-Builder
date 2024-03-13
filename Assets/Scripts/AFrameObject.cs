using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFrameObject : MonoBehaviour
{
    public string o_id, o_class, o_src, opentag, closetag;
    private string p;
    public float radius;


    public string GetProperties()
    {

        string ps = opentag; // start with the object's open tag ie <a-box 
        p = HtmlBuilder._punct; //this lets us enter quotation marks needed for html properties with the shorthand p. 

        if (gameObject.GetComponent<SpriteRenderer>() != null) //if has a sprite
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                o_src = gameObject.GetComponent<SpriteRenderer>().sprite.name; //remember to add the file to the site's root directory (for now)  ** to do: add optional folders **
            }
        }

        //if id, class or src are not empty, add them to the string. 

        if (o_id.Length > 0)
        {
            ps += " id = " + p + o_id + p;
        }
        if (o_class.Length > 0)
        {
            ps += " class = " + p + o_class + p;
        }
        if (o_src.Length > 0)
        {
            ps += " src = " + p + o_src + HtmlBuilder._imgExtension + p;
        }
        //   ps += " position = " + p + transform.position.x + " " + transform.position.y + " " + transform.position.z + p;
        ps += " position = " + p + transform.position.x + " " + transform.position.y + " " + (-1 * transform.position.z).ToString() + p; //this translates unity's left handed cartesian coordinates to three.js / a-frame's right handed. and same below for rotation. 

        ps += " rotation = " + p + (-1 * transform.rotation.eulerAngles.x).ToString() + " " + (-1 * transform.rotation.eulerAngles.y).ToString() + " " + transform.rotation.eulerAngles.z + p; ////corrected axes for rotstion from left hand to right hand.


        if (radius != 0) //just for spheres. // ** to do : replace with getting this from scale. 
        {
            ps += " radius = " + p + radius + p;
        }
        if (gameObject.GetComponent<SpriteRenderer>() != null) //if sprite, get sprite width and height for aframe image. Needs to be divided by 100 as unity by default does this but aframe makes a pixel = 1meter otherwise.
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                Sprite s = gameObject.GetComponent<SpriteRenderer>().sprite;
                Vector2 rectSize = new Vector2(s.textureRect.width / 100.0f, s.textureRect.height / 100.0f);
                ps += " height = " + p + rectSize.y + p + " width = " + p + rectSize.x + p;
            }


        }

        ps += " scale = " + p + transform.localScale.x + " " + transform.localScale.y + " " + transform.localScale.z + p; //get scale

        if (gameObject.GetComponent<MeshRenderer>() != null) //if has a mesh renderer - change its colour. ** to do : add option for materials with textures ** 
        {
            Color c = gameObject.GetComponent<MeshRenderer>().sharedMaterial.color;
            ps += " material=  " + p + "color: " + "#" + ColorUtility.ToHtmlStringRGB(c) + ";" + p;
            if (c.a < 1)
            {
                ps += " transparent = " + p + " true " + p + " opacity = " + p + c.a + p;
            }

        }
        ps += closetag; //finall add the close tag ie. ></a-box> 
        return ps; //return the whole string for this object.
    }
}
