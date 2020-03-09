# Build Order: You are given a list of projects and a list of dependencies (which is a list of pairs of
# projects, where the second project is dependent on the first project). All of a project's dependencies
# must be built before the project is. Find a build order that will allow the projects to be built. If there
# is no valid build order, return an error.
# EXAMPLE
# Input:
#    projects : a, b, c, d, e, f
#    dependencies: (a, d), (f , b) , (b, d) , (f , a), (d, c)
#    Output: e, c, d, b, a, f    [f, e, a, b, d, c]

import graph
#pg 262
def FindBuildOrder(d):
    g = BuildGraphFromDependencies(d)
    graph.TraverseGraphDepthFirst(g)

def BuildGraphFromDependencies(d):
    g = graph.Graph()
    map = dict()
    for t in d:
        parent = None
        child = None
        if t[0] in map:
            parent = map[t[0]]
        else:
            parent = graph.Node()
            parent.value = t[0]
            map[t[0]] = parent
            g.Insert(parent)
        if t[1] in map:
            child = map[t[1]]
        else:
            child = graph.Node()
            child.value = t[1]
            map[t[1]] = child
            g.Insert(child)
        parent.children.append(child)
    return g

# driver code
d = [("e", "d"), ("f" , "b") , ("b", "d") , ("f" , "a"), ("d", "c")]
FindBuildOrder(d)