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
        
    def Length(self):
        l = 0
        head = self.head
        while (head != None):
            l = l+1
            head = head.next
        return l
    
def GenerateSampleLinkedList1():
    l = LinkedList()
    l.Insert(4)
    l.Insert(2)
    l.Insert(1)
    l.Insert(3)
    l.Insert(4)
#    l.Insert(6)
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


# Palindrome: Implement a function to check if a linked list is a palindrome
class Result:
    def __init__(self):
        self.node = LinkedListNode()
        self.result = False

def IsLinkedListPalindrome(l):
    length = l.Length()
    p = IsLinkedListPalindromeRecurse(l.head, length)
    return p.result


def IsLinkedListPalindromeRecurse(head, l):
    print("head: ", head.value)
    if (head == None) or (l <= 0):
        res = Result()
        res.node = head
        res.result = True
        return res
    elif (l == 1):
        res = Result()
        res.node = head.next
        res.result = True
        return res
    
    res = IsLinkedListPalindromeRecurse(head.next, l - 2)
    print("res: ", res.node.value)

    if (res.result == False or res.node == None):
        return res

    if (head.value == res.node.value):
        res.result = True
    else:
        res.result = False
    
    res.node = res.node.next

    return res

# Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the
# beginning of the loop.
# DEFINITION
# Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node, so
# as to make a loop in the linked list.
# EXAMPLE
# Input: A -> B -> C -> D -> E -> C [the same C as earlier]
# Output: C

def IsCircularLinkedList(l):
    if (l == None):
        return False
    
    s = l.head
    if (s.next != None):
        f = s.next
    else:
        return False
    
    while(s != None):
        if (s == f):
            return True
        s = s.next
        if (f != None and f.next != None):
            f = f.next.next
    return False

# Intersection: Given two (singly) linked lists, determine if the two lists intersect. Return the
# intersecting node. Note that the intersection is defined based on reference, not value. That is, if the
# kth node of the first linked list is the exact same node (by reference) as the j t h node of the second
# linked list, then they are intersecting.

def GetLinkedListIntersectionNode(l1, l2):
    if (l1 == None or l2 == None):
        return None
    h1 = l1.head
    len1 = 0
    h2 = l2.head
    len2 = 0
    # get lenght of l1
    while(h1 != None):
        len1 = len1+1
        h1 = h1.next
    # get lenght of l1
    while(h2 != None):
        len2 = len2+1
        h2 = h2.next
    if (h1 != h2):
        print("The lists don't intersect!")
        return None
    h1 = l1.head
    h2 = l2.head
    while (len1 >= len2):
        h1 = h1.next
        len1 = len1-1
    while (len2 >= len1):
        h2 = h2.next
        len2 = len2-1    
    while(h1 != None and h2 != None):
        if (h1 == h2):
            return h1
        h1 = h1.next
        h2 = h2.next

# driver code
def main():
    l1 = GenerateSampleLinkedList1()
    # l2 = GenerateSampleLinkedList2()
    # PrintLinkedList(l1)
    # PrintLinkedList(l1)
    # print(IsLinkedListPalindrome(l1))
    # sumlist = AddNumbersInLinkedList(l1, l2)
    # PrintLinkedList (sumlist)
    # l.Reverse()
    # RemoveDuplicates(l)
    # PartitionLinkedList(l,4)
    # l1.last.next = l1.head
    print(IsCircularLinkedList(l1))

#main()