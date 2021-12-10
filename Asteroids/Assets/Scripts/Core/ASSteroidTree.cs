using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASSteroidTree
{
    
    public AsteroidTreeNode root;

    public ASSteroidTree(AsteroidTreeNode root)
    {
        this.root = root;
    }

    public bool isDestroyed
    {
        get{return CheckDestroyed(root);}
    }
    
    public int minDepth
    {
       get{ return GetMinDepth(root);}
    }



    int GetMinDepth(AsteroidTreeNode root)
    {
        int left =0, right =0, mid =0;

        if(root.left!=null) left = GetMinDepth(root.left);
        if(root.right!=null) right = GetMinDepth(root.right);
        if(root.middle!=null) mid = GetMinDepth(root.middle);

        return Mathf.Min(Mathf.Min(left,mid),right)+1; 

    }

    bool CheckDestroyed(AsteroidTreeNode root)
    {
        bool selfDestroyed , leftDestroyed , midDestroyed, rightDestroyed;

        selfDestroyed = root.isDestroyed;

        if(root.left!=null) leftDestroyed = CheckDestroyed(root.left);
        else leftDestroyed = root.isDestroyed;
        if(root.right!=null) rightDestroyed = CheckDestroyed(root.right);
        else rightDestroyed = true;
        if(root.middle!=null) midDestroyed = CheckDestroyed(root.middle);
        else midDestroyed = true;
        
        if(selfDestroyed&&midDestroyed&&leftDestroyed&&rightDestroyed) return true;
        else return false;
    }

    public static void ClearTree(AsteroidTreeNode root)
    {
        if(root.left!=null)ClearTree(root.left);
        if(root.middle!=null)ClearTree(root.middle);
        if(root.right!=null)ClearTree(root.right);

        root.parent =null;
        root=null;
        return;
    }

    
    

    

}
