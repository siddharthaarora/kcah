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
    l.Insert(4)
    l.Insert(3)
    l.Insert(1)
    l.Insert(9)
    l.Insert(5)
    l.Insert(6)
    l.Insert(7)
    l.Insert(2)
    return l

def PrintLinkedList(l):
    h = l.head
    while(h.next != None):
        print(h.value, end="")
        if ( h.next.next != None):
            print(" --> ", end="")
        h = h.next

# driver code
l = GenerateSampleLinkedList()
PrintLinkedList(l)
l.Reverse()
#PrintLinkedList(l)
