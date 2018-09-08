using System;
using System.Collections;
using System.Collections.Generic;

namespace Tutorial.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. 常见方法
            // 可以指定初始长度，但是随时可以改变
            List<Teacher> teachers = new List<Teacher>(1);
            teachers.Add(new Teacher() { Id = 1, Name = "Jeremy Gu", Age = 18 });

            Teacher[] teacherArray = new Teacher[]
            {
                new Teacher() { Id = 2, Name = "Henry", Age = 72 },
                new Teacher() { Id = 3, Name = "Nicole", Age = 16 },
            };

            // 可以一次加入多个值，可以是同类型的Array
            teachers.AddRange(teacherArray);

            // 可以在指定索引位置插入一个对象
            var newTeacher = new Teacher() { Id = 4, Name = "Joseph", Age = 20 };
            teachers.Insert(1, newTeacher);

            // 跟Array一样可以通过下标访问
            Console.WriteLine(teachers[0].Name + "****" + teachers[0].Age);

            // 排序前
            foreach (var teacher in teachers)
            {
                Console.WriteLine(string.Format("Teacher {0}, id is {1}, age is {2}", teacher.Name, teacher.Id, teacher.Age));
            }

            // List 默认是按照元素的下标排序的，可以倒序， 但是如何按照自定义规则进行排序呢？
            Console.WriteLine("****************************华丽的分割线********************************");

            teachers.Reverse();
            foreach (var teacher in teachers)
            {
                Console.WriteLine(string.Format("Teacher {0}, id is {1}, age is {2}", teacher.Name, teacher.Id, teacher.Age));
            }
            #endregion

            #region 02. 比较器

            // Console.WriteLine("****************************华丽的分割线********************************");
            //// 如何使用比较器，对复杂类型排序
            //teachers.Sort(new TeacherComparer());
            //
            //// 排序后
            //foreach (var teacher in teachers)
            //{
            //    Console.WriteLine(string.Format("Teacher {0}, id is {1}, age is {2}", teacher.Name, teacher.Id, teacher.Age));
            //}

            #endregion

            #region 03. IEnumerable interface

            //var newTeacher1 = new Teacher() { Id = 4, Name = "Joseph", Age = 20 };
            //newTeacher1.Add("人在江湖漂");
            //newTeacher1.Add("哪有不挨刀");

            //// 本来不支持foreach循环的类，只要继承了IEnumerable interface，就可以被foreach循环
            //foreach (var item in newTeacher1)
            //{
            //    Console.WriteLine("Looping Teacher class: " + item);
            //}

            #endregion

            #region 04. Dictionary

            // Dictionary 与 List最大的不同的是，List使用数字下标，而Dictionary使用Key

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.Add(110, "C# class");
            keyValuePairs.Add(111, "Frontend");
            keyValuePairs.Add(112, "backend");


            foreach (var key in keyValuePairs.Keys)
            {
                Console.WriteLine("Key is " + key);
                Console.WriteLine("Value is " + keyValuePairs[key]);
            }

            #endregion

            Console.ReadKey();
        }
    }

    // 一个类只要继承了IEnumerable interface，就可以被foreach循环
    public class Teacher : IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        LinkedList<string> items = new LinkedList<string>();

        public void Add(string str)
        {
            items.AddLast(str);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }

    // 任何继承IComparer<T> 接口的类，都可以作为比较器
    public class TeacherComparer : IComparer<Teacher>
    {
        // 结果是1， Teacher x 大于 Teacher y
        // 结果等于0，二者相等
        // 结果是-1， Teacher x 等于 Teacher y
        public int Compare(Teacher x, Teacher y)
        {
            var result = x.Age - y.Age == 0 ? 0 : x.Age - y.Age > 0 ? 1 : -1;
            return result;
        }
    }
}
