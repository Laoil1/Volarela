using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VolarelaNS;
using VolarelaNS.IGO;
using VolarelaNS.Switchs;
using VolarelaNS.DialogueNS;

public enum TypeOfNode
{
    Start,
    End,
    ConditionCheck,
    ConditionChange,
    TextEntry,
    SentenceQuestion,
    SentenceAnswer,
    Cinematique
}



[System.Serializable]
public class Node
{

    public int ID;
    [HideInInspector]
    public Rect rect;
    [HideInInspector]
    public  Vector2 centerScreen;

    [HideInInspector]
    public Rect initialRect;
    [HideInInspector]
    public Rect labelRect;
     [HideInInspector]
    public Rect initialLabelRect;
    [HideInInspector]
    public string title;

    [HideInInspector]
    public string dialogueText;
    [HideInInspector]
    public bool isDragged;
    [HideInInspector]
    public bool isSelected;
    public string name = "Phrase";
    public Emotions emotion;

    public ConnectionPoint inPoint;
    //[HideInInspector]
    public List<ConnectionPoint> outPoint;

    public GUIStyle style;
    public GUIStyle labelStyle;
    
    public GUIStyle defaultLabelStyle;
    public GUIStyle selectedLabelStyle;

    [HideInInspector]
    public GUIStyle defaultNodeStyle;
    [HideInInspector]
    public GUIStyle selectedNodeStyle;

    public TypeOfNode ton = TypeOfNode.SentenceQuestion;

    [HideInInspector]
    public Action<Node> OnRemoveNode;

    #region Variables Spécifique

        public Switch condition;
        public string fullText;
        public Character characterTalking;
        public List<AudioClip> textAudio;
        
        [HideInInspector]
        public List<Sprite> pictures;
        public List<String> questions;
	    public int questionsLenght;
        public List<String> answer;
        public int answersLengh;
        public string textEntry; 
        public List<string> approTextEntry;

        public bool changingConidition;
        public int approTextEntryLengh;

    #endregion 

