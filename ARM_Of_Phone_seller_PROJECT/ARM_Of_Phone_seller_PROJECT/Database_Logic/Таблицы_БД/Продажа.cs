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
        public string Номер_договора { get; set; }
        public DateTime Дата_заключения_договора { get; set; }
        public double Срок_действия_договора { get; set; }
        public DateTime Окончание_гарантийного_срока { get; set; }
        public DateTime Дата_продажи { get; set; }
        public double Процент_НДС { get; set; }
        public double Стоимость_постгарантийного_обсуживания { get; set; }
        public double Сумма_продажи { get; set; }
        public int ID_Специалиста { get; set; }
        public int ID_Клиента { get; set; }
        public int ID_Модели { get; set; }
    }
    public class ПродажаModel : IModel<Продажа_Поля>
    {
        public void Delete(Продажа_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"DELETE FROM Продажа WHERE Номер_договора = {item.Номер_договора}");
            }
        }

        public void Insert(Продажа_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"INSERT INTO Продажа VALUES (" +
                    $"\'{item.Номер_договора}\', " +
                    $"{GetDate(item.Дата_заключения_договора)}, " +
                    $"{item.Срок_действия_договора}, " +
                    $"{GetDate(item.Окончание_гарантийного_срока)}, " +
                    $"{GetDate(item.Дата_продажи)}, " +
                    $"{item.Процент_НДС}, " +
                    $"{item.Стоимость_постгарантийного_обсуживания}, " +
                    $"{item.Сумма_продажи}, " +
                    $"{item.ID_Специалиста}, " +
                    $"{item.ID_Клиента}, " +
                    $"{item.ID_Модели}, " +
                    $")");
            }
        }

        public IEnumerable<Продажа_Поля> Select()
        {
            using (var db = new DBController())
            {
                var reader = db.ExecuteReader($"SELECT * FROM Продажа");
                var list = new List<Продажа_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Продажа_Поля()
                        {
                            Номер_договора = reader.GetString(0),
                            Дата_заключения_договора = reader.GetDateTime(1),
                            Срок_действия_договора = reader.GetDouble(2),
                            Окончание_гарантийного_срока = reader.GetDateTime(3),
                            Дата_продажи = reader.GetDateTime(4),
                            Процент_НДС = reader.GetDouble(5),
                            Стоимость_постгарантийного_обсуживания = reader.GetDouble(6),
                            Сумма_продажи = reader.GetDouble(7),
                            ID_Специалиста = reader.GetInt32(8),
                            ID_Клиента = reader.GetInt32(9),
                            ID_Модели = reader.GetInt32(10)
                        });
                    }
                }
                return list;
            }
        }

        public void Update(Продажа_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"UPDATE Клиент SET " +
                    $"Номер_договора = {item.Номер_договора}, " +
                    $"Дата_заключения_договора = {item.Дата_заключения_договора}, " +
                    $"Срок_действия_договора = {item.Стоимость_постгарантийного_обсуживания}, " +
                    $"Окончание_гарантийного_срока = {item.Окончание_гарантийного_срока}, " +
                    $"Дата_продажи = {item.Дата_продажи}, " +
                    $"Процент_НДС = {item.Процент_НДС}, " +
                    $"Стоимость_постгарантийного_обсуживания = {item.Стоимость_постгарантийного_обсуживания}, " +
                    $"Сумма_продажи = {item.Сумма_продажи}, " +
                    $"ID_Специалиста = {item.ID_Специалиста}, " +
                    $"ID_Клиента = {item.ID_Клиента}, " +
                    $"ID_Модели = {item.ID_Модели}");
            }
        }
        private string GetDate(DateTime date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }

    }
}
