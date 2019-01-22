using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using VolarelaNS;


namespace VolarelaNS.DialogueNS{
[CreateAssetMenu(fileName="Dialogue", menuName ="Volarela/Dialogue", order = 2)]
	public class Dialogue : ScriptableObject {
		
		
		public List<Node> nodes;
		
		public Node selectedNode;

		public List<Connection> connections;

		public int globalConnectionPointIndex=0;
		public int globalNodeIndex=0;
        
		public bool areANodeSelected;
		
        public Node FindNodeByID (int _ID){
			foreach(var _node in nodes){
				if (_ID == _node.ID){
					return _node;
				}
			}
				return null;
        }

		public void Reset(Action<Node> OnClickRemoveNode, Action<ConnectionPoint> OnClickInPoint, Action<ConnectionPoint> OnClickOutPoint,Action<Connection> OnClickRemoveConnection)
		{
			if(nodes!= null){
                    foreach (var node in nodes)
                    {
                        if (node.OnRemoveNode != OnClickRemoveNode)
                        {
                            node.OnRemoveNode = OnClickRemoveNode;
                        }
                        if(node.inPoint.node != node)
                        {
                            node.inPoint.node = node;
                            node.inPoint.OnClickConnectionPoint = OnClickInPoint;
                            foreach(var con in connections){
                                if (con.inPoint.index == node.inPoint.index)
                                {
                                    if(con.inPoint != node.inPoint)
                                    {
                                        con.inPoint = node.inPoint;
                                    }
                                }
                            }

                        }
                        foreach(var _points in node.outPoint)
                        {
                            if(_points.node != node)
                            {
                                _points.node = node; 
                                _points.OnClickConnectionPoint = OnClickOutPoint;
                            }
                            foreach(var con in connections){
                                if (con.outPoint.index == _points.index)
                                {
                                    if(con.outPoint != _points)
                                    {
                                        con.outPoint = _points;
                                    }
                                }
                            }
                        }
                    }
                    foreach (var con in connections)
                    {
                        con.OnClickRemoveConnection = OnClickRemoveConnection;
                    }
                }
		}
		/*[OnOpenAssetAttribute(1)]
		public static bool step1(int instanceID, int line)
		{
			string name = EditorUtility.InstanceIDToObject(instanceID).name;
			OpenWindow();
			return false; // we did not handle the open
		}*/

	}

}