namespace LinkedListCycle{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public class Program
    {

        public async Task<bool> HasCycle(ListNode head, int Position)
        {
            ListNode slow = head;
            ListNode fast = head;
            if (head == null || head.next == null)
            {
                return false;
            }
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }
            return false;

        }

        static async Task Main(string[] args)
        {
            ListNode node1 = new ListNode(3);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(0);
            ListNode node4 = new ListNode(-4);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node4;
            Program solution = new Program();
            bool hasCycle = await solution.HasCycle(node1, 2);
            Console.WriteLine("Has cycle: " + hasCycle);
        }
    }

}
