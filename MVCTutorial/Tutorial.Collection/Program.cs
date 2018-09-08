using System;
using System.Collections;
using System.Collections.Generic;

namespace Tutorial.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. ��������
            // ����ָ����ʼ���ȣ�������ʱ���Ըı�
            List<Teacher> teachers = new List<Teacher>(1);
            teachers.Add(new Teacher() { Id = 1, Name = "Jeremy Gu", Age = 18 });

            Teacher[] teacherArray = new Teacher[]
            {
                new Teacher() { Id = 2, Name = "Henry", Age = 72 },
                new Teacher() { Id = 3, Name = "Nicole", Age = 16 },
            };

            // ����һ�μ�����ֵ��������ͬ���͵�Array
            teachers.AddRange(teacherArray);

            // ������ָ������λ�ò���һ������
            var newTeacher = new Teacher() { Id = 4, Name = "Joseph", Age = 20 };
            teachers.Insert(1, newTeacher);

            // ��Arrayһ������ͨ���±����
            Console.WriteLine(teachers[0].Name + "****" + teachers[0].Age);

            // ����ǰ
            foreach (var teacher in teachers)
            {
                Console.WriteLine(string.Format("Teacher {0}, id is {1}, age is {2}", teacher.Name, teacher.Id, teacher.Age));
            }

            // List Ĭ���ǰ���Ԫ�ص��±�����ģ����Ե��� ������ΰ����Զ��������������أ�
            Console.WriteLine("****************************�����ķָ���********************************");

            teachers.Reverse();
            foreach (var teacher in teachers)
            {
                Console.WriteLine(string.Format("Teacher {0}, id is {1}, age is {2}", teacher.Name, teacher.Id, teacher.Age));
            }
            #endregion

            #region 02. �Ƚ���

            // Console.WriteLine("****************************�����ķָ���********************************");
            //// ���ʹ�ñȽ������Ը�����������
            //teachers.Sort(new TeacherComparer());
            //
            //// �����
            //foreach (var teacher in teachers)
            //{
            //    Console.WriteLine(string.Format("Teacher {0}, id is {1}, age is {2}", teacher.Name, teacher.Id, teacher.Age));
            //}

            #endregion

            #region 03. IEnumerable interface

            //var newTeacher1 = new Teacher() { Id = 4, Name = "Joseph", Age = 20 };
            //newTeacher1.Add("���ڽ���Ư");
            //newTeacher1.Add("���в�����");

            //// ������֧��foreachѭ�����ֻ࣬Ҫ�̳���IEnumerable interface���Ϳ��Ա�foreachѭ��
            //foreach (var item in newTeacher1)
            //{
            //    Console.WriteLine("Looping Teacher class: " + item);
            //}

            #endregion

            #region 04. Dictionary

            // Dictionary �� List���Ĳ�ͬ���ǣ�Listʹ�������±꣬��Dictionaryʹ��Key

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

    // һ����ֻҪ�̳���IEnumerable interface���Ϳ��Ա�foreachѭ��
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

    // �κμ̳�IComparer<T> �ӿڵ��࣬��������Ϊ�Ƚ���
    public class TeacherComparer : IComparer<Teacher>
    {
        // �����1�� Teacher x ���� Teacher y
        // �������0���������
        // �����-1�� Teacher x ���� Teacher y
        public int Compare(Teacher x, Teacher y)
        {
            var result = x.Age - y.Age == 0 ? 0 : x.Age - y.Age > 0 ? 1 : -1;
            return result;
        }
    }
}
