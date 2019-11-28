using ARM_Of_Phone_seller_PROJECT.Database_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Of_Phone_seller_PROJECT.Model
{
    public class Специалист_Поля
    {
        public int ID_Специалиста { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public long Телефон { get; set; }
        public string Статус { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public DateTime Дата_рождения { get; set; }
        public string Основание_работы { get; set; }
        public bool Администратор { get; set; }
}
    public class СпециалистModel : IModel<Специалист_Поля>
    {
        public void Delete(Специалист_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"DELETE FROM Специалист WHERE id = {item.ID_Специалиста}");
            }
        }

        public void Insert(Специалист_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"INSERT INTO Специалист VALUES ({item.ID_Специалиста}, \'{item.Логин}\', \'{item.Пароль}\', {item.Телефон}, \'{item.Статус}\', \'{item.Фамилия}\', \'{item.Имя}\', \'{item.Отчество}\', {GetDate(item.Дата_рождения)}, \'{item.Основание_работы}\', {item.Администратор})");
            }
        }

        public IEnumerable<Специалист_Поля> Select()
        {
            using (var db = new DBController())
            {
                var reader = db.ExecuteReader($"SELECT * FROM Специалист");
                var list = new List<Специалист_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Специалист_Поля()
                        {
                            ID_Специалиста = reader.GetInt32(0),
                            Логин = reader.GetString(1),
                            Пароль = reader.GetString(2),
                            Телефон = reader.GetInt64(3),
                            Статус = reader.GetString(4),
                            Фамилия = reader.GetString(5),
                            Имя = reader.GetString(6),
                            Отчество = reader.GetString(7),
                            Дата_рождения = reader.GetDateTime(8),
                            Основание_работы = reader.GetString(9),
                            Администратор = reader.GetBoolean(10)
                        });
                    }
                }

                return list;
            }
        }

        public void Update(Специалист_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"UPDATE Специалист SET ID_Специалиста = {item.ID_Специалиста}, Логин = \'{item.Логин}\', Пароль = \'{item.Пароль}\', Телефон = {item.Телефон}, Статус = \'{item.Статус}\', Фамилия = \'{item.Фамилия}\', Имя = \'{item.Имя}\', Отчество = \'{item.Отчество}\', Дата_рождения = {item.Дата_рождения}, Основание_работы = \'{item.Основание_работы}\', Администратор = {item.Администратор}");
            }
        }

        private string GetDate(DateTime date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }
    }
}
