using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = new A();
            parent.name = "PA";

            A child = new A();
            child.age = 12;
            child.name = "child";
            child.Parent = parent;


            var newA = new A();

            var pars = child.GetType().GetProperties();

            foreach (var item in pars)
            {
                Console.WriteLine("{0}:{1}", item, item.GetType());
            }

            var p1 = newA.Parent;
            var p2 = child.Parent;

            var list = new List<A>();
            list.Add(child);
            list.Add(parent);
            list.Add(newA);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            Console.WriteLine(json);
            // var datatable = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);

            DataTable d = new DataTable();
            d.Columns.Add("ab", typeof(A));
            var row = d.NewRow();
            row["ab"] = new A() { name = "lisi" };
            d.Rows.Add(row);

            var itema= d.Rows[0][0] as A;

            Console.Read();

            //var key = typeof(B).get GetCustomAttribute(typeof(KeyAttribute));

            // Console.WriteLine(key);

            Console.Read();

        }
    }


    [Serializable]
    public class A
    {
        public string name { get; set; }

        public int age { get; set; }

        public A Parent { get; set; }

        public void test()
        {

            Console.WriteLine(this.GetType());
        }
    }

    public class B : A
    {
        [Key]
        public string name { get; set; }
        public string name2 { get; set; }
        public string name3 { get; set; }
        public string name4 { get; set; }
        public string name5 { get; set; }
    }
}