    public Node(int _ID, Vector2 position, float width, float height, GUIStyle nodeStyle, GUIStyle selectedStyle, GUIStyle inPointStyle, GUIStyle outPointStyle,GUIStyle lStyle, GUIStyle slStyle, Action<ConnectionPoint> OnClickInPoint, Action<ConnectionPoint> OnClickOutPoint, Action<Node> OnClickRemoveNode, Dialogue dialogue, TypeOfNode _type)
    {
        //note pour plus tard : Creer une classe style avec une banque de donnée etc..
        ID = _ID;
        ton = _type;
        outPoint = new List<ConnectionPoint>();
        switch(ton){
            case TypeOfNode.Start :
                rect = new Rect(position.x, position.y, width, height/2);
                initialRect =  new Rect(position.x, position.y, width, height/2);
                        
                labelRect = new Rect(rect.x + 20.0f, rect.y + 10, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y + 10, 175, 25);
                name = "Start";
                outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                dialogue.globalConnectionPointIndex += 1;
                break;
            
            case TypeOfNode.SentenceAnswer :
                rect = new Rect(position.x, position.y, width, height);
                initialRect =  new Rect(position.x, position.y, width, height);
        
                labelRect = new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                answer = new List<string>() {"Reponse A","Reponse B","Reponse C","Reponse D"};
                pictures = new List<Sprite>() {null,null,null,null};
                for(var i=0; i<4; i++){
                    outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                    dialogue.globalConnectionPointIndex += 1;
                }
                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;
            
            case TypeOfNode.SentenceQuestion:
                rect = new Rect(position.x, position.y, width, height);
                initialRect =  new Rect(position.x, position.y, width, height);
        
                labelRect = new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                questions = new List<string>() {"Je dois y aller","","",""};
                pictures = new List<Sprite>() {null,null,null,null};
                for(var i=0; i<4; i++){
                    outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                    dialogue.globalConnectionPointIndex += 1;
                }
                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;
            case TypeOfNode.Cinematique:
                rect = new Rect(position.x, position.y, width, height);
                initialRect =  new Rect(position.x, position.y, width, height);
        
                labelRect = new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;
            
            case TypeOfNode.ConditionCheck :
                rect = new Rect(position.x, position.y, width, height);
                initialRect =  new Rect(position.x, position.y, width, height);
        
                labelRect = new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                name = "Condition";
                for(var i=0; i<2; i++){
                    outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                    dialogue.globalConnectionPointIndex += 1;
                }
                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;

            case TypeOfNode.ConditionChange :
                rect = new Rect(position.x, position.y, width, height);
                initialRect =  new Rect(position.x, position.y, width, height);
        
                labelRect = new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y+40, 175, 25);

                name = "Condition";

                outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                dialogue.globalConnectionPointIndex += 1;

                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;

            case TypeOfNode.TextEntry :
                rect = new Rect(position.x, position.y, width, height);
                initialRect =  new Rect(position.x, position.y, width, height);
        
                labelRect = new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y+40, 175, 25);
                name = "Text Entry";
                approTextEntry = new List<string>(){"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",""};
                for(var i=0; i<2; i++){
                    outPoint.Add(new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint,dialogue.globalConnectionPointIndex));
                    dialogue.globalConnectionPointIndex += 1;
                }
                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;
            
            case TypeOfNode.End :
                rect = new Rect(position.x, position.y, width, height/2);
                initialRect =  new Rect(position.x, position.y, width, height/2);
                        
                labelRect = new Rect(rect.x + 20.0f, rect.y + 10, 175, 25);
                initialLabelRect =  new Rect(rect.x + 20.0f, rect.y + 10, 175, 25);
                name = "End";
                inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint, dialogue.globalConnectionPointIndex);
                dialogue.globalConnectionPointIndex += 1;
                break;
        }
        style = nodeStyle;
        labelStyle = lStyle;
        defaultLabelStyle = lStyle;
        selectedLabelStyle = slStyle;
        defaultNodeStyle = nodeStyle;
        selectedNodeStyle = selectedStyle;
        OnRemoveNode = OnClickRemoveNode;
    }

    #if (UNITY_EDITOR) 
        public void Drag(Vector2 _centerScreen)
        {
            rect.position = _centerScreen + initialRect.position;
            labelRect.position =_centerScreen + initialLabelRect.position;
            centerScreen = _centerScreen;
        }
        public void Selected(Vector2 delta)
        {
            initialLabelRect.position += delta;
            initialRect.position += delta;
            Drag (centerScreen);
        }
        
        public void Draw()
        {
            switch(ton){
                case TypeOfNode.Start :
                    DrawStart();
                    break;
                case TypeOfNode.SentenceAnswer :
                    DrawAnswer();
                    break;
                case TypeOfNode.SentenceQuestion :
                    DrawQuestion();
                    break;
                case TypeOfNode.ConditionCheck :
                    DrawConditionCheck();
                    break;   
                case TypeOfNode.ConditionChange :
                    DrawConditionChange();
                    break;           
                case TypeOfNode.TextEntry :
                    DrawTextEntry();
                    break;
                case TypeOfNode.End :
                    DrawEnd();
                    break;
                case TypeOfNode.Cinematique :
                    DrawCine();
                    break;
            }
        }

        public void DrawCine()
        {
            inPoint.Draw();
            if(outPoint[0] != null){
                outPoint[0].Draw();
            }
            GUI.Box(rect, title, style);
            EditorGUI.LabelField(labelRect,name,labelStyle);
        }

        public void DrawStart(){
            if(outPoint[0] != null){
                outPoint[0].Draw();
            }
            GUI.Box(rect, title, style);
            EditorGUI.LabelField(labelRect,name,labelStyle);
        }
        public void DrawQuestion(){
            inPoint.Draw();
            for (var i = 0; i<=questionsLenght; i++)
            {
                outPoint[i].Draw(i);
            }
            GUI.Box(rect, title, style);
            EditorGUI.LabelField(labelRect,name,labelStyle);
            //EditorGUI.TextField(labelRect,"");
        }

        public void DrawAnswer(){
            inPoint.Draw();
            for (var i = 0; i<=answersLengh; i++)
            {
                outPoint[i].Draw(i);
            }
            GUI.Box(rect, title, style);
            EditorGUI.LabelField(labelRect,name,labelStyle);
            //EditorGUI.TextField(labelRect,"");
        }
        public void DrawConditionCheck(){
            inPoint.Draw();
            for (var i = 0; i<2; i++)
            {
                outPoint[i].Draw(i);
            }
            GUI.Box(rect, title, style);
            condition = (Switch)EditorGUI.ObjectField(labelRect,condition, typeof(Switch), false);

        }

        public void DrawConditionChange()
        {
            inPoint.Draw();
            outPoint[0].Draw(0);
            GUI.Box(rect, title, style);
            condition = (Switch)EditorGUI.ObjectField(labelRect,condition, typeof(Switch), false);

        }
        

        public void DrawTextEntry(){
            inPoint.Draw();
            for (var i = 0; i<2; i++)
            {
                outPoint[i].Draw(i);
            }
            GUI.Box(rect, title, style);
            textEntry = EditorGUI.TextField(labelRect,textEntry);
            //EditorGUI.TextField(labelRect,"");
        }
        public void DrawEnd(){
            inPoint.Draw();
            GUI.Box(rect, title, style);
            EditorGUI.LabelField(labelRect,name,labelStyle);
        }

        public bool ProcessEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0)
                    {
                        if (rect.Contains(e.mousePosition))
                        {
                            isDragged = true;
                            GUI.changed = true;
                            isSelected = true;
                            style = selectedNodeStyle;
                            labelStyle = selectedLabelStyle;
                            
                        }
                        else
                        {
                            GUI.changed = true;
                            isSelected = false;
                            style = defaultNodeStyle;
                            labelStyle = defaultLabelStyle;
                        }
                    }

                    if (e.button == 1 && isSelected && rect.Contains(e.mousePosition))
                    {
                        if(ton != TypeOfNode.Start)
                        {
                            ProcessContextMenu();
                        }
                            e.Use();
                    }
                    break;

                case EventType.MouseUp:
                    isDragged = false;
                    break;

                case EventType.MouseDrag:
                    if (e.button == 0 && isDragged)
                    {
                            e.Use();
                        if(ton != TypeOfNode.Start){
                            Selected(e.delta);
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }

        private void UpdateOutPoint(){
            
        }

        private void ProcessContextMenu()
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Remove node"), false, OnClickRemoveNode);
            genericMenu.ShowAsContext();
        }

        private void OnClickRemoveNode()
        {
            if (OnRemoveNode != null)
            {
                OnRemoveNode(this);
            }
        }
    #endif
}