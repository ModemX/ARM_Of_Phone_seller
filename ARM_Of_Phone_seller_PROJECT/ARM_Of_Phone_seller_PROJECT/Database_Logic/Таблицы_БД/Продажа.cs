using ARM_Of_Phone_seller_PROJECT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД
{
    public class Продажа_Поля
    {
        public int Номер_договора { get; set; }
        public DateTime Дата_заключения_договора { get; set; }
        public double Срок_действия_договора { get; set; }
        public DateTime Окончание_гарантийного_срока { get; set; }
        public DateTime Дата_продажи { get; set; }
        public double Процент_НДС { get; set; }
        public double Стоимость_постгарантийного_обсуживания { get; set; }
        public double Сумма_продажи { get; set; }
        public string ID_Специалиста { get; set; }
        public string ID_Клиента { get; set; }
        public string ID_Модели { get; set; }

        public string Дата_продажи_DataGridView
        {
            get
            {
                return $"" +
                    $"{((Дата_продажи.Day < 10) ? $"0{Дата_продажи.Day}" : $"{Дата_продажи.Day}")}." +
                    $"{((Дата_продажи.Month < 10) ? $"0{Дата_продажи.Month}" : $"{Дата_продажи.Month}")}." +
                    $"{Дата_продажи.Year}";
            }
            set
            {
                try
                {
                    Дата_продажи = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    Дата_продажи = new DateTime(2019, 01, 01);
                }
            }
        }
    }
    public class ПродажаModel //: IModel<Продажа_Поля>
    {
        public void Delete(Продажа_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"DELETE FROM Продажа WHERE Номер_договора = {item.Номер_договора}");
            }
        }

        //public void Insert(Продажа_Поля item)
        //{
        //    using (var db = new DBController())
        //    {
        //        db.ExecuteNonQueryCommand($"INSERT INTO Продажа VALUES (" +
        //            $"\'{item.Номер_договора}\', " +
        //            $"{GetDate(item.Дата_заключения_договора)}, " +
        //            $"{item.Срок_действия_договора}, " +
        //            $"{GetDate(item.Окончание_гарантийного_срока)}, " +
        //            $"{GetDate(item.Дата_продажи)}, " +
        //            $"{item.Процент_НДС}, " +
        //            $"{item.Стоимость_постгарантийного_обсуживания}, " +
        //            $"{item.Сумма_продажи}, " +
        //            $"{item.ID_Специалиста}, " +
        //            $"{item.ID_Клиента}, " +
        //            $"{item.ID_Модели}, " +
        //            $")");
        //    }
        //}

        public IEnumerable<Продажа_Поля> Select()
        {
            using (var db = new DBController())
            {
                var reader = db.ExecuteReader($"SELECT dbo.Продажа.Номер_Договора, dbo.Продажа.Дата_заключения_договора, dbo.Продажа.Срок_действия_договора, dbo.Продажа.Окончание_гарантийного_срока, dbo.Продажа.Дата_продажи, dbo.Продажа.Процент_НДС, dbo.Продажа.Стоимость_постгарантийного_обсуживания, dbo.Продажа.Сумма_продажи, dbo.Специалист.Фамилия AS Фамилия_Специалиста, dbo.Клиент.Фамилия AS Фамилия_Клиента, dbo.Товар.Название_модели FROM dbo.Продажа INNER JOIN dbo.Клиент ON dbo.Продажа.ID_Клиента = dbo.Клиент.ID_Клиента INNER JOIN dbo.Специалист ON dbo.Продажа.ID_Специалиста = dbo.Специалист.ID_Специалиста INNER JOIN dbo.Товар ON dbo.Продажа.ID_Модели = dbo.Товар.ID_Модели");
                var list = new List<Продажа_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Продажа_Поля()
                        {
                            Номер_договора = reader.GetInt32(0),
                            Дата_заключения_договора = reader.GetDateTime(1),
                            Срок_действия_договора = reader.GetFloat(2),
                            Окончание_гарантийного_срока = reader.GetDateTime(3),
                            Дата_продажи = reader.GetDateTime(4),
                            Процент_НДС = reader.GetFloat(5),
                            Стоимость_постгарантийного_обсуживания = reader.GetFloat(6),
                            Сумма_продажи = reader.GetFloat(7),
                            ID_Специалиста = reader.GetString(8),
                            ID_Клиента = reader.GetString(9),
                            ID_Модели = reader.GetString(10)
                        });
                    }
                }
                return list;
            }
        }

        //public void Update(Продажа_Поля item)
        //{
        //    using (var db = new DBController())
        //    {
        //        db.ExecuteNonQueryCommand($"UPDATE Клиент SET " +
        //            $"Номер_договора = {item.Номер_договора}, " +
        //            $"Дата_заключения_договора = {item.Дата_заключения_договора}, " +
        //            $"Срок_действия_договора = {item.Стоимость_постгарантийного_обсуживания}, " +
        //            $"Окончание_гарантийного_срока = {item.Окончание_гарантийного_срока}, " +
        //            $"Дата_продажи = {item.Дата_продажи}, " +
        //            $"Процент_НДС = {item.Процент_НДС}, " +
        //            $"Стоимость_постгарантийного_обсуживания = {item.Стоимость_постгарантийного_обсуживания}, " +
        //            $"Сумма_продажи = {item.Сумма_продажи}, " +
        //            $"ID_Специалиста = {item.ID_Специалиста}, " +
        //            $"ID_Клиента = {item.ID_Клиента}, " +
        //            $"ID_Модели = {item.ID_Модели}");
        //    }
        //}

        public IEnumerable<Продажа_Поля> SearchInJournal(string MyValue)
        {
            using (var db = new DBController())
            {
                var reader = db.ExecuteReader($"exec SearchInJournal \'{MyValue}\'");
                var list = new List<Продажа_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Продажа_Поля()
                        {
                            Номер_договора = reader.GetInt32(0),
                            Дата_заключения_договора = reader.GetDateTime(1),
                            Срок_действия_договора = reader.GetFloat(2),
                            Окончание_гарантийного_срока = reader.GetDateTime(3),
                            Дата_продажи = reader.GetDateTime(4),
                            Процент_НДС = reader.GetFloat(5),
                            Стоимость_постгарантийного_обсуживания = reader.GetFloat(6),
                            Сумма_продажи = reader.GetFloat(7),
                            ID_Специалиста = reader.GetString(8),
                            ID_Клиента = reader.GetString(9),
                            ID_Модели = reader.GetString(10)
                        });
                    }
                }
                return list;
            }
        }

        private string GetDate(DateTime date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }

    }
}
