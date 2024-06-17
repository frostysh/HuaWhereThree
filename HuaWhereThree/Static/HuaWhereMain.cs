using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuaWhereThree.Static
{
    public static class HuaWhereMain
    {
        // // // // // DELEGATES

        public delegate TCollection Seeker<TCollection>(TCollection item);

        // // // // // METHODS

        //  МЕТОД-РОЗШИРЕННЯ.
        //  ПОВЕРТАЄ ТИП IEnumerable-GENERIC, ТОБТО ВНУТРІШНІ МЕХАНІЗМИ IEnumerable БУДУТЬ ПРАЦЮВАТИ ІЗ НАМИ ЗАДАНИМ ТИПОМ
        //  А ТАКОЖ ВСІ ЙОГО СУБ-КЛАСИ.
        //  ПЕРШИЙ АРГУМЕНТ СУБ-ТИПИ IEnumerable, ТОБТО ВСІ КОЛЕКЦІЇ (GENERIC).
        //  ДРУГИЙ АРГУМЕНТ — ДЕЛЕГАТ, ЯКОМУ ПРИСВОЮЄТЬСЯ МЕТОД ЯК ПАРАМЕТР ПРИ ВКИДАННІ У НАШ МЕТОД-РОЗШИРЕННЯ,
        //  ЩО ПОВЕРТАЄ ТИП, ЯКИЙ В КОЛЕКЦІЇ...
        public static IEnumerable<TCollection> HuaWhere<TCollection>(this IEnumerable<TCollection> collection, Seeker<TCollection> seeker)
        {
            // ОСКІЛЬКИ ТИП IEnumerable, МИ МОЖЕМО ВИКОРИСТАТИ foreach, АЛЕ ЯК ВОНО ПРАЦЮЄ, Я ОСОБИСТО НЕ МАЮ УЯВЛЕННЯ.
            foreach (TCollection item in collection)
            {
               // СПЕЦІАЛЬНИЙ ОПЕРАТОР yield — ЗУПИНЯЄ ІТЕРАЦІЮ, ПОВЕРТАЄ РЕЗУЛЬТАТ РОБОТИ seeker НА КОЛЕКЦІЮ IEnumerable (O_O)...
               // А ТОДІ ЗАПУСКАЄ ІТЕРАТОР ЗНОВУ, НЕ ВИХОДЯЧИ ЗА РАМКИ ОПЕРАТОРА ОБЛАСТІ (scope) {}...
               // ТОБТО ПРИ ВИКЛИКУ ToList() НАПРИКЛА (МЕТОД РОЗШИРЕННЯ), БУДЕ ПРАЦЮВАТИ ДВА ІТЕРАТОРА! О_О, КОРОТШЕ Я ЗАПЛУТАВСЯ...
               // А, ТАК, ПАРДОН ЗА EXTENSIVE COMMENTS...
               yield return seeker(item);
            }
        }
    }
}