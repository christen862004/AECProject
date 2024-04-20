namespace AECProject.Models
{
    //class IdentityUser<T>
    //{
    //    public T ID { get; set; }
    //    public string  UserNAme { get; set; }
    //    public string PAssword { get; set; }
    //}
    //class IdentityUser:IdentityUser<string>
    //{
       
    //}


    //class test1
    //{
    //    void method1()
    //    {
    //        IdentityUser<int> user=new
    //            IdentityUser<int>();
    //        user.ID = 1;
    //    }
    //}








    //abstractio (interface)
    interface ISort
    {
        List<int> Sort(List<int> list);
    }
    class ITISort:ISort
    {
        public List<int> Sort(List<int> list)
        {
            //using DS ITI
            return list;
        }
    }
    class SelectionSort:ISort
    {
        public List<int> Sort(List<int> list)
        {
            //using DS Selectio
            return list;
        }
    }
    class BubbleSort:ISort
    {
        public List<int> Sort(List<int> list)
        {
            //using DS Bubble
            return list;
        }
    }
    class xyzSort : ISort
    {
        public List<int> Sort(List<int> list)
        {
            throw new NotImplementedException();
        }
    }

    //DIP (high level class (Stack )depend on Low LEvel Class (bubble sort))
    //depend on abstartion
    //(IOC) Tigh Coupling == >lossly couple
    class Stack //full depned Bubble sort
    {
        public List<int> Arr { get; set; }
        ISort SortObj;//null
       
        public Stack(ISort _sortObj)//inject -ask
        {
            SortObj= _sortObj;
        }
        
        public List<int> sortList()
        {
            return SortObj.Sort(Arr);
        }
    }
    public class TestClass
    {
        //Full Property
        string name;
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        public dynamic FullNAme
        {
            set { Name = value; }
            get { return Name; }
        }


        public void m1()
        {
            Stack s4 = new Stack(new xyzSort());
            Stack s1 = new Stack(new BubbleSort());
            Stack s2 = new Stack(new SelectionSort());
            Stack s3 = new Stack(new ITISort());




            FullNAme = "Mohame";
            
            Name = "ahmed";//name


            
            dynamic x = 10;
            //x.Name = "asad";//Exception

            dynamic y = "ahmed";
            dynamic obj = new Student();
            
        }
    }
}
