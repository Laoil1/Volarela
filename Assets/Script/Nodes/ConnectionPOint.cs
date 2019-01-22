using System;
using System.Collections.Generic;
using UnityEngine;

public enum ConnectionPointType { In, Out }

[System.Serializable]
public class ConnectionPoint
{
    public Rect rect;

    public ConnectionPointType type;

    [NonSerialized]    
    public Node node;

    //Elle etait en public avant faire gaffe 
    private GUIStyle style;

    public List<int> connectedOutNodes;
    public int connectedInNode = -1;
    
    public int index;

    public Action<ConnectionPoint> OnClickConnectionPoint;
    
    public ConnectionPoint(Node _node, ConnectionPointType _type, GUIStyle _style, Action<ConnectionPoint> _OnClickConnectionPoint, int _index)
    {
        this.node = _node;
        this.type = _type;
        this.style = _style;
        this.OnClickConnectionPoint = _OnClickConnectionPoint;
        this.index = _index;
        rect = new Rect(0, 0, 10f, 15f);
    }

    public void Reset(Node _node, GUIStyle _style, Action<ConnectionPoint> _OnClickConnectionPoint)
    {
        this.node = _node;
        this.style = _style;
        this.OnClickConnectionPoint = _OnClickConnectionPoint;
    }

    public void Draw(int index)
    {
        rect.y = node.rect.y + ( node.rect.height * 0.18f*(index)) + rect.height;

        switch (type)
        {
            case ConnectionPointType.In:
                rect.x = node.rect.x - rect.width;
                // Debug.Log(connectedOutNodes[0].fullText);
                break;

            case ConnectionPointType.Out:
                rect.x = node.rect.x + node.rect.width;
                //Debug.Log(connectedInNode.fullText);
                break;
        }
        
        if (GUI.Button(rect, "", style))
        {
            if (OnClickConnectionPoint != null)
            {
                OnClickConnectionPoint(this);
            }
        }
    }

        public void Draw()
    {
        rect.y = node.rect.y + (node.rect.height * 0.5f) - rect.height * 0.5f;

        switch (type)
        {
            case ConnectionPointType.In:
                rect.x = node.rect.x - rect.width;
                break;

            case ConnectionPointType.Out:
                rect.x = node.rect.x + node.rect.width;
                break;
        }
        
        if (GUI.Button(rect, "", style))
        {
            if (OnClickConnectionPoint != null)
            {
                OnClickConnectionPoint(this);
            }
        }
    }
}