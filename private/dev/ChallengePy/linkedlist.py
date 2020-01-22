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

def GenerateSampleLinkedList1():
    l = LinkedList()
    l.Insert(4)
    l.Insert(3)
    l.Insert(1)
    # l.Insert(9)
    # l.Insert(5)
    # l.Insert(6)
    # l.Insert(1)
    return l

def GenerateSampleLinkedList2():
    l = LinkedList()
    l.Insert(9)
    l.Insert(3)
    l.Insert(7)
    l.Insert(1)
    # l.Insert(9)
    # l.Insert(5)
    # l.Insert(6)
    # l.Insert(1)
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

# Sum Lists: You have two numbers represented by a linked list, where each node contains a single
# digit. The digits are stored in reverse order, such that the 1's digit is at the head of the iist. Write a
# function that adds the two numbers and returns the sum as a linked list.
# EXAMPLE
# input; ( 7 - > 1 -> 6) + (S -> 9 -> 2). That is, 617 + 295.
# Output; 2 -> 1 -> 9.That is, 912.
# FOLLOW UP
# Suppose the digits are stored in forward order. Repeat the above problem.
# Input (6 -> 1 -> 7) + (2 -> 9 -> S). That is, 617 + 295.
# Output: 9 -> 1 -> 2.That is, 912.

def AddNumbersInLinkedList(l1, l2):
    n1 = l1.head
    n2 = l2.head
    sumlist = LinkedList()
    sum = 0
    pow = 0
    carry = 0

    while (True):
        if (n1 != None and n2 != None):
            t = n1.value + n2.value + carry
            if t >=10:
                sum = sum + ((t % 10) * 10 ** pow)
                carry = 1
            else:
                sum = sum + (t * 10 ** pow)
                carry = 0
            n1 = n1.next
            n2 = n2.next
        elif (n1 != None and n2 == None):
            t = n1.value + carry
            if t >= 10:
                sum = sum + ((t % 10) * 10 ** pow)
                carry = 1
            else:
                sum = sum + (t * 10 ** pow)
                carry = 0
            n1 = n1.next
        elif (n1 == None and n2 != None):
            t = n2.value + carry
            if t >= 10:
                sum = sum + ((t % 10) * 10 ** pow)
                carry = 1
            else:
                sum = sum + (t * 10 ** pow)
                carry = 0
            n2 = n2.next
        else:
            if carry == 1:
                sum = sum + 10 ** pow
            break
        pow = pow + 1
    
    while(sum > 0):
        digit = sum % 10
        sumlist.Insert(digit)
        sum = int(sum / 10)
    return sumlist

# driver code
l1 = GenerateSampleLinkedList1()
l2 = GenerateSampleLinkedList2()
PrintLinkedList(l1)
PrintLinkedList(l2)

sumlist = AddNumbersInLinkedList(l1, l2)
PrintLinkedList (sumlist)
# l.Reverse()
# RemoveDuplicates(l)
# PartitionLinkedList(l,4)
# PrintLinkedList(l)

