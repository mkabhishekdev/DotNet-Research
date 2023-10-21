using System.Drawing;

public class SinglyLinkedListImpl
{
    Node head;   // head of the list

    public class Node
    {
        public int data;
        public Node next;
        public Node(int x)
        {
            data = x;
            next = null;
        }
    }

// Insert - At front of the linked list
   public void InsertFront(int new_data)
   {
       Node new_node = new Node(new_data); //create the new node
       new_node.next = head;    // point the new node next to head
       head = new_node;  // update head of the linked list to be the new node
   }


// Insert - After a given Node
   public void InsertAfterGiven(Node prev_node, int new_data)
   {
       if(prev_node == null)
       {
           return;
       }
       Node new_node = new Node(new_data);
       new_node.next = prev_node.next;
       prev_node.next = new_node;
   }


// Insert - At the end of the linked list
  public void InsertAtEnd(int new_data)
  {
      Node new_node = new Node(new_data);

      if(head == null)
      {
          head = new Node(new_data);
          return;
      }

      new_node.next = null;
      Node last = head;
      while(last.next != null)
      {
        last = last.next;
      }
      last.next = new_node;
  }
    
}