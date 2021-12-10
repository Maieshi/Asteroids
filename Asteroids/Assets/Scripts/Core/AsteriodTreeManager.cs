using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodTreeManager 
{
    List<ASSteroidTree> TreeList = new List<ASSteroidTree>();

    public int listCount
    {
        get{return TreeList.Count;}
    }

    public void CreateTree(AsteroidTreeNode node)
    {
        ASSteroidTree tree = new ASSteroidTree(node);
        
        TreeList.Add(tree);
    }

    public void AddChild(AsteroidTreeNode parent,AsteroidTreeNode child)
    {
        if(parent.left == null)parent.left = child;
        else if(parent.middle == null)parent.middle = child;
        else parent.right = child;
    }

    public int GetTreeDepth(AsteroidTreeNode node)
    {
        return AsteroidTreeNode.GetDepth(node);
    }

    // void logtree(AsteroidTreeNode root)
    // {
    //     Debug.Log(root+" depth:"+AsteroidTreeNode.GetDepth(root));

    //     if(root.left!=null) logtree(root.left);
    //     if(root.middle!=null) logtree(root.middle);
    //     if(root.right!=null) logtree(root.right);
    // }

    // public void debug(AsteroidTreeNode node)
    // {
    //     logtree(FindRoot(node));
    // }
    
    ASSteroidTree FindTree(AsteroidTreeNode root)
    {
        return TreeList.Find(x=> x.root == root);
    }

    AsteroidTreeNode FindRoot(AsteroidTreeNode node)
    {
        return AsteroidTreeNode.GetRoot(node);
    }

    public int OnDeath(AsteroidTreeNode node)
    {
        node.isDestroyed = true;

        ASSteroidTree tree = FindTree( FindRoot(node));

        int depth = GetTreeDepth(node);
        
        if(tree.isDestroyed&&tree.minDepth==3)
        {
            

            TreeList.Remove(tree);
            ASSteroidTree.ClearTree(tree.root);
        }

        return depth;
    }




    
}
