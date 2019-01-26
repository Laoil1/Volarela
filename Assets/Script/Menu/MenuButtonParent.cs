using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VolarelaNS.IGO;

public class MenuButtonParent : MonoBehaviour, IMenuButton
{
  	public int index;

    public virtual GameObject ThisGo
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    public  virtual InGameObjectBase igo { get{throw new System.NotImplementedException();} set{ throw new System.NotImplementedException();} }
    public virtual Image ThisImg { get{throw new System.NotImplementedException();} set{ throw new System.NotImplementedException();} }
    public virtual  Text ThisText { get{throw new System.NotImplementedException();} set{ throw new System.NotImplementedException();}}

    public virtual void OnClickSetMenu()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnCreated()
    {
        throw new System.NotImplementedException();
    }
}
