import queue

class Node:
    def __init__(self):
        self.value = None
        self.left = None
        self.right = None
        self.parent = None

class Tree:
    def __init__(self):
        self.root = None

def CreateBSTOfSize(n):
    a = list(range(1,n))
    return CreateBSTFromSortedArray(a)

def CreateBSTFromSortedArray(a):
    bst = Tree()
    if (a != None or len(a) != 0):
        start = 0
        end = len(a) - 1
        bst.root = CreateBSTInternal(a, start, end, bst.root)
        return bst
    return bst

def CreateBSTInternal(a, start, end, parent):
    if (end < start):
        return None
    node = Node()
    node.parent = parent
    node.value = a[(end + start) // 2]
    node.left = CreateBSTInternal(a, start, (start + end) // 2 - 1, node)
    node.right = CreateBSTInternal(a, (start + end) // 2 + 1, end, node) 
    return node

def TraverseBST(t):
    if (t == None):
        print("Tree is empty!")

    q = queue.Queue()
    q.put(t.root)
    while(q.empty() == False):
        n = q.get()
        print(n.value, end = ": ")
        if (n.parent != None):
            print("Parent-->", n.parent.value, end=" ")
        if (n.left != None):
            q.put(n.left)
            print("Left-->", n.left.value, end=" ")
        if (n.right != None):
            q.put(n.right)
            print("Right-->", n.right.value, end = " ")
        print()

# driver code
def main():
    bst = CreateBSTOfSize(10)
    TraverseBST(bst)
#main()