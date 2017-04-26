using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MySerials.Models
{
    public class SerialDbInitializer : DropCreateDatabaseAlways<SerialContext>
    {
        protected override void Seed(SerialContext db)
        {
            Serial one = new Serial { Serial_title = "Теория большого взрыва", SerialDescription = "Молодежный" };
            Serial two = new Serial { Serial_title = "Сверхестественное", SerialDescription = "Мистика" };
            Serial three = new Serial { Serial_title = "Доктор Хаус", SerialDescription = "Медицина" };
            db.Serials.Add(one);
            db.Serials.Add(two);
            db.Serials.Add(three);
            Season first = new Season { Season_title = "первый сезон  2007 ", Serial = one };
            Season second = new Season { Season_title = "второй сезон 2008", Serial = one };
            Season third = new Season { Season_title = "третий сезон 2009", Serial = one };
            Season first1 = new Season { Season_title = "first season", Serial = two };
            Season second1 = new Season { Season_title = "second season", Serial = two };
            Season third1 = new Season { Season_title = "third season", Serial = two };
            Season first2 = new Season { Season_title = "Первый", Serial = three };
            Season second2 = new Season { Season_title = "Второй", Serial = three };
            Season third2 = new Season { Season_title = "Третий", Serial = three };
            db.Seasons.Add(first);
            db.Seasons.Add(second);
            db.Seasons.Add(third);
            db.Seasons.Add(first1);
            db.Seasons.Add(second1);
            db.Seasons.Add(third1);
            db.Seasons.Add(first2);
            db.Seasons.Add(second2);
            db.Seasons.Add(third2);
            Serie a = new Serie { Title = "Парадигма тухлой рыбы", Season = first};
            db.Series.Add(a);
            Serie b = new Serie { Title = "Евклид-авеню", Season = first };
            db.Series.Add(b);
            Serie c = new Serie { Title = "	Камень, ножницы, бумага, ящерица, Спок", Season = first };
            db.Series.Add(c);
            Serie d = new Serie { Title = "Загадка Вартабедиана", Season = second };
            db.Series.Add(d);
            Serie e = new Serie { Title = "Гипотеза подарка для ванной", Season = second };
            db.Series.Add(e);
            Serie f = new Serie { Title = "	Нестабильность робота убийцы", Season = second };
            db.Series.Add(f);
            base.Seed(db);
           
        }
    }
}