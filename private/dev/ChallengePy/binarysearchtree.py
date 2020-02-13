# Validate BST: Implement a function to check if a binary tree is a binary search tree.
import graph

def IsBinarySearchTree(t):
    return (IsBinarySearchSubtree(t.root, None, t.root.left, "LEFT") or IsBinarySearchSubtree(t.root, None, t.root.right, "RIGHT"))

def IsBinarySearchSubtree(root, parent, node, leftOrRight):
    if (node == None):
        return True

    if (leftOrRight == "LEFT"):
        if (node.value >= root.value):
            return False
        if (parent != None):
            if (node.value >= parent.value):
                return False
    elif (leftOrRight == "RIGHT"):
        if (node.value < root.value):
            return False
        if (parent != None):
            if (node.value < parent.value):
                return False
    if (node.left != None):
        return IsBinarySearchSubtree(root, node, node.left, "LEFT")
    if (node.right != None):
        return IsBinarySearchSubtree(root, node, node.right, "RIGHT")
    
    return True

# driver code
bst = graph.CreateSampleBST()
graph.TraverseBST(bst)
b = IsBinarySearchTree(bst)
print(b)