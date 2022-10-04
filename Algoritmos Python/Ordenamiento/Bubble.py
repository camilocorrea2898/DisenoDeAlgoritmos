# Python program for implementation of Bubble Sort
from datetime import datetime
from random import sample
lista = list(range(150)) 
vectorbs = sample(lista,100)

start = datetime.now()

def bubbleSort(arr):
    n = len(arr)
 
    # Traverse through all array elements
    for i in range(n):
 
        # Last i elements are already in place
        for j in range(0, n-i-1):
 
            # traverse the array from 0 to n-i-1
            # Swap if the element found is greater
            # than the next element
            if arr[j] > arr[j+1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
 
 
# Driver code to test above
arr = [64, 34, 25, 12, 22, 11, 90]
 
bubbleSort(arr)


print("Sorted array is:")
for i in range(len(vectorbs)):
    print("%d" % vectorbs[i], end=" ")

if __name__ == '__main__':
    arr = [12, 11, 13, 5, 6, 7]
    print("Given array is", end="\n")
    print(vectorbs)
    bubbleSort(vectorbs)
    print("Sorted array is: ", end="\n")
    print(vectorbs)

end = datetime.now()
 

print("The time of execution of above program is :",
      str(end-start)[5:])