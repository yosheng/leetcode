using System;
using System.Collections;
using System.Collections.Generic;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // 输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
            // 输出：7 -> 0 -> 8
            // 原因：342 + 465 = 807

            // ListNode l1 = new ListNode(2);
            // l1.next = new ListNode(4);
            // l1.next.next = new ListNode(3);
            //
            // ListNode l2 = new ListNode(5);
            // l2.next = new ListNode(6);
            // l2.next.next = new ListNode(4);
            //
            // ListNode l3 = AddTwoNumbers(l1, l2);
            // while (l3 != null)
            // {
            //     Console.WriteLine(l3.val);
            //     l3 = l3.next;
            // }
            
            // 342 + 465 = 807
            Print(LeetCodeAnswer(BuildNode(new int[]{3,4,2}),BuildNode(new int[]{4,6,5})));
            // 3416
            Print(LeetCodeAnswer(BuildNode(new int[]{1,0,9,5}),BuildNode(new int[]{2,3,2,1})));
            // 10
            Print(LeetCodeAnswer(BuildNode(new int[]{5}),BuildNode(new int[]{5})));
            // 243 + 564 = 807
            Print(AddTwoNumbers(BuildNode(new int[]{2,4,3}),BuildNode(new int[]{5,6,4})));
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // 进位
            int carry = 0;
            ListNode headNode = null;
            ListNode currentNode = null;
            while (l1 != null || l2 != null)
            {
                // 先进行相加
                var node = new ListNode((l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry);
                
                // 判断是否需要进位
                if (node.val > 9)
                {
                    carry = 1;
                    node.val -= 10;
                }
                else
                {
                    carry = 0;
                }

                // 判断是否为第一次头节点
                headNode = headNode == null ? node : headNode;
                
                // 如果不存在当前节点则默认node作为当前节点
                if (currentNode == null)
                {
                    currentNode = node;
                }
                else
                {
                    // 如果存在当前节点则将node指向当前的下个节点
                    currentNode.next = node;
                    currentNode = node;
                }

                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }

            // 出现进位但l1和l2下一数字都为0时上述循环无法进行，做特殊处理
            if (carry == 1)
            {
                currentNode.next = new ListNode(1);
            }

            return headNode;
        }

        static ListNode AddTwoNumbersByLink(ListNode l1, ListNode l2)
        {
            var s1 = new Stack<int>();
            var s2 = new Stack<int>();
            ListNode head = null;
            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int sum = 0;
            int sign = 0;
            while (s1.Count > 0 || s2.Count > 0)
            {
                sum = sign; // 前一次计算进位的值
                sum += s1.Count > 0 ? s1.Pop() : 0;
                sum += s2.Count > 0 ? s2.Pop() : 0;
                ListNode temp = new ListNode(sum % 10); //新增元素
                temp.next = head; // 把"头"改成新增元素
                head = temp; //把 自己设置为"头"
                sign = sum / 10; // 相加总和超过10则进位
            }
            
            // var s3 = new Stack<int>();
            // while (head != null)
            // {
            //     s3.Push(head.val);
            //     head = head.next;
            // }
            //
            // while (s3.Count > 0)
            // {
            //     var temp = new ListNode(s3.Pop());
            // }

            return head;
        }
        
        static ListNode AddTwoNumbersByStrToInt(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);

            // 递归获取节点数字并放到栈中
            var stack1 = new Stack();
            RecursiveGetVal(stack1, l1);

            var stack2 = new Stack();
            RecursiveGetVal(stack2, l2);

            // 出栈后字符串转数字
            var operateStr1 = string.Empty;
            while (stack1.Count > 0)
            {
                operateStr1 = operateStr1 + stack1.Pop();
            }

            var operateStr2 = string.Empty;
            while (stack2.Count > 0)
            {
                operateStr2 = operateStr2 + stack2.Pop();
            }

            // 计算结果
            var ansStr = (long.Parse(operateStr1) + long.Parse(operateStr2)).ToString();

            // 放回 ListNode
            var ansArray = ansStr.ToCharArray();

            // 重新入栈
            var ansStack = new Stack();
            for (int i = 0; i < ansArray.Length; i++)
            {
                ansStack.Push(ansArray[i]);
            }

            ListNode newHead = null;
            ListNode next = null;


            result = newHead = new ListNode(int.Parse(ansStack.Pop().ToString()));

            while (ansStack.Count > 0)
            {
                next = new ListNode(int.Parse(ansStack.Pop().ToString()));
                newHead.next = next;
                newHead = next;
            }

            return result;
        }

        static void RecursiveGetVal(Stack stack, ListNode node)
        {
            stack.Push(node.val);
            if (node.next != null)
            {
                RecursiveGetVal(stack, node.next);
            }
        }

        static ListNode LeetCodeAnswer(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0); //当前节点，进行迭代
            ListNode head = result; //头节点
            int next = 0; //若相加大于10进位则next==1
            while (l1 != null || l2 != null)
            {
                int value1, value2;
                if (l1 == null) //当l1或l2为空时，假设值为0
                    value1 = 0;
                else
                    value1 = l1.val;
                if (l2 == null)
                    value2 = 0;
                else
                    value2 = l2.val;
                int temp = value1 + value2;
                result.val = temp + next;
                if (result.val < 10) //判断是否进位
                {
                    next = 0;
                }
                else
                {
                    result.val = result.val - 10;
                    next = 1;
                }

                if (l1 != null) //l1和l2不为空时迭代
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
                if (l1 == null && l2 == null) //同时为空时结束，避免下方语句进行使得结果错误
                    break;
                result.next = new ListNode(0);
                result = result.next;
            }

            if (next == 1) //出现进位但l1和l2下一数字都为0时上述循环无法进行，做特殊处理
            {
                result.next = new ListNode(1);
            }

            return head;
        }
        
        private static void Print(ListNode node){
            while (node != null){
                Console.Write(node.val + " -> ");
                node = node.next;
            }
            Console.WriteLine("");
        }

        private static ListNode BuildNode(int[] nums){
            var head = new ListNode(nums[nums.Length - 1]);
            ListNode nextNode = head;
            for (int index = nums.Length - 2; index >=0; index--){
                var node = new ListNode(nums[index]);
                nextNode.next = node;
                nextNode = node;
            }
            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
}