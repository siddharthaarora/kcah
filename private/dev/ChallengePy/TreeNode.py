class TreeNode:
    def __init__(self):
        self.value = 0
        self.left = None
        self.right = None
    
    def Insert(self, val):
        if (self.value == 0):
            self.value = val
        elif (self.value > val):
            if (self.left == None):
                self.left = TreeNode()
            self.left.Insert(val)
        else:
            if (self.right == None):
                self.right = TreeNode()
            self.right.Insert(val)

    def PrintTree(self):
        self.PrintTreeNode(False, "")
    
    def PrintTreeNode(self, isRightNode, indent):
        if self.right:
            if isRightNode:
                self.right.PrintTreeNode(True, indent + "        ")
            else:
                self.right.PrintTreeNode(False, indent + " |    ")
        print(indent, end="")

        if isRightNode:
            print("/", end="")
        else:
            print("\\", end="")
        
        print("---- ", end="")

        self.PrintNodeValue()

        if self.left:
            if isRightNode:
                self.left.PrintTreeNode(True, indent + " |    ")
            else:
                self.left.PrintTreeNode(False, indent + "        ")

    def PrintNodeValue(self):
        if self.value == 0:
            print("<null")
        else:
            print(self.value)

def GenerateSampleTree(root):
    root.Insert(10)
    root.Insert(-3)
    root.Insert(0)
    root.Insert(5)
    root.Insert(9)

def GenerateBSTFromSortedArray(root):
    a = [10,-3,1,5,9]
    count = len(a)
    mid = int(count / 2)
    root.Insert(a[mid])
    left = mid - 1
    right = mid + 1
    while(True):
        if (left < 0 and right > count-1):
            return
        if (left >= 0):
            root.Insert(a[left])
        if (right <= count -1):
            root.Insert(a[right])
        left -= 1
        right += 1


def main():
    #root = TreeNode()
    #GenerateSampleTree(root)
    #root.PrintTree()

    root1 = TreeNode()
    GenerateBSTFromSortedArray(root1)
    root1.PrintTree()

main()