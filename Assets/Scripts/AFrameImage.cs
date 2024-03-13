using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
//script that is attached to image prefab in addition to aframe object. updates the width and height of the image in the scene to match the size of the image file. Not necessary at all but can be handy to see the values.
//just check the updateimage box if you changed the sprite, and it will update the rect transform.
[RequireComponent(typeof(SpriteRenderer))]
public class AFrameImage : MonoBehaviour
{
    public bool updateImage;
    private void Update()
    {

        if (updateImage)
        {
            ScaleImage();
            updateImage = false;
        }

    }
    public void ScaleImage() //bad name, it just updates the rect values
    {

        if (gameObject.GetComponent<SpriteRenderer>().sprite != null)
        {
            Sprite s = gameObject.GetComponent<SpriteRenderer>().sprite;

            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(s.textureRect.width, s.textureRect.height);


        }


    }
}
