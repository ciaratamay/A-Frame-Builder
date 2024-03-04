using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class HtmlBuilder : MonoBehaviour
{
    public bool GenerateHTML, UpdateSkybox;
    public string [] htmltags = { "<!DOCTYPE html><html><head><title>Title</title>", "</head><body>", "</body></html>" };
    public string [] libraries = { "https://aframe.io/releases/1.5.0/aframe.min.js" };
    public string libprefix = "<script src="; public string libsuffix = "></script>";
    public string punct;
    public static string _punct;
    private Dictionary<string, string> aframeDict;
    public string imgExtension;
    public static string _imgExtension;

    private AFrameObject skyObj = null;
    private void OnEnable()
    {
        aframeDict = new Dictionary<string, string>();

    }

    void Update()
    {
        //Debug.Log("tags : " + htmltags [0]);
        if (GenerateHTML)
        {
            _punct = punct;
            _imgExtension = imgExtension;
            if (skyObj != null)
            {
                skyObj.o_src = GetSky();
            }
            GenHTML();
            GenerateHTML = false;
        }
        if (UpdateSkybox)
        {

            UpdateSkybox = false;
            if (skyObj != null)
            {
                skyObj.o_src = GetSky();
            }
        }


    }

    void GenHTML()
    {
        string tempLibs = "";
        foreach (string s in libraries)
        {
            tempLibs += libprefix + s + libsuffix;
        }

        string allText = htmltags [0] + tempLibs + htmltags [1] + GenerateScene() + htmltags [2];
        Debug.Log(allText);
    }

    public string GenerateScene()
    {
        AFrameObject [] sceneObjects = GameObject.FindObjectsOfType<AFrameObject>();
        AFrameObject rootObject = sceneObjects [0];
        foreach (AFrameObject obj in sceneObjects)
        {
            if (obj.gameObject.name.Contains("Scene"))
            {
                rootObject = obj;
                Debug.Log("root changed to :" + obj.gameObject.name);
            }
            if (obj.gameObject.name.Contains("Sky"))
            {
                skyObj = obj;
            }

        }
        AFrameObject [] objects = rootObject.transform.GetComponentsInChildren<AFrameObject>();

        List<string> objectsHTML = new List<string>();
        objectsHTML.Add(rootObject.opentag);
        foreach (AFrameObject obj in objects)
        {
            if (obj != rootObject)
            {
                ///dont include blank properties like id etc.
                objectsHTML.Add(obj.GetProperties());


                //objectsHTML.Add(obj.opentag + " position= " + punct + obj.transform.position.x.ToString() + " " + obj.transform.position.y.ToString() + " " + obj.transform.position.z.ToString() + punct + " rotation= " + punct + obj.transform.rotation.x.ToString() + " " + obj.transform.rotation.y.ToString() + " " + obj.transform.rotation.z.ToString() + punct + " id=" + punct + obj.o_id + punct + " src= " + punct + obj.o_src + imgExtension + punct + obj.closetag);
            }
        }
        objectsHTML.Add(rootObject.closetag);
        string collated = "";
        foreach (string coll in objectsHTML)
        {
            collated += coll;
        }

        return collated;
    }

    string GetSky()
    {
        string skyboxName = RenderSettings.skybox.name;

        Debug.Log("skybox name" + skyboxName);
        return skyboxName;
    }


}
