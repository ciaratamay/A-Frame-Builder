using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFrameObject : MonoBehaviour
{
    public string o_id, o_class, o_src, opentag, closetag;
    private string p;

    public string GetProperties()
    {
        string ps = opentag;
        p = HtmlBuilder._punct;
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            o_src = gameObject.GetComponent<SpriteRenderer>().sprite.name + HtmlBuilder._imgExtension;
        }

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
        ps += " position = " + p + transform.position.x + " " + transform.position.y + " " + (-1 * transform.position.z).ToString() + p;
        //  ps += " rotation = " + p + transform.rotation.eulerAngles.x + " " + transform.rotation.eulerAngles.y + " " + transform.rotation.eulerAngles.z + p;
        ps += " rotation = " + p + (-1 * transform.rotation.eulerAngles.x).ToString() + " " + (-1 * transform.rotation.eulerAngles.y).ToString() + " " + transform.rotation.eulerAngles.z + p; ////corrected axes for rotstion from left hand to right hand.
        ps += " scale = " + p + transform.localScale.x + " " + transform.localScale.y + " " + transform.localScale.z + p;
        ps += closetag;
        return ps;
    }
}
