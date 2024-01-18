using NodeClass;
using NodeInserts.Models;

namespace NodeInserts
{
    internal class Program
    {
        public static bool IsShabatOnDate(Node<ShabatRecievers> shabat, int day, int month, int year)
        {
            while (shabat != null)
            {
                ShabatRecievers sh = shabat.GetValue();
                if (sh.GetYear() == year && sh.GetMonth() == month && sh.GetDay() == day)
                    return true;
            }
            return false;
        }
        public static Node<ShabatRecievers> DeleteShabatReciever(Node<ShabatRecievers> shabat, string name)
        {
            Node<ShabatRecievers> dummy = new Node<ShabatRecievers>(default, shabat);
            Node<ShabatRecievers> next = dummy.GetNext();
            Node<ShabatRecievers> current = dummy;
            while (next != null && !(next.GetValue().GetParent1() == name || next.GetValue().GetParent2() == name))
            {
                current = current.GetNext();
                next = current.GetNext();
            }
            if (next != null)
            {
                current.SetNext(next.GetNext());
                next.SetNext(null);

            }
            return dummy.GetNext();
        }
        static void Main(string[] args)
        {
            Node<ShabatRecievers> shabatShalom = new Node<ShabatRecievers>(new ShabatRecievers("Shiri", "Shira", 18, 1, 2024));
            Node<ShabatRecievers> nextShabat = new Node<ShabatRecievers>(new ShabatRecievers("Ofek", "Aviv", 25, 1, 2024));
            shabatShalom.SetNext(nextShabat);

            ShabatRecievers sh = shabatShalom.GetValue();
            string p1 = sh.GetParent1();


        }
    }
}