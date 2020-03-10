# First Common Ancestor: Design an algorithm and write code to find the first common ancestor
# of two nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not
# necessarily a binary search tree

import binarysearchtree2

def FindFirstCommonAncestor(root, n1, n2):
    if (n1 == None or n2 == None or root == None):
        return None
    if (n1 == root or n2 == root):
        return root
    found = [0,0,0]
    TraversePostOrderToFindCommonAncestor(root, n1, n2, found)
    return found[2]

def TraversePostOrderToFindCommonAncestor(root, n1, n2, found):
    if found[0] == 1 and found[1] == 1 and found[2] == 0:
        print("parent is: ", root.value)
        found[2] = root.value
        return
    if root != None:
        TraversePostOrderToFindCommonAncestor(root.left, n1, n2, found)
        TraversePostOrderToFindCommonAncestor(root.right, n1, n2, found)
        if found[0] == 0:
            if n1.value == root.value:
                found[0] = 1
        if found[1] == 0:
            if n2.value == root.value:
                found[1] = 1

# driver code
t = binarysearchtree2.CreateBSTOfSize(10)
binarysearchtree2.TraverseBST(t)
a= FindFirstCommonAncestor(t.root, t.root.left.left, t.root.right.left)
print(a)