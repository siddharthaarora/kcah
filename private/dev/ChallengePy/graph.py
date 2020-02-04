import queue
import enum

class VisitState(enum.Enum):
    NotVisited = 1
    Visiting = 2
    Visited = 3

class Node:
    def __init__(self):
        self.value = None
        self.left = None
        self.right = None
        self.children = []
        self.state = VisitState.NotVisited

class Tree:
    def __init__(self):
        self.root = None

class Graph:
    def __init__(self):
        self.nodes = []

    def Insert(self, node):
        self.nodes.append(node)

def CreateSampleGraph():
    n1 = Node()
    n1.value = 1
    n2 = Node()
    n2.value = 2
    n3 = Node()
    n3.value = 3
    n4 = Node()
    n4.value = 4
    n5 = Node()
    n5.value = 5
    n6 = Node()
    n6.value = 6
    n1.children = [n4, n2]
    n2.children = [n5]
    n3.children = [n5]
    n5.children = [n6]
    n6.children = [n1]

    g = Graph()
    g.Insert(n1)
    g.Insert(n2)
    g.Insert(n3)
    return g

def CreateSampleBST():
    n1 = Node()
    n1.value = 1
    n2 = Node()
    n2.value = 2
    n3 = Node()
    n3.value = 3
    n4 = Node()
    n4.value = 4
    n5 = Node()
    n5.value = 5
    n6 = Node()
    n6.value = 6

    bst = Tree()
    bst.root = n3
    n3.right = n5
    n5.left = n4
    n5.right = n6
    n3.left = n2
    n2.left = n1
    return bst

def TraverseGraphBreadthFirst(g):
    if g == None or g.nodes == None or len(g.nodes) == 0:
        print ("Graph is empty!")
    
    q = queue.Queue()

    for i in range (0, len(g.nodes)):
        q.put(g.nodes[i])

    while(q.empty() == False):
        n = q.get()
        for i in range(0, len(n.children)):
            print(n.value, "-->", n.children[i].value, end="; ")
            if (n.children[i].state == VisitState.NotVisited):
                q.put(n.children[i])
                n.children[i].state = VisitState.Visited
        print()

def TraverseBST(t):
    if (t == None):
        print("Tree is empty!")

    q = queue.Queue()
    q.put(t.root)
    while(q.empty() == False):
        n = q.get()
        print(n.value, end = ": ")
        if (n.left != None):
            q.put(n.left)
            print("Left-->", n.left.value, end=" ")
        if (n.right != None):
            q.put(n.right)
            print("Right-->", n.right.value, end = " ")
        print()

# Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a
# route between two nodes.
# Algo - simple breadth first graph traversal
def IsRouteExistsBetweenNodes(g, startNode, endNode):
    if g == None or g.nodes == None or len(g.nodes) == 0:
        print ("Graph is empty!")
        return False
    
    if startNode == endNode:
        return True

    q = queue.Queue()

    startNode.state = VisitState.Visiting
    q.put(startNode)
    while(q.empty() == False):
        n = q.get()
        if (n != None):
            for i in range(0, len(n.children)):
                if (n.children[i].state == VisitState.NotVisited):
                    if (endNode == n.children[i]):
                        return True
                    else:
                        n.children[i].state = VisitState.Visiting
                        q.put(n.children[i])
            n.state = VisitState.Visited
    return False

# Minimal Tree: Given a sorted (increasing order) array with unique integer elements, write an
# algorithm to create a binary search tree with minimal height.
def GenerateBalancedBST(a):
    bst = Tree()
    if (a != None or len(a) != 0):
        start = 0
        end = len(a) - 1
        bst.root = CreateBST(a, start, end)
        return bst
    return bst

def CreateBST(a, start, end):
    if (end < start):
        return None
    node = Node()
    node.value = a[(end + start) // 2]
    node.left = CreateBST(a, start, (start + end) // 2 - 1)
    node.right = CreateBST(a, (start + end) // 2 + 1, end) 
    return node

# driver code

# Graph Traversal
# g = CreateSampleGraph()
#TraverseGraphBreadthFirst(g)

# Route Exists
# n1 = Node()
# n1.value = 1
# n2 = Node()
# n2.value = 2
# n3 = Node()
# n3.value = 3
# n4 = Node()
# n4.value = 4
# n5 = Node()
# n5.value = 5
# n6 = Node()
# n6.value = 6
# n1.children = [n4, n2]
# n2.children = [n5]
# n3.children = [n5]
# n5.children = [n6]
# n6.children = [n1]
# g = Graph()
# g.Insert(n1)
# g.Insert(n2)
# g.Insert(n3)
# print(IsRouteExistsBetweenNodes(g, n1, n3))

# BST Traversal
#bst = CreateSampleBST()
#TraverseBST(bst)

# BST from sorted array
a = [1,2,3,4,5,6]
bst = GenerateBalancedBST(a)
TraverseBST(bst)