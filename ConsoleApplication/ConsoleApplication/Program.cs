using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;
using System.Net;

namespace ConsoleApplication
{
    public class Node
    {
        public int? Data;
        public Node LNode;
        public Node RNode;

        public Node()
        { }
        public Node(int d)
        {
            Data = d;
            LNode = null;
            RNode = null;
        }

        public Queue<Node> queue = new Queue<Node>();
        public int lcount = 0;


        public int height(ref Node Root)
        {
            if (Root == null)
            {
                return -1;
            }
            int lh = height(ref Root.LNode);
            int rh = height(ref Root.RNode);

            return (lh > rh ? lh : rh) + 1;
        }
        public int Lheight(ref Node Root)
        {
            //int rcount = 0;

            if (Root.LNode != null)
            {

                lcount++;

                Lheight(ref Root.LNode);


            }
            //else
            //{

            //}
            return lcount;
        }

        //public int Rheight(ref Node Root)
        //{
        //    //int rcount = 0;

        //    if (Root.RNode != null)
        //    {
        //        rcount++;

        //        Rheight(ref Root.RNode);


        //    }
        //    return rcount;
        //}

        public void load(ref Node root, int v)
        {
            //Node root = this;

            //Node asd = new Node(v);
            if (root == null)
            {
                root = new ConsoleApplication.Node(v);
                //return root;
            }
            else
            {
                if (v <= root.Data)
                {
                    load(ref root.LNode, v);
                }
                else
                {
                    load(ref root.RNode, v);
                }
            }



            //return root;

        }

        void print(Node R)
        {
            if (R != null)
            {
                if (R.LNode != null)
                {
                    Console.WriteLine(R.LNode.Data + " ");
                }
                if (R.RNode != null)
                {
                    Console.WriteLine(R.RNode.Data + " ");
                }
            }
        }

        public void preOrder(ref Node Root)
        {
            if (Root == null)
            {
                return;
            }
            else
            {
                Console.WriteLine(Root.Data);

                preOrder(ref Root.LNode);

                preOrder(ref Root.RNode);


            }
        }

        public void INOrder(ref Node Root)
        {
            if (Root == null)
            {
                return;
            }
            else
            {

                INOrder(ref Root.LNode);
                Console.WriteLine(Root.Data);

                INOrder(ref Root.RNode);


            }
        }


        public void levelOrder(ref Node Root)
        {
            if (Root != null)
            {
                queue.Enqueue(Root);

                while (queue.Count != 0)
                {
                    var aa = queue.First();

                    Console.Write(aa.Data);

                    if (aa.LNode != null)
                    {
                        queue.Enqueue(aa.LNode);
                    }
                    if (aa.RNode != null)
                    {
                        queue.Enqueue(aa.RNode);
                    }

                    queue.Dequeue();
                }

                //print(Root.LNode);

                //print(Root.RNode);

                //levelOrder(ref Root.LNode);

                //levelOrder(ref Root.RNode);
            }
            else
            {
                return;
            }
        }

    }
    //  public class ListNode
    //  {
    //    public int val;
    //    public ListNode next;
    //    public ListNode(int x) { val = x; }
    //}

    //  public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    //  {

    //      ListNode q = l1;

    //      string s = "";

    //      string s1 = "";

    //      while (q != null)
    //      {
    //          s = s + q.val.ToString();
    //          q = q.next;
    //      }

    //      q = l2;

    //      while (q != null)
    //      {
    //          s1 = s1 + q.val.ToString();
    //          q = q.next;
    //      }

    //      int qw = Convert.ToInt32(s.Reverse()) + Convert.ToInt32(s1.Reverse());

    //      q = null;

    //      foreach (char c in qw.ToString().Reverse())
    //      {
    //          q.val = Convert.ToInt32(c.ToString());
    //          q = q.next;
    //      }
    //      return q;
    //  }
    //class Program
    //{

    //public static int LengthOfLongestSubstring(string s)
    //{
    //    int cnt = 0;
    //    string ste = "";
    //    int max = 0;
    //    int k = 1;

    //    if (s.Length > k)
    //    {
    //        foreach (char c in s.ToCharArray())
    //        {
    //            int pos = s.Substring(k).IndexOf(c);

    //            max = pos > max ? pos : max;

    //            k++;

    //            //foreach(char d in s.ToCharArray().Skip(k))
    //            //{

    //            //}


    //            //if(ste.Contains(c.ToString()))
    //            //{
    //            //ste = c.ToString();
    //            //max = cnt > max ? cnt : max;
    //            //cnt = 1;
    //            //}
    //            //else
    //            //{
    //            //ste =  ste + c.ToString();
    //            //cnt++;
    //            //}
    //        }

    //        max++;
    //    }
    //    else
    //    {
    //        if (s.Length != 0)
    //            max = k;
    //    }
    //    //max = cnt > max ? cnt : max;

    //    return max;

    //}



    class Program
    {

