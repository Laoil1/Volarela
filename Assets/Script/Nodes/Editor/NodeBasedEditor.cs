using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace VolarelaNS{
    using DialogueNS;
    public class NodeBasedEditor : EditorWindow
    {

        private Dialogue  dialogue;

        private Node selectedNode;
        private NodeInspector nodeInspector;
        

        private GUIStyle sentenceStyle;
        private GUIStyle startStyle;
        private GUIStyle endStyle;
        private GUIStyle entryStyle;

        private GUIStyle labelStyle;
        private GUIStyle selectedLabelStyle;
        private GUIStyle selectedSentenceStyle;
        private GUIStyle selectedStartStyle;
        private GUIStyle selectedEndStyle;
        private GUIStyle selectedEntryStyle;
        private GUIStyle inPointStyle;
        private GUIStyle outPointStyle;

        private ConnectionPoint selectedInPoint;
        private ConnectionPoint selectedOutPoint;
        
        private Vector2 offset;
        private Vector2 drag;

        private Vector2 centerScreen;

        public bool fakeOnEnable = false;

        [MenuItem("Volarela/Dialogue Editor")]
        private static void OpenWindow()
        {
            NodeBasedEditor window = GetWindow<NodeBasedEditor>();
            window.titleContent = new GUIContent("Node Based Editor");
        }

        private void OnEnable()
        {               
            //T'active pas les styles  a l'activation d'unity gros naze ou un truc du genre 
            FakeOnEnable();
        }

        private void SetStyles()
        {
            var sentCol = Resources.Load ("EditorTextures/SenStyle") as Texture2D;
            sentenceStyle = new GUIStyle();
            sentenceStyle.alignment = TextAnchor.MiddleCenter;
            sentenceStyle.normal.background = sentCol;
            sentenceStyle.border = new RectOffset(12, 12, 12, 12);
            
            var selSentCol = Resources.Load ("EditorTextures/SelSenStyle") as Texture2D;            
            selectedSentenceStyle = new GUIStyle();
            selectedSentenceStyle.alignment = TextAnchor.MiddleCenter;
            selectedSentenceStyle.normal.background =  selSentCol;
            selectedSentenceStyle.border = new RectOffset(12, 12, 12, 12);
            
            var startCol = Resources.Load ("EditorTextures/StartStyle") as Texture2D;                        
            startStyle = new GUIStyle();
            startStyle.alignment = TextAnchor.MiddleCenter;
            startStyle.normal.background = startCol;
            startStyle.border = new RectOffset(12, 12, 12, 12);

            var selStartCol = Resources.Load ("EditorTextures/SelStartStyle") as Texture2D;                        
            selectedStartStyle = new GUIStyle();
            selectedStartStyle.alignment = TextAnchor.MiddleCenter;
            selectedStartStyle.normal.background =  selStartCol;
            selectedStartStyle.border = new RectOffset(12, 12, 12, 12);

            var endCol = Resources.Load ("EditorTextures/EndStyle") as Texture2D;                        
            endStyle = new GUIStyle();
            endStyle.alignment = TextAnchor.MiddleCenter;
            endStyle.normal.background = endCol;
            endStyle.border = new RectOffset(12, 12, 12, 12);

            var selEndCol = Resources.Load ("EditorTextures/SelEndStyle") as Texture2D;                        
            selectedEndStyle = new GUIStyle();
            selectedEndStyle.alignment = TextAnchor.MiddleCenter;
            selectedEndStyle.normal.background = selEndCol;
            selectedEndStyle.border = new RectOffset(12, 12, 12, 12);

            
            var entryCol = UsualFunction.MakeTex(2,2,new Color(132,119,232,100));                        
            selectedEntryStyle = new GUIStyle();
            selectedEntryStyle.alignment = TextAnchor.MiddleCenter;
            selectedEntryStyle.normal.background = entryCol;
            selectedEntryStyle.border = new RectOffset(12, 12, 12, 12);

            var selEntryCol = UsualFunction.MakeTex(2,2,new Color(132,119,232,75));                        
            selectedEntryStyle = new GUIStyle();
            selectedEntryStyle.alignment = TextAnchor.MiddleCenter;
            selectedEntryStyle.normal.background = selEntryCol;
            selectedEntryStyle.border = new RectOffset(12, 12, 12, 12);


            var pointCol =  Resources.Load ("EditorTextures/PointStyle") as Texture2D;                        
            inPointStyle = new GUIStyle();
            inPointStyle.normal.background = pointCol;
            inPointStyle.active.background = pointCol;
            inPointStyle.border = new RectOffset(4, 4, 12, 12);

            outPointStyle = new GUIStyle();
            outPointStyle.normal.background = pointCol;
            outPointStyle.active.background = pointCol;
            outPointStyle.border = new RectOffset(4, 4, 12, 12);

            labelStyle = new GUIStyle();
            labelStyle.fontSize = 20;
            labelStyle.fontStyle = FontStyle.Bold;
            labelStyle.alignment = TextAnchor.MiddleLeft;
            labelStyle.normal.textColor = new Color(0,0,0,1);

            selectedLabelStyle = new GUIStyle();
            selectedLabelStyle.fontSize = 23;
            selectedLabelStyle.fontStyle = FontStyle.Bold;
            selectedLabelStyle.alignment = TextAnchor.MiddleLeft;
            selectedLabelStyle.normal.textColor = new Color(1,1,1,1);
        }
        private void Reinitialize (){
            
            if (dialogue!= null)
            {
                // dialogue.Reset(OnClickRemoveNode,OnClickInPoint,OnClickOutPoint,OnClickRemoveConnection);
                // passer par un delegate (comme on a vu avec simon, pour l'appeler une fois);
                if(dialogue.nodes!= null){
                    foreach (var node in dialogue.nodes)
                    {
                        if (node.OnRemoveNode != OnClickRemoveNode)
                        {
                            node.OnRemoveNode = OnClickRemoveNode;
                        }
                        node.inPoint.Reset(node,inPointStyle, OnClickInPoint);
                        foreach(var con in dialogue.connections){
                            if (con.inPoint.index == node.inPoint.index)
                            {
                                if(con.inPoint != node.inPoint)
                                {
                                    con.inPoint = node.inPoint;
                                }
                            }
                        }
                        
                        foreach(var _points in node.outPoint)
                        {
                             _points.Reset(node,outPointStyle, OnClickOutPoint);
                            
                            foreach(var con in dialogue.connections){
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
                    foreach (var con in dialogue.connections)
                    {
                        con.OnClickRemoveConnection = OnClickRemoveConnection;
                    }
                }
            }
        }

        private void CreateStart(){
            if (dialogue.nodes == null)
            {
                dialogue.nodes = new List<Node>();
            }
            if(dialogue.nodes.Count <=0){
                dialogue.nodes.Add(new Node(dialogue.globalNodeIndex, new Vector2(20,450), 200, 100, startStyle, selectedStartStyle, inPointStyle, outPointStyle, labelStyle, selectedLabelStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode, dialogue, TypeOfNode.Start));
                dialogue.globalNodeIndex ++;
            }
        }

        private void FakeOnEnable()
        {
            SetStyles();
            if(dialogue != null){
                CreateStart();
                Reinitialize();

            }
        }
        private void OnGUI()
        {
            // OnEnable();
            dialogue = EditorGUILayout.ObjectField("Dialogue",dialogue,typeof(Dialogue),false) as Dialogue;
            if(GUI.Button(new Rect(153,18,50,17),"Reset"))
            {
                FakeOnEnable();
            }
            GUI.DrawTexture(new Rect (0,35,Screen.width,Screen.height),UsualFunction.MakeTex(2,2,Color.black));
                DrawGrid(20, 0.2f, Color.white);
                DrawGrid(100, 0.4f, Color.white);

                if(dialogue != null){
                    CreateStart();
                    DrawNodes();
                    DrawConnections();

                    DrawConnectionLine(Event.current);


                    ProcessNodeEvents(Event.current);
                    ProcessEvents(Event.current);

                    DrawInspector();
                }

                if (GUI.changed) 
                {
                    Repaint();
                    EditorUtility.SetDirty(dialogue);
                    EditorUtility.SetDirty(this);
                }
        }

        public void DrawInspector(){
            if(dialogue.nodes != null){
                foreach (var _node in dialogue.nodes)
                {
                    if(_node.isSelected == true){
                        selectedNode = _node;
                        break;
                    }
                    selectedNode = null;
                }
            }
                if(selectedNode != null){
                    dialogue.selectedNode = selectedNode;
                    Selection.activeObject = dialogue;
                    dialogue.areANodeSelected = true;

                }else{
                    dialogue.areANodeSelected = false;
                    Selection.activeObject = null;
                }
            

        }
        
        private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
        {
            int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
            int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

            Handles.BeginGUI();
            Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

            offset += drag * 0.5f;
            Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

            for (int i = 0; i < widthDivs; i++)
            {
                Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
            }

            for (int j = 0; j < heightDivs; j++)
            {
                Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
            }

            Handles.color = Color.white;
            Handles.EndGUI();
        }


        private void DrawNodes()
        {
            if (dialogue.nodes != null)
            {
                for (int i = 0; i < dialogue.nodes.Count; i++)
                {
                    dialogue.nodes[i].Draw();
                }
            }
        }

        private void DrawConnections()
        {
            if (dialogue.connections != null)
            {
                for (int i = 0; i < dialogue.connections.Count; i++)
                {
                    dialogue.connections[i].Draw();
                } 
            }
        }

        private void ProcessEvents(Event e)
        {   
            drag = Vector2.zero;
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0)
                    {
                        ClearConnectionSelection();
                    }

                    if (e.button == 1)
                    {
                        ProcessContextMenu(e.mousePosition);
                    }
                    break;
                
                case EventType.MouseDrag:
                    if(e.button == 0){
                        OnDrag(e.delta);
                    }
                    break;
                case EventType.KeyDown:
                    if(e.keyCode == KeyCode.H){
                        ReinitializeDrag();
                    }
                    break;
            }
        }

        private void ProcessNodeEvents(Event e)
        {
            if (dialogue.nodes != null)
            {
                for (int i = dialogue.nodes.Count - 1; i >= 0; i--)
                {
                    bool guiChanged = dialogue.nodes[i].ProcessEvents(e);

                    if (guiChanged)
                    {
                        GUI.changed = true;
                    }
                }
            }
        }
        
        private void DrawConnectionLine(Event e)
        {
            if (selectedInPoint != null && selectedOutPoint == null)
            {
                Handles.DrawBezier(
                    selectedInPoint.rect.center,
                    e.mousePosition,
                    selectedInPoint.rect.center + Vector2.left * 50f,
                    e.mousePosition - Vector2.left * 50f,
                    Color.white,
                    null,
                    2f
                );

                GUI.changed = true;
            }

            if (selectedOutPoint != null && selectedInPoint == null)
            {
                Handles.DrawBezier(
                    selectedOutPoint.rect.center,
                    e.mousePosition,
                    selectedOutPoint.rect.center - Vector2.left * 50f,
                    e.mousePosition + Vector2.left * 50f,
                    Color.white,
                    null,
                    2f
                );

                GUI.changed = true;
            }
        }
        private void ProcessContextMenu(Vector2 mousePosition)
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Add SentenceQuestion"), false, () => OnClickAddNode(mousePosition, TypeOfNode.SentenceQuestion, sentenceStyle, selectedSentenceStyle)); 
            genericMenu.AddItem(new GUIContent("Add SentenceAnswer"), false, () => OnClickAddNode(mousePosition, TypeOfNode.SentenceAnswer, sentenceStyle, selectedSentenceStyle)); 
            genericMenu.AddItem(new GUIContent("Add Cinematique"), false, () => OnClickAddNode(mousePosition, TypeOfNode.Cinematique, endStyle, selectedEndStyle)); 
            genericMenu.AddItem(new GUIContent("Add ConditionChange"), false, () => OnClickAddNode(mousePosition, TypeOfNode.ConditionChange, startStyle, selectedStartStyle)); 
            genericMenu.AddItem(new GUIContent("Add ConditionCheck"), false, () => OnClickAddNode(mousePosition, TypeOfNode.ConditionCheck, endStyle, selectedEndStyle)); 
            genericMenu.AddItem(new GUIContent("Add TextEntry"), false, () => OnClickAddNode(mousePosition, TypeOfNode.TextEntry, sentenceStyle, selectedSentenceStyle)); 
            genericMenu.AddItem(new GUIContent("Add End"), false, () => OnClickAddNode(mousePosition, TypeOfNode.End, endStyle, selectedEndStyle)); 
            genericMenu.ShowAsContext();
        }

        private void OnDrag(Vector2 delta){
            drag = delta;
            centerScreen += delta;

            if(dialogue.nodes != null){
                for (int i = 0; i < dialogue.nodes.Count; i++){
                    dialogue.nodes[i].Drag(centerScreen);
                }
            }
            GUI.changed = true;
        }

        private void ReinitializeDrag (){
            centerScreen = Vector2.zero;
            drag = Vector2.zero;
            OnDrag(Vector2.zero);
        }

        private void OnClickAddNode(Vector2 mousePosition, TypeOfNode typeOfNode, GUIStyle style, GUIStyle selectedStyle)
        {
            if (dialogue.nodes == null)
            {
                dialogue.nodes = new List<Node>();
            }

            dialogue.nodes.Add(new Node(dialogue.globalNodeIndex, mousePosition, 200, 100, style, selectedStyle, inPointStyle, outPointStyle, labelStyle, selectedLabelStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode, dialogue, typeOfNode));
            dialogue.globalNodeIndex ++;

        }

        

        private void OnClickInPoint(ConnectionPoint inPoint)
        {
            selectedInPoint = inPoint;

            if (selectedOutPoint != null)
            {
                if (selectedOutPoint.node != selectedInPoint.node)
                {
                    CreateConnection();
                    ClearConnectionSelection(); 
                }
                else
                {
                    ClearConnectionSelection();
                }
            }
        }

        private void OnClickOutPoint(ConnectionPoint outPoint)
        {
            if (outPoint.connectedInNode != -1)
            {
                foreach (var connection in dialogue.connections)
                {
                    if(connection.inPoint.node.ID == outPoint.connectedInNode)
                    if(connection.outPoint == outPoint)
                    {
                        dialogue.connections.Remove(connection);
                        break;
                    }
                }
            }
            selectedOutPoint = outPoint;
            if (selectedInPoint != null)
            {
                if (selectedOutPoint.node != selectedInPoint.node)
                {
                    CreateConnection();
                    ClearConnectionSelection();
                }
                else
                {
                    ClearConnectionSelection();
                }
            }
        }

        private void OnClickRemoveNode(Node node)
        {
            if (dialogue.connections != null)
            {
                List<Connection> connectionsToRemove = new List<Connection>();

                for (int i = 0; i < dialogue.connections.Count; i++)
                {
                    foreach(var _points in node.outPoint){
                        if (dialogue.connections[i].inPoint == node.inPoint || dialogue.connections[i].outPoint == _points)
                        {
                            connectionsToRemove.Add(dialogue.connections[i]);
                        }
                    }
                }

                for (int i = 0; i < connectionsToRemove.Count; i++)
                {
                    dialogue.connections.Remove(connectionsToRemove[i]);
                }

                connectionsToRemove = null;
            }
            selectedNode = null;
            dialogue.nodes.Remove(node);
        }

        private void OnClickRemoveConnection(Connection connection)
        {
            connection.inPoint.connectedOutNodes.Remove(connection.outPoint.index);
            connection.outPoint.connectedInNode = -1;
            dialogue.connections.Remove(connection);
        }

        private void CreateConnection()
        {
            if (dialogue.connections == null)
            {
                dialogue.connections = new List<Connection>();
            }
            var _connection = new Connection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection);
            dialogue.connections.Add(_connection);
            if(selectedInPoint.connectedOutNodes == null)
            {
                selectedInPoint.connectedOutNodes = new List<int>();
            }
            selectedInPoint.connectedOutNodes.Add(selectedOutPoint.node.ID);
            selectedOutPoint.connectedInNode = selectedInPoint.node.ID;
        }

        private void ClearConnectionSelection()
        {
            selectedInPoint = null;
            selectedOutPoint = null;
        }
    }
}