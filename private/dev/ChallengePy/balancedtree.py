import graph

# Check Balanced: implement a function to check if a binary tree is balanced. For the purposes of
# this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any
# node never differ by more than one.

def CheckBalancedTree(bst):
    if (bst == None or bst.root == None):
        return True
    lcount = [0]
    rcount = [0]
    b = CheckBalancedSubtree(bst.root, lcount, rcount, bst.root)
    return b

def CheckBalancedSubtree(node, lcount, rcount, root):
    if (node.left != None):
        lcount[0] = lcount[0] + 1
        CheckBalancedSubtree(node.left, lcount, rcount, root)

    if (node.right != None):
        rcount[0] = rcount[0] + 1
        CheckBalancedSubtree(node.right, lcount, rcount, root)

    if (root == node):
        if (lcount[0] - rcount[0] > 1):
            return False
        else:
            return True

# driver code
bst = graph.CreateSampleBST()
graph.TraverseBST(bst)
b = CheckBalancedTree(bst)
print(b)