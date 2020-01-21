class LinkedListNode:
    def __init__(self):
        self.value = 0
        self.next = None

class LinkedList:
    def __init__(self):
        self.head = LinkedListNode()
        self.last = LinkedListNode()
        self.head.value = None
        self.head.next = None
        self.last.value = None
        self.last.next = None

    def Insert(self, val):
        n = LinkedListNode()
        n.value = val
        n.next = None
        
        if (self.head.value == None):
            self.head = n
            self.last = n
        else:
            self.last.next = n
            self.last = n

    def Reverse(self, c = None, n = None):
        if (c is None and n is None):
            c = self.head
            n = self.head.next
        elif (n.next != None):
            c = n
            n = n.next
        
        if (n.next != None):
            print("recursing: ", c.value, n.value)
            self.Reverse(c, n)

        print("rewinding: ", c.value, n.value)
        n.next = c

        if (c == self.head):
            self.head = self.last
            self.last = c
            print("head: ", self.head.value, "last: ", self.last.value)

def GenerateSampleLinkedList():
    l = LinkedList()
    l.Insert(0)
    l.Insert(3)
    l.Insert(1)
    l.Insert(9)
    l.Insert(5)
    l.Insert(6)
    l.Insert(10)
    return l

def PrintLinkedList(l):
    h = l.head
    while(h != None):
        print(h.value, end="")
        if ( h.next != None):
            print(" --> ", end="")
        h = h.next
    print()

def RemoveDuplicates(l):
    h = l.head
    map = {}
    curr = None
    while(h != None):
        if h.value in map:
            curr.next = h.next
        else:
            map[h.value] = 1
            curr = h
        h = h.next
    print(map)

# Partition; Write code to partition a linked list around a value x, such that all nodes less than x come
# before all nodes greater than or equal tox. If x is contained within the list, the values of x only need
# to be after the elements less than x (see below). The partition element x can appear anywhere in the
# "right partition"; it does not need to appear between the left and right partitions.
# EXAMPLE
# input: 3 -> S -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
# Output: 3 -> 1 -> 2 -> 5 -> 5 -> 10 -> 8 

def PartitionLinkedList(l, x):
    h = l.head
    curr = h
    prev = h
    xnode = LinkedListNode()
    xnode.value = x
    i = 0
    while(curr != None):
        print(h.value, prev.value, curr.value)
        if(curr.value < x):
            if (curr == h):
                curr = curr.next
            else:
                prev.next = curr.next
                curr.next = h.next
                h.next = curr
                curr = prev.next
        else:
            if (xnode.next == None):
                xnode.next = curr.next
                curr = xnode
                prev.next = xnode
            prev = prev.next
            curr = curr.next
        i = i + 1
        if (i == 7):
            break

# driver code
l = GenerateSampleLinkedList()
PrintLinkedList(l)
#l.Reverse()
#RemoveDuplicates(l)
PartitionLinkedList(l,4)
PrintLinkedList(l)