        static void Main(string[] args)
        {
            Uri url = new Uri("https://freelance1.api.crm.dynamics.com/XRMServices/2011/Organization.svc");

            ClientCredentials cred = new ClientCredentials();
            cred.UserName.UserName = "karnall@freelance1.onmicrosoft.com";
            cred.UserName.Password = "RESistor69";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (OrganizationServiceProxy proxy = new OrganizationServiceProxy(url,null,cred,null))
            {
                IOrganizationService service = (IOrganizationService)proxy;

                Entity le = new Entity("lead");
                le["firstname"] = "AkarhK";
                le["lastname"] = "AVathKida";
                le["subject"] = "AtestLead2";
                le["statuscode"] = "New";
                le["companyname"] = "AKartCase12";

                service.Create(le);
            }
            
           // Console.WriteLine("Hello");

           // string qwe = "abcde";

           // string result = "";

           // for (int i = 0; i < qwe.Length; i++)
           // {
           //     string s1 = qwe[i].ToString();// qwe.Substring(i, qwe.LastIndexOf(qwe[i]) - i + 1);

           //     for (int j = i+1; j < qwe.Length; j++)
           //     {
           //         s1 += qwe[j];

           //         if (s1 == new string(s1.Reverse().ToArray()))
           //         {
           //             if (s1.Length > result.Length)
           //             {
           //                 result = s1;
           //             }
           //         }
           //         if (result.Length == 0)
           //             result = qwe[j].ToString();
           //     }
           //  }

           // int[] arr1 = new int[] { 23,26,31,35 };
           // int[] arr2 = new int[] { 3,5,7,9,11,16 };

           // List<int> ay = arr1.ToList();


           // ay.AddRange(arr2.ToList());

           // List<int> full = ay.OrderBy(x => x).ToList();

           // int remainder;
           // int quotient = Math.DivRem(full.Count, 2, out remainder);
           // double val;

           // if (remainder == 1)
           // {           
           //     val = full[quotient];
           // }
           // else
           // {
           //     val = ((full[quotient - 1] + full[quotient]) / (double)2);
           // }


           // //if(arr1.Length > arr2.Length)
           // //{
           //     //end = arr2.Length;
           // //}

           //// int[] partX = arr2.Take((start + end) / 2).ToArray();





           // string s = "abcabcbb";

           // List<char> strQ = new List<char>();

           // int res = 0;
           // var dict = new System.Collections.Generic.Dictionary<char,int>();
           // var start = 0;

           // for (int i = 0; i < s.Length; i++)
           // {
           //     if(strQ.Contains(s[i]))
           //     {
           //         res = res > i-res ? res : i - res;
           //     }
           //     else
           //     {
           //         strQ.Add(s[i]);
           //     }


           //     //if (dict.ContainsKey(s[i]))
           //     //{
           //     //    start = Math.Max(start, dict[s[i]] + 1);
           //     //    dict[s[i]] = i;
           //     //}
           //     //else
           //     //{
           //     //    dict.Add(s[i], i);
           //     //}

           //     //res = Math.Max(res, i - start + 1);
           // }


           // Node q = new ConsoleApplication.Node(3);

           // //q.load(ref q,3);
           // q.load(ref q, 2);
           // q.load(ref q, 5);
           // q.load(ref q, 6);
           // q.load(ref q, 4);
           // q.load(ref q, 1);
           // q.load(ref q, 7);

           // var eeee = q.height(ref q);


           // q.levelOrder(ref q);

           // q.preOrder(ref q);

           // q.INOrder(ref q);

           // getList();
           // //youcreditkarmatopview(ref q);

           // var refer = new List<string> { "()", "{}", "[]" };

           // var str = "[{}(])";



           // Stack<char> aaaaa = new Stack<char>();


           // foreach (char item in str.ToCharArray())
           // {
           //     if (item == '(' || item == '{' || item == '[')
           //     {
           //         aaaaa.Push(item);

           //     }
           //     else
           //     {
           //         if (aaaaa.Count == 0 || !refer.Contains(aaaaa.Peek().ToString() + (item).ToString()))
           //         {
           //             break;
           //         }
           //         else
           //         {
           //             aaaaa.Pop();
           //         }
           //     }
           // }




        }








        static void getList()
        {
            List<char> input = new List<char> { 'a', 'b', 'a', 'b', 'c', 'b', 'a', 'c', 'a', 'd', 'e', 'f', 'e', 'g', 'd', 'e', 'h', 'i', 'j', 'h', 'k', 'l', 'i', 'j' };

            //string str = "";

            //foreach (var item in input)
            //{
            //    str = str + item.ToString();
            //}
            int count = 0;
            List<int> lst = new List<int>();

            foreach (char c in input)
            {
                count = 0;
                for (int k = 0; k < input.Count; k++)
                {
                    if (c == input[k])
                    {
                        count = k;
                    }
                }

                if (count > 1)
                {
                    lst.Add(count + 1);
                }
            }

        }

        static void left(ref Node N)
        {
            if (N == null)
            {
                return;
            }
            else
            {
                left(ref N.LNode);
                Console.WriteLine(N.Data);
            }
        }

        static void right(ref Node N)
        {
            if (N == null)
            {
                return;
            }
            else
            {
                right(ref N.RNode);

                Console.WriteLine(N.Data);
            }
        }

        static void topview(ref Node root)
        {
            if (root == null)
            { return; }
            else
            {
                left(ref root);

                Console.WriteLine(root.Data);

                right(ref root);
            }
        }

        //static int Getmedian(List<int> lst)
        //{
        //    Stack<int> lowers = stack

        //    if (lst.Count == 0)
        //        return 0;
        //    else
        //    {
        //        if()
        //    }
        //}


    }
}
