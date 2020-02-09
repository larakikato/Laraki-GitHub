using System;

namespace bookstore
{

    public abstract class book {
        public abstract void Read();

        public int pages;

    }

    public class magazine : book, IPurchase, ICheckOut {

        public string purchasedOrChecked { get; set; }
        public string type { get; set; }
        public override void Read () {
            Console.WriteLine("Look at all these pretty pictures");
        }

        public void purchase(string purchasedOrChecked) {

            purchasedOrChecked = "Purchased";

        }

        public void check(string purchasedOrChecked) {

            purchasedOrChecked = "Checked";

    }

    public class novel : book, IPurchase, ICheckOut {

        public string purchasedOrChecked { get; set; }
        public string coverType { get; set; }
        public int numOfChapters { get; set; }
        public override void Read() {
            Console.WriteLine("It was a cold and foggy night...");

        }


        public void purchase(string purchasedOrChecked) {

            purchasedOrChecked = "Purchased";

        }

        public  void check(string purchasedOrChecked) {

            purchasedOrChecked = "Checked";
        }
    }

    public interface IPurchase {
        void purchase();

    }

    public interface ICheckOut {
        void check();

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
