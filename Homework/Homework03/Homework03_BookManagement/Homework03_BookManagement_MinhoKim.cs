using System;

namespace Homework03_BookManagement
{
    class Homework03_BookManagement_MinhoKim
    {
        static void Main(string[] args)
        {
            int maxSize = 5;
            Book[] books = new Book[]{
                new Book("노인과 바다", "헤밍웨이", "novel", "1990-01-01"),
                new Book("해리포터", "Jane", "Fantasy", "1997-11-11"),
                new Book("반지의 제왕", "골룸", "Fantasy", "2000-05-07"),
                new Book("풀소유", "혜민스님", "Essay", "2011-08-12"),
                new Book("김민호자서전", "Minho Kim", "Essay", "1996-11-25")
            };

            Borrowed[] BorrowedBooks = new Borrowed[maxSize];
            for (int i=0; i<maxSize; i++){
                BorrowedBooks[i] = new Borrowed();
            }

            for (int i=0; i<maxSize; i++){
                books[i].ShowInfo();
            }

            int cnt = 0;
            while (true){
                Console.WriteLine("================================");
                Console.WriteLine("| Current Borrowed Book Status |");
                Console.WriteLine("================================");
                for (int i=0; i<cnt; i++){
                    BorrowedBooks[i].ShowInfo_Borrowed();
                }

                Console.Write("대여할 책 이름을 입력하세요 (종료는 Q): ");
                String data = Console.ReadLine();
                if (data == "Q"){ break; }
                if (!Array.Exists(books, x => x.title == data)){
                    Console.WriteLine("\n책 목록에 존재하지 않는 책입니다.\n");
                    continue;
                }
                if (Array.Exists(BorrowedBooks, x => x.title == data)){
                    Console.WriteLine("\n이미 대여된 책입니다.\n");
                    continue;
                }

                Console.Write("성함을 입력해주세요: ");
                String name = Console.ReadLine();

                int idx = Array.FindIndex(books, x => x.title == data);
                // Borrowed borrowed = new Borrowed(books[idx], name, DateTime.Now.ToString("yyyy-MM-dd"));
                BorrowedBooks[cnt] = new Borrowed(books[idx], name, DateTime.Now.ToString("yyyy-MM-dd"));;
                cnt++;

                Console.WriteLine();
            }
        }
    }
    
    public class Book {
        public String title, writer, genre, publishDate;

        public Book(){
            this.title = null;
            this.writer = null;
            this.genre = null;
            this.publishDate = null;
        }
        
        public Book(String title, String writer, String genre, String publishDate){
            this.title = title;
            this.writer = writer;
            this.genre = genre;
            this.publishDate = publishDate;
        }

        public void ShowInfo(){
            Console.WriteLine($"title: {title, 10} | writer: {writer, 8} | genre: {genre, 8} | publishDate: {publishDate, 10}");
        }

        public String GetTitle(){ return this.title; }
        public String GetWriter(){ return this.writer; }
        public String GetGenre(){ return this.genre; }
        public String GetPublishDate(){ return this.publishDate; }
    }

    public class Borrowed : Book{
        public String name, borrowedDate;
        public int state;

        public Borrowed(){
            base.title = null;
            base.writer = null;
            base.genre = null;
            base.publishDate = null;
            this.name = null;
            this.borrowedDate = null;
            this.state = 1;
        }
        
        public Borrowed(Book book, String name, String date){
            base.title = book.GetTitle();
            base.writer = book.GetWriter();
            base.genre = book.GetGenre();
            base.publishDate = book.GetPublishDate();
            this.name = name;
            this.borrowedDate = date;
            this.state = 1;
        }

        public void ShowInfo_Borrowed(){
            ShowInfo();
            Console.WriteLine($"Borrowed Person: {name, 10} | Borrowed Date: {borrowedDate, 5} | Current State: {state}");
        }

        public void SetName(String name){ this.name = name; }
        public void SetDate(String borrowedDate){ this.borrowedDate = borrowedDate; }
    }
}
