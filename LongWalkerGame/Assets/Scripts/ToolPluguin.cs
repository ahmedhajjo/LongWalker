using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tool))]

public class ToolPluguin : Editor
{

    Vector3 MousePOS;
    Tool Script;
    bool createObjects = false;

    


    public Vector3 GetMousePos()
    {
        return MousePOS;
    }

    void screenGUI()
    {
        if (Script == null)
        {
            Script = (Tool)target;
        }

        MousePOS = new Vector3(Event.current.mousePosition.x, Event.current.mousePosition.y);
        MousePOS.y = SceneView.currentDrawingSceneView.camera.pixelHeight - MousePOS.y;
        MousePOS = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(MousePOS);
        MousePOS.z = 0;

        if (createObjects == true)
        {

            Event e = Event.current;
            if (e.isMouse)
            {
                if (e.type == EventType.MouseUp)
                {
                    if (e.button == 0 && e.alt == true)
                    {
                        Script.IstanObjects(GetMousePos());
                        EditorUtility.SetDirty(Script);
                        EditorUtility.SetDirty(Script.gameObject);
                    }
                }

            }

        }

    }


    public override void OnInspectorGUI()
    {
        
        DrawDefaultInspector();
        if (GUILayout.Button("Create Objects on mouse click = " + createObjects))
        {
            createObjects = !createObjects;
        }
     
            
            
     


    }



}






		
	
