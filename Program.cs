using System;
using System.Collections.Generic;
using System.Linq;

namespace sekizNisan
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) 2010 ile 2022 arasında mesai saatleri (9:00-18:00) 1000 adet Random tarih oluştur ve bir tarih listesine ata
            Random random = new Random();
            List<DateTime> dt = new List<DateTime>();
            DateTime start = new DateTime(2010, 01, 01);
            DateTime end = new DateTime(2022, 01, 01);

            TimeSpan sonuc = end-start;
            //for (int i = 0; i < 1000; i++)
            //{



            //    dt.Add(start.AddDays(random.Next(Convert.ToInt32(sonuc.TotalDays))).AddHours(random.Next(9, 18)).AddMinutes(random.Next(0, 59)));
                
            //}
            //foreach (var item in dt)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            // 2) Bu listede hafta sonu olmasaın
            static bool IsWeekend(DateTime dateTime)
            {
                if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                    return true;
                else
                    return false;
            }

            while (dt.Count < 1000)
            {

                DateTime newDate = start.AddDays(random.Next(Convert.ToInt32(sonuc.TotalDays))).AddHours(random.Next(9, 18)).AddMinutes(random.Next(0, 59));

                if (!IsWeekend(newDate))
                {

                    dt.Add(newDate);
                }

            }
            // 3) Bu listedeki içerisnde tarihlerin kaçı subat ayı içerisndedir.

            var countOfFebruary = GetFebruaryCount(dt);
            Console.WriteLine( "Şubat ayı sayısı:"+countOfFebruary);

            // 4) Bu listenin içerisndeki tarihlerin kaçı 12:00 (öğlen) den öncedir
            Console.WriteLine("saat 12 den önce olan tarih sayısı:"+dt.Where(q=>q.Hour<12).Count());
            // 5) bu listede kaç tane pazartesi var?
            var countOfDay = GetMonday(dt);
            Console.WriteLine("Pazartesi sayısı:"+countOfDay);
        }

        //pazartesi günü için dışarıdan nesne üretildi
        private static object GetMonday(List<DateTime> dt)
        {
            return dt.Where(q => q.DayOfWeek == DayOfWeek.Monday).Count();
        }

        // Şubat ayı sayısı için private tanımlanan bir nesne oluşturuldu.
        private static object GetFebruaryCount(List<DateTime> dt)
        {
            return dt.Where(v => v.Month == 2).Count();
        }
    }
}
