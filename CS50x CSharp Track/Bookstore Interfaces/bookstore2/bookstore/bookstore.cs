using System;

namespace bookstore
{
    public abstract class book {
        public abstract void Read();

        public int pages;

    }

    public class magazine : book, ICheckOut, IPurchase {
        public override void Read() {
            Console.WriteLine("We're reading a book");
        }

        public void purchase(){

        }

        public void check(){
            
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
