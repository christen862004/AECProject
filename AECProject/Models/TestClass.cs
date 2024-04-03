namespace AECProject.Models
{
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
            FullNAme = "Mohame";
            
            Name = "ahmed";//name


            
            dynamic x = 10;
            //x.Name = "asad";//Exception

            dynamic y = "ahmed";
            dynamic obj = new Student();
            
        }
    }
}
