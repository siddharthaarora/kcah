# Successor: Write an algorithm to find the "next" node (i.e., in-order successor) of a given node in a
# binary search tree. You may assume that each node has a link to its parent.
import binarysearchtree2

def FindNextNodeinBST(node):
    if (node == None):
        return None
    
    if (node.right == None) and (node.parent.value > node.value):
        return node.parent.value
    
    if (node.right == None) and (node.parent.right == node) and (node.parent.value < node.value):
        return FindNextParentNode(node)

    if (node.right != None):
        return FindSmallestNodeInLeftSubtree(node.right)

def FindSmallestNodeInLeftSubtree(n):
    if (n.left == None):
        return n.value
    while(n.left != None):
        n = n.left
    return n.value

def FindNextParentNode(n):
    parent = n.parent
    while (parent != None):
        if (parent.value < n.value):
            parent = parent.parent
        else:
            return parent.value
    return None
    
# driver code
def main():
    bst = binarysearchtree2.CreateBSTOfSize(20)
    binarysearchtree2.TraverseBST(bst)

    node = bst.root.left.right
    next = FindNextNodeinBST(node)
    print("Next node of ", node.value, " is ", next)

main()