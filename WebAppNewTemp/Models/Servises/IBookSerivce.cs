namespace WebAppNewTemp.Models.Servises
{
    public interface IBookSerivce
    {
        IEnumerable<Book> GetAll();
        void Delete(int id);
        int Add(Book book);
        //void Edit(int id, string newName);
    }


    public class NotImplBookSerivce : IBookSerivce
    {
        public int Add(Book book)
        {
            throw new NotImplementedException("not impl");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException("not impl");
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException("not impl");
        }
    }

    public class MockBookSerivce : IBookSerivce
    {
        public int Add(Book book)
        {
            Console.WriteLine($"{book.Name} {book.Id}");
            return 4566;
        }

        public void Delete(int id)
        {
            Console.WriteLine(id);
        }

        public IEnumerable<Book> GetAll()
        {
            yield return new Book() { Id=1,Name="11111"};
            yield return new Book() { Id = 2, Name = "22222" };
            yield return new Book() { Id = 3, Name = "333333" };
            yield return new Book() { Id=4, Name="44444"};
        }
    }

    public class MyBookSerivce : IBookSerivce
    {
        private static List<Book> _books;
        public List<Book> Books { get { return _books; } }
       
        public MyBookSerivce()
        {
            _books=new List<Book>();
        }

        public int Add(Book book)
        {
            book.Id = GetId();
            _books.Add(book);
            return book.Id;
        }
        public void Edit(int id, string newName)
        {
            var book = _books.Find(x => x.Id == id);
            int index = _books.IndexOf(book);
            _books[index].Name=newName;
        }

        public void Delete(int id)
        {
            var book = Books.Find(x=>x.Id==id);
            if(book==null)return;
            _books.Remove(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return Books;
        }

        private int GetId()
        {
            int i = 0;
            int id=1;
            if (_books.Count > 0)
            {
                int[] arrayID = new int[_books.Count];
                foreach (var bk in _books)
                {
                    arrayID[i] = bk.Id;
                    i++;
                }
                 id=arrayID.Max() + 1;
            }
            return id;
        }
    }
}

